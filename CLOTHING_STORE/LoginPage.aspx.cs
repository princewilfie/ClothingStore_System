using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CLOTHING_STORE
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Fetch user input from the login form
            string Email = email.Value.Trim();
            string Password = password.Value;

            // Check if the email and password are valid
            if (IsValidUser(Email, Password))
            {
                // Redirect to the default page
                Response.Redirect("Default.aspx");
            }
            else
            {
                // Display error message for invalid credentials
                errorMessage.Text = "Invalid email or password. Please try again.";
            }
        }

        // Method to validate user credentials
        private bool IsValidUser(string email, string password)
        {
            // Fetch user data from the database based on the provided email
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT Password FROM Users WHERE Email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the command and fetch the password from the database
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            // Password found in the database
                            string storedPassword = result.ToString();

                            // Compare the stored password with the provided password
                            if (storedPassword == password)
                            {
                                // Passwords match, user is authenticated
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        // You can display an error message or log the exception for debugging
                    }
                }
            }

            // Either user not found or password doesn't match
            return false;
        }
    }
}
