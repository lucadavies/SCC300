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
        StanfordCoreNLP pipeline;
        List<string> sents;
        List<SentimentAnalysisResults> resultsList;

        public Form1()
        {
            InitializeComponent();
            initPipeline();
        }

        private void initPipeline()
        {
            var jarRoot = @"C:\Users\Luca\Documents\University\General\UG3\SCC300\SCC300cs\SCC300cs\stanford-corenlp-3.7.0-models";

            // Annotation pipeline configuration
            var props = new java.util.Properties();
            props.setProperty("annotators", "tokenize, ssplit");
            props.setProperty("ner.useSUTime", "0");

            var CurDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory(jarRoot);         //change working dir to locate models
            pipeline = new StanfordCoreNLP(props);
            Directory.SetCurrentDirectory(CurDir);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            chart.Series["Default"].Points.Clear();
            for (int i = 0; i < 100; i++)
            {
                chart.Series["Default"].Points.AddXY(i + 1, rnd.Next(i * 10, i * 20));
            }
            
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {

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
        }

        private void BtnAnnotate_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != "")
            {
                panLoading.Visible = true;
                bgWkrAnnotate.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Please load text to be processed.", "Error");
            }
        }

        private void btnVaderSenti_Click(object sender, EventArgs e)
        {
            panLoading.Visible = true;
            bgWkrSenti.RunWorkerAsync();
        }

        private void bgWkrAnnotate_DoWork_AnnotateText(object sender, DoWorkEventArgs e)
        {
            edu.stanford.nlp.simple.Document doc = new edu.stanford.nlp.simple.Document(inputText);
            e.Result = doc.sentences();
        }

        private void bgWkrAnnotate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            java.util.List jSents = (java.util.List)e.Result;
            txtInput.Text = "";
            inputText = "";
            sents = new List<string>();
            for (java.util.Iterator itr = jSents.iterator(); itr.hasNext();)
            {
                sents.Add(((Sentence)itr.next()).text());
                inputText = inputText + sents[sents.Count - 1] + Environment.NewLine;
            }
            txtInput.Text = inputText;
            panLoading.Visible = false;
        }

        private void bgWkrSenti_DoWork_AnalyseText(object Sender, DoWorkEventArgs e)
        {
            SentimentIntensityAnalyzer analyzer = new SentimentIntensityAnalyzer();
            SentimentAnalysisResults results;
            resultsList = new List<SentimentAnalysisResults>();
            string op = "";
            txtOutput.Text = "";
            foreach (string s in sents)
            {
                results = analyzer.PolarityScores(s);
                resultsList.Add(results);
                op = op + "Sentence [" + (sents.IndexOf(s) + 1) + "]: " + s + Environment.NewLine;
                op = op + "Positive: " + results.Positive + " | ";
                op = op + "Negative: " + results.Negative + " | ";
                op = op + "Neutral: " + results.Neutral + " | ";
                op = op + "Compound: " + results.Compound;
                op = op + Environment.NewLine + Environment.NewLine;
            }
            e.Result = op;
        }

        private void bgWkrSenti_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtOutput.Text = (string)e.Result;
            panLoading.Visible = false;
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
