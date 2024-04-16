using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Staff_Purchase_.DataLayer
{
    public class ClsInsertData
    {

        private string _emppayroll = string.Empty;
        private string _displayno = string.Empty;
        private string _displayname = string.Empty;
        private string _amount = string.Empty;
        private string _loccode = string.Empty;
        private string _locname = string.Empty;
        private string _centername = string.Empty;
        private string _outlet = string.Empty;
        private string _type = string.Empty;
        private string _email = string.Empty;
        private string _contact = string.Empty;
        private string _doj = string.Empty;


        public string EMP_PAYROLLNO
        {
            get { return _emppayroll; }
            set { _emppayroll = value; }
        }
        public string EMP_DISPLAY_NUMBER
        {
            get { return _displayno; }
            set { _displayno = value; }
        }
        public string EMP_DISPLAY_NAME
        {
            get { return _displayname; }
            set { _displayname = value; }
        }
        public string AMOUNT
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public string LOC_CODE
        {
            get { return _loccode; }
            set { _loccode = value; }
        }
        public string LOC_NAME
        {
            get { return _locname; }
            set { _locname = value; }
        }
        public string CENTRE_NAME
        {
            get { return _centername; }
            set { _centername = value; }
        }
        public string Staff_Purchasing_outlet
        {
            get { return _outlet; }
            set { _outlet = value; }
        }
        public string Staff_Purchasing_Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string EMAIL
        {
            get { return _email; }
            set { _email = value; }
        }
        public string CONTACT_NO
        {
            get { return _contact; }
            set { _contact = value; }
        }
        public string DATE_OF_JOIN
        {
            get { return _doj; }
            set { _doj = value; }
        }
        public int InsertDataIntoDatabase(ClsInsertData obj)
        {
            // Connection string to your SQL Server database
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string connectionString = "Data Source=erimsdb.cargillsceylon.com; User Id=erims_app; Password=app123; Initial Catalog=ERIMS_IS;";
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            {


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Usp_InserttExcelData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the stored procedure
                        command.Parameters.AddWithValue("@EMP_PAYROLLNO", obj.EMP_PAYROLLNO);
                        command.Parameters.AddWithValue("@EMP_DISPLAY_NUMBER", obj.EMP_DISPLAY_NUMBER);
                        command.Parameters.AddWithValue("@EMP_DISPLAY_NAME", obj.EMP_DISPLAY_NAME);
                        command.Parameters.AddWithValue("@AMOUNT", obj.AMOUNT);
                        command.Parameters.AddWithValue("@LOC_CODE", obj.LOC_CODE);
                        command.Parameters.AddWithValue("@LOC_NAME", obj.LOC_NAME);
                        command.Parameters.AddWithValue("@CENTRE_NAME", obj.CENTRE_NAME);
                        command.Parameters.AddWithValue("@Staff_Purchasing_outlet", obj.Staff_Purchasing_outlet);
                        command.Parameters.AddWithValue("@Staff_Purchasing_Type", obj.Staff_Purchasing_Type);
                        command.Parameters.AddWithValue("@EMAIL", obj.EMAIL);
                        command.Parameters.AddWithValue("@CONTACT_NO", obj.CONTACT_NO);
                        command.Parameters.AddWithValue("@DATE_OF_JOIN", obj.DATE_OF_JOIN);

                        connection.Open();

                        command.ExecuteNonQuery();

                        connection.Close();
                        return 1;
                    }
                }

            }
        }

        public int updT_Mas_CreditCustomer(ClsInsertData obj)
        {
            // Connection string to your SQL Server database
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            {


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Usp_Upd_T_Mas_CreditCustomer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the stored procedure
                        //command.Parameters.AddWithValue("@EMP_PAYROLLNO", obj.EMP_PAYROLLNO);

                        connection.Open();

                        command.ExecuteNonQuery();

                        connection.Close();
                        return 1;
                    }
                }

            }
        }

        public int Ins_Link_BranchCustomer(ClsInsertData obj)
        {
            //Connection string to your SQL Server database
            string connectionString = "Data Source=CCPHIT-GANISLAP\\SQLEXPRESS;Initial Catalog=StaffPurchase;Integrated Security=True";
            //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            {


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("Isp_Ipd_T_Link_BranchCustomer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;



                        connection.Open();

                        command.ExecuteNonQuery();

                        connection.Close();
                        return 1;
                    }
                }

            }
        }
    }
}