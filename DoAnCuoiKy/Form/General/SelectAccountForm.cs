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
    public partial class SelectAccountForm : Form
    {
        public SelectAccountForm()
        {
            InitializeComponent();
        }
        Account account = new Account();
        private void employeeListDGV_DoubleClick(object sender, EventArgs e)
        {
            Globals.SelectedID = int.Parse(employeeListDGV.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }

        private void SelectAccountForm_Load(object sender, EventArgs e)
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
    }
}
