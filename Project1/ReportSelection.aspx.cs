using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Report Selection";
            ((Label)Master.FindControl("lblBanner")).Text = "CCIS 2645 Introduction to ASP.Net";
            ((Label)Master.FindControl("lblDate")).Text = DateTime.Now.ToShortDateString() +" "+ DateTime.Now.ToShortTimeString();
        }

        protected void btnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Contents["pageTitle"] = "Problems By Institution";
            Session.Contents["storedProcedure"] = "uspProblemsByInstitution";
            Response.Redirect("ReportDisplay.aspx");
        }

        protected void btnClient_Click(object sender, EventArgs e)
        {
            Session.Contents["pageTitle"] = "Problems By Client";
            Session.Contents["storedProcedure"] = "uspProblemsByClient";
            Response.Redirect("ReportDisplay.aspx");
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            Session.Contents["pageTitle"] = "Problems By Product";
            Session.Contents["storedProcedure"] = "uspProblemsByProduct";
            Response.Redirect("ReportDisplay.aspx");
        }

        protected void btnTechnician_Click(object sender, EventArgs e)
        {
            Session.Contents["pageTitle"] = "Problems By Technician";
            Session.Contents["storedProcedure"] = "uspProblemsByTechnician";
            Response.Redirect("ReportDisplay.aspx");
        }
    }
}