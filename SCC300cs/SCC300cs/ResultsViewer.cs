﻿using System;
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

        public ResultsViewer(List<string> sents, List<List<SentimentAnalysisResults>> chaptersResultsList, double granularity)
        {
            InitializeComponent();
            this.sents = sents;
            this.granularity = granularity;
            chart.Series["Compound"].Points.Clear(); //compound
            chart.Series["Positive"].Points.Clear(); //pos.
            chart.Series["Neutral"].Points.Clear(); //neut.
            chart.Series["Negative"].Points.Clear(); //neg.
            foreach (List<SentimentAnalysisResults> cRes in chaptersResultsList)
            {
                AddChapter(cRes);
            }
            GraphAll(chaptersResultsList);
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

        private void AddResultsToTable(List<SentimentAnalysisResults> res)
        {
            for (int i = 0; i < res.Count; i++)
            {
                dgvSenti.Rows.Add(i, res[i].Compound, res[i].Positive, res[i].Negative, res[i].Neutral, sents[i]);
            }
        }

        private void GraphAll(List<List<SentimentAnalysisResults>> res)
        {
            List<SentimentAnalysisResults> allRes = new List<SentimentAnalysisResults>();
            foreach (List<SentimentAnalysisResults> s in res)
            {
                allRes.AddRange(s);
            }
            PlotResults(allRes, ResultType.COMPOUND, chart.Series["Compound"]);
            PlotResults(allRes, ResultType.POSITIVE, chart.Series["Positive"]);
            PlotResults(allRes, ResultType.NEUTRAL, chart.Series["Neutral"]);
            PlotResults(allRes, ResultType.NEGATIVE, chart.Series["Negative"]);
            AddResultsToTable(allRes);
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
            ca.AxisX.Interval = 10;
            ca.AxisX.Maximum = 100D;
            ca.AxisX.Minimum = 0D;
            //ca.AxisX.Title = "Beginning / Electricity (%)";
            ca.AxisX.Title = "Beginning / End (%)";
            ca.AxisY.InterlacedColor = Color.White;
            ca.AxisY.Interval = 0.25D;
            ca.AxisY.LabelAutoFitMinFontSize = 5;
            ca.AxisY.Maximum = 1D;
            ca.AxisY.Minimum = -1D;
            ca.AxisY.Title = "Good / Bad (Sentiment)";
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

        private void LblCom_Click(object sender, EventArgs e)
        {
            ChkBoxCom_CheckedChanged(sender, e);
        }

        private void LblPos_Click(object sender, EventArgs e)
        {
            ChkBxPos_CheckedChanged(sender, e);
        }

        private void LblNeut_Click(object sender, EventArgs e)
        {
            ChkBxNeut_CheckedChanged(sender, e);
        }

        private void LblNeg_Click(object sender, EventArgs e)
        {
            ChkBxNeg_CheckedChanged(sender, e);
        }
    }
}
