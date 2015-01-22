using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;

namespace DB
{
    public static class DB
    {
        public static string CONNECTION = "Server=localhost;USERID=root;PASSWORD=root;Database=betradar;Charset=utf8;Connection Timeout=2;";

        public static int InsertXmlHead(string file, string xml)
        {
            int id = 0;

            MySqlConnection cn = default(MySqlConnection);
            MySqlCommand cm = new MySqlCommand();

            cn = new MySqlConnection(CONNECTION);

            cm.Connection = cn;
            cm.CommandText = "InsertXmlHead";
            cm.CommandType = System.Data.CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("_file", file);
            cm.Parameters.AddWithValue("_xml", xml);
            cm.Parameters.Add("_id", MySqlDbType.Int32).Direction = System.Data.ParameterDirection.Output;

            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
                id = Convert.ToInt32(cm.Parameters["_id"].Value);
                cn.Close();
            }
            catch
            {
                if (cn.State == System.Data.ConnectionState.Open) cn.Close();
            }

            cm.Dispose();
            cm = null;
            cn = null;

            return id;
        }
    }
}
