using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace Project1
{
    public partial class Resolutions : System.Web.UI.Page
    {
        string strTechRate;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblProbNum.Text = Convert.ToString(Session.Contents["ProblemNum"]);
            lblTicketNum.Text = Convert.ToString(Session.Contents["OpenTicketNum"]);
            if (!IsPostBack)
            {
                LoadTechnicians();
                Session.Contents["ResolutionNum"] = 1;
                lblResolutionNum.Text = Convert.ToString(Session.Contents["ResolutionNum"]);

            }
        }

        protected void btnReturnOpen_Click(object sender, EventArgs e)
        {
            Response.Redirect("OpenPoblems.aspx");
        }

        private void ResetForm()
        {
            ddlTechnician1.SelectedIndex = 0;
            txtResolution.Text = "";
            txtMisc.Text = "";
            txtSupplies.Text = "";
            txtMileage.Text = "";
            txtHours.Text = "";
            txtDateOnsite.Text = "";
            txtDateFixed.Text = "";
            txtCostMiles.Text = "";
        }

        private void LoadTechnicians()
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
                ddlTechnician1.DataSource = dsData.Tables[0];
                ddlTechnician1.DataTextField = "TechName";
                ddlTechnician1.DataValueField = "TechnicianID";
                ddlTechnician1.DataBind();
                ddlTechnician1.Items.Insert(0, new ListItem("(Please select a Technician)", string.Empty));

                dsData.Dispose();
            }
        }
        private static bool NumberVal(string rate)
        {
            string IsNum = "^[.,0-9]+$";
            if (rate != null) return Regex.IsMatch(rate, IsNum);
            else return false;
        }

        public bool IsValidated()
        {
            Boolean blnError = false;
            if(txtResolution.Text.Trim().Length > 2)
            {
                if(ddlTechnician1.SelectedIndex != 0)
                {
                    if (NumberVal(txtHours.Text))
                    {
                        
                        try {
                            Decimal hours;
                            hours = Convert.ToDecimal(txtHours.Text);
                            if(hours <= 0)
                            {
                                lblError.Text = "Please enter hours greater then zero";
                                blnError = true;
                                
                            }
                            if(txtMileage.Text.Trim().Length > 0 )
                            {
                                if (NumberVal(txtMileage.Text.Trim()))
                                {
                                    try
                                    {
                                        Decimal Miles;
                                        Miles = Convert.ToDecimal(txtMileage.Text);
                                        if (Miles <= 0)
                                        {
                                            lblError.Text = "Please enter a Mileage larger then zero.";
                                            blnError = true;
                                        }                                        
                                    }
                                    catch
                                    {
                                        lblError.Text = "Failed to Convert Miles.";
                                        blnError = true;
                                    }
                                }
                                else
                                {
                                    lblError.Text = "Mileage must be numberic.";
                                    blnError = true;
                                }
                                
                            }
                            if (txtMisc.Text.Trim().Length > 0)
                            {
                                if (NumberVal(txtMisc.Text.Trim()))
                                {
                                    try
                                    {
                                        Decimal Misc;
                                        Misc = Convert.ToDecimal(txtMisc.Text);
                                        if (Misc <= 0)
                                        {
                                            lblError.Text = "Please enter a Misc value larger then zero.";
                                            blnError = true;
                                        }
                                    }
                                    catch
                                    {
                                        lblError.Text = "Failed to Convert Misc.";
                                        blnError = true;
                                    }
                                }
                                else
                                {
                                    lblError.Text = "Misc must be numberic.";
                                    blnError = true;
                                }
                                
                            }
                            if (txtSupplies.Text.Trim().Length > 0)
                            {
                                if (NumberVal(txtSupplies.Text.Trim()))
                                {
                                    try
                                    {
                                        Decimal Misc;
                                        Misc = Convert.ToDecimal(txtSupplies.Text);
                                        if (Misc <= 0)
                                        {
                                            lblError.Text = "Please enter a Supplies value larger then zero.";
                                            blnError = true;
                                        }
                                    }
                                    catch
                                    {
                                        lblError.Text = "Failed to Supplies Misc.";
                                        blnError = true;
                                    }
                                }
                                else
                                {
                                    lblError.Text = "Supplies must be numberic.";
                                    blnError = true;
                                }

                            }
                            if(txtDateFixed.Text.Trim().Length > 0)
                            {
                                try
                                {
                                    DateTime formDate;
                                    formDate = Convert.ToDateTime(txtDateFixed.Text);
                                    if(formDate > DateTime.Now)
                                    {
                                        lblError.Text = "Date Fixed cannot be greater then todays date.";
                                        blnError = true;
                                    }
                                }
                                catch
                                {
                                    lblError.Text = "Please Enter a valid Date Fixed. (mm/dd/yyyy)";
                                    blnError = true;
                                }
                            }
                            if (txtDateOnsite.Text.Trim().Length > 0)
                            {
                                try
                                {
                                    DateTime formDate;
                                    formDate = Convert.ToDateTime(txtDateOnsite.Text);
                                    if (formDate > DateTime.Now)
                                    {
                                        lblError.Text = "Date Onsite cannot be greater then todays date.";
                                        blnError = true;
                                    }
                                }
                                catch
                                {
                                    lblError.Text = "Please Enter a valid Onsite Date. (mm/dd/yyyy)";
                                    blnError = true;
                                }
                            }
                            if (txtCostMiles.Text.Trim().Length > 0)
                            {
                                if (NumberVal(txtCostMiles.Text.Trim()))
                                {
                                    try
                                    {
                                        Decimal Misc;
                                        Misc = Convert.ToDecimal(txtCostMiles.Text);
                                        if (Misc <= 0)
                                        {
                                            lblError.Text = "Please enter a Cost Miles value larger then zero.";
                                            blnError = true;
                                        }
                                    }
                                    catch
                                    {
                                        lblError.Text = "Failed to Convert Cost Miles.";
                                        blnError = true;
                                    }
                                }
                                else
                                {
                                    lblError.Text = "Cost Miles must be numberic.";
                                    blnError = true;
                                }

                            }

                        }
                        catch{
                            lblError.Text = "Failed to convert hours.";
                            blnError = true;
                        }
                        
                    }
                    else
                    {
                        lblError.Text = "Please Enter Hours. Must be numeric";
                        blnError = true;
                    }
                }
                else
                {
                    lblError.Text = "Please Select a Technician";
                    blnError = true;
                }
            }
            else
            {
                lblError.Text = "Please Enter a Resolution";
                blnError = true;
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (IsValidated())
            {

                string strTechID;
                string strResDesc;
                string strIncNum;
                string strResNo;
                string strNoCharge;
                string strTicketID;
                Decimal dechours;
                string strDateFix;
                string strDateOnsite;
                string strMileage;
                string strMisc;
                string strSupplies;
                string strCostMiles;

                strTechID = ddlTechnician1.SelectedValue;
                strResDesc = txtResolution.Text.Trim();
                strIncNum = lblProbNum.Text.Trim();
                strResNo = lblResolutionNum.Text.Trim();
                if (chkNoCharge.Checked)
                {
                    strNoCharge = "1";
                }
                else
                {
                    strNoCharge = "0";
                }
                strTicketID = lblTicketNum.Text.Trim();
                dechours = Convert.ToDecimal(txtHours.Text.Trim());
                if (txtDateFixed.Text.Trim().Length <= 0)
                {
                    strDateFix = null;
                }
                else
                {
                    strDateFix = txtDateFixed.Text.Trim();
                }
                if(txtDateOnsite.Text.Trim().Length <= 0)
                {
                    strDateOnsite = null;
                }
                else
                {
                    strDateOnsite = txtDateOnsite.Text.Trim();
                }
                if(txtMileage.Text.Trim().Length <= 0)
                {
                    strMileage = null;
                }
                else
                {
                    strMileage = txtMileage.Text.Trim();
                }
                if(txtMisc.Text.Trim().Length <= 0)
                {
                    strMisc = null;
                }
                else
                {
                    strMisc = txtMisc.Text.Trim();
                }
                if(txtSupplies.Text.Trim().Length <= 0)
                {
                    strSupplies = null;
                }
                else
                {
                    strSupplies = txtSupplies.Text.Trim();
                }
                if(txtCostMiles.Text.Trim().Length <= 0)
                {
                    strCostMiles = null;
                }
                else
                {
                    strCostMiles = txtCostMiles.Text.Trim();
                }
                
                clsDatabase.InsertResolution(strTechID, strResDesc, strIncNum, strResNo, strNoCharge, strTicketID,
                    dechours, strDateFix, strDateOnsite, strMileage, strMisc, strSupplies, strCostMiles);
                
                
                int ResNumber = Convert.ToInt32(Session.Contents["ResolutionNum"]);
                ResNumber++;
                Session.Contents["ResolutionNum"] = ResNumber;
                lblResolutionNum.Text = Convert.ToString(ResNumber);
                ResetForm();
            }
        }

        protected void chkNoCharge_CheckedChanged(object sender, EventArgs e)
        {
            
        }

       

        private void DisplayTechInfo(String strTechID)
        {
            DataSet dsData;

            dsData = clsDatabase.GetTechnicianByID(strTechID);
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Technician.";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Technician.";
                dsData.Dispose();
            }
            else
            {
                if (dsData.Tables[0].Rows[0]["HRate"] == DBNull.Value)
                {
                    txtCostMiles.Text = "0";
                }
                else
                {
                    strTechRate = dsData.Tables[0].Rows[0]["HRate"].ToString();
                }

                dsData.Dispose();
            }
        }

        protected void ddlTechnician1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTechnician1.SelectedIndex != 0)
            {
                try
                {
                    DisplayTechInfo(ddlTechnician1.SelectedValue);
                }
                catch
                {
                    lblError.Text = "Error retreiving Technition Rate.";
                }
            }
        }
    }
}