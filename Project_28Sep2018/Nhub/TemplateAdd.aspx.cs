using System;
using DAL.Repository;


namespace Nhub
{
    public partial class TemplateAdd : System.Web.UI.Page
    {
        int flag = 0;
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
            flag++;
        }
        //protected void Update_Click(object sender, EventArgs e)
        //{
        //    TemplatesRepository tr = new TemplatesRepository();
        //    string Tmpltname = TemplateName.Text;
        //    int id = tr.GetTemplateId(Tmpltname);
        //    //int ChannelId = Convert.ToInt32(ChannelDDL.SelectedValue) ;
        //    //string url = uplaodtxt.Text;
        //    int ApprovalStatus = 1;
        //  //  tr.InsertUrl(id, ChannelId, url, ApprovalStatus);
        //}

        //protected void GVChannel_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = GVChannel.Rows[index];
        //    TextBox tb = (TextBox)row.FindControl("TextBox1");
        //}
        protected void Upload_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                TemplatesRepository tr = new TemplatesRepository();
                string Tmpltname = TemplateName.Text;
                int id = tr.GetTemplateId(Tmpltname);
                int ChannelId = Convert.ToInt32(ChannelDDL.SelectedValue);
                string url = URL.Text;
                int ApprovalStatus = 1;
                tr.InsertUrl(id, ChannelId, url, ApprovalStatus);
            }
            else
            {
                uploadlbltxt.Text = "First Create the template,then upload your template url!!";

            }
        }
    }
}
