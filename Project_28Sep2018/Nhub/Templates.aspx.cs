using NHubDAL.Model;
using NHubDAL.Repository;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nhub
{
    public partial class Templates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Context.User.IsInRole("OperationManager"))
            {
                Response.Redirect("NotAuthorized.aspx");
            }
           
            SourceRepository Sr = new SourceRepository();
            List<Source> L = Sr.GetSource();
            EventRepository ER = new EventRepository();
            TemplateEventRepository TE = new TemplateEventRepository();
            foreach (Source s in L)
            {
                Label SourceName = new Label();
                SourceName.Text = s.SourceName.ToString();
                PlaceHolder PR1 = new PlaceHolder();

                List<Events> Event = ER.GetEventsid(s.SourceId);
                foreach (Events OneEvent in Event)
                {
                    Table T = new Table();
                    TableRow tablerow = new TableRow();
                    TableCell tableCell = new TableCell();
                    Label LE = new Label();
                    LE.Text = OneEvent.EventName;
                    PlaceHolder Pr2 = new PlaceHolder();

                    List<TemplateEvent> TemplateEvent = TE.GetTemplatesid(OneEvent.EventId);

                    foreach (TemplateEvent OneTemplate in TemplateEvent)
                    {
                        Label LT = new Label();
                        LT.Text = OneTemplate.TemplateName;
                        HyperLink DeleteTemplate = new HyperLink();
                        HyperLink ConfigureTemplate = new HyperLink();
                        DeleteTemplate.Text = "Delete";
                        ConfigureTemplate.Text = "Configure";
                        DeleteTemplate.NavigateUrl = "TemplateDelete.aspx?id="+OneTemplate.TemplateId;
                        Pr2.Controls.Add(LT);

                        Pr2.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
                        Pr2.Controls.Add(DeleteTemplate);
                        Pr2.Controls.Add(ConfigureTemplate);
                        Pr2.Controls.Add(new LiteralControl("<br/>"));
                        tableCell.Controls.Add(Pr2);
                    }
                    
                    tablerow.Cells.Add(tableCell);
                    T.Rows.Add(tablerow);
                    PR1.Controls.Add(LE);
                    PR1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                    PR1.Controls.Add(T);
                    PR1.Controls.Add(new LiteralControl("<br/>"));
                }
                PlaceHolder1.Controls.Add(SourceName);
                PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
                PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
                PlaceHolder1.Controls.Add(PR1);
                PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
            }
        }
        protected void AddTmpltBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TemplateAdd.aspx");
        }
    }
}