using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

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

                            // Encrypt the provided password for comparison
                            string encryptedPassword = EncryptPassword(password);

                            // Compare the stored encrypted password with the provided encrypted password
                            if (storedPassword == encryptedPassword)
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


        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
