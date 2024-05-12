using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Linq;

namespace CLOTHING_STORE
{
    public partial class Shoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProductData();
            }

            if (Request["__EVENTTARGET"] == "addToCart")
            {
                // Extract product ID and quantity from the event argument
                string[] args = Request["__EVENTARGUMENT"].Split('|');
                int productId = Convert.ToInt32(args[0]);
                int quantity = Convert.ToInt32(args[1]);

                // Add the product to the cart session
                DataTable cart = GetCartDataTable();
                AddOrUpdateProductCartItem(cart, productId, quantity);
                Session["Cart"] = cart;

                // Redirect to cart page
                Response.Redirect("Cart.aspx");
            }
        }

        protected void PopulateProductData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT Product_Id, ProductName, UnitPrice FROM Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    ProductsRepeater.DataSource = reader;
                    ProductsRepeater.DataBind();
                }
            }
        }

        protected DataTable GetCartDataTable()
        {
            DataTable cart;
            if (Session["Cart"] == null)
            {
                cart = new DataTable();
                cart.Columns.Add("Product_Id", typeof(int));
                cart.Columns.Add("Quantity", typeof(int));
                cart.PrimaryKey = new DataColumn[] { cart.Columns["Product_Id"] }; // Define primary key on Product_Id
                Session["Cart"] = cart;
            }
            else
            {
                cart = (DataTable)Session["Cart"];
            }
            return cart;
        }

        protected void AddOrUpdateProductCartItem(DataTable cart, int productId, int quantity)
        {
            DataRow existingItem = cart.AsEnumerable()
                                        .FirstOrDefault(row => (int)row["Product_Id"] == productId);

            if (existingItem != null)
            {
                // If item already exists in the cart, update the quantity
                existingItem["Quantity"] = (int)existingItem["Quantity"] + quantity;
            }
            else
            {
                // If item does not exist in the cart, add it as a new row
                DataRow newRow = cart.NewRow();
                newRow["Product_Id"] = productId;
                newRow["Quantity"] = quantity;
                cart.Rows.Add(newRow);
            }
        }



    }
}
