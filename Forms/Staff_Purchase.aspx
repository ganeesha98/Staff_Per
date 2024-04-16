<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff_Purchase.aspx.cs" Inherits="Staff_Purchase_.Forms.Staff_Purchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">   

    <!--Common CSS File -->
    <link rel="stylesheet" href="../../Content/StaffPurchase.css" media="screen" />
    <link rel="stylesheet" href="../../Content/staffmain.css" media="screen" />

     <style>
        .navbar-inverse.navbar-nav > li > a:focus, .navbar- inverse.navbar- nav > li > a:hover {
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
}

.alignSuccessMessage{
    margin-left:90px;
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
            font-family: ui-monospace;
            background-color: #000000;
        }

        .input-field {
            width: 100%;
            padding: 5px;
            border: none;
            background-color: #FFFFFF;
            color: black;
        }

        .button-with-margin {
            margin-left: 210px;
        }
    </style>

    <style>
        .bordered{
            width:800px;
            height:auto;
            padding:20px;
            border:1px solid black;
        }

        .row{
            width:auto;
            height:auto;

        }
    </style> 

   
   
    <title></title>

    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    

     <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>

    <!-- jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <!-- Bootstrap JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


<style>

    .navbar-inverse {
        background-color: #fffbfb;
        border-color: #fd0d0d;
    }

        .navbar-inverse.navbar-nav > li > a:focus, .navbar- inverse.navbar- nav > li > a:hover {
            color: #090a22;
            background-color: transparent;
        }

        .navbar-inverse .navbar-nav > li > a {
            color: #000000;
        }

            .navbar-inverse .navbar-nav > li > a:focus, .navbar-inverse .navbar-nav > li > a:hover {
                color: #0a0459;
                background-color: #d7cdcd;
            }

        .navbar-inverse .navbar-toggle .icon-bar {
            background-color: #101010;
        }
    
    </style>

    <style>
        .form-group row{

        }

        .form-group {
         margin-bottom: 5px;
          }

        col-sm-2 col-form-label{

        }
        </style>


    <style>

        footer {
  text-align: center;
}

        
}
    </style>
 <style>
        /* Styles for the modal popup */
        .modal {
            display:;
            position: fixed;
            top: 0;
            left: 0;
            width: 650px;
            height: 640px;
            background-color: rgba(0, 0, 0, 0);
            z-index: 1;
            max-width: 500px;
            margin-left: auto;
            margin-right: 10px;
        }

        .modal-content {
            position: relative;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: white;
            padding: 20px;
            border: 1px solid #ccc;
        }

        .modal-content-container {
            max-height: 490px; /* Adjust the maximum height as needed */
            overflow-y: auto;
        }
    </style>

    <style>
        /* Style for selected row */
        .selected-row {
            background-color: yellow;
        }
        </style> 
     <style>
        /* Styles for the modal popup */
        .modal1 {
            display:;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.1);
            z-index: 1;
            max-width: 400px;
            margin-left: auto;
            margin-right: 130px;
        }

        .modal-content2 {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: white;
            padding: 20px;
            border: 1px solid #ccc;
        }

        .modal-content-container2 {
            max-height: 410px; /* Adjust the maximum height as needed */
            overflow-y:auto;
        }
    </style>
    <style>
        /* Styles for the modal popup */
        .modal2 {
            display:;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.1);
            z-index: 1;
            max-width: 410px;
            margin-left: auto;
            margin-right: 130px;
        }

        .modal-content3 {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: white;
            padding: 20px;
            border: 1px solid #ccc;
        }

        .modal-content-container3 {
            max-height: 410px; /* Adjust the maximum height as needed */
            overflow-y: auto;
        }
    </style>

    <style>
        /* Style for selected row */
        .selected-row3 {
            background-color: yellow;
        }
    </style> 

    <style>
        /* Style for selected row */
        .selected-row2 {
            background-color: yellow;
        }
        
        label.auto-style400 {
            width: 100px;
            height: 50px;
        }
        </style> 


</head>
<body>
    
    <div class="row">
        <div class="col-md-10 alignSuccessMessage">
            <div id="div1" visible="false" runat="server" class="alert alert-success fade-in">
                <asp:Label ID="Label1" runat="server" Visible="true"></asp:Label>
            </div>
        </div>       
    </div>
       
        <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">           
                <img src="../../cargillstransparent.png" width="105" height="53" />
            </div>
            <br />
            <p style="font-size: 20px; text-align: center;"><B> New Customer Purchase</B></p>
            
        </div>
    </div>

<br />
<br />
<br />
    <form id="form1" runat="server">
    <br />
        <div class="row">
            <div class="col-md-10 alignSuccessMessage">
                <div id="divMsg" visible="false" runat="server" class="alert alert-success fade-in">
                    <asp:Label ID="lblShowMessage" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
        </div>

        <div class="container mt-5">
            <div class="row">
                <div class="col-md-6">

                <div class="form-group row">
                        <label for="txtCustomer" class="col-sm-3 col-form-label">Customer Code :</label>

                        <div class="col-sm-6">
                            <asp:TextBox ID="txtsup" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" ErrorMessage="Required." ForeColor="Red" ControlToValidate="txtsup" Display="Dynamic" ValidationGroup="valGrpCreate"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCode" runat="server" ErrorMessage="Customer Code must be either 7 or 9 characters." ForeColor="Red" ControlToValidate="txtsup" Display="Dynamic" ValidationExpression="^.{7}$|^.{9}$" ValidationGroup="valGrpCreate"></asp:RegularExpressionValidator>
                        </div>
                    </div>
 
                <div class="form-group row">
                    <label for="txtName" class="col-sm-3 col-form-label">Name :</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="txtAddress" class="col-sm-3 col-form-label">Address :</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                    <div class="form-group row">
                        <label for="txtAlert" class="col-sm-3 col-form-label">Allow Alert :</label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="ddlUserStatus" runat="server" class="form-control" onchange="updateUserStatusText()">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                <div class="form-group row">
                        <label for="txtContact" class="col-sm-3 col-form-label">Contact No :</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvContact" runat="server" ErrorMessage="Required." ForeColor="Red" ControlToValidate="txtContact" Display="Dynamic" ValidationGroup="valGrpCreate"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revContact" runat="server" ErrorMessage="Contact number must be 10 digits." ForeColor="Red" ControlToValidate="txtContact" Display="Dynamic" ValidationExpression="^\d{10}$" ValidationGroup="valGrpCreate"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="txtEmail" class="col-sm-3 col-form-label">Email :</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Required." ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="valGrpCreate"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Invalid email format." ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b" ValidationGroup="valGrpCreate"></asp:RegularExpressionValidator>
                        </div>
                    </div>
            </div>

            <div class="col-md-6">

                <div class="form-group row">
                    <label for="txtdoj" class="col-sm-3 col-form-label">Date Of Join :</label>
                    <div class="col-sm-6">
            <asp:TextBox ID="txtEndDate2" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
                     <div class="col-sm-2">
                        <label for="txtdoj" class="auto-style400"style="font-size: 12px; color: #f22307; width="120%">(YYYMMDD)</label>
                    </div>
                </div>

        <div class="form-group row">
                        <label for="txtUsergroup" class="col-sm-3 col-form-label">Customer Group:</label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" onchange="updateUserStatusText()">
                                <asp:ListItem Value="A">--Select--</asp:ListItem>
                                <asp:ListItem Value="S">S-Staff Credit</asp:ListItem>
                                <asp:ListItem Value="D">D-Discount Cash</asp:ListItem>
                                <asp:ListItem Value="R">R-Retail Credit</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                <div class="form-group row">
                        <label for="txtUsertype" class="col-sm-3 col-form-label">Customer Type :</label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" onchange="updateUserStatusText()">
                                <asp:ListItem Value="A">--Select--</asp:ListItem>
                                <asp:ListItem Value="E">E-Employee</asp:ListItem>
                                <asp:ListItem Value="H">H-Excutive</asp:ListItem>
                                <asp:ListItem Value="R">R-Retail Credit</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                <div class="form-group row">
                        <label for="txtCompany" class="col-sm-3 col-form-label">Company :</label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="DropDownList3" runat="server" class="form-control" onchange="updateUserStatusText()">
                                <asp:ListItem Value="A">--Select--</asp:ListItem>
                                <asp:ListItem Value="00100">CR-Cargills Retails</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                <div class="form-group row">
                    <label for="txtSec" class="col-sm-3 col-form-label">Sec Code :</label>
                    <div class="col-sm-6">
            <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
                     <div class="col-sm-3">
                         <label for="txtreq" class="auto-style400" style="font-size: 12px; color: #f22307; text-align: center; display: block; margin: 0 auto; width: 120%; height: 50px;">
                             * Password to open E-statement (NIC/Customer Code)</label>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="txtCLimit" class="col-sm-3 col-form-label">Credit Limit :</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtCLimit" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                </div>
                </div>            
                
        <hr class="auto-style330" style="border-style: solid; background-color: #000000";width: 1125px; />

            <div class="container mt-5">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="txtSupplierVendor" class="col-sm-4 col-form-label">Outlet Code :</label>
                            <div class="col-sm-2">
                                <!--<button for="btnsup" class="auto-style328" style="background-color: #C0C0C0">...</button>-->
                                <button type="button" id="btnsup" class="btn btn-secondary" class="auto-style328" style="border-color: #333333; background-color: #e8edea">Find</button>

                                <div id="myModal" class="modal">
                                    <div class="modal-content">
                                        <div class="modal-content-container" style="overflow: auto">
                                            <!-- Modal header with a close button -->
                                            <div class="modal-header">
                                                <h2>Outlet code</h2>
                                                <button id="closeModal">Close</button>
                                                <label for="txtclose" style="font-size: 12px; color: #f22307; display: block; margin: 0 auto; width: 100%; height: 20px;">
                                        * Please click on close button to close window</label>
                                            </div>

                                            <div>
                                                <label for="searchBox">Search:</label>
                                                <input type="text" id="searchBox" class="form-control" placeholder="Type to search...">
                                                <button id="btnFilter" class="btn btn-secondary" style="margin-top: 5px;">Filter</button>
                                            </div>

                                            <!-- GridView -->
                                            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="True"></asp:GridView>

                                            <!-- Placeholder for the GridView -->
                                            <div id="gridViewPlaceholder"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-4">
                                <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-12">
                                <div class="col-sm-8" style="margin-left: 180px;">
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    <label for="CheckBox1">Is Fixed</label>
                                </div>
                                <div class="col-sm-12" style="margin-left: 180px;">
                                    <label for="txtfixed" style="font-size: 12px; color: #f22307; display: block; margin: 0 auto; width: 100%; height: 20px;">
                                        * Please run the download credit customer option at the outlet after adding new branch)</label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- start add button -->
            <asp:Button ID="btnadd" runat="server" CssClass="btn btn-secondary auto-style328 button-with-margin"
                Style="border-color: #333333; background-color: #e8edea"
                Text="Add" OnClick="btnadd_Click" />
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <br />
            
            <hr class="auto-style330" style="border-style: solid; background-color: #000000";width: 1125px; />
            
                <!-- end of the modal one -->

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#666666" BorderStyle="Dashed" BorderWidth="1px" CellPadding="4" Height="139px" Width="823px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" HorizontalAlign="Justify" AutoGenerateDeleteButton="True" OnRowDeleting="GridView1_RowDeleting" Font-Bold="True" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Strikeout="False">
                <Columns>
                    <asp:BoundField DataField="OutletCode" HeaderText="Outlet code">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LocationName" HeaderText="Location Name">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FixedStatus" HeaderText="Fixed Status">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                
                <HeaderStyle BackColor="#8f1818" Font-Bold="True" ForeColor="#FFFFFF" HorizontalAlign="Right" />
                <PagerStyle BackColor="#FFFFFF" ForeColor="#330099" HorizontalAlign="Right" />
                <RowStyle BackColor="White" ForeColor="#330099" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" HorizontalAlign="Right" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
                
                 <!-- end of the modal one -->
        </div>
        <br />
          <br />

        <div class="row">
            <div class="col-md-6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-secondary auto-style328"
            Style="border-color: #333333; background-color: #e8edea"
            OnClick="btnSave_Click" Width="100px" ValidationGroup="valGrpCreate" Visible="false" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnExit" runat="server" Text="Exit" Onclick="btnExit_Click" CssClass="btn btn-secondary auto-style328"
            Style="border-color: #333333; background-color: #e8edea" Width="100px"/>
            </div>
        </div>    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>        

        <script>
            // Event listener for the Search box
            document.getElementById('searchBox').addEventListener('input', function () {
                var searchBoxValue = this.value.toLowerCase();

                // Filter GridView data based on searchBoxValue
                filterGridView(searchBoxValue);
            });

            function filterGridView(searchValue) {
                var gridView = document.getElementById('<%= GridView5.ClientID %>');
                var rows = gridView.getElementsByTagName('tr');

                for (var i = 1; i < rows.length; i++) { // Start from index 1 to skip header row
                    var cells = rows[i].getElementsByTagName('td');
                    var shouldShowRow = false;

                    for (var j = 0; j < cells.length; j++) {
                        var cellText = cells[j].textContent.toLowerCase();

                        // If the cell text contains the search value, show the row
                        if (cellText.includes(searchValue)) {
                            shouldShowRow = true;
                            break;
                        }
                    }

                    // Toggle row visibility based on the filter result
                    rows[i].style.display = shouldShowRow ? '' : 'none';
                }
            }
        </script>
  

        <script>
            // JavaScript code to display data in the modal
            var btnsup = document.getElementById('btnsup');
            var modal = document.getElementById('myModal');
            var closeModalButton = document.getElementById('closeModal');
            var dataBody = document.getElementById('<%= GridView5.ClientID %>');
            var selectedRow = null;

            //var selectedRow = null;

            // Input fields          

            var TextBox10Input = document.getElementById('TextBox10');
            var TextBox11Input = document.getElementById('TextBox11');


            // Function to handle row selection and highlight
            function selectRow(row, rowData) {
                debugger;
                if (selectedRow) {
                    selectedRow.classList.remove('selected-row');
                }
                row.classList.add('selected-row');
                selectedRow = row;

                //closeModelButton.click();
                // Populate the input fields with the selected row's data
                var cells = row.cells;
                TextBox10Input.value = cells[0].textContent;
                TextBox11Input.value = cells[1].textContent;

            }

            btnsup.addEventListener('click', function () {
                // Display the modal when the button is clicked
                modal.style.display = 'block';

                // Load data when the modal is opened
                loadModalData();
            });

            closeModalButton.addEventListener('click', function () {
                // Close the modal when the "Close" button is clicked
                //dataBody.innerHTML = ''; // Clear the table content
                modal.style.display = 'none';
            });

            window.addEventListener('click', function (event) {
                if (event.target == modal) {
                    // Close the modal if the user clicks outside the modal content
                    //dataBody.innerHTML = '';
                    modal.style.display = 'none';
                }
            });

            dataBody.addEventListener('click', function (event) {
                var target = event.target;
                if (target.tagName === 'TD') {
                    var row = target.parentElement;
                    selectRow(row);
                }
            });

            function loadModalData() {
                // Add code here to load data into the modal (e.g., from the GridView)
                // Make an AJAX request to fetch data and populate the modal
                var xmlhttp = new XMLHttpRequest();
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        // Parse the response and populate the modal
                        var data = JSON.parse(xmlhttp.responseText);
                        // Implement code to populate the modal with data
                    }
                };

                // Replace 'GetDataUrl' with the URL to fetch data from the server
                xmlhttp.open('GET', 'GetDataUrl', true);
                xmlhttp.send();
            }

            $(document).ready(function () {
                $("#closeModal").click(function () {
                    $("#myModal").modal("hide");
                });
            });

        </script>

    <script>
        function updatecate1Text() {
            var dropdown = document.getElementById("ddlcate1");
            var selectedText = dropdown.options[dropdown.selectedIndex].text;
            document.getElementById("txtcate1").value = selectedText;
        }

        function updateUserStatusText() {
            var dropdown = document.getElementById("ddlUserStatus");
            var selectedText = dropdown.options[dropdown.selectedIndex].text;
            document.getElementById("txtUserStatus").value = selectedText;
        }

        function updatetypeText() {
            var dropdown = document.getElementById("ddltype");
            var selectedText = dropdown.options[dropdown.selectedIndex].text;
            document.getElementById("txttype").value = selectedText;
        }
    </script>    
                
        </form>
    <footer>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &copy; <%: DateTime.Now.Year %> - Powered By Cargills IT
        </p>
    </footer>   
</body>
</html>
