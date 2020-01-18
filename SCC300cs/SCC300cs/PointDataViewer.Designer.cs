namespace SCC300cs
{
    partial class PointDataViewer
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
            this.dgvSenti = new System.Windows.Forms.DataGridView();
            this.colNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTxt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSenti)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSenti
            // 
            this.dgvSenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNum,
            this.colScore,
            this.colTxt});
            this.dgvSenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSenti.Location = new System.Drawing.Point(0, 0);
            this.dgvSenti.Name = "dgvSenti";
            this.dgvSenti.Size = new System.Drawing.Size(800, 450);
            this.dgvSenti.TabIndex = 0;
            // 
            // colNum
            // 
            this.colNum.HeaderText = "Num";
            this.colNum.Name = "colNum";
            // 
            // colScore
            // 
            this.colScore.HeaderText = "Score";
            this.colScore.Name = "colScore";
            // 
            // colTxt
            // 
            this.colTxt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTxt.HeaderText = "Text";
            this.colTxt.Name = "colTxt";
            // 
            // PointDataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSenti);
            this.Name = "PointDataViewer";
            this.Text = "PointDataViewer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSenti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTxt;
    }
}