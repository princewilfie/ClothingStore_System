using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CLOTHING_STORE
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCart();
                DisplayCartContents();
            }
        }

        protected void PopulateCart()
        {
            DataTable cart = (DataTable)Session["Cart"];
            if (cart != null)
            {
                // Check if the "ProductName", "UnitPrice", "Quantity", "TotalPrice", and "ItemId" columns exist, if not, add them
                if (!cart.Columns.Contains("ProductName"))
                {
                    cart.Columns.Add("ProductName", typeof(string));
                }
                if (!cart.Columns.Contains("UnitPrice"))
                {
                    cart.Columns.Add("UnitPrice", typeof(decimal));
                }
                if (!cart.Columns.Contains("Quantity"))
                {
                    cart.Columns.Add("Quantity", typeof(int));
                }
                if (!cart.Columns.Contains("TotalPrice"))
                {
                    cart.Columns.Add("TotalPrice", typeof(decimal));
                }
                if (!cart.Columns.Contains("ItemId"))
                {
                    cart.Columns.Add("ItemId", typeof(int));
                }

                // Assuming you have a method GetProductDetailsById and GetTshirtDetailsById to retrieve product/t-shirt details from their IDs
                foreach (DataRow row in cart.Rows)
                {
                    if (row.Table.Columns.Contains("Product_Id"))
                    {
                        int productId = (int)row["Product_Id"];
                        var productDetails = GetProductDetailsById(productId);
                        row["ProductName"] = productDetails.Item1; // Assuming Item1 is the product name
                        row["UnitPrice"] = productDetails.Item2; // Assuming Item2 is the unit price
                    }
                    else if (row.Table.Columns.Contains("Tshirt_Id"))
                    {
                        int tshirtId = (int)row["Tshirt_Id"];
                        var tshirtDetails = GetTshirtDetailsById(tshirtId);
                        row["ProductName"] = tshirtDetails.Item1; // Assuming Item1 is the product name
                        row["UnitPrice"] = tshirtDetails.Item2; // Assuming Item2 is the unit price
                    }

                    // Calculate total price based on quantity
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
                    row["TotalPrice"] = quantity * unitPrice;
                }

                // Bind the updated DataTable to the GridView
                gvCart.DataSource = cart;
                gvCart.DataBind();
            }
        }

        // Example method to retrieve product details from IDs (replace with your actual implementation)
        private (string, decimal) GetProductDetailsById(int productId)
        {
            string productName;
            decimal unitPrice;

            // Query the database to get the product details based on the product ID
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT ProductName, UnitPrice FROM Products WHERE Product_Id = @ProductId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameter for ProductId
                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Check if there is a result
                    if (reader.Read())
                    {
                        // Retrieve product name and unit price from the database
                        productName = reader["ProductName"].ToString();
                        unitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    }
                    else
                    {
                        // If no result found, set default values
                        productName = "Unknown Product";
                        unitPrice = 0.00m;
                    }
                }
            }

            return (productName, unitPrice);
        }

        // Example method to retrieve t-shirt details from IDs (replace with your actual implementation)
        private (string, decimal) GetTshirtDetailsById(int tshirtId)
        {
            string tshirtName;
            decimal unitPrice;

            // Query the database to get the t-shirt details based on the t-shirt ID
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT TshirtName, UnitPrice FROM Tshirt WHERE Tshirt_Id = @TshirtId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameter for TshirtId
                command.Parameters.AddWithValue("@TshirtId", tshirtId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Check if there is a result
                    if (reader.Read())
                    {
                        // Retrieve t-shirt name and unit price from the database
                        tshirtName = reader["TshirtName"].ToString();
                        unitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    }
                    else
                    {
                        // If no result found, set default values
                        tshirtName = "Unknown T-shirt";
                        unitPrice = 0.00m;
                    }
                }
            }

            return (tshirtName, unitPrice);
        }

        protected void gvCart_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable cart = (DataTable)Session["Cart"];
                cart.Rows.RemoveAt(index);
                Session["Cart"] = cart;
                PopulateCart();
                DisplayCartContents(); // Add this line to update the displayed cart after removal
            }
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            DataTable cart = (DataTable)Session["Cart"];
            if (cart != null && cart.Rows.Count > 0)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
                string insertQuery = "INSERT INTO Orders (ProductName, Quantity, UnitPrice, TotalPrice) VALUES (@ProductName, @Quantity, @UnitPrice, @TotalPrice)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (DataRow row in cart.Rows)
                    {
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ProductName", (string)row["ProductName"]);
                            command.Parameters.AddWithValue("@Quantity", (int)row["Quantity"]);
                            command.Parameters.AddWithValue("@UnitPrice", (decimal)row["UnitPrice"]);
                            command.Parameters.AddWithValue("@TotalPrice", (decimal)row["TotalPrice"]);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                // Clear the cart session variable
                Session["Cart"] = null;

                // Redirect to Order.aspx page
                Response.Redirect("Order.aspx");
            }
            else
            {
                // Display a message indicating that the cart is empty
                // You can use a label or any other control for this
            }
        }





        protected void DisplayCartContents()
        {
            DataTable cart = (DataTable)Session["Cart"];
            if (cart != null && cart.Rows.Count > 0)
            {
                // Display the cart contents on the page for debugging
                gvCart.DataSource = cart;
                gvCart.DataBind();
            }
            else
            {
                lblEmptyCartMessage.Text = "Your cart is empty."; // Assuming lblEmptyCartMessage is an ASP.NET label control
            }
        }
    }
}
