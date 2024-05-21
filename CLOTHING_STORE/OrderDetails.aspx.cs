using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CLOTHING_STORE
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int orderId;
                if (int.TryParse(Request.QueryString["OrderId"], out orderId))
                {
                    DisplayOrderDetails(orderId);
                }
                else
                {
                    lblMessage.Text = "Invalid Order ID.";
                }
            }
        }

        protected void DisplayOrderDetails(int orderId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string selectQuery = "SELECT ProductName, Quantity, UnitPrice, TotalPrice, Size FROM Orders WHERE OrderId = @OrderId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@OrderId", orderId);

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
                        lblMessage.Text = "No items found for this order.";
                    }
                }
            }

            // Debugging statements
            lblMessage.Text += "<br /> OrderId: " + orderId.ToString();
        }

    }
}
