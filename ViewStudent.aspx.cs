using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AdmissionManagement
{
    public partial class ViewStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindViewStudentDetails();
            }
        }
            // used to get the details of student
        private void BindViewStudentDetails(Int64 stuid = 0)
        {
            try
            {
                String strqry = "select ST_ID,ST_NAME,ST_MOBILENO,ST_COLLEGENAME,ST_FEES,ST_BT_ID,ST_REF_NO from TBL_STUDENTDETAILS";
                clsDbConnector objcon = new clsDbConnector();
                DataSet ds = new DataSet();
                ds = objcon.GetDataSet(strqry);

                grdstudent.DataSource = ds.Tables[0]; //Converting dataset to datatable
                grdstudent.DataBind();
            }
            catch
            {
                throw;
            }
        }
        protected void grdstudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            { 
                if (e.CommandName == "myedit")
                {
                    Int64 stuid = Convert.ToInt64(e.CommandArgument);
                    Response.Redirect("~/Student Details.aspx?stuid=" + stuid);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}