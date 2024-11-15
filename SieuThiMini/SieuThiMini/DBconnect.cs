using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini
{
    class DBconnect
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private string con;
        public string myConnection()
        {
            con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.net\ontap\scpsnt\scpsnt\bin\Debug\ctbd.mdf;Integrated Security=True;Connect Timeout=30";//datasource, t thêm bậy bạ để vô đc á, nao làm thì sửa sau nha
            return con;
        }
        public DataTable getTables(string qury)
        {
            conn.ConnectionString=myConnection();
            cmd=new SqlCommand(qury,conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
