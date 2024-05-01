using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CLOTHING_STORE
{
    public partial class AdminUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data into the GridView
                BindUserData();
            }
        }

        protected void BindUserData()
        {
            // Connection string
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            // Stored procedure name
            string storedProcedure = "SP_GET_USERS_ADMINPANEL";

            // Create a connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                // Specify that it's a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                // Open the connection
                connection.Open();

                // Execute the command and fetch data into a DataTable
                DataTable dataTable = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }

                // Bind the DataTable to the GridView
                UsersGridView.DataSource = dataTable;
                UsersGridView.DataBind();
            }
        }

        protected void UsersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                // Extract the UserId from the CommandArgument
                int userId = Convert.ToInt32(e.CommandArgument);

                // Your delete logic here, you can call a stored procedure or directly delete from the database
                // For example:
                // DeleteUser(userId);

                // Refresh the GridView after deletion
                BindUserData();
            }
        }
    }
}
