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

namespace SCC300cs
{
    public partial class Form1 : Form
    {
        string inputText;
        string outputText;
        List<string> sents;
        List<SentimentAnalysisResults> resultsList;

        public Form1()
        {
            InitializeComponent();
            InitPipeline();
        }

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
            chart.Series["default"].Points.Clear();
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
            chart.Series["default"].Points.Clear();
            long charCount = 0;
            int sLen = 0;
            int ind = 0;
            foreach (SentimentAnalysisResults sar in resultsList)
            {
                ind = resultsList.IndexOf(sar);
                sLen = sents[ind].Length;
                chart.Series["default"].Points.AddXY(ind, sar.Compound);
                charCount += sLen;
            }
            txtInput.Text = inputText;
            txtOutput.Text = outputText;
            panLoading.Visible = false;
        }

        private void bgWkrProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

        private string Replace(string s, int index, int length, string replacement)
        {
            var builder = new StringBuilder();
            builder.Append(s.Substring(0, index));
            builder.Append(replacement);
            builder.Append(s.Substring(index + length));
            return builder.ToString();
        }
    }
}
