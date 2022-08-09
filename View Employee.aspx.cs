using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AdmissionManagement
{
    public partial class View_Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployeeDetails();
            }
        }
        // used to get the details of Employee
        private void BindEmployeeDetails(Int64 empid = 0)
        {
            try
            {
                string strqry = string.Empty;
                strqry = "select EMP_ID,EMP_NAME,EMP_COMP_ID,EMP_MAIL_ID,EMP_MOBILENO,EMP_DOJ,EMP_DOL,EMP_ROLE_ID,EMP_PASSWORD from TBL_EMPLOYEE";
                clsDbConnector objcon = new clsDbConnector();
                DataSet ds = new DataSet();
                ds = objcon.GetDataSet(strqry);

                gridemployee.DataSource = ds.Tables[0]; //Converting dataset to datatable
                gridemployee.DataBind();
            }
            catch
            {
               throw;
            }
         }
         protected void gridemployee_RowCommand(object sender, GridViewCommandEventArgs e)
         {
             try
             {
                 if (e.CommandName == "myedit")
                 {
                     Int64 empid = Convert.ToInt64(e.CommandArgument);
                     Response.Redirect("~/Employee.aspx?empid=" + empid);
                 }
              }
             catch
             {
                  throw;
             }
         }
    }
}
    
