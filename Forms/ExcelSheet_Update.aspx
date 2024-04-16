<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelSheet_Update.aspx.cs" Inherits="Staff_Purchase_.Forms.ExcelSheet_Update" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Purchase Goods Receiving </title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <!-- Bootstrap JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        .navbar-inverse.navbar-nav > li > a:focus,
        .navbar- inverse.navbar- nav > li > a:hover {
            color: #090a22;
            background-color: transparent;
        }

        .navbar-inverse {
            background-color: #ffffff;
            border-color: #ff0005;
        }

            .navbar-inverse .navbar-nav > li > a {
                color: #000000;
            }
    </style>
    <style type="text/css">
        .table-row1 {
            display: table-row;
        }

        .table-cell1 {
            display: table-cell;
            padding: 10px;
            color: #FFFFFF;
        }

        .header {
            background-color: #0000;
            width: 20px;
        }

        .input-field1 {
            width: 100%;
            padding: 5px;
            border: none;
            background-color: #FFFFFF;
            color: #FFFFFF;
        }
    </style>
    <style type="text/css">
        .table-container {
            display: table;
            width: 100%;
        }

        .table-row {
            display: table-row;
        }

        .table-cell {
            display: table-cell;
            padding: 10px;
            color: #FFFFFF;
        }

        .header {
            font-family: auto;
            background-color: #000000;
        }

        .input-field {
            width: Auto;
            padding: 5px;
            border: none;
            background-color: #FFFFFF;
            color: #000;
        }
    </style>

    <style>
        footer {
            position: fixed;
            bottom: 0;
            left: 0;
            width: 100%;
            background-color: #fffbfb;
            text-align: center;
            padding: 10px 0;
        }
    </style>

    <style>
        .navbar-inverse {
            background-color: #fffbfb;
            border-color: #fd0d0d;
        }

            .navbar-inverse.navbar-nav > li > a:focus,
            .navbar- inverse.navbar- nav > li > a:hover {
                color: #090a22;
                background-color: transparent;
            }

            .navbar-inverse .navbar-nav > li > a {
                color: #000000;
            }

                .navbar-inverse .navbar-nav > li > a:focus,
                .navbar-inverse .navbar-nav > li > a:hover {
                    color: #0a0459;
                    background-color: #d7cdcd;
                }

            .navbar-inverse .navbar-toggle .icon-bar {
                background-color: #101010;
            }
    </style>
    <style>
        .form-group row {
        }

        .form-group {
            margin-bottom: 20px;
        }

        col-sm-2 col-form-label {
        }
    </style>


    <style>
        footer {
            text-align: center;
        }

        }

        #form1 {
            width: 1234px;
            margin-left: 36px;
        }
    </style>


</head>

<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header" style="text-decoration: none; color: #000000; font-family: Arial, Helvetica, sans-serif; font-size: 25px; font-style: inherit; font-variant: inherit; font-weight: bold;" aria-busy="True">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <img src="../../cargillstransparent.png" width="105" height="53" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Staff Purchases
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />

    <form id="form1" runat="server">
        <br />
        <br />

        <div style="display: flex; align-items: center;">
            <asp:FileUpload ID="fuExcel" runat="server" Width="299px" />
            <asp:RequiredFieldValidator ID="rfvFuExcel" ControlToValidate="fuExcel" runat="server" ErrorMessage="Required!" CssClass="text-danger" ValidationGroup="valGrpUpload"></asp:RequiredFieldValidator>
            <asp:Button ID="btnUpload" runat="server" Text="View" ValidationGroup="valGrpUpload" OnClick="btnUpload_Click" CssClass="btn btn-secondary auto-style328" BackColor="#12ab31" Style="border-color: #333333; background-color: #e8edea" Width="100px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUploadData" Text="Upload" runat="server" CssClass="btn btn-secondary auto-style328" Visible="false" OnClick="btnUploadData_Click" Style="border-color: #333333; background-color: #e8edea" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID="btnExit" runat="server" Text="Exit" Onclick="btnExit_Click" CssClass="btn btn-secondary auto-style328"
            Style="border-color: #333333; background-color: #e8edea" Width="100px"/>

            
        </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="#009933"></asp:Label>
        <br />
        <br />

        <asp:GridView ID="dgvExcelData" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="93%" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle ForeColor="#330099" BackColor="White" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />

            <Columns>
                <asp:BoundField DataField="EMP_PAYROLLNO" HeaderText="EMP_PAYROLLNO" />
                <asp:BoundField DataField="EMP_DISPLAY_NUMBER" HeaderText="EMP_DISPLAY_NUMBER" />
                <asp:BoundField DataField="EMP_DISPLAY_NAME" HeaderText="EMP_DISPLAY_NAME" />
                <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" />
                <asp:BoundField DataField="LOC_CODE" HeaderText="LOC_CODE" />
                <asp:BoundField DataField="LOC_NAME" HeaderText="LOC_NAME" />
                <asp:BoundField DataField="CENTRE_NAME" HeaderText="CENTRE_NAME" />
                <asp:BoundField DataField="Staff Purchasing outlet" HeaderText="Staff Purchasing outlet" />
                <asp:BoundField DataField="Staff Purchasing Type" HeaderText="Staff Purchasing Type" />
                 <asp:BoundField DataField="Staff Purchasing Type" HeaderText="EMAIL" />
                <asp:BoundField DataField="Staff Purchasing Type" HeaderText="CONTACT_NO" />
                <asp:BoundField DataField="Staff Purchasing Type" HeaderText="DATE_OF_JOIN" />
            </Columns>


        </asp:GridView>
        <%--  </div>--%>
                
        <br />

        <div class="form-group">
        </div>
    </form>

    <footer>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &copy; <%: DateTime.Now.Year %> - Powered By Cargills IT
        </p>
    </footer>
</body>
</html>

