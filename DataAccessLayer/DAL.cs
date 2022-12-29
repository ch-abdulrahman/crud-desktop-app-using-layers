using System.Data;
using System.Data.SqlClient;

namespace CRUD.DataAccessLayer
{
    class DAL
    {
        static string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CRUD;Integrated Security=True";
        static SqlConnection con = new SqlConnection(conString);

        // return affected number of rows inserted, deleted or updated
        public static int ExecuteNonQuery(string query, CommandType type, params SqlParameter[] arr)
        {
            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.CommandType = type;
            cmd.Parameters.AddRange(arr);
            int n = cmd.ExecuteNonQuery();
            con.Close();
            return n;
        }

        // return DataTable containing rows and columns
        public static DataTable ExecuteTable(string query, CommandType type, params SqlParameter[] arr)
        {
            var cmd = new SqlCommand(query, con);
            cmd.CommandType = type;
            cmd.Parameters.AddRange(arr);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // return SqlParameter
        public static SqlParameter CreateParameter(string name, SqlDbType type, object value)
        {
            var p = new SqlParameter();
            p.ParameterName = name;
            p.SqlDbType = type;
            p.SqlValue = value;
            return p;
        }

    }
}
