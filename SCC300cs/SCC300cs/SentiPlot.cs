using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.ejml.simple;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.simple;
using VaderSharp;
using System.Windows.Forms.DataVisualization.Charting;

namespace SCC300cs
{
    public partial class SentiPlot : Form
    {
        string inputText;
        string outputText;
        double granularity = -1;
        List<string> sents;
        List<SentimentAnalysisResults> resultsList;

        public SentiPlot()
        {
            InitializeComponent();
            InitPipeline();
        }

        /// <summary>
        /// Initialises CoreNLP pipeline to tokenise the input into sentences
        /// </summary>
        private void InitPipeline()
        {
            var jarRoot = @"C:\Users\Luca\Documents\University\General\UG3\SCC300\SCC300cs\SCC300cs\stanford-corenlp-3.7.0-models";

            // Annotation pipeline configuration
            var props = new java.util.Properties();
            props.setProperty("annotators", "tokenize, ssplit");
            props.setProperty("ner.useSUTime", "0");

            var CurDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory(jarRoot);         //change working dir to locate models
            Directory.SetCurrentDirectory(CurDir);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart.Series[0].Points.Clear();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            panLoading.Visible = true;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputText = File.ReadAllText(ofd.FileName);
                }
            }
            Regex rgx = new Regex("[^\r\n]{2}\r\n[^\r\n]{2}");
            MatchCollection mc = rgx.Matches(inputText);
            foreach (Match m in mc.Cast<Match>().Reverse())
            {
                inputText = Replace(inputText, m.Index + 2, m.Length - 4, " ");
            }
            txtInput.Text = inputText;
            panLoading.Visible = false;
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != "")
            {
                panLoading.Visible = true;
                btnProcess.Enabled = false;
                bgWkrProcess.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Please load text to be processed.", "Error");
            }
        }

        private void BgWkr_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWkrProcess.ReportProgress(0);
            edu.stanford.nlp.simple.Document doc = new edu.stanford.nlp.simple.Document(inputText);
            java.util.List jSents = doc.sentences();
            inputText = "";
            sents = new List<string>();
            for (java.util.Iterator itr = jSents.iterator(); itr.hasNext();)
            {
                sents.Add(((Sentence)itr.next()).text());
                inputText = inputText + sents[sents.Count - 1] + Environment.NewLine;
            }
            bgWkrProcess.ReportProgress(50);
            SentimentIntensityAnalyzer analyzer = new SentimentIntensityAnalyzer();
            SentimentAnalysisResults results;
            resultsList = new List<SentimentAnalysisResults>();
            outputText = "";
            foreach (string s in sents)
            {
                results = analyzer.PolarityScores(s);
                resultsList.Add(results);
                outputText = outputText + "Sentence [" + (sents.IndexOf(s) + 1) + "]: " + s + Environment.NewLine;
                outputText = outputText + "Positive: " + results.Positive + " | ";
                outputText = outputText + "Negative: " + results.Negative + " | ";
                outputText = outputText + "Neutral: " + results.Neutral + " | ";
                outputText = outputText + "Compound: " + results.Compound;
                outputText = outputText + Environment.NewLine + Environment.NewLine;
            }
            bgWkrProcess.ReportProgress(100);
        }

        private void BgWkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            chart.Series[0].Points.Clear(); //combined
            chart.Series[1].Points.Clear(); //pos.
            chart.Series[2].Points.Clear(); //neut.
            chart.Series[3].Points.Clear(); //neg.
            //int sLen = 0;
            double totScore = 0;
            int totNum = (granularity == -1 ? 1 : Convert.ToInt32(Math.Ceiling(granularity * sents.Count))); //total number of lines to sum sentiment values for
            int num = 0;    //current number of lines that have been summed
            SentimentAnalysisResults sar;
            for (int s = 0; s < 4; s++) //loop to plot all result outputs
            {
                for (int i = 0; i < resultsList.Count; i++) //loop for each result set
                {
                    sar = resultsList[i];
                    if (num == totNum || i + 1 == resultsList.Count)
                    {
                        chart.Series[s].Points.AddXY(i, totScore / totNum);
                        num = 0;
                        totScore = 0;
                    }
                    if (num < totNum)
                    {
                        if (s == 0)
                            totScore += sar.Compound;
                        else if (s == 1)
                            totScore += sar.Positive;
                        else if (s == 2)
                            totScore += sar.Neutral;
                        else if (s == 3)
                            totScore += sar.Negative;
                        num++;
                    }
                }
                LabelBestWorst(s);
            }

            txtInput.Text = inputText;
            txtOutput.Text = outputText;
            panLoading.Visible = false;
            btnProcess.Enabled = true;
        }

        private void LabelBestWorst(int sInd)
        {
            DataPoint dp = chart.Series[sInd].Points.FindMaxByValue();
            dp.Label = sents[chart.Series[sInd].Points.IndexOf(dp)]; //label max. value
            dp = chart.Series[sInd].Points.FindMinByValue();
            dp.Label = sents[chart.Series[sInd].Points.IndexOf(dp)]; //label min. value
        }

        private void BgWkrProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0:
                    lblLoading.Text = "Tokenising...";
                    break;
                case 50:
                    lblLoading.Text = "Processing...";
                    break;
                case 100:
                    lblLoading.Text = "Loading...";
                    break;
            }
        }

        private void TBarGran_ValueChanged(object sender, EventArgs e)
        {

            switch (tBarGran.Value)
            {
                case 0:
                    granularity = -1;
                    break;
                case 1:
                    granularity = 0.001;
                    break;
                case 2:
                    granularity = 0.002;
                    break;
                case 3:
                    granularity = 0.005;
                    break;
                case 4:
                    granularity = 0.01;
                    break;
                case 5:
                    granularity = 0.02;
                    break;
                case 6:
                    granularity = 0.05;
                    break;
                case 7:
                    granularity = 0.1;
                    break;
                case 8:
                    granularity = 0.25;
                    break;
                case 9:
                    granularity = 0.5;
                    break;
                case 10:
                    granularity = 1;
                    break;
            }
            lblGran.Text = (granularity == -1 ? "1 Sentence" : granularity * 100 + "%");
        }

        private string Replace(string s, int index, int length, string replacement)
        {
            var builder = new StringBuilder();
            builder.Append(s.Substring(0, index));
            builder.Append(replacement);
            builder.Append(s.Substring(index + length));
            return builder.ToString();
        }

        private void Chart_Click(object sender, EventArgs e)
        {
            if (sents.Count != 0 && resultsList.Count != 0)
            {
                PointDataViewer pdv = new PointDataViewer(sents, resultsList);
                pdv.Show();
            }
        }
    }
}
