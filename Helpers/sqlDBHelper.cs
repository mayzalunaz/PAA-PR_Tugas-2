using System.Data;
using Npgsql;

namespace Manajemen_Kelas_PR.Helpers
{
    public class sqlDBHelper
    {
        private NpgsqlConnection conn;
        private string __constr;

        public sqlDBHelper(string pConstr)
        {
            __constr = pConstr;
            conn = new NpgsqlConnection();
            conn.ConnectionString = __constr;
        }

        public NpgsqlCommand GetNpgsqlCommand(string query)
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
        public void closeConnection()
        {
            conn.Close();
        }
    }
}
