using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLOTHING_STORE
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data into the GridView
                BindEventData();
            }
        }

        protected void BindEventData()
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


    }
}