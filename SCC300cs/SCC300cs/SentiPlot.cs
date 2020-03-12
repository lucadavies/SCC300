using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using edu.stanford.nlp.simple;
using VaderSharp;
using System.Web;

namespace SCC300cs
{
    public partial class SentiPlot : Form
    {
        string textName;
        string inputText;
        List<string> inputChapters = new List<string>();
        double granularity = -1;
        List<string> sents;
        List<List<SentimentAnalysisResults>> chapterResultsList;
        List<List<string>> chapterSents;
        

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
                ofd.Filter = "Text files (*.txt,*.html, *.xml)|*.txt;*.html;*.xml|All files (*.*)|*.*";
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputText = File.ReadAllText(ofd.FileName);
                    textName = Path.GetFileNameWithoutExtension(ofd.SafeFileName);
                    panLoading.Visible = true;
                    BtnLoad.Enabled = false;
                    bgWkrLoad.RunWorkerAsync(argument: Path.GetExtension(ofd.FileName));
                }
            }
        }

        private string LoadFromTxt(string i)
        {
            Regex rgx = new Regex("\\s+");
            return rgx.Replace(i, " ");
        }

        /// <summary>
        /// Project Gutenberg appears to not hold a standard format (RE: pre tags)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string LoadFromHTML(string input)
        {
            Regex body = new Regex("body>");                                        //match both <body> and </body> tags
            Regex pre = new Regex("<pre(.|\\r\\n)+?</pre>");                            //match whole <pre></pre> sections
            Regex headers = new Regex("<h[0-9]>");                                  //match on header sections to get chapters
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
            string ch;
            string ret = "";
            bgWkrLoad.ReportProgress(100);
            for (int ind = 0; ind < chaps.Length; ind++)
            {
                ch = htmlTags.Replace(chaps[ind], "");                           //remove all remaining HTML tags
                inputChapters.Add(LoadFromTxt(ch));
                ret += LoadFromTxt(ch + " ");
            }
            return ret;
        }

        private string loadFromXML(string input)
        {
            Regex tags = new Regex("<[^>]*>");
            string t = LoadFromTxt(tags.Replace(HttpUtility.HtmlDecode(input), ""));
            inputChapters.Add(LoadFromTxt(t));
            return t;
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

        private void BgWkrProcess_DoWork(object sen300der, DoWorkEventArgs e)
        {
            bgWkrProcess.ReportProgress(0);
            Document doc;
            java.util.List jSents;
            chapterSents = new List<List<string>>();
            inputText = "";
            for (int i = 0; i < inputChapters.Count; i++)
            {
                doc = new Document(inputChapters[i]);
                jSents = doc.sentences();
                List<string> cSents = new List<string>();
                for (java.util.Iterator itr = jSents.iterator(); itr.hasNext();)
                {
                    cSents.Add(((Sentence)itr.next()).text());
                    inputText = inputText + cSents[cSents.Count - 1] + Environment.NewLine;
                }
                chapterSents.Add(cSents);
            }

            bgWkrProcess.ReportProgress(50);
            SentimentIntensityAnalyzer analyzer = new SentimentIntensityAnalyzer();
            SentimentAnalysisResults results;
            List<SentimentAnalysisResults> temp = new List<SentimentAnalysisResults>();
            chapterResultsList = new List<List<SentimentAnalysisResults>>();
            sents = new List<string>();
            foreach (List<string> outputChapter in chapterSents)
            {
                temp.Clear();
                foreach (string c in outputChapter)
                {
                    results = analyzer.PolarityScores(c);
                    sents.Add(c);
                    temp.Add(results);
                }
                chapterResultsList.Add(new List<SentimentAnalysisResults>(temp));
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
            new ResultsViewer(textName, sents, chapterResultsList, granularity);
            txtInput.Text = inputText;
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
            else if (e.Argument.Equals(".xml")) ;
            {
                e.Result = loadFromXML(inputText);
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
