using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace CLOTHING_STORE
{
    public partial class Pants1 : System.Web.UI.Page
    {
        // Define a public property to store the Pants DataTable
        protected DataTable PantsDataTable { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Call a method to fetch pants data
                PopulatePantsData();
            }
        }

        protected void PopulatePantsData()
        {
            // Initialize PantsDataTable
            PantsDataTable = new DataTable();

            // Connection string
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            // SQL query to fetch pants data
            string query = "SELECT Pants_Id, PantsName, UnitPrice FROM Pants";

            // Create a connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Open the connection
                connection.Open();

                // Execute the command and fetch data into PantsDataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(PantsDataTable);
                }
            }

            // Add the 'ImageUrl' column to the DataTable
            PantsDataTable.Columns.Add("ImageUrl", typeof(string));

            // Now you can populate the 'ImageUrl' column with the appropriate image URLs for each pant
            foreach (DataRow row in PantsDataTable.Rows)
            {
                // Assuming you have a method to get the image URL based on the pant ID
                string imageUrl = GetPantImageUrl(Convert.ToInt32(row["Pants_Id"]));
                row["ImageUrl"] = imageUrl;
            }
        }

        // Method to retrieve image URL based on pant ID
        protected string GetPantImageUrl(int pantId)
        {
            // Implement logic to fetch image URL based on the pant ID
            // For example:
            // return "images/pants/pant" + pantId + ".jpg";

            // Placeholder return statement (replace with actual logic)
            return "images/pants" + pantId + ".jpg";
        }
    }
}
