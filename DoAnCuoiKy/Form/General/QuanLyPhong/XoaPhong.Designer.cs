
namespace DoAnCuoiKy
{
    partial class XoaPhong
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
            this.removeBt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.idTb = new System.Windows.Forms.TextBox();
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
            this.roomListDGV.TabIndex = 1;
            this.roomListDGV.DoubleClick += new System.EventHandler(this.roomListDGV_DoubleClick);
            // 
            // removeBt
            // 
            this.removeBt.AutoSize = true;
            this.removeBt.BackColor = System.Drawing.Color.OrangeRed;
            this.removeBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeBt.Location = new System.Drawing.Point(153, 480);
            this.removeBt.Name = "removeBt";
            this.removeBt.Size = new System.Drawing.Size(232, 56);
            this.removeBt.TabIndex = 2;
            this.removeBt.Text = "Remove";
            this.removeBt.UseVisualStyleBackColor = false;
            this.removeBt.Click += new System.EventHandler(this.removeBt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selected ID:";
            // 
            // idTb
            // 
            this.idTb.BackColor = System.Drawing.SystemColors.Window;
            this.idTb.Enabled = false;
            this.idTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTb.Location = new System.Drawing.Point(298, 444);
            this.idTb.Name = "idTb";
            this.idTb.Size = new System.Drawing.Size(69, 27);
            this.idTb.TabIndex = 4;
            // 
            // XoaPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 548);
            this.Controls.Add(this.idTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeBt);
            this.Controls.Add(this.roomListDGV);
            this.Name = "XoaPhong";
            this.Text = "XoaPhong";
            this.Load += new System.EventHandler(this.XoaPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView roomListDGV;
        private System.Windows.Forms.Button removeBt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idTb;
    }
}