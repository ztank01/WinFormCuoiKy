
namespace DoAnCuoiKy
{
    partial class ChinhSuaThongTinPhong
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
            this.hangCbB = new System.Windows.Forms.ComboBox();
            this.editBt = new System.Windows.Forms.Button();
            this.cancelBt = new System.Windows.Forms.Button();
            this.giaTb = new System.Windows.Forms.TextBox();
            this.idTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hangCbB
            // 
            this.hangCbB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hangCbB.FormattingEnabled = true;
            this.hangCbB.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.hangCbB.Location = new System.Drawing.Point(204, 85);
            this.hangCbB.Name = "hangCbB";
            this.hangCbB.Size = new System.Drawing.Size(63, 33);
            this.hangCbB.TabIndex = 16;
            this.hangCbB.SelectedValueChanged += new System.EventHandler(this.hangCbB_SelectedValueChanged);
            // 
            // editBt
            // 
            this.editBt.AutoSize = true;
            this.editBt.BackColor = System.Drawing.Color.Aqua;
            this.editBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBt.Location = new System.Drawing.Point(209, 221);
            this.editBt.Name = "editBt";
            this.editBt.Size = new System.Drawing.Size(146, 63);
            this.editBt.TabIndex = 15;
            this.editBt.Text = "Edit";
            this.editBt.UseVisualStyleBackColor = false;
            this.editBt.Click += new System.EventHandler(this.editBt_Click);
            // 
            // cancelBt
            // 
            this.cancelBt.AutoSize = true;
            this.cancelBt.BackColor = System.Drawing.Color.OrangeRed;
            this.cancelBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBt.Location = new System.Drawing.Point(17, 221);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(146, 63);
            this.cancelBt.TabIndex = 14;
            this.cancelBt.Text = "Cancel";
            this.cancelBt.UseVisualStyleBackColor = false;
            this.cancelBt.Click += new System.EventHandler(this.cancelBt_Click);
            // 
            // giaTb
            // 
            this.giaTb.Enabled = false;
            this.giaTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaTb.Location = new System.Drawing.Point(204, 167);
            this.giaTb.Name = "giaTb";
            this.giaTb.Size = new System.Drawing.Size(151, 30);
            this.giaTb.TabIndex = 13;
            // 
            // idTb
            // 
            this.idTb.Enabled = false;
            this.idTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTb.Location = new System.Drawing.Point(204, 8);
            this.idTb.Name = "idTb";
            this.idTb.Size = new System.Drawing.Size(100, 30);
            this.idTb.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "Giá 1 ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hạng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "ID Phòng:";
            // 
            // selectBt
            // 
            this.selectBt.Location = new System.Drawing.Point(310, 8);
            this.selectBt.Name = "selectBt";
            this.selectBt.Size = new System.Drawing.Size(75, 23);
            this.selectBt.TabIndex = 17;
            this.selectBt.Text = "Select";
            this.selectBt.UseVisualStyleBackColor = true;
            this.selectBt.Click += new System.EventHandler(this.selectBt_Click);
            // 
            // ChinhSuaThongTinPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(402, 349);
            this.Controls.Add(this.selectBt);
            this.Controls.Add(this.hangCbB);
            this.Controls.Add(this.editBt);
            this.Controls.Add(this.cancelBt);
            this.Controls.Add(this.giaTb);
            this.Controls.Add(this.idTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChinhSuaThongTinPhong";
            this.Text = "ChinhSuaThongTinPhong";
            this.Load += new System.EventHandler(this.ChinhSuaThongTinPhong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox hangCbB;
        private System.Windows.Forms.Button editBt;
        private System.Windows.Forms.Button cancelBt;
        private System.Windows.Forms.TextBox giaTb;
        private System.Windows.Forms.TextBox idTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectBt;
    }
}