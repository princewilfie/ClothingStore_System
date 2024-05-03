using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace CLOTHING_STORE
{
    public partial class AdminPants : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load the existing Pants on page load
                LoadPants();
            }
        }

        protected void btnAddPants_Click(object sender, EventArgs e)
        {
            // Add new Pants to the database
            AddNewPants();

            // Refresh the Pants list
            LoadPants();
        }

        protected void GridViewPants_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeletePants")
            {
                int pantsId = Convert.ToInt32(e.CommandArgument);
                DeletePants(pantsId);
                LoadPants(); // Reload the Pants after deletion
            }
        }

        private void LoadPants()
        {
            // Implement logic to fetch Pants from the database and display them
            var Pants = GetPants();

            // Bind the Pants to the GridView
            GridViewPants.DataSource = Pants;
            GridViewPants.DataBind();
        }

        private void AddNewPants()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            // Get pants details from input controls
            string pantsName = PantsNameTextBox.Text;
            decimal unitPrice = decimal.Parse(UnitPriceTextBox.Text);

            // Call the stored procedure to insert the new pants
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SP_INSERT_PANTS", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PantsName", pantsName);
                command.Parameters.AddWithValue("@UnitPrice", unitPrice);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        private int GetNextPantsId()
        {
            int nextId = 1; // Default value if no Pants exist

            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT MAX(Pants_Id) FROM Pants";

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

        private void DeletePants(int pantsId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "DELETE FROM Pants WHERE Pants_Id = @PantsId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PantsId", pantsId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private List<Pants> GetPants()
        {
            List<Pants> Pants = new List<Pants>();
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Pants_Id, PantsName, UnitPrice FROM Pants";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Pants pants = new Pants
                        {
                            Pants_Id = Convert.ToInt32(reader["Pants_Id"]),
                            PantsName = Convert.ToString(reader["PantsName"]),
                            UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                        };

                        // Format the UnitPrice without trailing zeros
                        pants.UnitPrice = decimal.Round(pants.UnitPrice, 0); // Round to 2 decimal places
                        Pants.Add(pants);
                    }
                    reader.Close();
                }
            }

            return Pants;
        }
    }

    public partial class Pants
    {
        public int Pants_Id { get; set; }
        public string PantsName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
