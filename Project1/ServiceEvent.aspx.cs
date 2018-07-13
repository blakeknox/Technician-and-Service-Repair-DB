using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Project1
{
    public partial class ServiceEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            if (!IsPostBack)
            {
                lblError.Text = "";
                LoadClients();
            }
            
            
        }

        private void LoadClients()
        {
            DataSet dsData;

            dsData = clsDatabase.GetClientList();
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Client list";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Client list";
                dsData.Dispose();
            }
            else
            {
                ddlClient.DataSource = dsData.Tables[0];
                ddlClient.DataTextField = "ClientName";
                ddlClient.DataValueField = "ClientID";
                ddlClient.DataBind();
                ddlClient.Items.Insert(0, new ListItem("(Please select a Client)", string.Empty));

                dsData.Dispose();
            }
            
        }

        private bool formVal()
        {
            bool isVal = true;
            if(ddlClient.SelectedIndex == 0)
            {
                lblError.Text = "Please Select a Client";
                isVal = false;
            }
            else
            {
                if (txtContact.Text.Trim().Length > 1)
                {
                    if (!NumberVal(txtPhone.Text))
                    {
                        lblError.Text = "Please enter a Valid Phone Number";
                        isVal = false;
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    lblError.Text = "Please Enter a Contact.";
                    isVal = false;
                }
            }
      
            return isVal;
            
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (formVal())
            {
                try
                {
                    string strServiceDate = Convert.ToString(DateTime.Now);
                    string strClientID = ddlClient.SelectedValue;
                    string strContact = txtContact.Text;
                    string strPhone;
                    Int32 intNewTicketID = 0;

                    string dirtyNum = txtPhone.Text.Trim();
                    string cleanNum = Regex.Replace(dirtyNum, "[^0-9a-zA-Z]+", "");
                    strPhone = cleanNum;

                    intNewTicketID = clsDatabase.InsertServiceEvent(strClientID, strContact, strPhone, strServiceDate);
                    if(Convert.ToInt32(intNewTicketID) > 0)
                    {
                        Session.Contents["NewTicketID"] = intNewTicketID;
                        Response.Redirect("Problems.aspx");
                    }
                    else
                    {
                        lblError.Text = "Error getting new ticket ID.";
                    }
                }
                catch
                {
                    lblError.Text = "Failed to insert service event";
                }
                
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private static bool NumberVal(string num)
        {
            string MatchPhoneNumberPattern = "^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]?\\d{3}[\\s.-]?\\d{4}$";
            if (num != null) return Regex.IsMatch(num, MatchPhoneNumberPattern);
            else return false;

        }

        private void ResetForm()
        {
            txtContact.Text = "";
            txtPhone.Text = "";
            ddlClient.SelectedIndex = 0;
        }
    }
}