﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nhub
{
    public partial class TemplateAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Templates.aspx");
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Templates.aspx");
        }
    }
}