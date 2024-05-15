using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLOTHING_STORE
{
    public partial class AdminProduct : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load the existing products on page load
                LoadProducts();
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            // Add new item to the database
            AddNewItem();

            // Refresh the products list
            LoadProducts();
            int newProductId = GetNextProductId();

            // Fetch the newly added product and pass it to Pants page
            FetchAndPassNewProduct();
        }

        protected void GridViewProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteProduct")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                DeleteProduct(productId);
                LoadProducts(); // Reload the products after deletion
            }
        }

        private void LoadProducts()
        {
            // Implement logic to fetch products from the database and display them
            var products = GetProducts();

            // Bind the products to the GridView
            GridViewProducts.DataSource = products;
            GridViewProducts.DataBind();
        }

        private List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Product_Id, ProductName, UnitPrice, QuantityAvailable, Size FROM Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Product_Id = Convert.ToInt32(reader["Product_Id"]),
                            ProductName = reader["ProductName"] != DBNull.Value ? Convert.ToString(reader["ProductName"]) : string.Empty,
                            UnitPrice = reader["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(reader["UnitPrice"]) : 0m,
                            QuantityAvailable = reader["QuantityAvailable"] != DBNull.Value ? Convert.ToInt32(reader["QuantityAvailable"]) : 0,
                            Size = reader["Size"] != DBNull.Value ? Convert.ToString(reader["Size"]) : string.Empty
                        };

                        // Optionally format UnitPrice
                        product.UnitPrice = decimal.Round(product.UnitPrice, 0); // Round to 0 decimal places
                        products.Add(product);
                    }

                    reader.Close();
                }
            }

            return products;
        }




        private void AddNewItem()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (Product_Id, ProductName, UnitPrice, QuantityAvailable, Size) VALUES (@Product_Id, @ProductName, @UnitPrice, @QuantityAvailable, @Size)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_Id", GetNextProductId()); // Provide a value for Product_Id
                    command.Parameters.AddWithValue("@ProductName", productNameTextBox.Text);
                    command.Parameters.AddWithValue("@UnitPrice", decimal.Parse(unitPriceTextBox.Text));
                    command.Parameters.AddWithValue("@QuantityAvailable", int.Parse(quantityTextBox.Text));
                    command.Parameters.AddWithValue("@Size", sizeTextBox.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }



        private void DeleteProduct(int productId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "DELETE FROM Products WHERE Product_Id = @ProductId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductId", productId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private int GetNextProductId()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            int nextProductId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(Product_Id), 0) + 1 FROM Products"; // Get the maximum existing Product_Id and add 1
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                nextProductId = (int)command.ExecuteScalar();
            }

            return nextProductId;
        }

        private void FetchAndPassNewProduct()
        {
            // Fetch the newly added product
            string productName = productNameTextBox.Text;

            // Pass the product name to the Pants page using Session
            Session["NewProductName"] = productName;
        }

        protected void btnUpdateItem_Click(object sender, EventArgs e)
        {
           
        }

        private void UpdateProduct(int productId, string productName, decimal unitPrice, int quantityAvailable, string size)
        {
            // Implement logic to update the product in the database
            // For demonstration purposes, you can use a placeholder method
            // Replace this with your actual logic to update the product
            // For example:
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET ProductName = @ProductName, UnitPrice = @UnitPrice, QuantityAvailable = @QuantityAvailable, Size = @Size WHERE Product_Id = @ProductId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    command.Parameters.AddWithValue("@QuantityAvailable", quantityAvailable);
                    command.Parameters.AddWithValue("@Size", size);
                    command.Parameters.AddWithValue("@ProductId", productId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }




        public class Product
        {
            public int Product_Id { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int QuantityAvailable { get; set; }
            public string Size { get; set; }
        }

    }
}
