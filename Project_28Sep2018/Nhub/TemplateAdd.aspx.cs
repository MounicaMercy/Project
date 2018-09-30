using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Repository;
using DAL1;
namespace Nhub
{
    public partial class TemplateAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.IsInRole("OperationManager"))
            {
                Response.Redirect("NotAuthorized.aspx");
            }  
        }
        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Templates.aspx");
        }
        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            TemplatesRepository tr = new TemplatesRepository();
            int ServiceLineID = Convert.ToInt32(ServiceLineDDL.SelectedValue);
            int NotificationId = Convert.ToInt32(NotificationDDL.SelectedValue);
            string Templatename = TemplateName.Text;
            String name = Context.User.Identity.Name;
            string id=tr.Getid(name);
            int ApprovalStatus = 1;
            tr.Insert(Templatename, id, ServiceLineID, NotificationId, ApprovalStatus); 
            Response.Redirect("Templates.aspx");
        }
        protected void Upload_Click(object sender, EventArgs e)
        {
            TemplatesRepository tr = new TemplatesRepository();
            string Tmpltname = TemplateName.Text;
            int id = tr.GetTemplateId(Tmpltname);
            int ChannelId = Convert.ToInt32(ChannelDDL.SelectedValue) ;
            string url = uplaodtxt.Text;
            int ApprovalStatus = 1;
            tr.InsertUrl(id, ChannelId, url, ApprovalStatus);
         
        }
    }
}
