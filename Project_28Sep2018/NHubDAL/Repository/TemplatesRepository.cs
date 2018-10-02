using NHubDAL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHubDAL.Repository
{
    public class TemplatesRepository
    {
        public void Insert(string Templatename, string oid, int ServiceLineID, int NotificationId, int ApprovalStatus)
        {
            SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
            SqlCommand cmd = new SqlCommand("proc_inser", DefaultConnection);
            DefaultConnection.Open();
            cmd.Connection = DefaultConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ServiceLineID", ServiceLineID);
            cmd.Parameters.AddWithValue("@EventId", NotificationId);
            cmd.Parameters.AddWithValue("@TemplateName", Templatename);
            cmd.Parameters.AddWithValue("@OperationManagerId", oid);
            cmd.Parameters.AddWithValue("@ApprovalStatusId", ApprovalStatus);
            cmd.ExecuteNonQuery();
            DefaultConnection.Close();
        }
        public string Getid(string name)
        {
            SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());

            DefaultConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("select Id from AspNetUsers where UserName='" + name + "'", DefaultConnection);
            object o = cmd.ExecuteScalar();
            string s = o.ToString();
            return s;
            DefaultConnection.Close();
            DefaultConnection.Dispose();
        }
        public void InsertUrl(int TemplateID, int ChannelId, string Url, int ApprovalStatus)
        {
            SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
            SqlCommand cmd = new SqlCommand("proc_inserturl", DefaultConnection);
            DefaultConnection.Open();
            cmd.Connection = DefaultConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TemplateID", TemplateID);
            cmd.Parameters.AddWithValue("@ChannelId", ChannelId);
            cmd.Parameters.AddWithValue("@Url", Url);
            cmd.Parameters.AddWithValue("@ApprovalStatusId", ApprovalStatus);
            cmd.ExecuteNonQuery();
            DefaultConnection.Close();
        }
        public int GetTemplateId(string name)
        {
            SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
            DefaultConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("select Id from Template where Name='" + name + "'", DefaultConnection);
            object o = cmd.ExecuteScalar();
            int s = Convert.ToInt32(o.ToString());
            return s;
        }
        public void Delete(int id)
        {
            SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
            DefaultConnection.Open();

            SqlCommand cmd = new SqlCommand("proc_delete", DefaultConnection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TemplateId", id);

            cmd.Connection = DefaultConnection;
            cmd.ExecuteNonQuery();
            DefaultConnection.Close();
            DefaultConnection.Dispose();
        }
        public void UpdateStatus()
        {
            SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
            DefaultConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("UPDATE TemplateChannel set ApprovalStatusId=2 where TemplateId in (SELECT T.Id FROM  Template T WHERE T.ApprovalStatusId =2)", DefaultConnection);
            cmd.ExecuteNonQuery();
            DefaultConnection.Close();
        }
        public List<Templates> GetTemplate(int id)
        {
            List<Templates> T = new List<Templates>();
            SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
            DefaultConnection.Open();
            string Str = "select * from Template where Id="+id;
            SqlCommand cmd = new SqlCommand(Str,DefaultConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    T.Add(new Templates
                    { 
                    TemplateId = Convert.ToInt32(dr["Id"].ToString()),
                    TemplateName = dr["Name"].ToString()
                    });
                }
                return T;
                DefaultConnection.Close();
            }
            DefaultConnection.Close();
        }

    }
}
