using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DoAnCuoiKy
{
    class LichLamViec
    {
        mydb db = new mydb();
        public bool insertLichLamViec(int id, int calam, int tuan, DateTime ngaybatdau)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO LichLamViec(Id,calam,tuan,ngaybatdau) VALUES (@id,@calam,@tuan,@ngaybd)"
                , db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@calam", SqlDbType.Int).Value = calam;
            cmd.Parameters.Add("@tuan", SqlDbType.Int).Value = tuan;
            cmd.Parameters.Add("@ngaybd", SqlDbType.DateTime).Value = ngaybatdau;
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
        public DataTable getLichLamViec()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM LichLamViec",db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getLichLamViecById(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM LichLamViec WHERE Id=@id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public int getSoTuanLamViec()
        {
            SqlCommand cmd = new SqlCommand("SELECT MAX(tuan) FROM LichLamViec", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return int.Parse(table.Rows[0][0].ToString()) + 1;
        }
        public bool deleteLichLamViec()
        {
            bool flag;
            SqlCommand command = new SqlCommand("DELETE FROM LichLamViec", db.getConnection);
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                flag= true;
            }
            else
            {
                db.closeConnection();
                flag = false;
            }
            command.CommandText = "DELETE FROM CheckInOut";
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                flag = flag && true;
            }
            else
            {
                db.closeConnection();
                flag = false;
            }
            return flag;
        }
        public DataTable getAllEmployeeWorking()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT Id FROM LichLamViec", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
