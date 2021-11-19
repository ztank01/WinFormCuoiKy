using System.Data.SqlClient;
using System.Data;

namespace DoAnCuoiKy
{
    class mydb
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;
    Initial Catalog=QLHotel;Integrated Security=True;
    Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
    ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        // get the connection
        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }
        // open the connection
        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))
            {
                con.Open();
            }
        }
        // close the connection
        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
            {
                con.Close();
            }
        }
    }
}
