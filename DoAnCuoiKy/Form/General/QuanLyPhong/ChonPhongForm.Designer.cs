﻿
namespace DoAnCuoiKy
{
    partial class ChonPhongForm
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
            this.roomListDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.roomListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // roomListDGV
            // 
            this.roomListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomListDGV.Location = new System.Drawing.Point(12, 12);
            this.roomListDGV.Name = "roomListDGV";
            this.roomListDGV.RowHeadersWidth = 51;
            this.roomListDGV.RowTemplate.Height = 24;
            this.roomListDGV.Size = new System.Drawing.Size(513, 426);
            this.roomListDGV.TabIndex = 0;
            this.roomListDGV.DoubleClick += new System.EventHandler(this.roomListDGV_DoubleClick);
            // 
            // ChonPhongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 450);
            this.Controls.Add(this.roomListDGV);
            this.Name = "ChonPhongForm";
            this.Text = "ChonPhongForm";
            this.Load += new System.EventHandler(this.ChonPhongForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView roomListDGV;
    }
}