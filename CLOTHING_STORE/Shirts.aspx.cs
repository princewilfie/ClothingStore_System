﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace CLOTHING_STORE
{
    public partial class Shirts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateTshirtData();
                
            }

            if (Request["__EVENTTARGET"] == "addToCart")
            {
                // Extract T-shirt ID and quantity from the event argument
                string[] args = Request["__EVENTARGUMENT"].Split('|');
                int tshirtId = Convert.ToInt32(args[0]);
                int quantity = Convert.ToInt32(args[1]);

                // Add the T-shirt to the cart session
                DataTable cart = GetCartDataTable();
                AddOrUpdateTshirtCartItem(cart, tshirtId, quantity);
                Session["Cart"] = cart;

                // Redirect to cart page
                Response.Redirect("Cart.aspx");
            }
        }

        protected void PopulateTshirtData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClothingStoreDBConnectionString"].ConnectionString;
            string query = "SELECT Tshirt_Id, TshirtName, UnitPrice, QuantityAvailable, Size FROM Tshirt";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                   
                 

                    TshirtsRepeater.DataSource = reader;
                    TshirtsRepeater.DataBind();
                }
            }
        }



        protected DataTable GetCartDataTable()
        {
            DataTable cart;
            if (Session["Cart"] == null)
            {
                cart = new DataTable();
                cart.Columns.Add("Tshirt_Id", typeof(int)); // Ensure column name matches exactly with what is in the database
                cart.Columns.Add("Quantity", typeof(int));
                cart.PrimaryKey = new DataColumn[] { cart.Columns["Tshirt_Id"] }; // Define primary key on Tshirt_Id
                Session["Cart"] = cart;
            }
            else
            {
                cart = (DataTable)Session["Cart"];
            }
            return cart;
        }

        protected void AddOrUpdateTshirtCartItem(DataTable cart, int tshirtId, int quantity)
        {
            DataRow existingItem = cart.AsEnumerable()
                                        .FirstOrDefault(row => (int)row["Tshirt_Id"] == tshirtId);

            if (existingItem != null)
            {
                // If item already exists in the cart, update the quantity
                existingItem["Quantity"] = (int)existingItem["Quantity"] + quantity;
            }
            else
            {
                // If item does not exist in the cart, add it as a new row
                DataRow newRow = cart.NewRow();
                newRow["Tshirt_Id"] = tshirtId;
                newRow["Quantity"] = quantity;
                cart.Rows.Add(newRow);
            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split('|');
            int tshirtId = Convert.ToInt32(args[0]);
            int quantityAvailable = Convert.ToInt32(args[1]);

            int quantitySelected = Convert.ToInt32(((TextBox)btn.Parent.FindControl("quantity_" + tshirtId)).Text);

            if (quantityAvailable == 0)
            {
                lblMessage.Text = "Sorry, this product is out of stock.";
                lblMessage.Visible = true;
            }
            else if (quantitySelected > quantityAvailable)
            {
                lblMessage.Text = "Selected quantity exceeds available quantity.";
                lblMessage.Visible = true;
            }
            else if (quantitySelected <= 0)
            {
                lblMessage.Text = "Please enter a valid quantity.";
                lblMessage.Visible = true;
            }
            else
            {
                DataTable cart = GetCartDataTable();
                AddOrUpdateTshirtCartItem(cart, tshirtId, quantitySelected);
                Session["Cart"] = cart;
                Response.Redirect("Cart.aspx");
            }
        }

    }
}
