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

            //if (!Context.User.IsInRole("OperationManager"))
            //{
            //    Response.Redirect("NotAuthorized.aspx");
            //}
           
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
                    Table Tables = new Table();
                    TableRow Rows = new TableRow();
                    TableCell Cells = new TableCell();

                    Label EventName = new Label();
                    EventName.Text = OneEvent.EventName;

                    Label LTSpace1 = new Label();
                    LTSpace1.Text = "";
                    LTSpace1.Width = 65;

                    PlaceHolder PR2 = new PlaceHolder();

                    List<TemplateEvent> TemplateEvent = TE.GetTemplatesid(OneEvent.EventId);
                    foreach (TemplateEvent OneTemplate in TemplateEvent)
                    {
                        Label LTSpace2 = new Label();
                        LTSpace2.Text = "";
                        LTSpace2.Width = 115;

                        Label TemplateName = new Label();
                        TemplateName.Text = OneTemplate.TemplateName;

                       
                        HyperLink ConfigureTemplate = new HyperLink();
                        HyperLink DeleteTemplate = new HyperLink();

                        LiteralControl LTSpace3 = new LiteralControl();
                        LTSpace3.Text = "&nbsp;&nbsp;";

                        LiteralControl LTSpace4 = new LiteralControl();
                        LTSpace4.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

                        ConfigureTemplate.Text = "Configure";
                        DeleteTemplate.Text = "Delete";
                     
                        DeleteTemplate.NavigateUrl ="TemplateDelete.aspx?id="+OneTemplate.TemplateId;

                        PR2.Controls.Add(LTSpace2);
                        PR2.Controls.Add(TemplateName);
                        PR2.Controls.Add(LTSpace4);
                        PR2.Controls.Add(ConfigureTemplate);
                        PR2.Controls.Add(LTSpace3);
                        PR2.Controls.Add(DeleteTemplate);
                        Cells.Controls.Add(PR2);
                    }
                    Rows.Cells.Add(Cells);
                    Tables.Rows.Add(Rows);
                    PR1.Controls.Add(LTSpace1);
                    PR1.Controls.Add(EventName);
                    PR1.Controls.Add(Tables);
                }
                PlaceHolder1.Controls.Add(SourceName);
                PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
                PlaceHolder1.Controls.Add(PR1);
            }
        }
        protected void AddTmpltBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TemplateAdd.aspx");
        }
    }
}