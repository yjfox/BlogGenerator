using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogGenerator.Webpage
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string struid = (Session["uid"] == null ? string.Empty : Session["uid"].ToString());
            if (struid.Length==0)
            ((Label)Master.FindControl("Label_sign")).Text = "Sign In";
            else ((Label)Master.FindControl("Label_sign")).Text = "Sign Out"; 
        }
    }
}