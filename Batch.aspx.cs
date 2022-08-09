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
    public partial class Batch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindCourse();
                }
                if (Request.QueryString["batch_id"] != null)
                {
                    Int64 batch_id = Convert.ToInt64(Request.QueryString["batch_id"]);
                    getBatchDetails(batch_id);
                }
            }
            catch
            {
                throw;
            }
        }
        private void getBatchDetails(Int64 batch_id)
        {
            try
            {
                string strqry = string.Empty;
                strqry = "select * from TBL_BATCHES where BT_ID='" + batch_id + "'";
                clsDbConnector objconn = new clsDbConnector();
                DataSet ds = objconn.GetDataSet(strqry);

                DataTable dt = ds.Tables[0];

                txtbatchnumber.Text = Convert.ToString(dt.Rows[0]["BATCH_NUMBER"]);
                drpCourseID.SelectedValue = Convert.ToString(dt.Rows[0]["BT_CO_ID"]);
                txtfromdate.Text = Convert.ToString(dt.Rows[0]["BT_FROMDATE"]);
                txttodate.Text = Convert.ToString(dt.Rows[0]["BT_TODATE"]);
                //DateTime bt_fromdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //DateTime bt_todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                if (string.IsNullOrEmpty(txtbatchnumber.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Batch Number";
                    return;
                }
                if (string.IsNullOrEmpty(drpCourseID.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Batch Course ID";
                    return;
                }
                if (string.IsNullOrEmpty(txtfromdate.Text.Trim()))
                {
                    lblmessage.Text = "Enter From Date";
                    return;
                }
                if (string.IsNullOrEmpty(txttodate.Text.Trim()))
                {
                    lblmessage.Text = "Enter the To Date";
                    return;
                }

                Int64 batch_number = Convert.ToInt64(txtbatchnumber.Text);
                Int64 batch_courseID = Convert.ToInt64(drpCourseID.SelectedValue);
                //Int64 bt_fromdate = Convert.ToInt64(txtfromdate.Text);
                //Int64 bt_todate = Convert.ToInt64(txttodate.Text);
                DateTime bt_fromdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime bt_todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                clsDbConnector objcon = new clsDbConnector();
                Int64 batch_id = objcon.Find_Automatic_no("BT_ID", "TBL_BATCHES");
                string strqry = string.Empty;
                strqry = "insert into TBL_BATCHES values ('" + batch_id + "','" + batch_number + "','" + batch_courseID + "',convert(datetime,'" + bt_fromdate + "',103),convert(datetime,'" + bt_todate + "',103))";

                bool issave = objcon.runSQL(strqry);
                if (issave == true)
                {
                    lblmessage.Text = " Successfully";
                }
            }
            catch
            {
                throw;
            }
        }
        private void BindCourse()
        {
            try
            {
                string strqry = string.Empty;
                strqry = "SELECT CO_ID,CO_NAME FROM TBL_COURSE";
                clsDbConnector objcon = new clsDbConnector();
                DataSet ds = objcon.GetDataSet(strqry);
                drpCourseID.DataSource = ds.Tables[0];
                drpCourseID.DataTextField = "CO_NAME";
                drpCourseID.DataValueField = "CO_ID";
                drpCourseID.DataBind();
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
                if (string.IsNullOrEmpty(txtbatchnumber.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Batch Number";
                    return;
                }
                if (string.IsNullOrEmpty(drpCourseID.Text.Trim()))
                {
                    lblmessage.Text = "Enter the Batch Course ID";
                    return;
                }
                if (string.IsNullOrEmpty(txtfromdate.Text.Trim()))
                {
                    lblmessage.Text = "Enter From Date";
                    return;
                }
                if (string.IsNullOrEmpty(txttodate.Text.Trim()))
                {
                    lblmessage.Text = "Enter the To Date";
                    return;
                }

                Int64 batch_number = Convert.ToInt64(txtbatchnumber.Text);
                Int64 batch_courseID = Convert.ToInt64(drpCourseID.SelectedValue);
                //Int64 bt_fromdate = Convert.ToInt64(txtfromdate.Text);
                //Int64 bt_todate = Convert.ToInt64(txttodate.Text);
                DateTime bt_fromdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime bt_todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                clsDbConnector objcon = new clsDbConnector();
                Int64 batch_id = objcon.Find_Automatic_no("BT_ID", "TBL_BATCHES");
                string strqry = string.Empty;
                strqry = "UPDATE TBL_BATCHES SET BATCH_NUMBER='" + batch_number + "',BT_CO_ID='" + batch_courseID + "',BT_FROMDATE=convert(datetime,'" + bt_fromdate + "',103),BT_TODATE= convert(datetime,'" + bt_todate + "' , 103)";

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