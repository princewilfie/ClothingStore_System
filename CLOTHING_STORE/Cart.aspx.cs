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
                if (!cart.Columns.Contains("Size"))
                {
                    cart.Columns.Add("Size", typeof(string)); // Add Size column if it doesn't exist
                }


                foreach (DataRow row in cart.Rows)
                {
                    if (row.Table.Columns.Contains("Product_Id"))
                    {
                        int productId = (int)row["Product_Id"];
                        var productDetails = GetProductDetailsById(productId);
                        row["ProductName"] = productDetails.Item1;
                        row["UnitPrice"] = productDetails.Item2;
                        string size = GetSizeById(productId); // Assuming you have a method to fetch size by product ID
                        row["Size"] = size;
                    }
                    else if (row.Table.Columns.Contains("Tshirt_Id"))
                    {
                        int tshirtId = (int)row["Tshirt_Id"];
                        var tshirtDetails = GetTshirtDetailsById(tshirtId);
                        row["ProductName"] = tshirtDetails.Item1;
                        row["UnitPrice"] = tshirtDetails.Item2;
                        string size = GetSizeByTshirtId(tshirtId); // Get size by t-shirt ID
                        row["Size"] = size;
                    }

                    int quantity = Convert.ToInt32(row["Quantity"]);
                    decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
                    row["TotalPrice"] = quantity * unitPrice;
                }


                gvCart.DataSource = cart;
                gvCart.DataBind();
            }
        }

        private (string, decimal) GetProductDetailsById(int productId)
        {
            string productName;
            decimal unitPrice;

            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT ProductName, UnitPrice FROM Products WHERE Product_Id = @ProductId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        productName = reader["ProductName"].ToString();
                        unitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    }
                    else
                    {
                        productName = "Unknown Product";
                        unitPrice = 0.00m;
                    }
                }
            }

            return (productName, unitPrice);
        }

        private (string, decimal) GetTshirtDetailsById(int tshirtId)
        {
            string tshirtName;
            decimal unitPrice;

            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT TshirtName, UnitPrice FROM Tshirt WHERE Tshirt_Id = @TshirtId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TshirtId", tshirtId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tshirtName = reader["TshirtName"].ToString();
                        unitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    }
                    else
                    {
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
                DisplayCartContents();
            }
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable cart = (DataTable)Session["Cart"];
                if (cart != null && cart.Rows.Count > 0)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
                    string productInsertQuery = "INSERT INTO Orders (ProductName, Quantity, UnitPrice, TotalPrice, Size) VALUES (@ProductName, @Quantity, @UnitPrice, @TotalPrice, @Size)";
                    string productUpdateQuery = "UPDATE Products SET QuantityAvailable = QuantityAvailable - @Quantity WHERE Product_Id = @ProductId";
                    string tshirtInsertQuery = "INSERT INTO Orders (ProductName, Quantity, UnitPrice, TotalPrice, Size) VALUES (@ProductName, @Quantity, @UnitPrice, @TotalPrice, @Size)";
                    string tshirtUpdateQuery = "UPDATE Tshirt SET QuantityAvailable = QuantityAvailable - @Quantity WHERE Tshirt_Id = @TshirtId";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        foreach (DataRow row in cart.Rows)
                        {
                            // Determine whether the item is a product or a T-shirt and execute the appropriate SQL queries
                            if (row.Table.Columns.Contains("Product_Id"))
                            {
                                // Product item
                                using (SqlCommand command = new SqlCommand(productInsertQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@ProductName", (string)row["ProductName"]);
                                    command.Parameters.AddWithValue("@Quantity", (int)row["Quantity"]);
                                    command.Parameters.AddWithValue("@UnitPrice", (decimal)row["UnitPrice"]);
                                    command.Parameters.AddWithValue("@TotalPrice", (decimal)row["TotalPrice"]);
                                    command.Parameters.AddWithValue("@Size", (string)row["Size"]);

                                    command.ExecuteNonQuery();
                                }

                                // Update quantity available for products
                                using (SqlCommand updateCommand = new SqlCommand(productUpdateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Quantity", (int)row["Quantity"]);
                                    updateCommand.Parameters.AddWithValue("@ProductId", (int)row["Product_Id"]);

                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                            else if (row.Table.Columns.Contains("Tshirt_Id"))
                            {
                                // T-shirt item
                                using (SqlCommand command = new SqlCommand(tshirtInsertQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@ProductName", (string)row["ProductName"]);
                                    command.Parameters.AddWithValue("@Quantity", (int)row["Quantity"]);
                                    command.Parameters.AddWithValue("@UnitPrice", (decimal)row["UnitPrice"]);
                                    command.Parameters.AddWithValue("@TotalPrice", (decimal)row["TotalPrice"]);
                                    command.Parameters.AddWithValue("@Size", (string)row["Size"]);

                                    command.ExecuteNonQuery();
                                }

                                // Update quantity available for T-shirts
                                using (SqlCommand updateCommand = new SqlCommand(tshirtUpdateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Quantity", (int)row["Quantity"]);
                                    updateCommand.Parameters.AddWithValue("@TshirtId", (int)row["Tshirt_Id"]);

                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    // Clear the cart session variable
                    Session["Cart"] = null;

                    // Redirect to Order.aspx page
                    Response.Redirect("~/Order.aspx");
                }
                else
                {
                    lblEmptyCartMessage.Text = "Your cart is empty.";
                    lblEmptyCartMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblEmptyCartMessage.Text = "An error occurred: " + ex.Message;
                lblEmptyCartMessage.Visible = true;
                System.Diagnostics.Debug.WriteLine("Checkout_Click Exception: " + ex.Message);
            }
        }


        protected void DisplayCartContents()
        {
            DataTable cart = (DataTable)Session["Cart"];
            if (cart != null && cart.Rows.Count > 0)
            {
                gvCart.DataSource = cart;
                gvCart.DataBind();
                lblEmptyCartMessage.Visible = false;
            }
            else
            {
                lblEmptyCartMessage.Text = "Your cart is empty.";
                lblEmptyCartMessage.Visible = true;
            }
        }

        private string GetSizeById(int productId)
        {
            string size = ""; // Default value

            // Establish your database connection and query to retrieve size based on product ID
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT Size FROM Products WHERE Product_Id = @ProductId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                object result = command.ExecuteScalar();

                // Check if size value is retrieved from the database
                if (result != null)
                {
                    size = result.ToString(); // Assign the retrieved size value
                }
            }

            return size;
        }


        private string GetSizeByTshirtId(int tshirtId)
        {
            string size = ""; // Default value

            // Establish your database connection and query to retrieve size based on t-shirt ID
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT Size FROM Tshirt WHERE Tshirt_Id = @TshirtId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TshirtId", tshirtId);

                connection.Open();
                object result = command.ExecuteScalar();

                // Check if size value is retrieved from the database
                if (result != null)
                {
                    size = result.ToString(); // Assign the retrieved size value
                }
            }

            return size;
        }


    }
}