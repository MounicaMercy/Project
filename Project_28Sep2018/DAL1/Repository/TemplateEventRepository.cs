using DAL1.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1.Repository
{
    public class TemplateEventRepository
    {
        public List<TemplateEvent> GetTemplatesid(int EventId)
        {
            SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
            List<TemplateEvent> TemplatesList = new List<TemplateEvent>();
            DefaultConnection.Open();
            string sql = "Select * From Template where EventId=" + EventId;
            SqlCommand myCommand = new SqlCommand(sql, DefaultConnection);
            TemplateEvent t;
            using (SqlDataReader dr = myCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    t = new TemplateEvent
                    {
                        TemplateId = Convert.ToInt32(dr["Id"].ToString()),
                        TemplateName = dr["Name"].ToString(),
                        EventId = Convert.ToInt32(dr["EventId"].ToString()),
                    };
                    TemplatesList.Add(t);
                }
            }
            return TemplatesList;
        }
    }
}
