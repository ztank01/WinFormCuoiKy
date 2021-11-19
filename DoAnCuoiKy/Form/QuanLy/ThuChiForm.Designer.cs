
namespace DoAnCuoiKy
{
    partial class ThuChiForm
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
            this.tinhTienLuongBt = new System.Windows.Forms.Button();
            this.xemKhoanThuBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tinhTienLuongBt
            // 
            this.tinhTienLuongBt.AutoSize = true;
            this.tinhTienLuongBt.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tinhTienLuongBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhTienLuongBt.Location = new System.Drawing.Point(12, 12);
            this.tinhTienLuongBt.Name = "tinhTienLuongBt";
            this.tinhTienLuongBt.Size = new System.Drawing.Size(165, 35);
            this.tinhTienLuongBt.TabIndex = 0;
            this.tinhTienLuongBt.Text = "Tính Tiền Lương";
            this.tinhTienLuongBt.UseVisualStyleBackColor = false;
            this.tinhTienLuongBt.Click += new System.EventHandler(this.tinhTienLuongBt_Click);
            // 
            // xemKhoanThuBt
            // 
            this.xemKhoanThuBt.AutoSize = true;
            this.xemKhoanThuBt.BackColor = System.Drawing.Color.Gold;
            this.xemKhoanThuBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemKhoanThuBt.Location = new System.Drawing.Point(12, 70);
            this.xemKhoanThuBt.Name = "xemKhoanThuBt";
            this.xemKhoanThuBt.Size = new System.Drawing.Size(315, 35);
            this.xemKhoanThuBt.TabIndex = 1;
            this.xemKhoanThuBt.Text = "Xem Các Khoản Thu Trong Ngày";
            this.xemKhoanThuBt.UseVisualStyleBackColor = false;
            this.xemKhoanThuBt.Click += new System.EventHandler(this.xemKhoanThuBt_Click);
            // 
            // ThuChiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(410, 312);
            this.Controls.Add(this.xemKhoanThuBt);
            this.Controls.Add(this.tinhTienLuongBt);
            this.Name = "ThuChiForm";
            this.Text = "ThuChiForm";
            this.Load += new System.EventHandler(this.ThuChiForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tinhTienLuongBt;
        private System.Windows.Forms.Button xemKhoanThuBt;
    }
}