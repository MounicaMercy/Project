using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Repository;
namespace Nhub
{
    public partial class TemplateAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Context.User.IsInRole("SuperAdmin"))
            //{
            //    Response.Redirect("NotAuthorized.aspx");
            //}
            if (!Context.User.IsInRole("OperationManager"))
            {
                Response.Redirect("NotAuthorized.aspx");
            }
            Table T = new Table();
            ChannelRepository cr = new ChannelRepository();
            List<Channel> L = cr.GetChannel();
            foreach (Channel c in L)
            {
                TableRow TR = new TableRow();
                T.Rows.Add(TR);
                TableCell TC = new TableCell();

                Label Channelname = new Label();
                Channelname.Text = c.ChannelName.ToString();
                Channelname.Width =190;

                TextBox txtbox = new TextBox();
                txtbox.ToolTip = "Insert url of the document";

                Label l1 = new Label();
                l1.Width = 5;

                Button Upload = new Button();
                Upload.Text = "Upload";
                Upload.Width = 200;

                Label l = new Label();
                l.Width = 200;
                l.Text = "";
               
                PlaceHolder1.Controls.Add(Channelname);
                PlaceHolder1.Controls.Add(txtbox);
                PlaceHolder1.Controls.Add(l1);
                PlaceHolder1.Controls.Add(Upload);
                PlaceHolder1.Controls.Add(l);

                TR.Cells.Add(TC);
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

            tr.Insert(Templatename, id, ServiceLineID, NotificationId); 

            Response.Redirect("Templates.aspx");
        }
    }
}