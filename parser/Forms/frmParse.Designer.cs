﻿namespace Parser.Forms
{
    partial class frmParse
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this._id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._sport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tournament = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._copm1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._comp2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnParse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._id,
            this._sport,
            this._category,
            this._tournament,
            this._copm1,
            this._comp2});
            this.dgv.Location = new System.Drawing.Point(12, 40);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(680, 390);
            this.dgv.TabIndex = 14;
            // 
            // _id
            // 
            this._id.DataPropertyName = "id";
            this._id.HeaderText = "id";
            this._id.Name = "_id";
            this._id.ReadOnly = true;
            this._id.Visible = false;
            // 
            // _sport
            // 
            this._sport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._sport.DataPropertyName = "sport";
            this._sport.HeaderText = "Sport";
            this._sport.Name = "_sport";
            this._sport.ReadOnly = true;
            // 
            // _category
            // 
            this._category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._category.DataPropertyName = "category";
            this._category.HeaderText = "Category";
            this._category.Name = "_category";
            this._category.ReadOnly = true;
            // 
            // _tournament
            // 
            this._tournament.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._tournament.DataPropertyName = "tournament";
            this._tournament.HeaderText = "Tournament";
            this._tournament.Name = "_tournament";
            this._tournament.ReadOnly = true;
            // 
            // _copm1
            // 
            this._copm1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._copm1.DataPropertyName = "comp1";
            this._copm1.HeaderText = "Comp1";
            this._copm1.Name = "_copm1";
            this._copm1.ReadOnly = true;
            // 
            // _comp2
            // 
            this._comp2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._comp2.DataPropertyName = "comp2";
            this._comp2.HeaderText = "Comp2";
            this._comp2.Name = "_comp2";
            this._comp2.ReadOnly = true;
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(505, 9);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(101, 27);
            this.btnParse.TabIndex = 13;
            this.btnParse.Text = "Parse file";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(43, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(349, 22);
            this.txtFile.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "File:";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(398, 9);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(101, 27);
            this.btnOpen.TabIndex = 10;
            this.btnOpen.Text = "Open file";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // frmParse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmParse";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parsiranje datoteke";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn _id;
        private System.Windows.Forms.DataGridViewTextBoxColumn _sport;
        private System.Windows.Forms.DataGridViewTextBoxColumn _category;
        private System.Windows.Forms.DataGridViewTextBoxColumn _tournament;
        private System.Windows.Forms.DataGridViewTextBoxColumn _copm1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _comp2;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
    }
}