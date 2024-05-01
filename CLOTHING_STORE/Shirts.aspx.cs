using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace CLOTHING_STORE
{
    public partial class Shirts : Page
    {
        // Define a public property to store the T-shirts DataTable
        protected DataTable TshirtsDataTable { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Call a method to fetch T-shirt data
                PopulateTshirtData();
            }
        }

        protected void PopulateTshirtData()
        {
            // Initialize TshirtsDataTable
            TshirtsDataTable = new DataTable();

            // Connection string
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            // SQL query to fetch T-shirt data
            string query = "SELECT Tshirt_Id, TshirtName, UnitPrice FROM Tshirt";

            // Create a connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Open the connection
                connection.Open();

                // Execute the command and fetch data into TshirtsDataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(TshirtsDataTable);
                }
            }

            // Add the 'ImageUrl' column to the DataTable
            TshirtsDataTable.Columns.Add("ImageUrl", typeof(string));

            // Now you can populate the 'ImageUrl' column with the appropriate image URLs for each T-shirt
            foreach (DataRow row in TshirtsDataTable.Rows)
            {
                // Assuming you have a method to get the image URL based on the T-shirt ID
                string imageUrl = GetTshirtImageUrl(Convert.ToInt32(row["Tshirt_Id"]));
                row["ImageUrl"] = imageUrl;
            }
        }

        // Method to retrieve image URL based on T-shirt ID
        protected string GetTshirtImageUrl(int tshirtId)
        {
            // Implement logic to fetch image URL based on the T-shirt ID
            // For example:
            // return "images/tshirts/tshirt" + tshirtId + ".jpg";

            // Placeholder return statement (replace with actual logic)
            return "images/tshirt" + tshirtId + ".jpg";
        }
    }
}
