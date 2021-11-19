using System.Data;
using System.Data.SqlClient;

namespace DoAnCuoiKy
{
    class Phong
    {
        mydb db = new mydb();

        public bool insertPhong(int id, int loai, int gia)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Phong(Id,loai,gia) VALUES " +
                "(@id,@loai,@gia)", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@loai", SqlDbType.Int).Value = loai;
            cmd.Parameters.Add("@gia", SqlDbType.Int).Value = gia;
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
        public bool updatePhong(int id, int loai, int gia)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Phong SET loai=@loai,gia=@gia" +
                " WHERE Id=@id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@loai", SqlDbType.Int).Value = loai;
            cmd.Parameters.Add("@gia", SqlDbType.Int).Value = gia;
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
        public bool deletePhong(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Phong WHERE Id=@id", db.getConnection);
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
        public bool exists(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Phong WHERE Id=@id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows.Count > 0;
        }
        public DataTable getAll()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Phong", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getById(int Id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Phong WHERE Id = @id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
