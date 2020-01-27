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
        int chapters = 0;
        private enum ResultType
        {
            COMPOUND,
            POSITIVE,
            NEUTRAL,
            NEGATIVE
        }

        public ResultsViewer(List<string> sents, List<List<SentimentAnalysisResults>> resultsList, double granularity)
        {
            InitializeComponent();
            this.sents = sents;
            this.granularity = granularity;
            chart.Series["Compound"].Points.Clear(); //compound
            chart.Series["Positive"].Points.Clear(); //pos.
            chart.Series["Neutral"].Points.Clear(); //neut.
            chart.Series["Negative"].Points.Clear(); //neg.
            foreach (List<SentimentAnalysisResults> cRes in resultsList)
            {
                AddChapter(cRes);
            }
            Show();
        }

        public void AddChapter(List<SentimentAnalysisResults> res)
        {
            Series chap = new Series()
            {
                Name = "Ch" + (chapters + 1),
                LegendText = "Ch" + (chapters + 1),
                ChartType = SeriesChartType.Spline,
            };
            int pageNum = chapters / 5;
            if (chapters % 5 == 0)
            {
                NewTab("Ch" + (chapters  + 1) + "-" + (chapters + 5));
            }
            PlotResults(res, ResultType.COMPOUND, chap);
            foreach (Control c in tabCtrlResults.TabPages[(chapters / 5) + 2].Controls)
            {
                if (c is Chart)
                {
                    ((Chart)c).Series.Add(chap);
                }
            }
            chapters++;
        }

        private void PlotResults(List<SentimentAnalysisResults> res, ResultType type, Series s)
        {
            double totScore = 0;
            int totNum = (granularity == -1 ? 1 : Convert.ToInt32(Math.Ceiling(granularity * sents.Count))); //total number of lines to sum sentiment values for
            int num = 0;    //current number of lines that have been summed
            SentimentAnalysisResults sar;
            for (int i = 0; i < res.Count; i++) //loop for each result set
            {
                sar = res[i];
                if (num == totNum || i + 1 == res.Count)
                {

                    s.Points.AddXY((i / (double)res.Count) * 100, totScore / totNum);
                    num = 0;
                    totScore = 0;
                }
                if (num < totNum)
                {
                    switch (type)
                    {
                        case ResultType.COMPOUND:
                            totScore += sar.Compound;
                            break;
                        case ResultType.POSITIVE:
                            totScore += sar.Positive;
                            break;
                        case ResultType.NEUTRAL:
                            totScore += sar.Neutral;
                            break;
                        case ResultType.NEGATIVE:
                            totScore += sar.Negative;
                            break;
                    }
                    num++;
                }
            }
            LabelBestWorst(s);
        }

        public void NewTab(string name)
        {
            TabPage t = new TabPage
            {
                Name = "tbPg" + name,
                Text = name
            };
            Chart c = new Chart
            {
                Palette = ChartColorPalette.BrightPastel,
                Dock = DockStyle.Fill
            };
            c.Legends.Add(new Legend()
            {
                Docking = Docking.Bottom
            });
            ChartArea ca = new ChartArea();
            ca.AxisX.Maximum = 100D;
            ca.AxisX.Minimum = 0D;
            ca.AxisX.Title = "Beginning / Electricity";
            ca.AxisY.InterlacedColor = System.Drawing.Color.White;
            ca.AxisY.Interval = 0.25D;
            ca.AxisY.LabelAutoFitMinFontSize = 5;
            ca.AxisY.Maximum = 1D;
            ca.AxisY.Minimum = -1D;
            ca.AxisY.Title = "Good / Bad";
            ca.Name = "chartArea" + name;
            c.ChartAreas.Add(ca);

            t.Controls.Add(c);
            tabCtrlResults.TabPages.Add(t);
        }

        private void LabelBestWorst(Series s)
        {
            if (s.Points.Count > 0)
            {
                DataPoint dp = s.Points.FindMaxByValue();
                dp.Label = sents[s.Points.IndexOf(dp)]; //label max. value
                dp = s.Points.FindMinByValue();
                dp.Label = sents[s.Points.IndexOf(dp)]; //label min. value
            }
        }

        private void ChkBoxCom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxCom.Checked)
            {
                chart.Series["Compound"].Enabled = true;
            }
            else
            {
                chart.Series["Compound"].Enabled = false;
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
