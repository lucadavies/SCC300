using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.ejml.simple;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.neural.rnn;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.sentiment;
using edu.stanford.nlp.trees;
using edu.stanford.nlp.util;

namespace SCC300cs
{
    public partial class Form1 : Form
    {
        string inputText;
        Document doc;
        StanfordCoreNLP pipeline;

        public Form1()
        {
            InitializeComponent();
            pipeline = new StanfordCoreNLP(@"C:\Users\Luca\Documents\University\General\UG3\SCC300\SCC300cs\SCC300cs\stanford-corenlp-3.7.0-models\edu\stanford\nlp\models");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                    inputText = System.IO.File.ReadAllText(ofd.FileName);
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
            Annotation doc = new Annotation(inputText);
            pipeline.annotate(doc);

        }

        private void BtnTokenize_Click(object sender, EventArgs e)
        {
            //doc = new Document(inputText);
            //java.util.List sens = doc.sentences();
            //txtInput.Clear();
            //for (int i = 0; i < sens.size(); i++)
            //{
            //    txtInput.AppendText(sens.get(i).ToString());
            //    txtInput.AppendText(Environment.NewLine);
            //}
        }

        private void btnLem_Click(object sender, EventArgs e)
        {
            //java.util.Properties props = new java.util.Properties();
            //props.setProperty("annotators", "tokenize, ssplit, parse, sentiment");
            //java.util.List sens = doc.sentences();
            //txtInput.Clear();
            //for (int i = 0; i < sens.size(); i++)
            //{
            //    java.util.List lems = ((Sentence)sens.get(i)).lemmas();
            //    for (int j = 0; j < lems.size(); j++)
            //    {
            //        txtInput.AppendText(lems.get(j).ToString());
            //        txtInput.AppendText(" ");
                    
            //    }
            //}
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
