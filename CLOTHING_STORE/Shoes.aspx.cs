using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CLOTHING_STORE
{
    public partial class Shoes : System.Web.UI.Page
    {
        // Property to store product data
        protected DataTable ProductsDataTable { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Call a method to fetch product data
                PopulateProductData();
            }
        }

        protected void PopulateProductData()
        {
            // Initialize ProductsDataTable
            ProductsDataTable = new DataTable();

            // Connection string
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            // SQL query to fetch product data
            string query = "SELECT Product_Id, ProductName, UnitPrice FROM Products";

            // Create a connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Open the connection
                connection.Open();

                // Execute the command and fetch data into ProductsDataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(ProductsDataTable);
                }
            }

            // Add the 'ImageUrl' column to the DataTable
            ProductsDataTable.Columns.Add("ImageUrl", typeof(string));

            // Now you can populate the 'ImageUrl' column with the appropriate image URLs for each product
            foreach (DataRow row in ProductsDataTable.Rows)
            {
                // Assuming you have a method to get the image URL based on the product ID
                string imageUrl = GetImageUrl(Convert.ToInt32(row["Product_Id"]));
                row["ImageUrl"] = imageUrl;
            }
        }

        // Method to retrieve image URL based on product ID
        protected string GetImageUrl(int productId)
        {
            // Implement logic to fetch image URL based on the product ID
            // For example:
            // return "images/shoes" + productId + ".jpg";

            // Placeholder return statement (replace with actual logic)
            return "images/shoes" + productId + ".jpg";
        }
    }
}
