using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLOTHING_STORE
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check if the entered credentials are correct
            if (username == "admin" && password == "1234")
            {
                // Redirect to admin panel
                Response.Redirect("AdminDashBoard.aspx");
            }
            else
            {
                // Display error message
                lblMessage.Text = "Invalid username or password.";
            }
        }
    }
}