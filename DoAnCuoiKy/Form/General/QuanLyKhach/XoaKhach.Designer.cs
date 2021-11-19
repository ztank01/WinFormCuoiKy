
namespace DoAnCuoiKy
{
    partial class XoaKhach
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
            this.label1 = new System.Windows.Forms.Label();
            this.idTb = new System.Windows.Forms.TextBox();
            this.removeBt = new System.Windows.Forms.Button();
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
            this.customerListDGV.TabIndex = 1;
            this.customerListDGV.Click += new System.EventHandler(this.customerListDGV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selected ID:";
            // 
            // idTb
            // 
            this.idTb.Enabled = false;
            this.idTb.Location = new System.Drawing.Point(713, 447);
            this.idTb.Name = "idTb";
            this.idTb.Size = new System.Drawing.Size(172, 22);
            this.idTb.TabIndex = 3;
            // 
            // removeBt
            // 
            this.removeBt.AutoSize = true;
            this.removeBt.BackColor = System.Drawing.Color.OrangeRed;
            this.removeBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeBt.Location = new System.Drawing.Point(713, 475);
            this.removeBt.Name = "removeBt";
            this.removeBt.Size = new System.Drawing.Size(113, 39);
            this.removeBt.TabIndex = 4;
            this.removeBt.Text = "Remove";
            this.removeBt.UseVisualStyleBackColor = false;
            this.removeBt.Click += new System.EventHandler(this.removeBt_Click);
            // 
            // XoaKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 519);
            this.Controls.Add(this.removeBt);
            this.Controls.Add(this.idTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerListDGV);
            this.Name = "XoaKhach";
            this.Text = "XoaKhach";
            this.Load += new System.EventHandler(this.XoaKhach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerListDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idTb;
        private System.Windows.Forms.Button removeBt;
    }
}