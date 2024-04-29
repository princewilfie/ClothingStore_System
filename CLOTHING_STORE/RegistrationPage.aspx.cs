using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;


namespace CLOTHING_STORE
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            // Fetch user input from the registration form
            string FirstName = firstName.Text.Trim();
            string LastName = lastName.Text.Trim();
            string Email = email.Text.Trim();
            string ContactNumber = contactNumber.Text.Trim();
            string Address = address.Text.Trim();
            string Password = password.Text;
            string ConfirmPassword = confirmPassword.Text;

            if (Password != ConfirmPassword)
            {
                // Passwords do not match, display an error message
                errorMessage.Text = "Passwords do not match.";
                return; // Exit the method
            }

            // Encrypt the password using SHA-256 algorithm
            string encryptedPassword = EncryptPassword(Password);

            // Insert user data into the database
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string storedProcedure = "SP_INSERT_USER_REGISTRATION";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Password", encryptedPassword);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Registration successful
                            // You can redirect the user to a login page or display a success message
                            Response.Redirect("LoginPage.aspx");
                        }
                        else
                        {
                            // Registration failed
                            // You can display an error message to the user
                        }
                    }
                    catch (Exception ex)
                    {   
                        // Handle any exceptions
                        // You can display an error message to the user or log the exception for debugging
                    }
                }


            }
        }

        // Method to encrypt the password using SHA-256 algorithm
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