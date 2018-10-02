using NHubDAL.Repository;
using System;
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
            TemplatesRepository Tr = new TemplatesRepository();
            Tr.UpdateStatus();
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
            createlbltxt.Text = "Template Created,Now insert the url";
            uploadlbltxt.Text = "";
        }
        protected void Upload_Click(object sender, EventArgs e)
        {
           
            try
            {
                TemplatesRepository tr = new TemplatesRepository();
                string Tmpltname = TemplateName.Text;
                int id = tr.GetTemplateId(Tmpltname);
                int ChannelId = Convert.ToInt32(ChannelDDL.SelectedValue);
                string url = URL.Text;
                int ApprovalStatus = 1;
                tr.InsertUrl(id, ChannelId, url, ApprovalStatus);
                Uploadsucces.Text = "Template Inserted";
            }
           
            catch (Exception ex)
            {
                uploadlbltxt.Text = "First Create the template,then upload your template url!!";
            }
          
        }
    }
}
