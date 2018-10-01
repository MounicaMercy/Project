using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Repository;
using DAL1.Model;
using DAL1.Repository;

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
            Table T = new Table();
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
                TableRow tablerow = new TableRow();
                TableCell tableCell = new TableCell();
                foreach(Events OneEvent in  Event)
                {
                    Label LE = new Label();
                    LE.Text = OneEvent.EventName;
                    PlaceHolder Pr2 = new PlaceHolder();

                    List<TemplateEvent> TemplateEvent = TE.GetTemplatesid(OneEvent.EventId);

                    foreach(TemplateEvent OneTemplate in TemplateEvent)
                    {
                        
                    }
                   
                       
                }
            }
        }   

            protected void AddTmpltBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TemplateAdd.aspx");
        }
    }
}