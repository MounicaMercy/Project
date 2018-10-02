using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Web.UI.WebControls;
using NHubDAL.Model;
using NHubDAL.Repository;

namespace Nhub
{
    public partial class TemplateDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            TemplatesRepository Tr = new TemplatesRepository();
            int idvalue= Convert.ToInt32(Request.QueryString["id"].ToString());
            List<NHubDAL.Model.Templates> T = Tr.GetTemplate(idvalue);
            foreach (NHubDAL.Model.Templates Templatedetails in T)
            {
                DeleteTemplate.Text = Templatedetails.TemplateId.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int tid = Convert.ToInt32(DeleteTemplate.Text.ToString());
            TemplatesRepository tr = new TemplatesRepository();
            tr.Delete(tid);
            Response.Redirect("Templates.aspx");
        }
    }
}