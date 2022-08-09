using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;

namespace AdmissionManagement
{
    public partial class Student_Details : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["stuid"] != null)
                    {
                        Int64  updatestuid = Convert.ToInt64(Request.QueryString["stuid"]);
                        //Int64 stuid = 0;
                        //stuid = Convert.ToInt64();
                        getStudentDetails(updatestuid);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private void getStudentDetails(Int64 stuid)
        {
            try
            {
                string strqry = string.Empty;
                strqry = "select * from TBL_STUDENTDETAILS where ST_ID='" + stuid + "'";
                clsDbConnector objconn = new clsDbConnector();
                DataSet ds = objconn.GetDataSet(strqry);

                DataTable dt = ds.Tables[0];

                txtstudentname.Text = Convert.ToString(dt.Rows[0]["ST_NAME"]);
                txtmobno.Text = Convert.ToString(dt.Rows[0]["ST_MOBILENO"]);
                txtcollname.Text = Convert.ToString(dt.Rows[0]["ST_COLLEGENAME"]);
                txtfees.Text = Convert.ToString(dt.Rows[0]["ST_FEES"]);
                txtbatchid.Text = Convert.ToString(dt.Rows[0]["ST_BT_ID"]);
                txtrefno.Text = Convert.ToString(dt.Rows[0]["ST_REF_NO"]);
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
                if (string.IsNullOrEmpty(txtstudentname.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Student Name";
                    return;
                }
                if (string.IsNullOrEmpty(txtmobno.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Mobile Number";
                    return;
                }
                if (string.IsNullOrEmpty(txtcollname.Text.Trim()))
                {
                    lblmessage.Text = "Enter The College Name";
                    return;
                }
                if (string.IsNullOrEmpty(txtfees.Text.Trim()))
                {
                    lblmessage.Text = "Enter the College Fees";
                    return;
                }
                if (string.IsNullOrEmpty(txtbatchid.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Batch ID";
                    return;
                }
                if (string.IsNullOrEmpty(txtrefno.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Reference Number";
                    return;
                }

                String stuname = Convert.ToString(txtstudentname.Text);
                Int64 stumobno = Convert.ToInt64(txtmobno.Text);
                String clgname = Convert.ToString(txtcollname.Text);
                Int64 clgfees = Convert.ToInt64(txtfees.Text);
                Int64 batchID = Convert.ToInt64(txtbatchid.Text);
                String refno = Convert.ToString(txtrefno.Text);

                clsDbConnector objcon = new clsDbConnector();
                Int64 stuid = objcon.Find_Automatic_no("ST_ID", "TBL_STUDENTDETAILS");
                string strqry = string.Empty;
                strqry = "insert into TBL_STUDENTDETAILS values ('" + stuid + "','" + stuname + "','" + stumobno + "','" + clgname + "','" + clgfees + "','" + batchID + "','" + refno + "')";

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
                if (string.IsNullOrEmpty(txtstudentname.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Student Name";
                    return;
                }
                if (string.IsNullOrEmpty(txtmobno.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Mobile Number";
                    return;
                }
                if (string.IsNullOrEmpty(txtcollname.Text.Trim()))
                {
                    lblmessage.Text = "Enter The College Name";
                    return;
                }
                if (string.IsNullOrEmpty(txtfees.Text.Trim()))
                {
                    lblmessage.Text = "Enter the College Fees";
                    return;
                }
                if (string.IsNullOrEmpty(txtbatchid.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Batch ID";
                    return;
                }
                if (string.IsNullOrEmpty(txtrefno.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Reference Number";
                    return;
                }

                String stuname = Convert.ToString(txtstudentname.Text);
                Int64 stumobno = Convert.ToInt64(txtmobno.Text);
                String clgname = Convert.ToString(txtcollname.Text);
                Int64 clgfees = Convert.ToInt64(txtfees.Text);
                Int64 batchID = Convert.ToInt64(txtbatchid.Text);
                String refno = Convert.ToString(txtrefno.Text);

                clsDbConnector objcon = new clsDbConnector();

                Int64 stuid = 0;
                if (Request.QueryString["stuid"] != null)
                {
                    stuid = Convert.ToInt64(Request.QueryString["stuid"]);
                }
                  
                string strqry = string.Empty;
                strqry = "Update TBL_STUDENTDETAILS set ST_NAME='" + stuname + "',ST_MOBILENO='" + stumobno + "',ST_COLLEGENAME='" + clgname + "',ST_FEES='" + clgfees + "',ST_BT_ID='"+ batchID + "' ,ST_REF_NO='"+ refno + "' where ST_ID='"+ stuid + "'";
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