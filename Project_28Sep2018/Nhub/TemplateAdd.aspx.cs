using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Repository;
namespace Nhub
{
    public partial class TemplateAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Table T = new Table();
            TemplatesRepository tr = new TemplatesRepository();
            ChannelRepository cr = new ChannelRepository();
            List<Channel> L = cr.GetChannel();
            foreach (Channel c in L)
            {
                TableRow TR = new TableRow();
                T.Rows.Add(TR);
                TableCell TC = new TableCell();

                Label Channelname = new Label();
                Channelname.Text = c.ChannelName.ToString();

                TextBox txtbox = new TextBox();
                txtbox.ToolTip = "Insert url of the document";

                //Button Upload = new Button();
                //Upload.
                //Image im = new Image();
                //im.ImageUrl = "~//" + c.PURL.ToString();
                //im.Width = 161;
                //im.Height = 217;

                //HyperLink HL = new HyperLink();
                //HL.Text = p.PName.ToString();
                //HL.ID = "Hyperlink_file";
                //HL.NavigateUrl = "ProductDescrptionPage.aspx?id=" + p.PId;
                //PlaceHolder1.Controls.Add(im);
                //PlaceHolder1.Controls.Add(HL);
                PlaceHolder1.Controls.Add(Channelname);
                PlaceHolder1.Controls.Add(txtbox);

                TR.Cells.Add(TC);
            }


        }



        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Templates.aspx");
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            int ServiceLineID = Convert.ToInt32(ServiceLineDDL.SelectedValue);
            int NotificationId = Convert.ToInt32(NotificationDDL.SelectedValue);
            string Templatename = TemplateName.Text;
            //int Channelid = Convert.ToInt32(.SelectedValue);

            TemplatesRepository tr = new TemplatesRepository();
           // tr.Insert(ServiceLineID, NotificationId, Templatename);

            Response.Redirect("Templates.aspx");
        }
    }
}