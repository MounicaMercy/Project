using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL1.Model;
using DAL.Repository;
using DAL1.Repository;

//namespace Nhub
//{
//    public partial class TemplateDelete : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {

//           TemplatesRepository tr = new TemplatesRepository();
//            int id = Convert.ToInt32(Request.QueryString["id"]);
//            Templates T = tr.GetTemplates(id);

//            DeleteTemplate.Text = T.TemplateId.ToString();
//            //ProductId.Text = P.PId.ToString();
//        }

//        protected void Button1_Click(object sender, EventArgs e)
//        {
//            int tid = Convert.ToInt32(DeleteTemplate.Text.ToString());
//            TemplatesRepository tr = new TemplatesRepository();
//            tr.Delete(tid);
//        }
//    }
//}