using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AdmissionManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string stremail = txtemail.Text;
                string strpassword = txtpass.Text;
                DataSet ds = new DataSet();

                string strqry = "select * from TBL_LOGIN where EMAIL = '" + stremail + "' and PASSWORD='" + strpassword + "'";

                clsDbConnector objconn = new clsDbConnector();
                ds = objconn.GetDataSet(strqry);

                if(ds.Tables[0].Rows.Count > 0)
                {
                    lblmessage.Text = "LOGIN SUCCESSFUL";

                    Session["EMAIL"] = stremail;
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    lblmessage.Text = "LOGIN FAILED";
                }
            }
            catch
            {
                throw;
            }
        }
    }
}