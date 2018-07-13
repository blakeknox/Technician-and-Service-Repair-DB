using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project1
{
    public partial class Problems : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            lblTicketCount.Text = Convert.ToString(Session.Contents["NewTicketID"]);
            if (!IsPostBack)
            {
                LoadProductsList();
                LoadTechniciansList();
                Session.Contents["ProblemCount"] = 1;
                lblProbCount.Text = Convert.ToString(Session.Contents["ProblemCount"]);
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (FormValidation())
            {
                try
                {
                    string strTicketID = lblTicketCount.Text;
                    string strIncNo = lblProbCount.Text;
                    string strProbDesc = txtProbDesc.Text;
                    string strTechID = ddlTechnician.SelectedValue;
                    string strProdID = ddlProduct.SelectedValue;

                    clsDatabase.InsertProblem(strTicketID,strIncNo,strProbDesc,strTechID,strProdID);

                    int ProblemNumber = Convert.ToInt32(Session.Contents["ProblemCount"]);
                    ProblemNumber++;
                    Session.Contents["ProblemCount"] = ProblemNumber;
                    lblProbCount.Text = Convert.ToString(ProblemNumber);
                    ResetForm();
                }
                catch
                {
                    lblError.Text = "Failed to Insert Problem.";
                }
                
            }
            
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        public void LoadProductsList()
        {
            DataSet dsData;

            dsData = clsDatabase.GetProductList();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Product list";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Product list";
                dsData.Dispose();
            }
            else
            {
                ddlProduct.DataSource = dsData.Tables[0];
                ddlProduct.DataTextField = "ProductDesc";
                ddlProduct.DataValueField = "ProductID";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("(Please select a Product)", string.Empty));

                dsData.Dispose();
            }
        }
        public void LoadTechniciansList()
        {
            DataSet dsData;

            dsData = clsDatabase.GetTechnicianList();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Technician list";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Technician list";
                dsData.Dispose();
            }
            else
            {
                ddlTechnician.DataSource = dsData.Tables[0];
                ddlTechnician.DataTextField = "TechName";
                ddlTechnician.DataValueField = "TechnicianID";
                ddlTechnician.DataBind();
                ddlTechnician.Items.Insert(0, new ListItem("(Please select a Technician)", string.Empty));

                dsData.Dispose();
            }
        }
        private void ResetForm()
        {
            lblError.Text = "";
            ddlProduct.SelectedIndex = 0;
            ddlTechnician.SelectedIndex = 0;
            txtProbDesc.Text = "";
        }
        public void GetTickNum()
        {
            int ticketnum;
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
                int LastRow = dsData.Tables[0].Rows.Count -1 ;
                ticketnum = Convert.ToInt16(dsData.Tables[0].Rows[LastRow]["TicketID"])+1;
                lblTicketCount.Text = Convert.ToString(ticketnum);

            }
        }

        public bool FormValidation()
        {
            bool blnError = false;

            if(ddlProduct.SelectedIndex == 0)
            {
                lblError.Text = "Please Select a Product";
                blnError = true;
            }
            else
            {
                if(ddlTechnician.SelectedIndex == 0)
                {
                    lblError.Text = "Please Select a Technician";
                    blnError = true;
                }
                else
                {
                    if(txtProbDesc.Text.Trim().Length <= 0)
                    {
                        lblError.Text = "Please enter a Problem Description";
                        blnError = true;
                    }
                   
                }
            }

            if (blnError)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnReturnToService_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceEvent.aspx");
        }
    }
}