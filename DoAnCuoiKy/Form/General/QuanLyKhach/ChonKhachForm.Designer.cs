
namespace DoAnCuoiKy
{
    partial class ChonKhachForm
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
            this.customerListDGV.TabIndex = 0;
            this.customerListDGV.DoubleClick += new System.EventHandler(this.customerDGV_DoubleClick);
            // 
            // ChonKhachForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 450);
            this.Controls.Add(this.customerListDGV);
            this.Name = "ChonKhachForm";
            this.Text = "ChonKhachForm";
            this.Load += new System.EventHandler(this.ChonKhachForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customerListDGV;
    }
}