using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLOTHING_STORE
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCounts();
            }
        }
        private void PopulateCounts()
        {
            lblUserCount.Text = GetCount("Users").ToString();
            lblProductCount.Text = GetCount("Products").ToString();
            lblPantsCount.Text = GetCount("Pants").ToString();
            lblOrderCount.Text = GetCount("Orders").ToString();
            lblTshirtCount.Text = GetCount("Tshirt").ToString();
        }

        private int GetCount(string tableName)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\PRACTICE\\CLOTHING_STORE\\CLOTHING_STORE\\App_Data\\ClothingStoreDB.mdf;Integrated Security=True"; // Replace with your actual connection string
            string query = "SELECT COUNT(*) FROM " + tableName;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count;
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Redirect to AdminLogin.aspx
            Response.Redirect("AdminLogin.aspx");
        }


        protected void btnExportUsers_Click(object sender, EventArgs e)
        {
            ExportToCSV("Users");
        }

        protected void btnExportProducts_Click(object sender, EventArgs e)
        {
            ExportToCSV("Products");
        }

        protected void btnExportPants_Click(object sender, EventArgs e)
        {
            ExportToCSV("Pants");
        }

        protected void btnExportOrders_Click(object sender, EventArgs e)
        {
            ExportToCSV("Orders");
        }

        protected void btnExportTshirt_Click(object sender, EventArgs e)
        {
            ExportToCSV("Tshirt");
        }

        protected void UsersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Implement your logic to handle row deletion here
        }

        protected void UsersGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Implement your logic to handle row editing here
        }


        private void ExportToCSV(string tableName)
        {
            // Assuming you have a method to get the DataTable for each entity
            DataTable dt = GetDataTable(tableName);

            if (dt != null && dt.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + tableName + ".csv");
                Response.Charset = "";
                Response.ContentType = "application/text";

                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    sb.Append(dt.Columns[k].ColumnName + ',');
                }
                sb.Append("\r\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + ',');
                    }
                    sb.Append("\r\n");
                }
                Response.Output.Write(sb.ToString());
                Response.Flush();
                Response.End();
            }
        }

        private DataTable GetDataTable(string tableName)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\PRACTICE\\CLOTHING_STORE\\CLOTHING_STORE\\App_Data\\ClothingStoreDB.mdf;Integrated Security=True"; // Replace with your actual connection string
            string query = "";

            switch (tableName)
            {
                case "Users":
                    query = "SELECT UserId, FirstName, LastName, Email, ContactNumber, Address FROM Users";
                    break;
                case "Products":
                    query = "SELECT Product_Id, Category_Id, ProductName, UnitPrice, QuantityAvailable, Size FROM Products";
                    break;
                case "Pants":
                    query = "SELECT Pants_Id,  PantsName, UnitPrice  FROM Pants ";
                    break;
                case "Orders":
                    query = "SELECT OrderId, ProductName, Quantity, UnitPrice, TotalPrice, Size FROM Orders";
                    break;
                case "Tshirt":
                    query = "SELECT Tshirt_Id, Category_Id, TshirtName, UnitPrice, QuantityAvailable, Size FROM Tshirt";
                    break;
                default:
                    return null;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }

        }
    }
}