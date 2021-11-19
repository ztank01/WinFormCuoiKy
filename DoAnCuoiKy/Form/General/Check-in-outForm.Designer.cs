
namespace DoAnCuoiKy
{
    partial class Check_in_outForm
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
            this.checkinBt = new System.Windows.Forms.Button();
            this.checkoutBt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.welcomeLb = new System.Windows.Forms.Label();
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.shiftLb = new System.Windows.Forms.Label();
            this.caLamViecDGV = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caLamViecDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // checkinBt
            // 
            this.checkinBt.AutoSize = true;
            this.checkinBt.BackColor = System.Drawing.Color.Lime;
            this.checkinBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkinBt.Location = new System.Drawing.Point(15, 344);
            this.checkinBt.Name = "checkinBt";
            this.checkinBt.Size = new System.Drawing.Size(160, 49);
            this.checkinBt.TabIndex = 0;
            this.checkinBt.Text = "Check in";
            this.checkinBt.UseVisualStyleBackColor = false;
            this.checkinBt.Click += new System.EventHandler(this.checkinBt_Click);
            // 
            // checkoutBt
            // 
            this.checkoutBt.AutoSize = true;
            this.checkoutBt.BackColor = System.Drawing.Color.OrangeRed;
            this.checkoutBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkoutBt.Location = new System.Drawing.Point(585, 344);
            this.checkoutBt.Name = "checkoutBt";
            this.checkoutBt.Size = new System.Drawing.Size(180, 49);
            this.checkoutBt.TabIndex = 1;
            this.checkoutBt.Text = "Check out";
            this.checkoutBt.UseVisualStyleBackColor = false;
            this.checkoutBt.Click += new System.EventHandler(this.checkoutBt_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightYellow;
            this.panel1.Controls.Add(this.welcomeLb);
            this.panel1.Controls.Add(this.imgBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 92);
            this.panel1.TabIndex = 3;
            // 
            // welcomeLb
            // 
            this.welcomeLb.AutoSize = true;
            this.welcomeLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLb.Location = new System.Drawing.Point(85, 64);
            this.welcomeLb.Name = "welcomeLb";
            this.welcomeLb.Size = new System.Drawing.Size(70, 17);
            this.welcomeLb.TabIndex = 1;
            this.welcomeLb.Text = "Welcome ";
            // 
            // imgBox
            // 
            this.imgBox.BackColor = System.Drawing.Color.SlateGray;
            this.imgBox.Location = new System.Drawing.Point(3, 3);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(76, 78);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBox.TabIndex = 0;
            this.imgBox.TabStop = false;
            // 
            // shiftLb
            // 
            this.shiftLb.AutoSize = true;
            this.shiftLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shiftLb.Location = new System.Drawing.Point(189, 124);
            this.shiftLb.Name = "shiftLb";
            this.shiftLb.Size = new System.Drawing.Size(181, 38);
            this.shiftLb.TabIndex = 4;
            this.shiftLb.Text = "Ca hiện tại:";
            // 
            // caLamViecDGV
            // 
            this.caLamViecDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.caLamViecDGV.Location = new System.Drawing.Point(15, 177);
            this.caLamViecDGV.Name = "caLamViecDGV";
            this.caLamViecDGV.RowHeadersWidth = 51;
            this.caLamViecDGV.RowTemplate.Height = 24;
            this.caLamViecDGV.Size = new System.Drawing.Size(750, 161);
            this.caLamViecDGV.TabIndex = 5;
            // 
            // Check_in_outForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(783, 411);
            this.Controls.Add(this.caLamViecDGV);
            this.Controls.Add(this.shiftLb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkoutBt);
            this.Controls.Add(this.checkinBt);
            this.Name = "Check_in_outForm";
            this.Text = "Check_in_outForm";
            this.Load += new System.EventHandler(this.Check_in_outForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caLamViecDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkinBt;
        private System.Windows.Forms.Button checkoutBt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label welcomeLb;
        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.Label shiftLb;
        private System.Windows.Forms.DataGridView caLamViecDGV;
    }
}