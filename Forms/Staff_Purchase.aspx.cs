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
    public partial class Staff_Purchase : System.Web.UI.Page
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
                // Bind GridView with stored data
                BindGridView();

            }

        }


        protected void btnadd_Click(object sender, EventArgs e)
        {

            // Retrieve values from TextBoxes
            string textBox10Value = TextBox10.Text.Trim();
            string textBox11Value = TextBox11.Text.Trim();

            // Check if both TextBoxes have values
            if (string.IsNullOrEmpty(textBox10Value) || string.IsNullOrEmpty(textBox11Value))
            {
                // Display an error message under the button
                lblErrorMessage.Text = " * Please select Outlet Codes using FindBox ";
                lblErrorMessage.Visible = true;
                return;
            }

            // Clear any previous error message
            lblErrorMessage.Text = "";
            lblErrorMessage.Visible = false;

            // Show the Save button if there is at least one item in GridView1
            btnSave.Visible = GridView1.Rows.Count > -1;

            // Get values from TextBoxes and CheckBox
            string outletCode = TextBox10.Text;
            string locationName = TextBox11.Text;
            string fixedStatus = CheckBox1.Checked ? "Y" : "N";

            // Create a new data item
            DataItem newItem = new DataItem
            {
                OutletCode = outletCode,
                LocationName = locationName,
                FixedStatus = fixedStatus
            };

            // Add the new item to the list
            YourDataList.Add(newItem);

            // Bind GridView with updated data
            BindGridView();

            // Clear TextBoxes and CheckBox after adding data
            TextBox10.Text = "";
            TextBox11.Text = "";
            CheckBox1.Checked = false;
        }

        private void BindGridView()
        {
            // Bind GridView with the stored data
            GridView1.DataSource = YourDataList;
            GridView1.DataBind();
        }

        private void LoadSupData()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";

            //string query = "SELECT [Branch_Code],[Loc_Name],[Loc_Type] FROM [StaffPurchase].[dbo].[T_Mas_Location]";
            string query = "SELECT Branch_Code AS [Code],Loc_Name AS [Name],Loc_Type AS [Type] FROM [T_Mas_Location] WHERE Status IN('A','P') and Loc_Group = 'RT' ";

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Save data to [StaffPurchase].[dbo].[T_Mas_Customer] table
                string sqlQueryCustomer = @"
                INSERT INTO [dbo].[T_Mas_Customer]
                       ([Customer_ID]
                       ,[Customer_Name]
                       ,[Address]
                       ,[Contact_No]
                       ,[Email_ID]
                       ,[AllowAlert]
                       ,[CustomerGroup]
                       ,[DateOfJoin]
                       ,[CustomerType]
                       ,[Company]
                       ,[SecCode]
                       ,[Sys_User]
                       ,[Sys_Date]
                       ,[Status]
                       ,[EBillFlag]
                       ,[EBillMode]
                       ,[EbillMasterFlag])
                 VALUES
                       (@Customer_ID
                       ,@Customer_Name
                       ,@Address
                       ,@Contact_No
                       ,@Email_ID
                       ,@AllowAlert
                       ,@CustomerGroup
                       ,@DateOfJoin
                       ,@CustomerType
                       ,@Company
                       ,@SecCode
                       ,@Sys_User
                       ,@Sys_Date
                       ,@Status
                       ,@EBillFlag
                       ,@EBillMode
                       ,@EbillMasterFlag);
                SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmdCustomer = new SqlCommand(sqlQueryCustomer, connection))
                {
                    // Set parameters
                    cmdCustomer.Parameters.AddWithValue("@Customer_ID", txtsup.Text);
                    cmdCustomer.Parameters.AddWithValue("@Customer_Name", txtName.Text);
                    cmdCustomer.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmdCustomer.Parameters.AddWithValue("@Contact_No", txtContact.Text);
                    cmdCustomer.Parameters.AddWithValue("@Email_ID", txtEmail.Text);
                    cmdCustomer.Parameters.AddWithValue("@AllowAlert", ddlUserStatus.SelectedValue);
                    cmdCustomer.Parameters.AddWithValue("@CustomerGroup", DropDownList1.SelectedValue);
                    cmdCustomer.Parameters.AddWithValue("@DateOfJoin", txtEndDate2.Text);
                    cmdCustomer.Parameters.AddWithValue("@CustomerType", DropDownList2.SelectedValue);
                    cmdCustomer.Parameters.AddWithValue("@Company", DropDownList3.SelectedValue);
                    cmdCustomer.Parameters.AddWithValue("@SecCode", TextBox14.Text);
                    // Add other parameters...

                    // Set default values
                    cmdCustomer.Parameters.AddWithValue("@Sys_User", "sys");
                    cmdCustomer.Parameters.AddWithValue("@Sys_Date", DateTime.Now);
                    cmdCustomer.Parameters.AddWithValue("@Status", true); // Assuming Status is a bit field
                    cmdCustomer.Parameters.AddWithValue("@EBillFlag", 0);
                    cmdCustomer.Parameters.AddWithValue("@EBillMode", "Email");
                    cmdCustomer.Parameters.AddWithValue("@EbillMasterFlag", 1);


                    // Execute the query and return the inserted CustomerID
                    object result = cmdCustomer.ExecuteScalar();
                    int customerId = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    // Execute the query and return the inserted CustomerID
                    //int customerId = Convert.ToInt32(cmdCustomer.ExecuteScalar());


                    // Save data to [StaffPurchase].[dbo].[T_Mas_CreditCustomer] table
                    // string sqlQueryCreditCustomer = "INSERT INTO [StaffPurchase].[dbo].[T_Mas_CreditCustomer] (Customer_ID, Credit_Limit, Amount_Debit, Active_Status, DeactiveReasonCode, Monthly_Limit) " +
                    //  "VALUES (@Customer_ID, @Credit_Limit, @Amount_Debit, @Active_Status, @DeactiveReasonCode, @Monthly_Limit)";

                    using (SqlCommand cmdCreditCustomer = new SqlCommand("sp_InsertCreditCustomer", connection))
                    {
                        cmdCreditCustomer.CommandType = CommandType.StoredProcedure;

                        // Set parameters for T_Mas_CreditCustomer
                        cmdCreditCustomer.Parameters.AddWithValue("@Customer_ID", txtsup.Text);
                        cmdCreditCustomer.Parameters.AddWithValue("@Credit_Limit", txtCLimit.Text);
                        // Add other parameters for T_Mas_CreditCustomer...

                        // Set default values for T_Mas_CreditCustomer
                        cmdCreditCustomer.Parameters.AddWithValue("@Amount_Debit", "0.00");
                        cmdCreditCustomer.Parameters.AddWithValue("@Active_Status", "1");
                        cmdCreditCustomer.Parameters.AddWithValue("@DeactiveReasonCode", "NA");
                        cmdCreditCustomer.Parameters.AddWithValue("@Monthly_Limit", "0.00");

                        // Execute the query for T_Mas_CreditCustomer
                        cmdCreditCustomer.ExecuteNonQuery();
                    }
                }


                // Save data to [StaffPurchase].[dbo].[T_Link_BranchCustomer] table
                string sqlQueryLinkBranchCustomer = "INSERT INTO [T_Link_BranchCustomer] (Branch_Code, Customer_Id, Fixed) " +
                                                    "VALUES (@Branch_Code, @Customer_Id, @Fixed)";
                foreach (GridViewRow row in GridView1.Rows)
                {

                    // Deserialize the data from the GridView row
                    DataItem dataItem = new DataItem
                    {
                        OutletCode = row.Cells[1].Text,
                        // LocationName = row.Cells[1].Text, // Change to the correct column index
                        FixedStatus = row.Cells[3].Text // Change to the correct column index
                    };

                    //string outletCode = row.Cells[0].Text;

                    //string outletCode = row.Cells[GridView1.Columns["OutletCode"].Index].Text;
                    //string fixedStatus = ((CheckBox)row.FindControl("CheckBox1")).Checked ? "Y" : "N";
                    // Get the value of CheckBox1 for Yes or No
                    //string fixedStatus = CheckBox1.Checked ? "Y" : "N";

                    using (SqlCommand cmdLinkBranchCustomer = new SqlCommand(sqlQueryLinkBranchCustomer, connection))
                    {
                        cmdLinkBranchCustomer.Parameters.AddWithValue("@Customer_Id", txtsup.Text);
                        cmdLinkBranchCustomer.Parameters.AddWithValue("@Branch_Code", dataItem.OutletCode);
                        cmdLinkBranchCustomer.Parameters.AddWithValue("@Fixed", dataItem.FixedStatus);
                        cmdLinkBranchCustomer.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }

            // After saving data
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Data saved successfully.');", true);

            // Insert a log entry for the save action
            InsertLogEntry( txtsup.Text + txtName.Text  +  ", Customer Added.");

            cleardata();
        }

        private void cleardata()
        {
            // Clear input controls
            txtsup.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtCLimit.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox14.Text = "";
            txtEndDate2.Text = "";
            ddlUserStatus.SelectedIndex = 0; // Assuming this is a dropdown list
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;

            // Clear YourDataList
            YourDataList.Clear();

            // Bind GridView with updated data (empty data)
            BindGridView();
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the index of the row being deleted
            int rowIndex = e.RowIndex;

            // Remove the item from YourDataList based on the index
            YourDataList.RemoveAt(rowIndex);

            // Rebind GridView with updated data
            BindGridView();

            // Show or hide the Save button based on whether there are any rows in GridView1
            btnSave.Visible = GridView1.Rows.Count > 0;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard.aspx");
        }

    }

    [Serializable]
    internal class DataItem
    {
        public string OutletCode { get; set; }
        public string LocationName { get; set; }
        public string FixedStatus { get; set; }

    }
}