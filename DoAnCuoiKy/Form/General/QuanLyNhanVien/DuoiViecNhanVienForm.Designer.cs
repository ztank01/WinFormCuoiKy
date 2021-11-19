
namespace DoAnCuoiKy
{
    partial class DuoiViecNhanVienForm
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
            this.employeeListDGV = new System.Windows.Forms.DataGridView();
            this.removeBt = new System.Windows.Forms.Button();
            this.idTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.employeeListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeListDGV
            // 
            this.employeeListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeListDGV.Location = new System.Drawing.Point(12, 12);
            this.employeeListDGV.Name = "employeeListDGV";
            this.employeeListDGV.RowHeadersWidth = 51;
            this.employeeListDGV.RowTemplate.Height = 24;
            this.employeeListDGV.Size = new System.Drawing.Size(1145, 628);
            this.employeeListDGV.TabIndex = 1;
            this.employeeListDGV.Click += new System.EventHandler(this.employeeListDGV_Click);
            // 
            // removeBt
            // 
            this.removeBt.AutoSize = true;
            this.removeBt.BackColor = System.Drawing.Color.OrangeRed;
            this.removeBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeBt.Location = new System.Drawing.Point(507, 689);
            this.removeBt.Name = "removeBt";
            this.removeBt.Size = new System.Drawing.Size(148, 46);
            this.removeBt.TabIndex = 35;
            this.removeBt.Text = "Remove";
            this.removeBt.UseVisualStyleBackColor = false;
            this.removeBt.Click += new System.EventHandler(this.removeBt_Click);
            // 
            // idTb
            // 
            this.idTb.Enabled = false;
            this.idTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTb.Location = new System.Drawing.Point(594, 646);
            this.idTb.Name = "idTb";
            this.idTb.Size = new System.Drawing.Size(100, 28);
            this.idTb.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(441, 649);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 36;
            this.label1.Text = "Selected ID:";
            // 
            // DuoiViecNhanVienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 747);
            this.Controls.Add(this.idTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeBt);
            this.Controls.Add(this.employeeListDGV);
            this.Name = "DuoiViecNhanVienForm";
            this.Text = "DuoiViecNhanVienForm";
            this.Load += new System.EventHandler(this.DuoiViecNhanVienForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView employeeListDGV;
        private System.Windows.Forms.Button removeBt;
        private System.Windows.Forms.TextBox idTb;
        private System.Windows.Forms.Label label1;
    }
}