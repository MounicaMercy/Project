
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Data;

namespace DAL.Repository
{
    public class TemplatesRepository
    {
        
        public void Insert(string Templatename, string oid, int ServiceLineID, int NotificationId)
        {
            try
            {


                SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
                //string str = "insert into Template values(ServiceLineID)";
                SqlCommand cmd = new SqlCommand("proc_inser", DefaultConnection);
                DefaultConnection.Open();
                cmd.Connection = DefaultConnection;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ServiceLineID", ServiceLineID);
                cmd.Parameters.AddWithValue("@EventId", NotificationId);
                cmd.Parameters.AddWithValue("@TemplateName", Templatename);
                cmd.Parameters.AddWithValue("@OperationManagerId", oid);
                cmd.ExecuteNonQuery();
                DefaultConnection.Close();
            }
            finally
            {

                
                
            }
        }
        public string Getid(string name)
        {
            SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());

            DefaultConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("select Id from AspNetUsers where UserName='"+name+"'" , DefaultConnection);

            //cmd = new SqlCommand("select * from UserInfo where EMail=@Email", con);
            //cmd.Parameters.Add("@Email", SqlDbType.Varchar, 1000).Value = Email;
            // cmd.Parameters.Add("@", SqlDbType.NVarChar, 1000).Value = name;

            //string str = "select Id from AspNetUsers where UserName='"+name+"'";

            object o = cmd.ExecuteScalar();
            string s = o.ToString();
           // int s=cmd.ExecuteNonQuery();
            return s;
            DefaultConnection.Close();
            DefaultConnection.Dispose();
           

        }
    }

}
