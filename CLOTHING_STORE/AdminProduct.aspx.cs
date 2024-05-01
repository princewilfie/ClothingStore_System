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
                string query = "SELECT Product_Id, ProductName, UnitPrice FROM Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Product_Id = Convert.ToInt32(reader["Product_Id"]),
                            ProductName = Convert.ToString(reader["ProductName"]),
                            UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                        };

                        // Format the UnitPrice without trailing zeros
                        product.UnitPrice = decimal.Round(product.UnitPrice, 0); // Round to 2 decimal places
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
                string query = "INSERT INTO Products (Product_Id, ProductName, UnitPrice) VALUES (@Product_Id, @ProductName, @UnitPrice)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Product_Id", GetNextProductId()); // Get the next available Product_Id
                command.Parameters.AddWithValue("@ProductName", productNameTextBox.Text);
                command.Parameters.AddWithValue("@UnitPrice", decimal.Parse(unitPriceTextBox.Text));

                connection.Open();
                command.ExecuteNonQuery();
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
    }

    public class Product
    {
        public int Product_Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
