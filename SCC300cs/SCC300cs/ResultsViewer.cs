using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VaderSharp;

namespace SCC300cs
{
    public partial class ResultsViewer : Form
    {
        string textName;
        List<string> sents;
        double granularity = -1;
        int chapters = 0;
        int chapterOffset = 0;
        Regex jpeg = new Regex(".jpeg$");
        private enum ResultType
        {
            COMPOUND,
            POSITIVE,
            NEUTRAL,
            NEGATIVE
        }

        public ResultsViewer(string textName, List<string> sents, List<List<SentimentAnalysisResults>> chaptersResultsList, double granularity)
        {
            InitializeComponent();
            this.textName = textName;
            this.sents = sents;
            this.granularity = granularity;
            chart.Series["Compound"].Points.Clear(); //compound
            chart.Series["Positive"].Points.Clear(); //pos.
            chart.Series["Neutral"].Points.Clear(); //neut.
            chart.Series["Negative"].Points.Clear(); //neg.
            chart.Series["Positive"].Enabled = false;
            chart.Series["Neutral"].Enabled = false;
            chart.Series["Negative"].Enabled = false;
            chart.Titles[0].Text = textName;
            chart.Series[0].Points.AddXY(1, 0);
            foreach (List<SentimentAnalysisResults> cRes in chaptersResultsList)
            {
                AddChapter(cRes);
            }
            chapterOffset = 0;
            GraphAll(chaptersResultsList);
            Show();
        }

        /// <summary>
        /// Adds a new chapter to this ResultsViewer
        /// </summary>
        /// <param name="res"> The List of SentimentAnalysisResults produced by the chapter</param>
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
            chapterOffset += res.Count;
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
            chart.ChartAreas[0].AxisX.Title += "\n\n[Block size " + (granularity == -1 ? 1 : Convert.ToInt32(Math.Ceiling(granularity * allRes.Count))) + " sents. / " + sents.Count + "]";
            AddResultsToTable(allRes);
            //Add100RandomToTable(allRes);
        }

        private void PlotResults(List<SentimentAnalysisResults> res, ResultType type, Series s)
        {
            double totScore = 0;
            int totNum = (granularity == -1 ? 1 : Convert.ToInt32(Math.Ceiling(granularity * res.Count))); //total number of lines to sum sentiment values for
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
            LabelBestWorst(s, totNum);
        }

        private void AddResultsToTable(List<SentimentAnalysisResults> res)
        {
            for (int i = 0; i < res.Count; i++)
            {
                dgvSenti.Rows.Add(i, res[i].Compound, res[i].Positive, res[i].Negative, res[i].Neutral, sents[i]);
            }
        }

        private void Add100RandomToTable(List<SentimentAnalysisResults> res)
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int ind = rnd.Next(res.Count - 1);
                dgvSenti.Rows.Add(i, res[ind].Compound, res[ind].Positive, res[ind].Negative, res[ind].Neutral, sents[ind]);
                res.RemoveAt(ind);
            }
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

        private void LabelBestWorst(Series s, int totNum)
        {
            if (s.Points.Count > 0)
            {
                string l = "";
                int sentIndex;
                DataPoint dp = s.Points.FindMaxByValue();
                sentIndex = s.Points.IndexOf(dp);
                for (int i = 0; i < totNum && (sentIndex + chapterOffset + i) < s.Points.Count; i++)
                {
                    l += sents[s.Points.IndexOf(dp) + chapterOffset + i];
                }
                dp.Label = (l.Length > 50 ? l.Substring(0, 47) + "..." : l);        //label max. value with abreviated sentence
                dp.LabelToolTip = l;                                                //label max. value with full sentence
                dp = s.Points.FindMinByValue();
                sentIndex = s.Points.IndexOf(dp);
                l = sents[sentIndex + chapterOffset];
                for (int i = 0; i < totNum && (sentIndex + chapterOffset + i) < s.Points.Count; i++)
                {
                    l += sents[s.Points.IndexOf(dp) + chapterOffset + i];
                }
                dp.Label = (l.Length > 50 ? l.Substring(0, 47) + "..." : l);        //label max. value with abreviated sentence
                dp.LabelToolTip = l;                                                //label max. value with full sentence
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JPEG files (*.jpeg)|*jpeg";
                sfd.FilterIndex = 0;
                sfd.RestoreDirectory = true;
                sfd.FileName = textName;
                sfd.OverwritePrompt = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!(jpeg.IsMatch(sfd.FileName)))
                    {
                        sfd.FileName += ".jpeg";
                    }
                    chart.SaveImage(sfd.FileName, ChartImageFormat.Jpeg);
                }
            }
        }

        private void chkBoxHideSenti_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxHideSenti.Checked)
            {
                dgvSenti.Columns[1].Visible = false;
                dgvSenti.Columns[2].Visible = false;
                dgvSenti.Columns[3].Visible = false;
                dgvSenti.Columns[4].Visible = false;
            }
            else
            {
                dgvSenti.Columns[1].Visible = true;
                dgvSenti.Columns[2].Visible = true;
                dgvSenti.Columns[3].Visible = true;
                dgvSenti.Columns[4].Visible = true;
            }
        }
    }
}
