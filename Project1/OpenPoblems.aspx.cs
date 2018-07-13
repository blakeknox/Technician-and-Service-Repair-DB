using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Project1
{
    public partial class OpenPoblems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadOpenProblems();
        }

        protected void btnReturnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        private void LoadOpenProblems()
        {
            DataSet dsData = null;
            dsData = clsDatabase.GetOpenProblems();
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
                gvProblems.DataSource = dsData.Tables[0];
                gvProblems.DataBind();
            }
        }

        protected void gvProblems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Trim().ToUpper() == "SELECT")
            {
                Session.Contents["OpenTicketNum"] = gvProblems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.ToString();
                Session.Contents["ProblemNum"] = gvProblems.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.ToString();
                Response.Redirect("Resolutions.aspx");
            }
        }
    }
}