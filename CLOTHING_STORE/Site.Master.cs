using System;
using System.Web;
using System.Web.Security;

namespace CLOTHING_STORE
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Perform logout actions here
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            // Redirect the user to the login page
            Response.Redirect("~/WelcomePage.aspx");
        }
    }
}
