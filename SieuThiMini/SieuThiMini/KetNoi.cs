using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini
{
    internal class KetNoi
    {
        private string connectionString = @"Server=LAPTOP-54B90UMK;Database=QUANLIBH;Integrated Security=True";
        private SqlConnection connection;

        public KetNoi()
        {
            connection = new SqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public void ExecuteNonQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

}