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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsViewer));
            this.tabCtrlResults = new System.Windows.Forms.TabControl();
            this.tbPg = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNeg = new System.Windows.Forms.Label();
            this.lblNeut = new System.Windows.Forms.Label();
            this.lblPos = new System.Windows.Forms.Label();
            this.lblCom = new System.Windows.Forms.Label();
            this.chkBxNeg = new System.Windows.Forms.CheckBox();
            this.chkBoxCom = new System.Windows.Forms.CheckBox();
            this.chkBxNeut = new System.Windows.Forms.CheckBox();
            this.chkBxPos = new System.Windows.Forms.CheckBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvSenti = new System.Windows.Forms.DataGridView();
            this.colTxt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNeut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPgTable = new System.Windows.Forms.TabPage();
            this.chkBoxHideSenti = new System.Windows.Forms.CheckBox();
            this.tabCtrlResults.SuspendLayout();
            this.tbPg.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSenti)).BeginInit();
            this.tbPgTable.SuspendLayout();
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
            this.tabCtrlResults.Size = new System.Drawing.Size(784, 461);
            this.tabCtrlResults.TabIndex = 1;
            // 
            // tbPg
            // 
            this.tbPg.Controls.Add(this.panel1);
            this.tbPg.Controls.Add(this.chart);
            this.tbPg.Location = new System.Drawing.Point(4, 22);
            this.tbPg.Name = "tbPg";
            this.tbPg.Padding = new System.Windows.Forms.Padding(3);
            this.tbPg.Size = new System.Drawing.Size(776, 435);
            this.tbPg.TabIndex = 0;
            this.tbPg.Text = "Graph";
            this.tbPg.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.lblNeg);
            this.panel1.Controls.Add(this.lblNeut);
            this.panel1.Controls.Add(this.lblPos);
            this.panel1.Controls.Add(this.lblCom);
            this.panel1.Controls.Add(this.chkBxNeg);
            this.panel1.Controls.Add(this.chkBoxCom);
            this.panel1.Controls.Add(this.chkBxNeut);
            this.panel1.Controls.Add(this.chkBxPos);
            this.panel1.Location = new System.Drawing.Point(0, 393);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 42);
            this.panel1.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(693, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblNeg
            // 
            this.lblNeg.AutoSize = true;
            this.lblNeg.Location = new System.Drawing.Point(269, 20);
            this.lblNeg.Name = "lblNeg";
            this.lblNeg.Size = new System.Drawing.Size(50, 13);
            this.lblNeg.TabIndex = 9;
            this.lblNeg.Text = "Negative";
            this.lblNeg.Click += new System.EventHandler(this.LblNeg_Click);
            // 
            // lblNeut
            // 
            this.lblNeut.AutoSize = true;
            this.lblNeut.Location = new System.Drawing.Point(191, 20);
            this.lblNeut.Name = "lblNeut";
            this.lblNeut.Size = new System.Drawing.Size(41, 13);
            this.lblNeut.TabIndex = 8;
            this.lblNeut.Text = "Neutral";
            this.lblNeut.Click += new System.EventHandler(this.LblNeut_Click);
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Location = new System.Drawing.Point(111, 20);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(44, 13);
            this.lblPos.TabIndex = 7;
            this.lblPos.Text = "Positive";
            this.lblPos.Click += new System.EventHandler(this.LblPos_Click);
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(20, 20);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(58, 13);
            this.lblCom.TabIndex = 6;
            this.lblCom.Text = "Compound";
            this.lblCom.Click += new System.EventHandler(this.LblCom_Click);
            // 
            // chkBxNeg
            // 
            this.chkBxNeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBxNeg.AutoSize = true;
            this.chkBxNeg.Location = new System.Drawing.Point(255, 20);
            this.chkBxNeg.Name = "chkBxNeg";
            this.chkBxNeg.Size = new System.Drawing.Size(15, 14);
            this.chkBxNeg.TabIndex = 5;
            this.chkBxNeg.UseVisualStyleBackColor = true;
            this.chkBxNeg.CheckedChanged += new System.EventHandler(this.ChkBxNeg_CheckedChanged);
            // 
            // chkBoxCom
            // 
            this.chkBoxCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBoxCom.AutoSize = true;
            this.chkBoxCom.Checked = true;
            this.chkBoxCom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxCom.Location = new System.Drawing.Point(6, 20);
            this.chkBoxCom.Name = "chkBoxCom";
            this.chkBoxCom.Size = new System.Drawing.Size(15, 14);
            this.chkBoxCom.TabIndex = 2;
            this.chkBoxCom.UseVisualStyleBackColor = true;
            this.chkBoxCom.CheckedChanged += new System.EventHandler(this.ChkBoxCom_CheckedChanged);
            // 
            // chkBxNeut
            // 
            this.chkBxNeut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBxNeut.AutoSize = true;
            this.chkBxNeut.Location = new System.Drawing.Point(177, 20);
            this.chkBxNeut.Name = "chkBxNeut";
            this.chkBxNeut.Size = new System.Drawing.Size(15, 14);
            this.chkBxNeut.TabIndex = 4;
            this.chkBxNeut.UseVisualStyleBackColor = true;
            this.chkBxNeut.CheckedChanged += new System.EventHandler(this.ChkBxNeut_CheckedChanged);
            // 
            // chkBxPos
            // 
            this.chkBxPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBxPos.AutoSize = true;
            this.chkBxPos.Location = new System.Drawing.Point(97, 20);
            this.chkBxPos.Name = "chkBxPos";
            this.chkBxPos.Size = new System.Drawing.Size(15, 14);
            this.chkBxPos.TabIndex = 3;
            this.chkBxPos.UseVisualStyleBackColor = true;
            this.chkBxPos.CheckedChanged += new System.EventHandler(this.ChkBxPos_CheckedChanged);
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Maximum = 100D;
            chartArea1.AxisX.MaximumAutoSize = 100F;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Beginning / End (%)";
            chartArea1.AxisY.InterlacedColor = System.Drawing.Color.White;
            chartArea1.AxisY.Interval = 0.25D;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = -1D;
            chartArea1.AxisY.Title = "Good / Bad";
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(3, 3);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "Compound";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Lime;
            series2.Legend = "Legend1";
            series2.Name = "Positive";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Aqua;
            series3.Legend = "Legend1";
            series3.Name = "Neutral";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "Negative";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(770, 387);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart";
            title1.Name = "titleAll";
            title1.Text = "<>";
            this.chart.Titles.Add(title1);
            // 
            // dgvSenti
            // 
            this.dgvSenti.AllowUserToAddRows = false;
            this.dgvSenti.AllowUserToDeleteRows = false;
            this.dgvSenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.colCom,
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
            this.dgvSenti.Size = new System.Drawing.Size(770, 403);
            this.dgvSenti.TabIndex = 1;
            // 
            // colTxt
            // 
            this.colTxt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTxt.HeaderText = "Text";
            this.colTxt.Name = "colTxt";
            // 
            // colNeut
            // 
            this.colNeut.HeaderText = "Neutral";
            this.colNeut.Name = "colNeut";
            this.colNeut.Width = 60;
            // 
            // colNeg
            // 
            this.colNeg.HeaderText = "Negative";
            this.colNeg.Name = "colNeg";
            this.colNeg.Width = 60;
            // 
            // colPos
            // 
            this.colPos.HeaderText = "Positive";
            this.colPos.Name = "colPos";
            this.colPos.Width = 60;
            // 
            // colCom
            // 
            this.colCom.HeaderText = "Compound";
            this.colCom.Name = "colCom";
            this.colCom.Width = 60;
            // 
            // colNum
            // 
            this.colNum.HeaderText = "Num";
            this.colNum.Name = "colNum";
            this.colNum.Width = 50;
            // 
            // tbPgTable
            // 
            this.tbPgTable.Controls.Add(this.chkBoxHideSenti);
            this.tbPgTable.Controls.Add(this.dgvSenti);
            this.tbPgTable.Location = new System.Drawing.Point(4, 22);
            this.tbPgTable.Name = "tbPgTable";
            this.tbPgTable.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgTable.Size = new System.Drawing.Size(776, 435);
            this.tbPgTable.TabIndex = 1;
            this.tbPgTable.Text = "Table";
            this.tbPgTable.UseVisualStyleBackColor = true;
            // 
            // chkBoxHideSenti
            // 
            this.chkBoxHideSenti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBoxHideSenti.AutoSize = true;
            this.chkBoxHideSenti.Location = new System.Drawing.Point(8, 412);
            this.chkBoxHideSenti.Name = "chkBoxHideSenti";
            this.chkBoxHideSenti.Size = new System.Drawing.Size(141, 17);
            this.chkBoxHideSenti.TabIndex = 2;
            this.chkBoxHideSenti.Text = "Hide Sentiment Columns";
            this.chkBoxHideSenti.UseVisualStyleBackColor = true;
            this.chkBoxHideSenti.CheckedChanged += new System.EventHandler(this.chkBoxHideSenti_CheckedChanged);
            // 
            // ResultsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabCtrlResults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "ResultsViewer";
            this.Text = "Results";
            this.tabCtrlResults.ResumeLayout(false);
            this.tbPg.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSenti)).EndInit();
            this.tbPgTable.ResumeLayout(false);
            this.tbPgTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabCtrlResults;
        private System.Windows.Forms.TabPage tbPg;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.CheckBox chkBxNeg;
        private System.Windows.Forms.CheckBox chkBxNeut;
        private System.Windows.Forms.CheckBox chkBxPos;
        private System.Windows.Forms.CheckBox chkBoxCom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNeg;
        private System.Windows.Forms.Label lblNeut;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tbPgTable;
        private System.Windows.Forms.CheckBox chkBoxHideSenti;
        private System.Windows.Forms.DataGridView dgvSenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNeut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTxt;
    }
}