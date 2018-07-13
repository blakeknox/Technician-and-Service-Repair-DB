using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Project1
{
    public partial class TechnicianInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {    
                LoadTechnicians();
                DisplayTechInfo(ddlTechnician.SelectedValue);
                lblError.Text = "";
                btnClear.Enabled = false;
                if (ddlTechnician.SelectedIndex == 0)
                {
                    btnRemove.Enabled = false;
                }
                else
                {
                    btnRemove.Enabled = true;
                }
            }
            if(ddlTechnician.SelectedIndex == 0)
            {
                btnRemove.Enabled = false;
            }
            else
            {
                btnRemove.Enabled = true;
            }
            
        }

        // Load technician drop down info
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
                ddlTechnician.DataSource = dsData.Tables[0];
                ddlTechnician.DataTextField = "TechName";
                ddlTechnician.DataValueField = "TechnicianID";
                ddlTechnician.DataBind();
                ddlTechnician.Items.Insert(0, new ListItem("(Please select a Technician)", string.Empty));

                dsData.Dispose();
            }
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
                if (dsData.Tables[0].Rows[0]["fName"] == DBNull.Value)
                {
                    txtFname.Text = "";
                }
                else
                {
                    txtFname.Text = dsData.Tables[0].Rows[0]["fName"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["lName"] == DBNull.Value)
                {
                    txtLname.Text = "";
                }
                else
                {
                    txtLname.Text = dsData.Tables[0].Rows[0]["lName"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["MInit"] == DBNull.Value)
                {
                    txtMI.Text = "";
                }
                else
                {
                    txtMI.Text = dsData.Tables[0].Rows[0]["MInit"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["Email"] == DBNull.Value)
                {
                    txtEmail.Text = "";
                }
                else
                {
                    txtEmail.Text = dsData.Tables[0].Rows[0]["Email"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["Dept"] == DBNull.Value)
                {
                    txtDepartment.Text = "";
                }
                else
                {
                    txtDepartment.Text = dsData.Tables[0].Rows[0]["Dept"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["Phone"] == DBNull.Value)
                {
                    txtPhone.Text = "";
                }
                else
                {
                    txtPhone.Text = dsData.Tables[0].Rows[0]["Phone"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["HRate"] == DBNull.Value)
                {
                    txtHourlyRate.Text = "";
                }
                else
                {
                    txtHourlyRate.Text = dsData.Tables[0].Rows[0]["HRate"].ToString();
                }

                dsData.Dispose();
            }
        }


        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void ddlTechnician_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlTechnician.SelectedIndex == 0)
            {
                Reset();
            }
            else
            {
                DisplayTechInfo(ddlTechnician.SelectedValue);
            }
           
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            bool dataBaseVal;
            dataBaseVal = true;
            string fName = "";
            string lName = "";
            string MI = "";
            string phoneNum = "";
            decimal hourlyRate = 0;
            string email = "";
            string department = "";

            //name validation and setting of local variables for insertion into db
            if (NameVal(txtFname.Text.Trim()) && NameVal(txtLname.Text.Trim()))
            {
                fName = txtFname.Text.Trim();
                lName = txtLname.Text.Trim();
                if (txtMI.Text.Trim().Length == 1)
                {
                    MI = txtMI.Text.Trim();
                }
                else if(txtMI.Text.Trim().Length > 1)
                {
                    dataBaseVal = false;
                    lblError.Text = "Middle Initial may only be 1 letter.";
                }
                else
                {
                    MI = null;
                }
            }
            else
            {
                dataBaseVal = false;
                lblError.Text = "Invalid First/Last Name.";
            }
            
            //Phone number validation and set variable for insertion into db
            if (NumberVal(txtPhone.Text.Trim())) 
            {
                //removing special characters after validation for insertion into db
                string dirtyNum = txtPhone.Text.Trim();
                string cleanNum = Regex.Replace(dirtyNum, "[^0-9a-zA-Z]+", "");
                phoneNum = cleanNum;

            }
            else
            {
                dataBaseVal = false;
                lblError.Text = "Invalid Phone number";
            }

            // checking for email and validate
            if(txtEmail.Text.Trim().Length == 0)
            {
                email = null;
            }
            else if(txtEmail.Text.Trim().Length > 0 && txtEmail.Text.Trim().Length <= 50)
            {
                email = txtEmail.Text.Trim();
            }
            else
            {
                dataBaseVal = false;
                lblError.Text = "Invalid Email can only be 50 char.";
            }

            // checking for department and validate
            if (txtDepartment.Text.Trim().Length == 0)
            {
                department = null;
            }
            else if (txtDepartment.Text.Trim().Length > 0 && txtDepartment.Text.Trim().Length <= 25)
            {
                department = txtDepartment.Text.Trim();
            }
            else
            {
                dataBaseVal = false;
                lblError.Text = "Invalid Department can only be 25 char.";
            }

            //validating hourly rate
            if(txtHourlyRate.Text.Trim().Length > 0 && PayRateVal(txtHourlyRate.Text.Trim()))
            {
                string dirtyNum = txtHourlyRate.Text.Trim();
                string cleanNum = Regex.Replace(dirtyNum, "[^.,0-9]+", "");
                //hourlyRate = cleanNum;
                if(Decimal.TryParse(cleanNum, out hourlyRate))
                {

                }
                else
                {
                    lblError.Text = "Could not convert hourlyrate";
                }

                
            }
            else
            {
                dataBaseVal = false;
                lblError.Text = "Please enter a valid pay rate.";
            }


            if (dataBaseVal)
            {
                if (ddlTechnician.SelectedIndex == 0)
                {
                    try
                    {
                        clsDatabase.InsertTechnician(fName, lName, MI, email, department, phoneNum, hourlyRate);
                        Reset();
                        LoadTechnicians();
                        ddlTechnician.Enabled = true;
                    }
                    catch
                    {
                        lblError.Text = "Could not insert technician info.";
                    }
                }
                else
                {
                    string strTechID = ddlTechnician.SelectedValue;

                    try
                    {
                        clsDatabase.UpdateTechnician(strTechID, fName, lName, MI, email, department, phoneNum, hourlyRate);
                        Reset();
                    }
                    catch
                    {
                        lblError.Text = "Could not insert technician info.";
                    }
                }
                
                
            }          

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        { 
            if(ddlTechnician.SelectedIndex == 0)
            {
                btnNewTech.Enabled = true;
                ddlTechnician.Enabled = true;
                btnRemove.Enabled = false;
                Reset();
            }
            else
            {
                DisplayTechInfo(ddlTechnician.SelectedValue);
                ddlTechnician.Enabled = true;      
            }
            
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                clsDatabase.DeleteTechnician(ddlTechnician.SelectedValue);
                LoadTechnicians();
                ddlTechnician.SelectedIndex = 0;
            }
            catch
            {
                lblError.Text = "Could not remove Technician.";
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnNewTech_Click(object sender, EventArgs e)
        {
            if(ddlTechnician.SelectedIndex != 0)
            {
                ddlTechnician.SelectedIndex = 0;
            }
            btnNewTech.Enabled = false;
            ddlTechnician.Enabled = false;
            btnClear.Enabled = true;
            btnRemove.Enabled = false;
            Reset();
        }

        protected void txtPhone_TextChanged(object sender, EventArgs e)
        {}

        private static bool PayRateVal (string rate)
        {
            string IsNum = "^[.,0-9]+$";
            if (rate != null) return Regex.IsMatch(rate, IsNum);
            else return false;
        }

        private static bool NumberVal(string num)
        {
            string MatchPhoneNumberPattern = "^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]?\\d{3}[\\s.-]?\\d{4}$";
            if (num != null) return Regex.IsMatch(num, MatchPhoneNumberPattern);
            else return false;

        }

        private static bool NameVal(string name)
        {
            if(name.Trim().Length >= 2 && name.Trim().Length <= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Reset()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            txtMI.Text = "";
            txtEmail.Text = "";
            txtHourlyRate.Text = "";
            txtDepartment.Text = "";
            txtPhone.Text = "";
            lblError.Text = "";
        }
       
    }
}