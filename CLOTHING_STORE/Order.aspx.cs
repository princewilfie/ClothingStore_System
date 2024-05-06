using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CLOTHING_STORE
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayOrderDetails();
            }
        }

        protected void DisplayOrderDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string selectQuery = "SELECT ProductName, Quantity, UnitPrice, TotalPrice FROM Orders";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        DataTable orderDetails = new DataTable();
                        orderDetails.Load(reader);

                        gvOrderDetails.DataSource = orderDetails;
                        gvOrderDetails.DataBind();

                        lblMessage.Text = ""; // Clear any previous message
                    }
                    else
                    {
                        lblMessage.Text = "No items in the order.";
                    }
                }
            }
        }


    }
}
