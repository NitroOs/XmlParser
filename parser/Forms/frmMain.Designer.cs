namespace Parser.Forms
{
    partial class frmMain
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
            this.btnOverview = new System.Windows.Forms.Button();
            this.btnPars = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOverview
            // 
            this.btnOverview.Location = new System.Drawing.Point(12, 42);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Size = new System.Drawing.Size(75, 23);
            this.btnOverview.TabIndex = 3;
            this.btnOverview.Text = "Pregled";
            this.btnOverview.UseVisualStyleBackColor = true;
            // 
            // btnPars
            // 
            this.btnPars.Location = new System.Drawing.Point(12, 12);
            this.btnPars.Name = "btnPars";
            this.btnPars.Size = new System.Drawing.Size(75, 23);
            this.btnPars.TabIndex = 2;
            this.btnPars.Text = "Parser";
            this.btnPars.UseVisualStyleBackColor = true;
            this.btnPars.Click += new System.EventHandler(this.btnPars_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnOverview);
            this.Controls.Add(this.btnPars);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Parser v0.1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Button btnPars;
    }
}