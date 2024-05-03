using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace CLOTHING_STORE
{
    public partial class AdminTshirt : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load the existing Tshirts on page load
                LoadTshirts();
            }
        }

        protected void btnAddTshirt_Click(object sender, EventArgs e)
        {
            // Add new Tshirt to the database
            AddNewTshirt();

            // Refresh the Tshirts list
            LoadTshirts();
        }

        protected void GridViewTshirts_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteTshirt")
            {
                int tshirtId = Convert.ToInt32(e.CommandArgument);
                DeleteTshirt(tshirtId);
                LoadTshirts(); // Reload the Tshirts after deletion
            }
        }

        private void LoadTshirts()
        {
            // Implement logic to fetch Tshirts from the database and display them
            var Tshirts = GetTshirts();

            // Bind the Tshirts to the GridView
            GridViewTshirts.DataSource = Tshirts;
            GridViewTshirts.DataBind();
        }

        private void AddNewTshirt()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            // Get tshirt details from input controls
            string tshirtName = TshirtNameTextBox.Text;
            decimal unitPrice = decimal.Parse(UnitPriceTextBox.Text);

            // Call the stored procedure to insert the new tshirt
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SP_INSERT_TSHIRT", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TshirtName", tshirtName);
                command.Parameters.AddWithValue("@UnitPrice", unitPrice);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private int GetNextTshirtId()
        {
            int nextId = 1; // Default value if no Tshirts exist

            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT MAX(Tshirt_Id) FROM Tshirt";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    nextId = Convert.ToInt32(result) + 1;
                }
            }

            return nextId;
        }


        private void DeleteTshirt(int tshirtId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "DELETE FROM Tshirt WHERE Tshirt_Id = @TshirtId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TshirtId", tshirtId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private List<Tshirt> GetTshirts()
        {
            List<Tshirt> Tshirts = new List<Tshirt>();
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Tshirt_Id, TshirtName, UnitPrice FROM Tshirt";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Tshirt tshirt = new Tshirt
                        {
                            Tshirt_Id = Convert.ToInt32(reader["Tshirt_Id"]),
                            TshirtName = Convert.ToString(reader["TshirtName"]),
                            UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                        };

                        // Format the UnitPrice without trailing zeros
                        tshirt.UnitPrice = decimal.Round(tshirt.UnitPrice, 0); // Round to 2 decimal places
                        Tshirts.Add(tshirt);
                    }
                    reader.Close();
                }
            }

            return Tshirts;
        }
    }

    public class Tshirt
    {
        public int Tshirt_Id { get; set; }
        public string TshirtName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
