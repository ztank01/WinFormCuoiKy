using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DoAnCuoiKy
{
    public partial class ChonPhongTrongForm : Form
    {
        public ChonPhongTrongForm()
        {
            InitializeComponent();
        }
        Khach khach = new Khach();
        Phong phong = new Phong();
        mydb db = new mydb();
        private void ChonPhongTrongForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Phong WHERE Id not in (SELECT phong FROM Khach)", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            roomListDGV.DataSource = table;
            roomListDGV.Columns[0].HeaderText = "ID Phòng";
            roomListDGV.Columns[1].HeaderText = "Hạng";
            roomListDGV.Columns[2].HeaderText = "Giá 1 ngày";
        }

        private void roomListDGV_DoubleClick(object sender, EventArgs e)
        {
            Globals.SelectedID_Phong = int.Parse(roomListDGV.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }
    }
}
