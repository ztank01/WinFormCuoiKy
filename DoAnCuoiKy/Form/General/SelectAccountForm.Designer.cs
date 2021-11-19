
namespace DoAnCuoiKy
{
    partial class SelectAccountForm
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
            this.employeeListDGV.DoubleClick += new System.EventHandler(this.employeeListDGV_DoubleClick);
            // 
            // SelectAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 653);
            this.Controls.Add(this.employeeListDGV);
            this.Name = "SelectAccountForm";
            this.Text = "SelectAccountForm";
            this.Load += new System.EventHandler(this.SelectAccountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView employeeListDGV;
    }
}