using System;
using System.Data;
using System.Data.SqlClient; 

namespace DoAnCuoiKy
{
    class CheckInOut
    {
        mydb db = new mydb();
        public bool insertCheckIn( DateTime check_in, DateTime check_out, int day, int work_time, int soCa)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CheckInOut(Id,check_in,check_out,day,work_time,soCa) " +
                "VALUES (@id,@in,@out,@day,@worktime,@soCa)", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Globals.GlobalUserId;
            cmd.Parameters.Add("@in", SqlDbType.DateTime).Value = check_in;
            cmd.Parameters.Add("@out", SqlDbType.DateTime).Value = check_out;
            cmd.Parameters.Add("@day", SqlDbType.Int).Value = day;
            cmd.Parameters.Add("@worktime", SqlDbType.Int).Value = work_time;
            cmd.Parameters.Add("@soCa", SqlDbType.Int).Value = soCa;
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
        public DataTable getWorkTimeTotal(int day)
        {
            SqlCommand cmd = new SqlCommand("SELECT Account.Id,fname,lname, SUM(work_time),soCa FROM CheckInOut,Account WHERE day=@day AND CheckInOut.Id=Account.Id  GROUP BY Account.Id,fname,lname,soCa", db.getConnection);
            cmd.Parameters.Add("@day", SqlDbType.Int).Value = day;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
