namespace SCC300cs
{
    partial class SentiPlot
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.GroupBox groupBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SentiPlot));
            this.lblGran = new System.Windows.Forms.Label();
            this.tBarGran = new System.Windows.Forms.TrackBar();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.bgWkrProcess = new System.ComponentModel.BackgroundWorker();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.panLoading = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.bgWkrLoad = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarGran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.panLoading.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 51);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 13);
            label1.TabIndex = 10;
            label1.Text = "Sentence";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(272, 51);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(62, 13);
            label3.TabIndex = 12;
            label3.Text = "Whole Text";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            groupBox1.Controls.Add(this.lblGran);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(this.tBarGran);
            groupBox1.Location = new System.Drawing.Point(195, 378);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(336, 71);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Granulairty";
            // 
            // lblGran
            // 
            this.lblGran.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGran.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGran.Location = new System.Drawing.Point(131, 48);
            this.lblGran.Name = "lblGran";
            this.lblGran.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lblGran.Size = new System.Drawing.Size(71, 16);
            this.lblGran.TabIndex = 13;
            this.lblGran.Text = "1 Sentence";
            this.lblGran.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tBarGran
            // 
            this.tBarGran.LargeChange = 2;
            this.tBarGran.Location = new System.Drawing.Point(6, 19);
            this.tBarGran.Name = "tBarGran";
            this.tBarGran.Size = new System.Drawing.Size(328, 45);
            this.tBarGran.TabIndex = 9;
            this.tBarGran.ValueChanged += new System.EventHandler(this.TBarGran_ValueChanged);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnLoad.Location = new System.Drawing.Point(12, 390);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(75, 52);
            this.BtnLoad.TabIndex = 0;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(697, 390);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 52);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.BtnProcess_Click);
            // 
            // bgWkrProcess
            // 
            this.bgWkrProcess.WorkerReportsProgress = true;
            this.bgWkrProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWkrProcess_DoWork);
            this.bgWkrProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgWkrProcess_ProgressChanged);
            this.bgWkrProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWkrProcess_RunWorkerCompleted);
            // 
            // picLoading
            // 
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(3, 3);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(200, 200);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 6;
            this.picLoading.TabStop = false;
            // 
            // panLoading
            // 
            this.panLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panLoading.Controls.Add(this.panel1);
            this.panLoading.Controls.Add(this.picLoading);
            this.panLoading.Location = new System.Drawing.Point(300, 76);
            this.panLoading.Name = "panLoading";
            this.panLoading.Size = new System.Drawing.Size(206, 236);
            this.panLoading.TabIndex = 7;
            this.panLoading.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLoading);
            this.panel1.Location = new System.Drawing.Point(4, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 23);
            this.panel1.TabIndex = 8;
            // 
            // lblLoading
            // 
            this.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoading.Location = new System.Drawing.Point(0, 0);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(199, 23);
            this.lblLoading.TabIndex = 7;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bgWkrLoad
            // 
            this.bgWkrLoad.WorkerReportsProgress = true;
            this.bgWkrLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWkrLoad_DoWork);
            this.bgWkrLoad.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgWkrLoad_ProgressChanged);
            this.bgWkrLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWkrLoad_RunWorkerCompleted);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtInput);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 360);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text";
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(6, 19);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(748, 335);
            this.txtInput.TabIndex = 2;
            // 
            // SentiPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(groupBox1);
            this.Controls.Add(this.panLoading);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "SentiPlot";
            this.Text = "SentiPlot";
            this.Load += new System.EventHandler(this.Form1_Load);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarGran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.panLoading.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Button btnProcess;
        private System.ComponentModel.BackgroundWorker bgWkrProcess;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Panel panLoading;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar tBarGran;
        private System.Windows.Forms.Label lblGran;
        private System.ComponentModel.BackgroundWorker bgWkrLoad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtInput;
    }
}

