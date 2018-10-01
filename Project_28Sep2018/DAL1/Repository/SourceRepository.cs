using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DAL1.Model;

namespace DAL1.Repository
{
    public class SourceRepository
    {
        SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
        public List<Source> GetSource()
        {
            List<Source> SourceList = new List<Source>();
            DefaultConnection.Open();
            string sql = "Select * From Source";
            SqlCommand myCommand = new SqlCommand(sql, DefaultConnection);
            Source s;
            using (SqlDataReader dr = myCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    s = new Source
                    {
                        SourceId = Convert.ToInt32(dr["Id"].ToString()),
                        SourceName = dr["Name"].ToString()
                    };
                    SourceList.Add(s);
                }
            }
            return SourceList;
        }
        public Source GetSource(int id)
        {
            Source S = new Source();
            DefaultConnection.Open();
            string str = "select * from Source where Id=" + id;
            SqlCommand cmd = new SqlCommand(str, DefaultConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                dr.Read();
                S.SourceId = Convert.ToInt32(dr["Id"].ToString());
                S.SourceName = dr["Name"].ToString();
                return S;
                DefaultConnection.Close();
            }
            DefaultConnection.Close();
        }
    }
}
