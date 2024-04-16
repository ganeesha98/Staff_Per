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
    public partial class OutletChange : System.Web.UI.Page
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
                // Initialize DataTable in ViewState
                DataTable dt = new DataTable();
                dt.Columns.Add("Branch_Code", typeof(string));
                dt.Columns.Add("Customer_id", typeof(string));
                dt.Columns.Add("Fixed", typeof(string));

                ViewState["GridView2Data"] = dt;
            }

            {

                LoadSupData();
            }
            {
                LoadSupData1();
            }

            {
                // Bind GridView with stored data
                BindGridView();

            }

        }




        protected void btnadd_Click(object sender, EventArgs e)
        {
            // Get values from controls
            string branchCode = TextBox13.Text.Trim();
            string customerID = TextBox10.Text.Trim();
            string fixedStatus = CheckBox1.Checked ? "Y" : "N";

            // Your connection string
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Your SQL query to insert data
            string query = "INSERT INTO [T_Link_BranchCustomer] (Branch_Code, Customer_id, Fixed) VALUES (@BranchCode, @CustomerID, @Fixed)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@BranchCode", branchCode);
                        command.Parameters.AddWithValue("@CustomerID", customerID);
                        command.Parameters.AddWithValue("@Fixed", fixedStatus);

                        // Open the connection
                        connection.Open();

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                    // Insert a log entry for the save action
                    InsertLogEntry(TextBox10.Text + TextBox11.Text + TextBox13.Text + ", Outlet Updated .");
                }

                // Refresh the GridView by re-binding to the data source
                GridView2.DataSourceID = "SqlDataSource1";
                GridView2.DataBind();

                // Clear input controls
                TextBox13.Text = "";
                CheckBox1.Checked = false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Error number for violation of primary key constraint
                {
                    // Display a custom message when a duplicate key violation occurs
                    lblErrorMessage.Text = "Outlet already exists in the table.";
                }
                else
                {
                    // Display the generic SQL exception message
                    lblErrorMessage.Text = ex.Message;
                }
            }
        }



        /*protected void btnadd_Click(object sender, EventArgs e)
        {
            // Get values from controls
            string branchCode = TextBox13.Text.Trim();
            string customerID = TextBox10.Text.Trim();
            string fixedStatus = CheckBox1.Checked ? "Y" : "N";

            // Your connection string
            string connectionString = "Data Source=CCPHIT-LASANLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";

            // Your SQL query to check if the branch code exists
            string checkQuery = "SELECT COUNT(*) FROM [T_Link_BranchCustomer] WHERE Branch_Code = @BranchCode";

            // Your SQL query to insert data
            string insertQuery = "INSERT INTO [T_Link_BranchCustomer] (Branch_Code, Customer_id, Fixed) VALUES (@BranchCode, @CustomerID, @Fixed)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Check if the branch code already exists
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@BranchCode", branchCode);
                        connection.Open();
                        int branchCount = (int)checkCommand.ExecuteScalar();

                        // If branch code exists, show error message
                        if (branchCount > 0)
                        {
                            lblErrorMessage.Text = "Outlet already exists in the table.";
                            return; // Stop further execution
                        }
                    }

                    // Insert the branch code if it doesn't exist
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@BranchCode", branchCode);
                        insertCommand.Parameters.AddWithValue("@CustomerID", customerID);
                        insertCommand.Parameters.AddWithValue("@Fixed", fixedStatus);

                        // Execute the insertion
                        insertCommand.ExecuteNonQuery();
                    }

                    // Insert a log entry for the save action
                    InsertLogEntry(TextBox10.Text + TextBox11.Text + TextBox13.Text + ", Outlet Updated .");
                }

                // Refresh the GridView by re-binding to the data source
                GridView2.DataSourceID = "SqlDataSource1";
                GridView2.DataBind();

                // Clear input controls
                TextBox13.Text = "";
                CheckBox1.Checked = false;
            }
            catch (SqlException ex)
            {
                // Display the error message to the user
                //lblErrorMessage.Text = ex.Message;

                // Handle other SQL exceptions
                lblErrorMessage.Text = "An error occurred while adding the outlet.";
            }
        }*/


        /*protected void btnadd_Click(object sender, EventArgs e)
        {
            // Get values from controls
            string branchCode = TextBox13.Text.Trim();
            string customerID = TextBox10.Text.Trim();
            string fixedStatus = CheckBox1.Checked ? "Y" : "N";

            // Your connection string
            string connectionString = "Data Source=CCPHIT-LASANLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";

            // Your SQL query to insert data
            string query = "INSERT INTO [T_Link_BranchCustomer] (Branch_Code, Customer_id, Fixed) VALUES (@BranchCode, @CustomerID, @Fixed)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@BranchCode", branchCode);
                        command.Parameters.AddWithValue("@CustomerID", customerID);
                        command.Parameters.AddWithValue("@Fixed", fixedStatus);

                        // Open the connection
                        connection.Open();

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                    // Insert a log entry for the save action
                    InsertLogEntry(TextBox10.Text + TextBox11.Text + TextBox13.Text + ", Outlet Updated .");
                }

                // Refresh the GridView by re-binding to the data source
                GridView2.DataSourceID = "SqlDataSource1";
                GridView2.DataBind();

                // Clear input controls
                TextBox13.Text = "";
                CheckBox1.Checked = false;
            }
            catch (SqlException ex)
            {
                // Check if the exception is due to a duplicate key violation
                if (ex.Number == 2627) // Error number for duplicate key violation
                {
                    // Display a message to the user indicating that the outlet is already in the table
                    lblErrorMessage.Text = "Outlet already exists in the table.";
                }
                else
                {
                    // Handle other SQL exceptions
                    lblErrorMessage.Text = "An error occurred while adding the outlet.";
                }
            }
        }*/


        /*protected void btnadd_Click(object sender, EventArgs e)
        {
            // Get values from controls
            string branchCode = TextBox13.Text.Trim();
            string customerID = TextBox10.Text.Trim();
            string fixedStatus = CheckBox1.Checked ? "Y" : "N";

            // Your connection string
            string connectionString = "Data Source=CCPHIT-LASANLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";

            // Your SQL query to insert data
            string query = "INSERT INTO [T_Link_BranchCustomer] (Branch_Code, Customer_id, Fixed) VALUES (@BranchCode, @CustomerID, @Fixed)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@BranchCode", branchCode);
                    command.Parameters.AddWithValue("@CustomerID", customerID);
                    command.Parameters.AddWithValue("@Fixed", fixedStatus);

                    // Open the connection
                    connection.Open();

                    // Execute the query
                    command.ExecuteNonQuery();
                }
                // Insert a log entry for the save action
                InsertLogEntry( TextBox10.Text  +   TextBox11.Text  +   TextBox13.Text + ", Outlet Updated .");
            }

            // Refresh the GridView by re-binding to the data source
            GridView2.DataSourceID = "SqlDataSource1";
            GridView2.DataBind();

            // Clear input controls
            TextBox13.Text = "";
            CheckBox1.Checked = false;
        }*/


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



        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the Branch_Code from the DataKeys collection
            string branchCode = GridView2.DataKeys[e.RowIndex].Values["Branch_Code"].ToString();

            // Assuming you have a connection string named "ConnectionString"
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // SQL query to delete records
                string deleteQuery = "DELETE FROM [T_Link_BranchCustomer] WHERE Branch_Code = @Branch_Code";

                using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, connection))
                {
                    // Set the parameter value for the DeleteCommand
                    cmdDelete.Parameters.AddWithValue("@Branch_Code", branchCode);

                    // Execute the delete query
                    int rowsAffected = cmdDelete.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // Records deleted successfully
                        lblErrorMessage.Text = "Record deleted successfully.";

                        // Refresh or rebind the GridView after deletion
                        GridView2.DataBind();
                    }
                    else
                    {
                        // No matching records found
                        lblErrorMessage.Text = "No matching record found for deletion.";
                    }
                }
            }
        }

        private List<DataItem> GetDataItems()
        {
            List<DataItem> dataItems = new List<DataItem>();

            foreach (GridViewRow row in GridView2.Rows)
            {
                DataItem item = new DataItem
                {
                    OutletCode = row.Cells[0].Text,
                    LocationName = row.Cells[1].Text,
                    FixedStatus = row.Cells[2].Text
                };

                dataItems.Add(item);
            }

            return dataItems;
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
            string query = "SELECT Customer_ID AS [Code],Customer_Name AS [Name] FROM [T_Mas_Customer]";

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


        private void LoadSupData1()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string query = "SELECT [Branch_Code],[Loc_Name],[Loc_Type] FROM [StaffPurchase].[dbo].[T_Mas_Location]";
            string query = "SELECT Customer_ID AS [Code],Customer_Name AS [Name] FROM [T_Mas_Customer]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        //GridView3.DataSource = reader;
                        //GridView3.DataBind();
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


        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
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

            // Show or hide the Save button based on whether there are any rows in GridView1
            //btnSave.Visible = GridView1.Rows.Count > 0;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}