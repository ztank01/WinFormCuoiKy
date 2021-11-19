using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAnCuoiKy
{
    public partial class ChonKhachForm : Form
    {
        public ChonKhachForm()
        {
            InitializeComponent();
        }
        mydb db = new mydb();
        private void ChonKhachForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Khach", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            customerListDGV.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            customerListDGV.RowTemplate.Height = 80;
            customerListDGV.DataSource = table;
            picCol = (DataGridViewImageColumn)customerListDGV.Columns[5];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            customerListDGV.AllowUserToAddRows = false;
            customerListDGV.Columns[0].HeaderText = "Customer ID";
            customerListDGV.Columns[1].HeaderText = "First Name";
            customerListDGV.Columns[2].HeaderText = "Last Name";
            customerListDGV.Columns[3].HeaderText = "Gender";
            customerListDGV.Columns[4].HeaderText = "Phone";
            customerListDGV.Columns[5].HeaderText = "Picture";
            customerListDGV.Columns[6].HeaderText = "Ngày đến";
            customerListDGV.Columns[7].HeaderText = "Ngày đi";
            customerListDGV.Columns[8].HeaderText = "Phòng";
            customerListDGV.Columns[9].HeaderText = "Đã thanh toán";

        }

        private void customerDGV_DoubleClick(object sender, EventArgs e)
        {
            Globals.SelectedID_Khach = int.Parse(customerListDGV.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }
    }
}
