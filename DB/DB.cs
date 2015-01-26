using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MySql.Data.MySqlClient;

namespace DB
{
    public class DB
    {
        public static string CONNECTION = "Server=localhost;USERID=root;PASSWORD=root;Database=betradar;Charset=utf8;Connection Timeout=2;";

        public static int InsertXmlHead(string file, string crc, ref int err)
        {
            int id = 0;

            MySqlConnection cn = default(MySqlConnection);
            MySqlCommand cm = new MySqlCommand();

            cn = new MySqlConnection(CONNECTION);

            cm.Connection = cn;
            cm.CommandText = "InsertXmlHead";
            cm.CommandType = System.Data.CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("_file", file);
            cm.Parameters.AddWithValue("_crc", crc);
            cm.Parameters.Add("_id", MySqlDbType.Int32).Direction = System.Data.ParameterDirection.Output;
            cm.Parameters.Add("_err", MySqlDbType.Int32).Direction = System.Data.ParameterDirection.Output;

            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
                id = Convert.ToInt32(cm.Parameters["_id"].Value);
                err = Convert.ToInt32(cm.Parameters["_err"].Value);
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

        public static void InsertXmlData(int idDat, int SportID, string Sport, int CategoryID, string Category, int TournamentID
            , string Tournament, int MatchId, string Comp1, string Comp2)
        {
            MySqlConnection cn = default(MySqlConnection);
            MySqlCommand cm = new MySqlCommand();

            cn = new MySqlConnection(CONNECTION);

            cm.Connection = cn;
            cm.CommandText = "InsertXmlData";
            cm.CommandType = System.Data.CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("_iddat", idDat);
            cm.Parameters.AddWithValue("_SportID", SportID);
            cm.Parameters.AddWithValue("_Sport", Sport);
            cm.Parameters.AddWithValue("_CategoryID", CategoryID);
            cm.Parameters.AddWithValue("_Category", Category);
            cm.Parameters.AddWithValue("_TournamentID", TournamentID);
            cm.Parameters.AddWithValue("_Tournament", Tournament);
            cm.Parameters.AddWithValue("_MatchID", MatchId);
            cm.Parameters.AddWithValue("_Comp1", Comp1);
            cm.Parameters.AddWithValue("_Comp2", Comp2);

            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch
            {
                if (cn.State == System.Data.ConnectionState.Open) cn.Close();
            }

            cm.Dispose();
            cm = null;
            cn = null;
        }

        public static void UpdateXmlData(int id, int status)
        {
            MySqlConnection cn = default(MySqlConnection);
            MySqlCommand cm = new MySqlCommand();

            cn = new MySqlConnection(CONNECTION);

            cm.Connection = cn;
            cm.CommandText = "UpdateXmlData";
            cm.CommandType = System.Data.CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("_id", id);
            cm.Parameters.AddWithValue("_status", status);

            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch
            {
                if (cn.State == System.Data.ConnectionState.Open) cn.Close();
            }

            cm.Dispose();
            cm = null;
            cn = null;
        }

        public static DataTable GetXmlData(int idDat)
        {
            DataTable dt = new DataTable();

            MySqlConnection cn = new MySqlConnection(CONNECTION);
            MySqlCommand cm = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();

            cm.Connection = cn;
            cm.CommandText = "GetXmlData";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("_idDat", idDat);
            da.SelectCommand = cm;

            try
            {
                cn.Open();
                da.Fill(dt);
                cn.Close();
            }
            catch
            {
                if (cn.State == System.Data.ConnectionState.Open) cn.Close();
            }

            cm.Dispose(); cm = null;
            da.Dispose(); da = null;
            cn = null;

            return dt;
        }
    }
}
