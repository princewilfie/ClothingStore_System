using System;
using System.Configuration;
using System.Data.SqlClient;

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

            // Insert user data into the database
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "INSERT INTO Users (FirstName, LastName, Email, ContactNumber, Address, Password) VALUES (@FirstName, @LastName, @Email, @ContactNumber, @Address, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Password", Password);

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

    }
}
