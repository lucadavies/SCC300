namespace SCC300cs
{
    partial class Form1
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
            this.BtnLoad = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnTokenize = new System.Windows.Forms.Button();
            this.btnLem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(12, 415);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(75, 23);
            this.BtnLoad.TabIndex = 0;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(776, 397);
            this.txtInput.TabIndex = 1;
            // 
            // btnTokenize
            // 
            this.btnTokenize.Location = new System.Drawing.Point(93, 415);
            this.btnTokenize.Name = "btnTokenize";
            this.btnTokenize.Size = new System.Drawing.Size(75, 23);
            this.btnTokenize.TabIndex = 2;
            this.btnTokenize.Text = "Tokenize";
            this.btnTokenize.UseVisualStyleBackColor = true;
            this.btnTokenize.Click += new System.EventHandler(this.BtnTokenize_Click);
            // 
            // btnLem
            // 
            this.btnLem.Location = new System.Drawing.Point(174, 415);
            this.btnLem.Name = "btnLem";
            this.btnLem.Size = new System.Drawing.Size(75, 23);
            this.btnLem.TabIndex = 3;
            this.btnLem.Text = "Lemmatize";
            this.btnLem.UseVisualStyleBackColor = true;
            this.btnLem.Click += new System.EventHandler(this.btnLem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLem);
            this.Controls.Add(this.btnTokenize);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.BtnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnTokenize;
        private System.Windows.Forms.Button btnLem;
    }
}

