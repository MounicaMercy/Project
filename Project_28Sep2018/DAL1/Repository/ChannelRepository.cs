using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repository
{
    public class ChannelRepository
    {
        SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
        public List<Channel> GetChannel()
        {
            List<Channel> ChannelList = new List<Channel>();
            DefaultConnection.Open();
            string sql = "Select * From Channel";
            SqlCommand myCommand = new SqlCommand(sql, DefaultConnection);
            Channel b;
            using (SqlDataReader dr = myCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    b = new Channel
                    {
                        ChannelId = Convert.ToInt32(dr["Id"].ToString()),
                        ChannelName = dr["Name"].ToString()
                    };
                    ChannelList.Add(b);
                }
            }
            return ChannelList;
        }
        
    }
}
