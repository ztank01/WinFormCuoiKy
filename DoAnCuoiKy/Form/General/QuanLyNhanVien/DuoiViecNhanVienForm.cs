using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class DuoiViecNhanVienForm : Form
    {
        public DuoiViecNhanVienForm()
        {
            InitializeComponent();
        }
        Account account = new Account();
        private void DuoiViecNhanVienForm_Load(object sender, EventArgs e)
        {
            string where_clause = "";
            if (Globals.role.Contains("TiepTan"))
            {
                where_clause = "WHERE role = 'LaoCong'";
            }
            else
            {
                if (Globals.role.Contains("QuanLy"))
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
        }

        private void removeBt_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(idTb.Text,out id))
            {
                if (MessageBox.Show("Thao tac nay se xoa lich lam viec hien tai, Ban chac chu", "Duoi Viec nhan vien",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (account.deleteEmployee(id))
                    {
                        MessageBox.Show("Employee Removed", "Duoi Viec nhan vien");
                        this.DuoiViecNhanVienForm_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Something Wrong", "Duoi Viec nhan vien");
                    }
                }
            }
            else
            {
                MessageBox.Show("Plese Choose Employee You Want To Fire","Duoi Viec Nhan Vien");
            }
        }
    }
}
