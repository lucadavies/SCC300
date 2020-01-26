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
using edu.stanford.nlp.simple;
using VaderSharp;
using System.Windows.Forms.DataVisualization.Charting;
using System.Web;

namespace SCC300cs
{
    public partial class SentiPlot : Form
    {
        string inputText;
        List<string> inputChapters;
        string outputText;
        double granularity = -1;
        List<string> sents;
        List<SentimentAnalysisResults> resultsList;
        

        public SentiPlot()
        {
            InitializeComponent();
            InitPipeline();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            Directory.SetCurrentDirectory(jarRoot);                                 //change working dir to locate models
            Directory.SetCurrentDirectory(CurDir);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt,*.html)|*.txt;*.html|All files (*.*)|*.*";
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputText = File.ReadAllText(ofd.FileName);
                    panLoading.Visible = true;
                    BtnLoad.Enabled = false;
                    bgWkrLoad.RunWorkerAsync(argument: Path.GetExtension(ofd.FileName));
                }
            }
        }

        private string LoadFromTxt(string i)
        {
            Regex rgx = new Regex("[^\r\n]{2}\r\n[^\r\n]{2}");
            MatchCollection mc = rgx.Matches(i);
            foreach (Match m in mc.Cast<Match>().Reverse())
            {
                i = Replace(i, m.Index + 2, m.Length - 4, " ");
            }
            return i;
        }

        private string LoadFromHTML(string input)
        {
            Regex body = new Regex("body>");                                        //match both <body> and </body> tags
            Regex pre = new Regex("<pre(.|\n)+?</pre>");                            //match whole <pre></pre> sections
            Regex headers = new Regex("<h[0-9]>.*</h[0-9]>");                       //match on header sections to get chapters
            Regex htmlTags = new Regex("<[^>]*>");                                  //match on html tags
           try
            {
                bgWkrLoad.ReportProgress(0);
                input = body.Split(input)[1];                                       //split on "body>" to give three sections, pre-, mid- and post-body, take 1 for content
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("HTML file imporperly formatted", "SentiPlot");
                return "";
            }
            bgWkrLoad.ReportProgress(25);
            input = pre.Replace(input, "");                                         //remove full <pre>,/pre> sections
            bgWkrLoad.ReportProgress(50);
            input = HttpUtility.HtmlDecode(input);                                  //decode HTML special characters
            bgWkrLoad.ReportProgress(75);
            string[] chaps = headers.Split(input);                                      //split on header tags to split into chapters
            string ret = "";
            bgWkrLoad.ReportProgress(100);
            for (int ind = 0; ind < chaps.Length; ind++)
            {
                chaps[ind] = htmlTags.Replace(chaps[ind], "");                           //remove all remaining HTML tags
                ret += LoadFromTxt(chaps[ind] + " ");
            }
            return ret;
        }

        private string Replace(string s, int index, int length, string replacement)
        {
            var builder = new StringBuilder();
            builder.Append(s.Substring(0, index));
            builder.Append(replacement);
            builder.Append(s.Substring(index + length));
            return builder.ToString();
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

        private void BgWkrProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWkrProcess.ReportProgress(0);
            Document doc = new Document(inputText);
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

        private void BgWkrProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResultsViewer res = new ResultsViewer(sents, resultsList, granularity);
            txtInput.Text = inputText;
            txtOutput.Text = outputText;
            panLoading.Visible = false;
            btnProcess.Enabled = true;
        }

        private void BgWkrLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument.Equals(".txt"))
            {
                e.Result = LoadFromTxt(inputText);
            }
            else if (e.Argument.Equals(".html"))
            {
                e.Result = LoadFromHTML(inputText);
            }
        }

        private void BgWkrLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0:
                    lblLoading.Text = "Removing excess HTML...";
                    break;
                case 25:
                    lblLoading.Text = "Removing Gutenberg metadata...";
                    break;
                case 50:
                    lblLoading.Text = "Decoding HTML characters...";
                    break;
                case 75:
                    lblLoading.Text = "Chapter splitting...";
                    break;
                case 100:
                    lblLoading.Text = "Removing remaining HTML tags...";
                    break;
            }
        }

        private void BgWkrLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            inputText = (string)e.Result;
            txtInput.Text = inputText;
            panLoading.Visible = false;
            BtnLoad.Enabled = true;
        }
    }
}
