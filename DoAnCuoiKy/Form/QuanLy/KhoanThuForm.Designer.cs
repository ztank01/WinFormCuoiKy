
namespace DoAnCuoiKy
{
    partial class KhoanThuForm
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
            this.xuatFileBt = new System.Windows.Forms.Button();
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
            this.customerListDGV.Size = new System.Drawing.Size(1528, 542);
            this.customerListDGV.TabIndex = 0;
            // 
            // xuatFileBt
            // 
            this.xuatFileBt.AutoSize = true;
            this.xuatFileBt.BackColor = System.Drawing.Color.Lime;
            this.xuatFileBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuatFileBt.Location = new System.Drawing.Point(45, 564);
            this.xuatFileBt.Name = "xuatFileBt";
            this.xuatFileBt.Size = new System.Drawing.Size(99, 35);
            this.xuatFileBt.TabIndex = 1;
            this.xuatFileBt.Text = "Xuất File";
            this.xuatFileBt.UseVisualStyleBackColor = false;
            this.xuatFileBt.Click += new System.EventHandler(this.xuatFileBt_Click);
            // 
            // KhoanThuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 613);
            this.Controls.Add(this.xuatFileBt);
            this.Controls.Add(this.customerListDGV);
            this.Name = "KhoanThuForm";
            this.Text = "KhoanThuForm";
            this.Load += new System.EventHandler(this.KhoanThuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerListDGV;
        private System.Windows.Forms.Button xuatFileBt;
    }
}