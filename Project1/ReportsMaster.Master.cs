using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Project1
{
    public partial class ReportsMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["AppTitle"] != null)
            {
                Page.Title = ConfigurationManager.AppSettings["AppTitle"].ToString();
            }

        }
    }
}