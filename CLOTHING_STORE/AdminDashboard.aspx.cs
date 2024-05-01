using System;
using System.Web.UI;

namespace CLOTHING_STORE
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Redirect to AdminLogin.aspx
            Response.Redirect("AdminLogin.aspx");
        }
    }
}
