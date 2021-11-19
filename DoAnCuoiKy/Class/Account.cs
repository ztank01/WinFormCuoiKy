using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DoAnCuoiKy
{
    class Account
    {
        mydb db = new mydb();
        LichLamViec lichlv = new LichLamViec();
        public int countRole(string role)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE role=@role", db.getConnection);
            cmd.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows.Count;
        }
        public DataTable getEmployeeByRole(string role)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE role=@role", db.getConnection);
            cmd.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getEmployeeById(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE Id=@id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public string defineRole(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE Id=@id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows[0][3].ToString();
        }
        public bool insertEmployee(int id, string uname, string pass, string role, string fname, 
            string lname, string email, string phone,string address, MemoryStream pic)
        {
            lichlv.deleteLichLamViec();
            SqlCommand cmd = new SqlCommand("INSERT INTO Account(Id,username,password,role,fname,lname,email," +
                "phone,address,pic) VALUES (@id,@uname,@pass,@role,@fname,@lname,@email,@phone,@address,@pic)",db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            cmd.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }  
        }
        public int getIdMax()
        {
            SqlCommand cmd = new SqlCommand("SELECT MAX(Id) FROM Account", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return int.Parse(table.Rows[0][0].ToString());
        }
        public DataTable getEmployeeList(string where_clause)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Account " + where_clause, db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool deleteEmployee(int id)
        {
            lichlv.deleteLichLamViec();
            SqlCommand command = new SqlCommand("DELETE FROM Account WHERE  Id=@id", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool updateEmployee(int id, string uname, string pass, string role, string fname,
            string lname, string email, string phone, string address, MemoryStream pic)
        {
            lichlv.deleteLichLamViec();
            SqlCommand cmd = new SqlCommand("UPDATE Account SET username=@uname,password=@pass,role=@role," +
                "fname=@fname,lname=@lname,email=@email, phone=@phone,address=@address,pic=@pic WHERE Id=@id",
                db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            cmd.Parameters.Add("@role", SqlDbType.VarChar).Value = role;
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();
            db.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
    }
}
