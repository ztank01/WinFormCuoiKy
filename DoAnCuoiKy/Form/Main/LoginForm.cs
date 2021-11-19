using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace DoAnCuoiKy
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acceptBt_Click(object sender, EventArgs e)
        {
            mydb db = new mydb();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM Account WHERE " +
                "username = @user AND password = @pass", db.getConnection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = usernameTb.Text;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = passwordTb.Text;
            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Globals.SetGlobalUserId(int.Parse(table.Rows[0][0].ToString()));
                string role = table.Rows[0][3].ToString();
                Globals.role = role;
                if (role.Contains("QuanLy"))
                {
                    Thread threadQL = new Thread(new ThreadStart(ShowFormQL)); // Tao luong moi
                    threadQL.SetApartmentState(ApartmentState.STA);
                    threadQL.Start();
                    this.Close();//Dong luong hien tai
                }
                else
                {
                    if (role.Contains("TiepTan"))
                    {
                        Thread threadTT = new Thread(new ThreadStart(ShowFormTT)); // Tao luong moi
                        threadTT.SetApartmentState(ApartmentState.STA);
                        threadTT.Start();
                        this.Close();//Dong luong hien tai
                    }
                    else
                    {
                        Thread threadLC = new Thread(new ThreadStart(ShowFormLC)); // Tao luong moi
                        threadLC.SetApartmentState(ApartmentState.STA);
                        threadLC.Start();
                        this.Close();//Dong luong hien tai
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid username of password", "Login error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowFormQL()
        {
            QuanLyMainForm frm = new QuanLyMainForm();
            frm.ShowDialog();
        }
        private void ShowFormTT()
        {
            TiepTanMainForm frm = new TiepTanMainForm();
            frm.ShowDialog();
        }
        private void ShowFormLC()
        {
            LaoCongMainForm frm = new LaoCongMainForm();
            frm.ShowDialog();
        }
    }
}
