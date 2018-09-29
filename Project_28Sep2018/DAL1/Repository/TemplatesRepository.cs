
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Repository
{
    public class TemplatesRepository
    {
        SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
        public void Insert(int ServiceLineID, int NotificationId, string Templatename, int Channelid)
        {
           
            DefaultConnection.Open();
            SqlCommand cmd = new SqlCommand("proc_inserttemplate", DefaultConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ServiceLineID", ServiceLineID);
            cmd.Parameters.AddWithValue("@NotificationID", NotificationId);
            cmd.Parameters.AddWithValue("@TemplateName", Templatename);
            cmd.Parameters.AddWithValue("@ChannelID", Channelid);
        
            cmd.Connection = DefaultConnection;
            cmd.ExecuteNonQuery();
            DefaultConnection.Close();
            DefaultConnection.Dispose();
        }
    }
}
