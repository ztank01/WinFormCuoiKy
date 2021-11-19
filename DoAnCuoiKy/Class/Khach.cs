using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;

namespace DoAnCuoiKy
{
    class Khach
    {
        mydb db = new mydb();

        public bool insertKhach(int id, string fname, string lname, string gender, string phone, 
            MemoryStream pic, DateTime ngayden, DateTime ngaydi,int phong, int datra )
        {
            string status = "";
            if (Globals.role.Contains("TiepTan"))
            {
                status = "new";
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO Khach(Id,fname,lname,gender,phone,pic,ngayden," +
                "ngaydi,phong,datra,new) VALUES (@id,@fname,@lname,@gender,@phone,@pic,@ngayden,@ngaydi,@phong,@datra,@new)",
                db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();
            cmd.Parameters.Add("@ngayden", SqlDbType.DateTime).Value = ngayden;
            cmd.Parameters.Add("@ngaydi", SqlDbType.DateTime).Value = ngaydi;
            cmd.Parameters.Add("@phong", SqlDbType.Int).Value = phong;
            cmd.Parameters.Add("@datra", SqlDbType.Int).Value = datra;
            cmd.Parameters.Add("@new", SqlDbType.VarChar).Value = status;
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
        public bool updateKhach(int id, string fname, string lname, string gender, string phone,
            MemoryStream pic, DateTime ngayden, DateTime ngaydi, int phong, int datra)
        {
            string status = "";
            if (Globals.role.Contains("TiepTan"))
            {
                status = "new";
            }
            SqlCommand cmd = new SqlCommand("UPDATE Khach SET fname=@fname,lname=@lname,gender=@gender," +
                "phone=@phone,pic=@pic,ngayden=@ngayden,ngaydi=@ngaydi,phong=@phong,datra=@datra,new=@new WHERE Id=@id",
                db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();
            cmd.Parameters.Add("@ngayden", SqlDbType.DateTime).Value = ngayden;
            cmd.Parameters.Add("@ngaydi", SqlDbType.DateTime).Value = ngaydi;
            cmd.Parameters.Add("@phong", SqlDbType.Int).Value = phong;
            cmd.Parameters.Add("@datra", SqlDbType.Int).Value = datra;
            cmd.Parameters.Add("@new", SqlDbType.VarChar).Value = status;
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
        public bool deleteKhach(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Khach WHERE Id=@id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
        public int getSoKhachNew()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Khach WHERE new='new'", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows.Count;
        }
        public bool daXem()
        {
            SqlCommand cmd = new SqlCommand("UPDATE Khach SET new='' WHERE new='new'", db.getConnection);
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
        public DataTable getAllKhach()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Khach", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getKhachById(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Khach WHERE Id=@id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getKhachinDay(DateTime now)
        {
            DateTime time_start;
            DateTime time_end;
            if (now.Hour > 7)
            {
                time_start = new DateTime(now.Year, now.Month, now.Day, 7, 0, 0);
                time_end = new DateTime(now.Year, now.Month, now.Day + 1, 6, 59, 59);
            }
            else
            {
                time_start = new DateTime(now.Year, now.Month, now.Day-1, 7, 0, 0);
                time_end = new DateTime(now.Year, now.Month, now.Day, 6, 59, 59);
            }
            SqlCommand cmd = new SqlCommand("SELECT Id,fname,lname,gender,phone,pic,ngayden,ngaydi," +
                "phong,datra FROM Khach WHERE ngayden >= '"
                 + time_start.ToString("f") + "' AND ngayden < '" + time_end.ToString("f") + "'", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
