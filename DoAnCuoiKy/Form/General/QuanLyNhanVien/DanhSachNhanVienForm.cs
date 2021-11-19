using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class DanhSachNhanVienForm : Form
    {
        public DanhSachNhanVienForm()
        {
            InitializeComponent();
        }
        Account account = new Account();
        private void DanhSachNhanVienForm_Load(object sender, EventArgs e)
        {
            if (Globals.role.Contains("QuanLy"))
            {
                tieptanRBt.Visible = true;
            }
            string where_clause = "";
            if (Globals.role.Contains("TiepTan"))
            {
                where_clause = "WHERE role = 'LaoCong'";
            }
            else
            {
                if (Globals.role.Contains("QuanLy") )
                {
                    where_clause = "WHERE role = 'LaoCong' OR role = 'TiepTan'";
                }
            }
            //Dinh dang DataGridView
            employeeListDGV.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            employeeListDGV.RowTemplate.Height = 80;
            employeeListDGV.DataSource = account.getEmployeeList(where_clause);
            picCol = (DataGridViewImageColumn)employeeListDGV.Columns[9];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            employeeListDGV.AllowUserToAddRows = false;
            employeeListDGV.Columns[0].HeaderText = "Employee ID";
            employeeListDGV.Columns[1].HeaderText = "User Name";
            employeeListDGV.Columns[2].HeaderText = "Password";
            employeeListDGV.Columns[3].HeaderText = "Role";
            employeeListDGV.Columns[4].HeaderText = "First Name";
            employeeListDGV.Columns[5].HeaderText = "Last Name";
            employeeListDGV.Columns[6].HeaderText = "Email";
            employeeListDGV.Columns[7].HeaderText = "Phone";
            employeeListDGV.Columns[8].HeaderText = "Address";
            employeeListDGV.Columns[9].HeaderText = "Picture";
            
        }

        private void employeeListDGV_Click(object sender, EventArgs e)
        {
            idTb.Text = employeeListDGV.CurrentRow.Cells[0].Value.ToString();
            usernameTb.Text = employeeListDGV.CurrentRow.Cells[1].Value.ToString();
            passwordTb.Text = employeeListDGV.CurrentRow.Cells[2].Value.ToString();
            fnameTb.Text = employeeListDGV.CurrentRow.Cells[4].Value.ToString();
            lnameTb.Text = employeeListDGV.CurrentRow.Cells[5].Value.ToString();
            emailTb.Text = employeeListDGV.CurrentRow.Cells[6].Value.ToString();
            phoneTb.Text = employeeListDGV.CurrentRow.Cells[7].Value.ToString();
            addressTb.Text = employeeListDGV.CurrentRow.Cells[8].Value.ToString();
            string role = employeeListDGV.CurrentRow.Cells[3].Value.ToString();
            if(role.Contains("TiepTan"))
            {
                tieptanRBt.Checked = true;
            }
            else
            {
                laocongRBt.Checked = true;
            }
            byte[] pic = (byte[])employeeListDGV.CurrentRow.Cells[9].Value;
            MemoryStream picture = new MemoryStream(pic);
            imgBox.Image = Image.FromStream(picture);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (verified())
            {
                int id = int.Parse(idTb.Text);
                if ( tieptanRBt.Checked || laocongRBt.Checked)
                {
                    string role = "";
                    if (tieptanRBt.Checked)
                    {
                        role = "TiepTan";
                    }
                    else
                    {
                        role = "LaoCong";
                    }
                    MemoryStream pic = new MemoryStream();
                    imgBox.Image.Save(pic, imgBox.Image.RawFormat);
                    if (MessageBox.Show("Thao tac nay se xoa lich lam viec hien tai, Ban chac chu", "Chinh sua thong tin nhan vien",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (account.updateEmployee(id, usernameTb.Text, passwordTb.Text,
                        role, fnameTb.Text, lnameTb.Text, emailTb.Text, phoneTb.Text, addressTb.Text, pic))
                        {
                            MessageBox.Show("Employee Edited", "Chinh sua thong tin nhan vien");
                            this.DanhSachNhanVienForm_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Something Wrong", "Chinh sua thong tin nhan vien");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Choose Employee's Role", "Chinh sua thong tin nhan vien");
                }
            }
            else
            {
                MessageBox.Show("Please Enter All Fields", "Chinh sua thong tin nhan vien");
            }
        }
        bool verified()
        {
            if ((fnameTb.Text.Trim() == "")
                || (lnameTb.Text.Trim() == "")
                || (phoneTb.Text.Trim() == "")
                || (emailTb.Text.Trim() == "")
                || (addressTb.Text.Trim() == "")
                || (usernameTb.Text.Trim() == "")
                || (passwordTb.Text.Trim() == "")
                || imgBox.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void removeBt_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(idTb.Text, out id))
            {
                if (MessageBox.Show("Thao tac nay se xoa lich lam viec hien tai, Ban chac chu", "Duoi Viec nhan vien",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (account.deleteEmployee(id))
                    {
                        MessageBox.Show("Employee Removed", "Duoi Viec nhan vien");
                        this.DanhSachNhanVienForm_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Something Wrong", "Duoi Viec nhan vien");
                    }
                }
            }
            else
            {
                MessageBox.Show("Plese Choose Employee You Want To Fire or Enter A Valid ID", "Duoi Viec Nhan Vien");
            }
        }

        private void addBt_Click(object sender, EventArgs e)
        {
            if (verified())
            {
                int id = int.Parse(idTb.Text);
                if ( tieptanRBt.Checked || laocongRBt.Checked)
                {
                    string role = "";
                    if (tieptanRBt.Checked)
                    {
                        role = "TiepTan";
                    }
                    else
                    {
                        role = "LaoCong";
                    }
                    MemoryStream pic = new MemoryStream();
                    imgBox.Image.Save(pic, imgBox.Image.RawFormat);
                    if (MessageBox.Show("Thao tac nay se xoa lich lam viec hien tai, Ban chac chu", "Them nhan vien",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (account.insertEmployee(id, usernameTb.Text, passwordTb.Text,
                            role, fnameTb.Text, lnameTb.Text, emailTb.Text, phoneTb.Text, addressTb.Text, pic))
                        {
                            MessageBox.Show("Employee Added", "Them Nhan Vien");
                            this.DanhSachNhanVienForm_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Something Wrong", "Them Nhan Vien");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Choose Employee's Role", "Them Nhan Vien");
                }
            }
            else
            {
                MessageBox.Show("Please Enter All Fields", "Them Nhan Vien");
            }
        }
    }
}
