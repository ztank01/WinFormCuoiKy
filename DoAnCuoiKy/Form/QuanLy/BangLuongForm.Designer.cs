
namespace DoAnCuoiKy
{
    partial class BangLuongForm
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
            this.bangLuongDGV = new System.Windows.Forms.DataGridView();
            this.xuatFileBt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bangLuongDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bangLuongDGV
            // 
            this.bangLuongDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bangLuongDGV.Location = new System.Drawing.Point(12, 12);
            this.bangLuongDGV.Name = "bangLuongDGV";
            this.bangLuongDGV.RowHeadersWidth = 51;
            this.bangLuongDGV.RowTemplate.Height = 24;
            this.bangLuongDGV.Size = new System.Drawing.Size(776, 358);
            this.bangLuongDGV.TabIndex = 0;
            // 
            // xuatFileBt
            // 
            this.xuatFileBt.AutoSize = true;
            this.xuatFileBt.BackColor = System.Drawing.Color.Lime;
            this.xuatFileBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuatFileBt.Location = new System.Drawing.Point(12, 390);
            this.xuatFileBt.Name = "xuatFileBt";
            this.xuatFileBt.Size = new System.Drawing.Size(121, 35);
            this.xuatFileBt.TabIndex = 1;
            this.xuatFileBt.Text = "Xuất ra File";
            this.xuatFileBt.UseVisualStyleBackColor = false;
            this.xuatFileBt.Click += new System.EventHandler(this.xuatFileBt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(634, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đơn vị thời gian: giờ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đơn vị tiền: nghìn đồng";
            // 
            // BangLuongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xuatFileBt);
            this.Controls.Add(this.bangLuongDGV);
            this.Name = "BangLuongForm";
            this.Text = "BangLuongForm";
            this.Load += new System.EventHandler(this.BangLuongForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bangLuongDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView bangLuongDGV;
        private System.Windows.Forms.Button xuatFileBt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}