using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL1.Model;
using DAL1.Repository;

namespace Nhub
{
    public partial class Templates : System.Web.UI.Page
    {
        public object NotificationsBody { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //LinkButton[] LB;
            //PlaceHolder[] PH;
            //int NoOfSources;

            //EventRepository Obj = new EventRepository();
            //List<Source> ListOfSources = new List<Source>();
            //ListOfSources = Obj.
            //NoOfSources = ListOfSources.Count;
            //List<Events> ListOfEvents = new List<Events>();

            //LB = new LinkButton[NoOfSources];
            //PH = new PlaceHolder[NoOfSources];
            //if (!IsPostBack)
            //{
            //    for (int count = 0; count < NoOfSources; count++)
            //    {
            //        LB[count] = new LinkButton();
            //        PH[count] = new PlaceHolder();
            //        LB[count].Text = ListOfSources[count].SourceName;

            //        LB[count].ID = ListOfSources[count].SourceId.ToString();
            //        PH[count].ID = ListOfSources[count].SourceId.ToString();


            //        ListOfEvents = Obj.GetEvents(ListOfSources[count].SId);
            //        foreach (Events Event in ListOfEvents)
            //        {
            //            PH[count].Controls.Add(new LiteralControl("<br/>"));
            //            PH[count].Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp"));
            //            Label L = new Label();
            //            L.Text = Event.EventName;
            //            PH[count].Controls.Add(L);
            //        }
            //        //LB[count].Command += LinkButtonClick;
            //        NotificationsBody.Controls.Add(LB[count]);
            //        NotificationsBody.Controls.Add(PH[count]);
            //        NotificationsBody.Controls.Add(new LiteralControl("<br/>"));
            //    }
            //}



        }   

            protected void AddTmpltBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TemplateAdd.aspx");
        }
    }
}