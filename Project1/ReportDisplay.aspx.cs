using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            LoadProblems();
            //Page.Title = Session.Contents["pageTitle"].ToString();
            ((Label)Master.FindControl("lblAppName")).Text = Session.Contents["pageTitle"].ToString();
            ((Label)Master.FindControl("lblBanner")).Text = "CCIS 2645 Introduction to ASP.Net";
            ((Label)Master.FindControl("lblDate")).Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();//("hh:mm:ss tt") formats time with tt puts am/pm
        }

        protected void btnReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportSelection.aspx");
        }

        protected void LoadProblems()
        {
            DataSet dsData = null;
            dsData = clsDatabase.ProblemsProduct(Session.Contents["storedProcedure"].ToString());//procedure);
            if (dsData == null)
            {
                lblError.Text = "Error loading Product Data.";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error loading Product Data.";
            }
            else if (dsData.Tables[0].Rows.Count < 1)
            {
                lblError.Text = "Error loading Product Data.";
            }
            else
            {
                gvReports.DataSource = dsData.Tables[0];
                gvReports.DataBind();
            }
        }

        protected void gvReports_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}