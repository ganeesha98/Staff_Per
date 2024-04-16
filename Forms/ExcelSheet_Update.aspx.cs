using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using ExcelDataReader;
using Staff_Purchase_.DataLayer;
using System.Configuration;

namespace Staff_Purchase_.Forms
{
    public partial class ExcelSheet_Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                GaneeshasMethod();

                //SecondMethod();
            }
            catch (Exception ex)
            {
                // Log or display the exception details
                lblMessage.Text = $"An error occurred: {ex.Message}";
                Debug.WriteLine($"An error occurred: {ex.ToString()}"); // Log the full exception details for debugging
            }
        }

        private void SecondMethod()
        {

            FileUpload _objExcel = new FileUpload();
            _objExcel = fuExcel;

            string fileName = _objExcel.FileName.ToString().Trim();
            string fileExtension = Path.GetExtension(fileName);

            #region Check File Type
            // Check file is excel or not
            if (fileExtension != ".xlsx")
            {
                lblMessage.Text = "Invalid File Type!";
                return;
            }
            #endregion

            string filePath = Server.MapPath("~/Uploads/") + fileName;
            _objExcel.SaveAs(filePath);

            // string excelConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";
            string excelConnectionString = $"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={filePath};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

            using (OleDbConnection excelConnection = new OleDbConnection(excelConnectionString))
            {
                excelConnection.Open();

                // Get the list of available sheets in the Excel workbook
                DataTable schemaTable = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (schemaTable != null && schemaTable.Rows.Count > 0)
                {
                    // Assuming the first sheet is used
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();

                    // Query to select all data from the sheet
                    string query = $"SELECT * FROM [{sheetName}]";

                    // Create an OleDbCommand to execute the query
                    using (OleDbCommand cmd = new OleDbCommand(query, excelConnection))
                    {
                        // Create an OleDbDataAdapter to fill a DataTable
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            DataTable excelDataTable = new DataTable();

                            // Fill the DataTable with data from the Excel sheet
                            da.Fill(excelDataTable);

                            // Now you have your data in a DataTable (excelDataTable)
                            // You can use this DataTable as needed
                        }
                    }
                }
            }


            DataTable dt_ExcelData = new DataTable();
        }

        private void GaneeshasMethod()
        {
            btnUploadData.Visible = false;
            if (fuExcel != null && lblMessage != null)
            {
                Debug.WriteLine("Before fileUpload.HasFile check");
                if (fuExcel.HasFile && Path.GetExtension(fuExcel.FileName) == ".xlsx")
                {
                    Stream stream = fuExcel.PostedFile.InputStream;
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = reader.AsDataSet();

                        // Assuming your GridView has AutoGenerateColumns set to false
                        dgvExcelData.AutoGenerateColumns = false;

                        // Assuming the columns are defined in the GridView markup
                        ((BoundField)dgvExcelData.Columns[0]).DataField = "EMP_PAYROLLNO";
                        ((BoundField)dgvExcelData.Columns[1]).DataField = "EMP_DISPLAY_NUMBER";
                        ((BoundField)dgvExcelData.Columns[2]).DataField = "EMP_DISPLAY_NAME";
                        ((BoundField)dgvExcelData.Columns[3]).DataField = "AMOUNT";
                        ((BoundField)dgvExcelData.Columns[4]).DataField = "LOC_CODE";
                        ((BoundField)dgvExcelData.Columns[5]).DataField = "LOC_NAME";
                        ((BoundField)dgvExcelData.Columns[6]).DataField = "CENTRE_NAME";
                        ((BoundField)dgvExcelData.Columns[7]).DataField = "Staff_Purchasing_outlet";
                        ((BoundField)dgvExcelData.Columns[8]).DataField = "Staff_Purchasing_Type";
                        ((BoundField)dgvExcelData.Columns[9]).DataField = "EMAIL";
                        ((BoundField)dgvExcelData.Columns[10]).DataField = "CONTACT_NO";
                        ((BoundField)dgvExcelData.Columns[11]).DataField = "DATE_OF_JOIN";

                        DataTable dt = new DataTable();
                        dt = result.Tables[0];

                        //Remove Sheet Header
                        dt.Rows.RemoveAt(0);
                        //dt.Rows.RemoveAt(0);
                        //dt.Rows.RemoveAt(0);

                        if (dt.Rows.Count == 0)
                        {
                            lblMessage.Text = "Excel cannot be empty!";
                            return;
                        }

                        //dt = MakeNewHeader(dt)_
                        string[] arrColumnNames = { "EMP_PAYROLLNO", "EMP_DISPLAY_NUMBER", "EMP_DISPLAY_NAME", "AMOUNT", "LOC_CODE", "LOC_NAME", "CENTRE_NAME", "Staff_Purchasing_outlet", "Staff_Purchasing_Type", "EMAIL", "CONTACT_NO", "DATE_OF_JOIN" };
                        ChangeColumnNames(dt, arrColumnNames);


                        dgvExcelData.DataSource = dt;
                        dgvExcelData.DataBind();
                    }

                    lblMessage.Text = "";
                    btnUploadData.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Please select a valid Excel file (.xlsx)";
                }
                Debug.WriteLine("After fileUpload.HasFile check");
            }
            else
            {
                Debug.WriteLine("fileUpload or lblMessage is null");
            }
        }

        public static void ChangeColumnNames(DataTable dataTable, string[] newColumnNames)
        {
            // Check if the number of new column names matches the existing column count
            if (dataTable.Columns.Count == newColumnNames.Length)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    // Set the new name for each column
                    dataTable.Columns[i].ColumnName = newColumnNames[i];
                }
            }
            else
            {
                throw new ArgumentException("The number of new column names does not match the existing column count.");
            }
        }
        private DataTable MakeNewHeader(DataTable dt)
        {
            try
            {
                dt.Columns.Clear();

                DataRow headerRow = dt.Rows[0];
                foreach (object item in headerRow.ItemArray)
                {
                    // Add a new DataColumn with a default name
                    DataColumn newColumn = new DataColumn($"Column{dt.Columns.Count + 1}");
                    dt.Columns.Add(newColumn);
                }

                // Remove the first row as it is now used as column names
                dt.Rows.RemoveAt(0);

                return dt;
            }
            catch (Exception excLsk)
            {
                throw;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnUploadData_Click(object sender, EventArgs e)
        {
            SaveDataToDB();
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard.aspx");
        }



        private void SaveDataToDB()
        {
            try
            {
                // Set all status = 0 in table T_Mas_CreditCustomer
                ClsInsertData _objUpd = new ClsInsertData();
                _objUpd.updT_Mas_CreditCustomer(_objUpd);

                ClsInsertData _objIpd = new ClsInsertData();
                _objIpd.updT_Mas_CreditCustomer(_objIpd);




                int rowEffected = 0;

                string emppayroll = string.Empty;
                string displayno = string.Empty;
                string displayname = string.Empty;
                string amount = string.Empty;
                string loccode = string.Empty;
                string locname = string.Empty;
                string centername = string.Empty;
                string outlet = string.Empty;
                string type = string.Empty;
                string email = string.Empty;
                string contact = string.Empty;
                string doj = string.Empty;


                foreach (GridViewRow di in dgvExcelData.Rows)
                {

                    emppayroll = di.Cells[0].Text.ToString();
                    displayno = di.Cells[1].Text.ToString();
                    displayname = di.Cells[2].Text.ToString();
                    amount = di.Cells[3].Text.ToString();
                    loccode = di.Cells[4].Text.ToString();
                    locname = di.Cells[5].Text.ToString();
                    centername = di.Cells[6].Text.ToString();
                    outlet = di.Cells[7].Text.ToString();
                    type = di.Cells[8].Text.ToString();
                    email = di.Cells[9].Text.ToString();
                    contact = di.Cells[10].Text.ToString();
                    doj = di.Cells[11].Text.ToString();

                    // Insert data to database
                    ClsInsertData _objInsert = new ClsInsertData();

                    _objInsert.EMP_PAYROLLNO = emppayroll;
                    _objInsert.EMP_DISPLAY_NUMBER = displayno;
                    _objInsert.EMP_DISPLAY_NAME = displayname;
                    _objInsert.AMOUNT = amount;
                    _objInsert.LOC_CODE = loccode;
                    _objInsert.LOC_NAME = locname;
                    _objInsert.CENTRE_NAME = centername;
                    _objInsert.Staff_Purchasing_outlet = outlet;
                    _objInsert.Staff_Purchasing_Type = type;
                    _objInsert.EMAIL = email;
                    _objInsert.CONTACT_NO = contact;
                    _objInsert.DATE_OF_JOIN = doj;

                    _objInsert.InsertDataIntoDatabase(_objInsert);
                    rowEffected = rowEffected + 1;
                }

                lblMessage.Text = " records successfully inserted!";
            }
            catch (Exception excLsk)
            {
                throw;
            }
        }


    }
}