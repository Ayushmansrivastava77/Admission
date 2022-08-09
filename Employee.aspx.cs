using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace AdmissionManagement
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    BindRoles();
                }
                if (Request.QueryString["empid"] != null)
                {
                    Int64 empid = Convert.ToInt64(Request.QueryString["empid"]);
                    getEmployeeDetails(empid);
                }
            }
            catch
            {
                throw;
            }
        }

        private void BindRoles()
        {
            try
            {
                string strqry = string.Empty;
                strqry = "SELECT RL_ID,RL_NAME FROM TBL_ROLES";

                clsDbConnector objcon = new clsDbConnector();
                DataSet ds = objcon.GetDataSet(strqry);

                drproleID.DataSource = ds.Tables[0];
                drproleID.DataTextField = "RL_NAME";
                drproleID.DataValueField = "RL_ID";
                drproleID.DataBind();
            }
            catch
            {
                throw;
            }
        }
        private void getEmployeeDetails(Int64 empid)
        {
            try
            {
                string strqry = string.Empty;
                strqry = "select * from TBL_EMPLOYEE where EMP_ID='" + empid + "'";
                clsDbConnector objconn = new clsDbConnector();
                DataSet ds = objconn.GetDataSet(strqry);

                DataTable dt = ds.Tables[0];

                txtemployeename.Text = Convert.ToString(dt.Rows[0]["EMP_NAME"]);
                txtemployeecompID.Text = Convert.ToString(dt.Rows[0]["EMP_COMP_ID"]);
                txtemailID.Text = Convert.ToString(dt.Rows[0]["EMP_MAIL_ID"]);
                txtmobilenumber.Text = Convert.ToString(dt.Rows[0]["EMP_MOBILENO"]);
                txtdateofjoin.Text = Convert.ToString(dt.Rows[0]["EMP_DOJ"]);
                txtdateofleaving.Text = Convert.ToString(dt.Rows[0]["EMP_DOL"]);
                //DateTime dateofjoin = DateTime.ParseExact(txtdateofjoin.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //DateTime dateofleave = DateTime.ParseExact(txtdateofleaving.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                drproleID.SelectedValue = Convert.ToString(dt.Rows[0]["EMP_ROLE_ID"]);
                txtpassword.Text = Convert.ToString(dt.Rows[0]["EMP_PASSWORD"]);
            }
            catch
            {
                throw;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtemployeename.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Name";
                    return;
                }
                if (string.IsNullOrEmpty(txtemployeecompID.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Company ID";
                    return;
                }
                if (string.IsNullOrEmpty(txtemailID.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Email ID";
                    return;
                }
                if (string.IsNullOrEmpty(txtmobilenumber.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Mobile Number";
                    return;
                }
                if (string.IsNullOrEmpty(txtdateofjoin.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Date of Joining";
                    return;
                }
                if (string.IsNullOrEmpty(drproleID.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Role ID";
                    return;
                }
                if (string.IsNullOrEmpty(txtpassword.Text.Trim()))
                {
                    lblmessage.Text = "Enter Password";
                    return;
                }

                string empname = Convert.ToString(txtemployeename.Text);
                string cpmID = Convert.ToString(txtemployeecompID.Text);
                string mailID = Convert.ToString(txtemailID.Text);
                Int64 mobno = Convert.ToInt64(txtmobilenumber.Text);

                DateTime dateofjoin = DateTime.ParseExact(txtdateofjoin.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateofleave = DateTime.ParseExact(txtdateofleaving.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                /*Int64 dateofjoin = Convert.ToInt64(txtdateofjoin.Text);
                Int64 dateofleave = Convert.ToInt64(txtdateofleaving.Text);*/
                Int64 roleID = Convert.ToInt64(drproleID.SelectedValue);
                string password = Convert.ToString(txtpassword.Text);

                clsDbConnector objcon = new clsDbConnector();
                Int64 empid = objcon.Find_Automatic_no("EMP_ID", "TBL_EMPLOYEE");
                string strqry = string.Empty;
                strqry = "insert into TBL_EMPLOYEE values ('" + empid + "','" + empname + "','" + cpmID + "','" + mailID + "','" + mobno + "',convert(datetime,'" + dateofjoin + "',103),convert(datetime,'" + dateofleave + "',103),'" + roleID + "','" + password + "')";

                bool issave = objcon.runSQL(strqry);
                if (issave == true)
                {
                    lblmessage.Text = "Saved Successfully";
                }
                else
                {
                    lblmessage.Text = "Failed";
                }
            }
            catch
            {
                throw;
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtemployeename.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Name";
                    return;
                }
                if (string.IsNullOrEmpty(txtemployeecompID.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Company ID";
                    return;
                }
                if (string.IsNullOrEmpty(txtemailID.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Email ID";
                    return;
                }
                if (string.IsNullOrEmpty(txtmobilenumber.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Mobile Number";
                    return;
                }
                if (string.IsNullOrEmpty(txtdateofjoin.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Date of Joining";
                    return;
                }
                if (string.IsNullOrEmpty(txtdateofleaving.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Date of Leaving";
                    return;
                }
                if (string.IsNullOrEmpty(drproleID.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Employee Role ID";
                    return;
                }
                if (string.IsNullOrEmpty(txtpassword.Text.Trim()))
                {
                    lblmessage.Text = "ENTER PASSWORD";
                    return;
                }

                String empname = Convert.ToString(txtemployeename.Text);
                string cpmID = Convert.ToString(txtemployeecompID.Text);
                String mailID = Convert.ToString(txtemailID.Text);
                Int64 mobno = Convert.ToInt64(txtmobilenumber.Text);
                //Int64 dateofjoin = Convert.ToInt64(txtdateofjoin.Text);
                //Int64 dateofleave = Convert.ToInt64(txtdateofleaving.Text);
                DateTime dateofjoin = DateTime.ParseExact(txtdateofjoin.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateofleave = DateTime.ParseExact(txtdateofleaving.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Int64 roleID = Convert.ToInt64(drproleID.SelectedValue);
                String password = Convert.ToString(txtpassword.Text);

                clsDbConnector objcon = new clsDbConnector();
                string strqry = string.Empty;
                strqry = "UPDATE TBL_EMPLOYEE SET EMP_NAME='" + empname + "',EMP_COMP_ID='" + cpmID + "',EMP_MAIL_ID='" + mailID + "',EMP_MOBILENO='" + mobno + "',EMP_DOJ=convert(datetime,'" + dateofjoin + "',103),EMP_DOL= convert(datetime,'" + dateofleave + "' , 103),EMP_ROLE_ID='" + roleID + "',EMP_PASSWORD='" + password + "'";

                bool issupdate = objcon.runSQL(strqry);
                if (issupdate == true)
                {
                    lblmessage.Text = "Updated Successfully";
                }
                else
                {
                    lblmessage.Text = "Failed";
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
