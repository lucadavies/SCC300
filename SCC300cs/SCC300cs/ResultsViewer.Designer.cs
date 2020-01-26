namespace SCC300cs
{
    partial class ResultsViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsViewer));
            this.tabCtrlResults = new System.Windows.Forms.TabControl();
            this.tbPg = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbPgTable = new System.Windows.Forms.TabPage();
            this.dgvSenti = new System.Windows.Forms.DataGridView();
            this.colNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNeut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTxt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCtrlResults.SuspendLayout();
            this.tbPg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.tbPgTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSenti)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrlResults
            // 
            this.tabCtrlResults.Controls.Add(this.tbPg);
            this.tabCtrlResults.Controls.Add(this.tbPgTable);
            this.tabCtrlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlResults.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlResults.Name = "tabCtrlResults";
            this.tabCtrlResults.SelectedIndex = 0;
            this.tabCtrlResults.Size = new System.Drawing.Size(800, 450);
            this.tabCtrlResults.TabIndex = 1;
            // 
            // tbPg
            // 
            this.tbPg.Controls.Add(this.chart);
            this.tbPg.Location = new System.Drawing.Point(4, 22);
            this.tbPg.Name = "tbPg";
            this.tbPg.Padding = new System.Windows.Forms.Padding(3);
            this.tbPg.Size = new System.Drawing.Size(792, 424);
            this.tbPg.TabIndex = 0;
            this.tbPg.Text = "Graph";
            this.tbPg.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            chartArea1.AxisX.Title = "Beginning / Electricity";
            chartArea1.AxisY.Title = "Good / Bad";
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(3, 3);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            series1.Legend = "Legend1";
            series1.Name = "Combined";
            series1.YValuesPerPoint = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Lime;
            series2.Legend = "Legend1";
            series2.Name = "Positive";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Aqua;
            series3.Legend = "Legend1";
            series3.Name = "Neutral";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "Negative";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(786, 418);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart";
            // 
            // tbPgTable
            // 
            this.tbPgTable.Controls.Add(this.dgvSenti);
            this.tbPgTable.Location = new System.Drawing.Point(4, 22);
            this.tbPgTable.Name = "tbPgTable";
            this.tbPgTable.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgTable.Size = new System.Drawing.Size(792, 424);
            this.tbPgTable.TabIndex = 1;
            this.tbPgTable.Text = "Table";
            this.tbPgTable.UseVisualStyleBackColor = true;
            // 
            // dgvSenti
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSenti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNum,
            this.colComb,
            this.colPos,
            this.colNeg,
            this.colNeut,
            this.colTxt});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSenti.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSenti.Location = new System.Drawing.Point(3, 3);
            this.dgvSenti.Name = "dgvSenti";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSenti.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSenti.Size = new System.Drawing.Size(786, 418);
            this.dgvSenti.TabIndex = 1;
            // 
            // colNum
            // 
            this.colNum.HeaderText = "Num";
            this.colNum.Name = "colNum";
            this.colNum.Width = 50;
            // 
            // colComb
            // 
            this.colComb.HeaderText = "Combined";
            this.colComb.Name = "colComb";
            this.colComb.Width = 60;
            // 
            // colPos
            // 
            this.colPos.HeaderText = "Positive";
            this.colPos.Name = "colPos";
            this.colPos.Width = 60;
            // 
            // colNeg
            // 
            this.colNeg.HeaderText = "Negative";
            this.colNeg.Name = "colNeg";
            this.colNeg.Width = 60;
            // 
            // colNeut
            // 
            this.colNeut.HeaderText = "Neutral";
            this.colNeut.Name = "colNeut";
            this.colNeut.Width = 60;
            // 
            // colTxt
            // 
            this.colTxt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTxt.HeaderText = "Text";
            this.colTxt.Name = "colTxt";
            // 
            // ResultsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabCtrlResults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResultsViewer";
            this.Text = "Results";
            this.tabCtrlResults.ResumeLayout(false);
            this.tbPg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tbPgTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSenti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabCtrlResults;
        private System.Windows.Forms.TabPage tbPg;
        private System.Windows.Forms.TabPage tbPgTable;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DataGridView dgvSenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNeut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTxt;
    }
}