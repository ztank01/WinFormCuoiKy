
namespace DoAnCuoiKy
{
    partial class DanhSachKhach
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
            this.customerListDGV = new System.Windows.Forms.DataGridView();
            this.daXemBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // customerListDGV
            // 
            this.customerListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerListDGV.Location = new System.Drawing.Point(12, 12);
            this.customerListDGV.Name = "customerListDGV";
            this.customerListDGV.RowHeadersWidth = 51;
            this.customerListDGV.RowTemplate.Height = 24;
            this.customerListDGV.Size = new System.Drawing.Size(1518, 426);
            this.customerListDGV.TabIndex = 2;
            // 
            // daXemBt
            // 
            this.daXemBt.BackColor = System.Drawing.Color.Lime;
            this.daXemBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daXemBt.Location = new System.Drawing.Point(677, 444);
            this.daXemBt.Name = "daXemBt";
            this.daXemBt.Size = new System.Drawing.Size(206, 32);
            this.daXemBt.TabIndex = 3;
            this.daXemBt.Text = "Đã Xem";
            this.daXemBt.UseVisualStyleBackColor = false;
            this.daXemBt.Click += new System.EventHandler(this.daXemBt_Click);
            // 
            // DanhSachKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 488);
            this.Controls.Add(this.daXemBt);
            this.Controls.Add(this.customerListDGV);
            this.Name = "DanhSachKhach";
            this.Text = "DanhSachKhach";
            this.Load += new System.EventHandler(this.DanhSachKhach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customerListDGV;
        private System.Windows.Forms.Button daXemBt;
    }
}