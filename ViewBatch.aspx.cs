using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AdmissionManagement
{
    public partial class ViewBatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBatchDetails();
            }
        }
        // used to get the details of batch
        private void BindBatchDetails(Int64 batch_id = 0)
        {
            try
            {
                String strqry = "select BT_ID,BATCH_NUMBER,BT_CO_ID,BT_FROMDATE,BT_TODATE from TBL_BATCHES";
                clsDbConnector objcon = new clsDbConnector();
                DataSet ds = new DataSet();
                ds = objcon.GetDataSet(strqry);

                grdBatch.DataSource = ds.Tables[0]; //Converting dataset to datatable
                grdBatch.DataBind();
            }
            catch
            {
                throw;
            }
        }
        protected void grdBatch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "myedit")
                {
                    Int64 batch_id = Convert.ToInt64(e.CommandArgument);
                    Response.Redirect("~/Batch.aspx?batch_id=" + batch_id);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}