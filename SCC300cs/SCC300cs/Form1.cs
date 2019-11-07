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
using edu.stanford.nlp.simple;

namespace SCC300cs
{
    public partial class Form1 : Form
    {
        string inputText;
        Document doc;

        public Form1()
        {
            InitializeComponent();
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
            //inputText = inputText.Replace(Environment.NewLine, "FUCK");
            Regex rgx = new Regex("[^\r\n]{2}\r\n[^\r\n]{2}");
            MatchCollection mc = rgx.Matches(inputText);
            Regex rrgx = new Regex("\r\n");
            foreach (Match m in mc.Cast<Match>().Reverse())
            {
                inputText = Replace(inputText, m.Index + 2, m.Length - 4, " ");
            }
            txtInput.Text = inputText;
        }

        private void BtnTokenize_Click(object sender, EventArgs e)
        {
            doc = new Document(inputText);
            java.util.List sens = doc.sentences();
            txtInput.Clear();
            for (int i = 0; i < sens.size(); i++)
            {
                txtInput.AppendText(sens.get(i).ToString());
                txtInput.AppendText(Environment.NewLine);
            }
        }

        private void btnLem_Click(object sender, EventArgs e)
        {
            java.util.List sens = doc.sentences();
            txtInput.Clear();
            for (int i = 0; i < sens.size(); i++)
            {
                //java.util.list lems = ((sentence)sens.get(i)).lemmas();
                //for (int j = 0; j < lems.size(); j++)
                //{
                //    txtinput.appendtext(lems.get(j).tostring());
                //    txtinput.appendtext(" ");
                //}
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
