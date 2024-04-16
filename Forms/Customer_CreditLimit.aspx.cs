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
using System.Diagnostics;
using System.Configuration;

namespace Staff_Purchase_.Forms
{
    public partial class Customer_CreditLimit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSupData();
        }


        private void LoadSupData()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string query = "SELECT [Branch_Code],[Loc_Name],[Loc_Type] FROM [StaffPurchase].[dbo].[T_Mas_Location]";
            string query = "SELECT Customer_ID AS [Code],Credit_Limit AS [Limit] FROM [T_Mas_CreditCustomer]";

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



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Assuming you have a connection string named "ConnectionString"
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update Credit_Limit in [T_Mas_CreditCustomer] table
                string updateQuery = "sp_UpdateCreditLimit";

                using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection))
                {
                    cmdUpdate.CommandType = CommandType.StoredProcedure;

                    // Set parameters
                    cmdUpdate.Parameters.AddWithValue("@Customer_ID", TextBox10.Text);
                    cmdUpdate.Parameters.AddWithValue("@Credit_Limit", Convert.ToDecimal(TextBox11.Text));

                    // Execute the stored procedure
                    int rowsAffected = cmdUpdate.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Records updated successfully
                        lblErrorMessage.Text = "Credit Limit updated successfully.";

                        // Insert a log entry for the save action
                        InsertLogEntry(TextBox10.Text + ", Credit Limit Updated.");

                        // Check if the alert has already been shown in this session
                        if (Session["AlertShown"] == null)
                        {
                            // Set the session variable to indicate that the alert has been shown
                            Session["AlertShown"] = true;

                            

                            // Refresh the page with the "alert=updated" parameter appended
                            Response.Redirect(Request.Url.AbsoluteUri + (Request.Url.AbsoluteUri.Contains("?") ? "&" : "?") + "alert=updated");

                            // Register client-side script to display an alert
                            //string alertScript = "alert('Credit Limit updated successfully.');";
                            //ClientScript.RegisterStartupScript(this.GetType(), "UpdateSuccess", alertScript, true);

                        }
                        // Records updated successfully
                        lblErrorMessage.Text = "Credit Limit updated successfully.";
                    }
                    else
                    {
                        

                        // Redirect to the same page to reload it
                        Response.Redirect(Request.Url.AbsoluteUri);

                        // No matching records found
                        lblErrorMessage.Text = "No matching records found for update.";

                        // Refresh the page without modifying the URL further
                        //Response.Redirect(Request.Url.AbsoluteUri + "?alert=updated");
                    }
                }
            }
        }



        /*protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Assuming you have a connection string named "ConnectionString"
            string connectionString = "Data Source=CCPHIT-LASANLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update Credit_Limit in [T_Mas_CreditCustomer] table
                string updateQuery = "sp_UpdateCreditLimit";

                using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection))
                {
                    cmdUpdate.CommandType = CommandType.StoredProcedure;

                    // Set parameters
                    cmdUpdate.Parameters.AddWithValue("@Customer_ID", TextBox10.Text);
                    cmdUpdate.Parameters.AddWithValue("@Credit_Limit", Convert.ToDecimal(TextBox11.Text));

                    // Execute the stored procedure
                    int rowsAffected = cmdUpdate.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Records updated successfully
                        lblErrorMessage.Text = "Credit Limit updated successfully.";

                        // Show an alert to the user
                        string alertScript = "alert('Credit Limit updated successfully.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateSuccess", alertScript, true);

                        // Insert a log entry for the save action
                        InsertLogEntry(TextBox10.Text + ", Credit Limit Updated.");

                        
                    }
                    else
                    {
                        // Refresh the page
                       // Response.Redirect(Request.Url.AbsoluteUri + "?alert=updated");

                        // No matching records found
                        lblErrorMessage.Text = "No matching records found for update.";

                        // Show an alert to the user
                        string alertScript = "alert('Credit Limit updated successfully.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", alertScript, true);

                        // Refresh the page
                        Response.Redirect(Request.Url.AbsoluteUri + "?alert=updated");
                    }
                }
            }
        }
        */

        /*
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Assuming you have a connection string named "ConnectionString"
            string connectionString = "Data Source=CCPHIT-LASANLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update Credit_Limit in [T_Mas_CreditCustomer] table
                string updateQuery = "sp_UpdateCreditLimit";

                using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection))
                {
                    cmdUpdate.CommandType = CommandType.StoredProcedure;

                    // Set parameters
                    cmdUpdate.Parameters.AddWithValue("@Customer_ID", TextBox10.Text);
                    cmdUpdate.Parameters.AddWithValue("@Credit_Limit", Convert.ToDecimal(TextBox11.Text));

                    // Execute the stored procedure
                    int rowsAffected = cmdUpdate.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Records updated successfully
                        lblErrorMessage.Text = "Credit Limit updated successfully.";

                        // Show an alert to the user
                        string alertScript = "alert('Credit Limit updated successfully.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateSuccess", alertScript, true);

                        
                    }

                    else
                    {
                        

                        // No matching records found
                        lblErrorMessage.Text = "No matching records found for update.";

                        // Show an alert to the user
                        string alertScript = "alert('Credit Limit updated successfully.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", alertScript, true);

                        
                    }

                    

                    // Insert a log entry for the save action
                    InsertLogEntry(TextBox10.Text + ", Credit Limit Updated.");
                }

                // Refresh the page
                //Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
        */

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

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard.aspx");
        }
    }
}