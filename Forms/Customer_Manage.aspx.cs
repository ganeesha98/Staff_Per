using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using System.Configuration;

namespace Staff_Purchase_.Forms
{
    public partial class Customer_Manage : System.Web.UI.Page
    {
        private List<DataItem> YourDataList
        {
            get
            {
                if (ViewState["YourDataList"] == null)
                {
                    ViewState["YourDataList"] = new List<DataItem>();
                }
                return (List<DataItem>)ViewState["YourDataList"];
            }
            set { ViewState["YourDataList"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the current date and time from the database or server.
            DateTime dt1 = DateTime.Now;

            // Get the valid login user name from the default.aspx.cs code btnLogin_Click() function.
            string validUsername = (string)System.Web.HttpContext.Current.Session["ValidUsername"];

            // Load the user data from the database when the page is loaded
            if (!IsPostBack) // Ensure that the code is executed only on the initial page load, not on postbacks
            {

                LoadSupData();
            }
            {
               // LoadSupData1();
            }

            {
                // Bind GridView with stored data
                BindGridView();

            }

        }

        private void BindGridView()
        {
            // Bind GridView with the stored data
            //GridView1.DataSource = YourDataList;
            //GridView1.DataBind();
        }

        private void LoadSupData()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string query = "SELECT [Branch_Code],[Loc_Name],[Loc_Type] FROM [StaffPurchase].[dbo].[T_Mas_Location]";
            string query = "SELECT Customer_ID AS [Code],Customer_Name AS [Name] FROM [T_Mas_Customer] where Status=1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        GridView5.DataSource = reader;
                        GridView5.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions here
                        string errorMessage = "An error occurred while fetching data. Please try again later.";

                        // Display the error message to the user
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "errorAlert", $"alert('{errorMessage}');", true);
                    }

                }
            }

        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Assuming you have a connection string named "ConnectionString"
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Delete records from T_Link_BranchCustomer table
                string deleteLinkBranchCustomerQuery = "DELETE FROM [T_Link_BranchCustomer] WHERE customer_ID = @CustomerID";

                using (SqlCommand cmdDeleteLinkBranchCustomer = new SqlCommand(deleteLinkBranchCustomerQuery, connection))
                {
                    cmdDeleteLinkBranchCustomer.Parameters.AddWithValue("@CustomerID", TextBox10.Text);
                    cmdDeleteLinkBranchCustomer.ExecuteNonQuery();
                }

                // Delete records from T_Mas_CreditCustomer table
                string deleteCreditCustomerQuery = "DELETE FROM [T_Mas_CreditCustomer] WHERE customer_ID = @CustomerID";

                using (SqlCommand cmdDeleteCreditCustomer = new SqlCommand(deleteCreditCustomerQuery, connection))
                {
                    cmdDeleteCreditCustomer.Parameters.AddWithValue("@CustomerID", TextBox10.Text);
                    cmdDeleteCreditCustomer.ExecuteNonQuery();
                }

                // Update records in T_Mas_Customer table (setting Status to 0)
                string updateCustomerQuery = "UPDATE [T_Mas_Customer] SET Status = 0 WHERE customer_ID = @CustomerID";

                using (SqlCommand cmdUpdateCustomer = new SqlCommand(updateCustomerQuery, connection))
                {
                    cmdUpdateCustomer.Parameters.AddWithValue("@CustomerID", TextBox10.Text);
                    int rowsAffected = cmdUpdateCustomer.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Records deleted successfully
                        lblErrorMessage.Text = "Customer deleted successfully.";

                        // Show an alert to the user
                        string alertScript = "alert('Customer deleted successfully.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "DeleteSuccess", alertScript, true);

                        // Reload the page using Response.Redirect
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    else
                    {
                        // No matching records found
                        lblErrorMessage.Text = "No matching customer found for deletion.";

                        // Show an alert to the user
                        string alertScript = "alert('No matching customer found for deletion.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "DeleteError", alertScript, true);

                        // Reload the page using Response.Redirect
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }


                    // Reload the page using Response.Redirect
                    Response.Redirect(Request.Url.AbsoluteUri );

                    // Insert a log entry for the save action
                    InsertLogEntry(TextBox11.Text + TextBox10.Text + ", Customer Deleted.");
                }
            }
        }


        /*protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Assuming you have a connection string named "ConnectionString"
            string connectionString = "Data Source=CCPHIT-LASANLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Delete records from T_Link_BranchCustomer table
                string deleteLinkBranchCustomerQuery = "DELETE FROM [T_Link_BranchCustomer] WHERE customer_ID = @CustomerID";

                using (SqlCommand cmdDeleteLinkBranchCustomer = new SqlCommand(deleteLinkBranchCustomerQuery, connection))
                {
                    cmdDeleteLinkBranchCustomer.Parameters.AddWithValue("@CustomerID", TextBox10.Text);
                    cmdDeleteLinkBranchCustomer.ExecuteNonQuery();
                }

                // Delete records from T_Mas_CreditCustomer table
                string deleteCreditCustomerQuery = "DELETE FROM [T_Mas_CreditCustomer] WHERE customer_ID = @CustomerID";

                using (SqlCommand cmdDeleteCreditCustomer = new SqlCommand(deleteCreditCustomerQuery, connection))
                {
                    cmdDeleteCreditCustomer.Parameters.AddWithValue("@CustomerID", TextBox10.Text);
                    cmdDeleteCreditCustomer.ExecuteNonQuery();
                }

                // Update records in T_Mas_Customer table (setting Status to 0)
                string updateCustomerQuery = "UPDATE [T_Mas_Customer] SET Status = 0 WHERE customer_ID = @CustomerID";

                using (SqlCommand cmdUpdateCustomer = new SqlCommand(updateCustomerQuery, connection))
                {
                    cmdUpdateCustomer.Parameters.AddWithValue("@CustomerID", TextBox10.Text);
                    int rowsAffected = cmdUpdateCustomer.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Records deleted successfully
                        lblErrorMessage.Text = "Customer deleted successfully.";

                        // Show an alert to the user
                        string alertScript = "alert('Customer deleted successfully.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "DeleteSuccess", alertScript, true);

                        // Reload the page using JavaScript
                        //string reloadScript = "window.location.reload();";
                        //ClientScript.RegisterStartupScript(this.GetType(), "ReloadPage", reloadScript, true);
                    }
                    else
                    {

                        // Redirect to the same page to reload it
                        Response.Redirect(Request.Url.AbsoluteUri); 

                        // No matching records found
                        lblErrorMessage.Text = "No matching customer found for deletion.";

                        // Show an alert to the user
                        string alertScript = "alert('No matching customer found for deletion.');";
                        //ClientScript.RegisterStartupScript(this.GetType(), "DeleteSuccess", alertScript, true);
                    }

                    // Insert a log entry for the save action
                    InsertLogEntry( TextBox11.Text + TextBox10.Text + ", Customer Deleted.");
                }
            }
        }
        */

        protected void btnExit_Click(object sender, EventArgs e)
        {
            // Implement the logic to redirect to the dashboard.aspx
            Response.Redirect("~/Dashboard.aspx");
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the index of the row being deleted
            int rowIndex = e.RowIndex;

            // Remove the item from YourDataList based on the index
            YourDataList.RemoveAt(rowIndex);

            // Rebind GridView with updated data
            BindGridView();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void InsertLogEntry(string description)
        {
            // Assuming you have a connection string named "ConnectionString"
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Get the current user's username (you need to replace this with your actual method of getting the username)
                string currentUser = "Admin"; // Replace with your logic to get the current user

                // Get the current date and time
                DateTime currentDate = DateTime.Now;
                string dateString = currentDate.ToString("yyyy-MM-dd");
                string timeString = currentDate.ToString("HH:mm:ss");

                // Call the stored procedure
                string insertLogProcedure = "InsertCustomerLog";
                using (SqlCommand cmd = new SqlCommand(insertLogProcedure, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@sUser", currentUser);
                    cmd.Parameters.AddWithValue("@sDate", dateString);
                    cmd.Parameters.AddWithValue("@sTime", timeString);
                    cmd.Parameters.AddWithValue("@Description", description);

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();
                }
            }
        }   
    }

}