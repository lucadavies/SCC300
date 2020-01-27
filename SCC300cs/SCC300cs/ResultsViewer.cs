using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VaderSharp;

namespace SCC300cs
{
    public partial class ResultsViewer : Form
    {
        List<string> sents;
        double granularity = -1;
        List<SentimentAnalysisResults> resultsList;

        public ResultsViewer(List<string> sents, List<SentimentAnalysisResults> resultsList, double granularity)
        {
            InitializeComponent();
            this.sents = sents;
            this.resultsList = resultsList;
            this.granularity = granularity;
            chart.Series[0].Points.Clear(); //combined
            chart.Series[1].Points.Clear(); //pos.
            chart.Series[2].Points.Clear(); //neut.
            chart.Series[3].Points.Clear(); //neg.
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

                        chart.Series[s].Points.AddXY((i / (double)resultsList.Count) * 100, totScore / totNum);
                        Console.WriteLine("X: {0}, Y: {1}", i / (double)resultsList.Count * 100, totScore / totNum);
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
                LabelBestWorst(chart.Series[s]);
            }
            for (int i = 0; i < resultsList.Count; i++)
            {
                dgvSenti.Rows.Add(i, resultsList[i].Compound, resultsList[i].Positive, resultsList[i].Negative, resultsList[i].Neutral, sents[i]);
            }
            LabelBestWorst(chart.Series[chart.Series.Count - 1]);
            Show();
        }

        public void AddResultSet()
        {
            
        }

        private void LabelBestWorst(Series s)
        {
            DataPoint dp = s.Points.FindMaxByValue();
            dp.Label = sents[s.Points.IndexOf(dp)]; //label max. value
            dp = s.Points.FindMinByValue();
            dp.Label = sents[s.Points.IndexOf(dp)]; //label min. value
        }

        private void ChkBoxComb_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxComb.Checked)
            {
                chart.Series["Combined"].Enabled = true;
            }
            else
            {
                chart.Series["Combined"].Enabled = false;
            }
        }

        private void ChkBxPos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxPos.Checked)
            {
                chart.Series["Positive"].Enabled = true;
            }
            else
            {
                chart.Series["Positive"].Enabled = false;
            }
        }

        private void ChkBxNeut_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxNeut.Checked)
            {
                chart.Series["Neutral"].Enabled = true;
            }
            else
            {
                chart.Series["Neutral"].Enabled = false;
            }
        }

        private void ChkBxNeg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxNeg.Checked)
            {
                chart.Series["Negative"].Enabled = true;
            }
            else
            {
                chart.Series["Negative"].Enabled = false;
            }
        }
    }
}
