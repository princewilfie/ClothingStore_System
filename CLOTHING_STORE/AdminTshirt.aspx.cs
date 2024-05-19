using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        protected void GridViewTshirts_RowCommand(object sender, GridViewCommandEventArgs e)
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
            var tshirts = GetTshirts();

            // Bind the Tshirts to the GridView
            GridViewTshirts.DataSource = tshirts;
            GridViewTshirts.DataBind();

            Console.WriteLine("Number of Tshirts in data source: " + tshirts.Count);

        }



        private void AddNewTshirt()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tshirt (Tshirt_Id, TshirtName, UnitPrice, QuantityAvailable, Size) VALUES (@Tshirt_Id, @TshirtName, @UnitPrice, @QuantityAvailable, @Size)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tshirt_Id", GetNextTshirtId());
                    command.Parameters.AddWithValue("@TshirtName", TshirtNameTextBox.Text);
                    command.Parameters.AddWithValue("@UnitPrice", decimal.Parse(UnitPriceTextBox.Text));
                    command.Parameters.AddWithValue("@QuantityAvailable", int.Parse(QuantityTextBox.Text));
                    command.Parameters.AddWithValue("@Size", SizeTextBox.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private int GetNextTshirtId()
        {
            int nextId = 1; // Default value if no Tshirts exist

            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT ISNULL(MAX(Tshirt_Id), 0) + 1 FROM Tshirt"; // Get the maximum existing Tshirt_Id and add 1

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                nextId = (int)command.ExecuteScalar();
            }

            return nextId;
        }

        private void DeleteTshirt(int tshirtId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tshirt WHERE Tshirt_Id = @Tshirt_Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tshirt_Id", tshirtId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private List<Tshirt> GetTshirts()
        {
            List<Tshirt> tshirts = new List<Tshirt>();
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Tshirt_Id, TshirtName, UnitPrice, QuantityAvailable, Size FROM Tshirt";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("TshirtName from database: " + reader["TshirtName"]);



                        Tshirt tshirt = new Tshirt
                        {
                            Tshirt_Id = Convert.ToInt32(reader["Tshirt_Id"]),
                            TshirtName = reader["TshirtName"] != DBNull.Value ? Convert.ToString(reader["TshirtName"]) : string.Empty,
                            UnitPrice = reader["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(reader["UnitPrice"]) : 0m,
                            QuantityAvailable = reader["QuantityAvailable"] != DBNull.Value ? Convert.ToInt32(reader["QuantityAvailable"]) : 0,
                            Size = reader["Size"] != DBNull.Value ? Convert.ToString(reader["Size"]) : string.Empty
                        };

                        Console.WriteLine("TshirtName after conversion: " + tshirt.TshirtName);

                        // Optionally format UnitPrice
                        tshirt.UnitPrice = decimal.Round(tshirt.UnitPrice, 0); // Round to 0 decimal places
                        tshirts.Add(tshirt);
                    }

                    reader.Close();
                }
            }

            return tshirts;
        }



        public class Tshirt
        {
            public int Tshirt_Id { get; set; }
            public string TshirtName { get; set; }
            public decimal UnitPrice { get; set; }
            public int QuantityAvailable { get; set; }
            public string Size { get; set; }
        }
    }
}
