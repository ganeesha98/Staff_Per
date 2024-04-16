<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_Manage.aspx.cs" Inherits="Staff_Purchase_.Forms.Customer_Manage" %>


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

    <style>
        footer {
            position: fixed;
            bottom: 0;
            left: 0;
            width: 100%;
            background-color: #fffbfb;
            text-align: center;
            padding: 5px 0;
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
        .auto-style1 {
            margin-left: 149px;
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
            <p style="font-size: 20px; text-align: center;"><B>Customer Remove/Delete</B></p>
            
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

                             
            </div>

            <div class="col-md-6">

                

                </div>
                </div>            
                
        

            <div class="container mt-5">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group row">
                            <label for="txtSupplierVendor" class="col-sm-2 col-form-label">Customer Code :</label>
                            <div class="col-sm-1">
                                <!--<button for="btnsup" class="auto-style328" style="background-color: #C0C0C0">...</button>-->
                                <button type="button" id="btnsup" class="btn btn-secondary" class="auto-style328" style="border-color: #333333; background-color: #e8edea">Find</button>

                                <div id="myModal" class="modal">
                                    <div class="modal-content">
                                        <div class="modal-content-container" style="overflow: auto">
                                            <!-- Modal header with a close button 
                                            <div class="modal-header"> -->
                                                <h2>Customer code</h2>
                                                <!--<button id="closeModal">Close</button>
                                                <label for="txtclose" style="font-size: 12px; color: #f22307; display: block; margin: 0 auto; width: 100%; height: 20px;">
                                        * Please click on close button to close window</label>-->
                                            

                                            <div>
                                                <label for="searchBox">Search:</label>
                                                <input type="text" id="searchBox" class="form-control" placeholder="Type to search...">
                                                
                                                <button id="closeModal">Ok</button>
                                                 
                                                <label for="txtclose" style="font-size: 12px; color: #f22307; display: block; margin: 0 auto; width: 100%; height: 20px;">
                                        * Please click on Ok button to close window</label>
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

                            <div class="col-sm-3">
                                <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <asp:Button ID="btnDelete" runat="server" Text="Delete Customer" CssClass="btn btn-secondary auto-style328"
                    Style="border-color: #333333; background-color: #e8edea"
                    OnClick="btnDelete_Click" Width="150px" OnClientClick="return validateFields();"/>
                            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>

                            <asp:Button ID="Button1" runat="server" Text="Exit" CssClass="btn btn-secondary auto-style328"
                    Style="border-color: #333333; background-color: #e8edea"
                    OnClick="btnExit_Click" Width="100px" />
                            
                        </div>
                    </div>
                </div>
            </div>

            <!-- start add button -->
            
            <br />
            <div class="col-sm-12" style="margin-left: 180px;">
                                    <label for="txtfixed" style="font-size: 12px; color: #f22307; display: block; margin: 0 auto; width: 100%; height: 20px;">
                                        * Please note. This Is Use Only For Customer Remove/Delete from Database</label>
                                </div> 
            
            <hr class="auto-style330" style="border-style: solid; background-color: #000000";width: 1125px; />
            






           <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />


            


        </div>
        <br />
          <br />

        <div class="row">
            <div class="col-md-6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
            </div>
        </div>  
        

        
            
        


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script> 
        
        <script>
            function showAlert() {
                // Get the value of the "alert" query parameter from the URL
                var alertParam = new URLSearchParams(window.location.search).get('alert');

                // If the "alert" parameter is set to "updated", display the alert
                if (alertParam === 'updated') {
                    alert('Credit Limit updated successfully.');
                }
            }

            // Call the showAlert function after the page has been reloaded
            window.onload = showAlert;
        </script>

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




        <script type="text/javascript">
            function validateFields() {
                var textBox10Value = document.getElementById('<%= TextBox10.ClientID %>').value;
                var textBox11Value = document.getElementById('<%= TextBox11.ClientID %>').value;

                if (textBox10Value.trim() === '' || textBox11Value.trim() === '') {
                    alert('Please select customer first.');
                    return false; // Prevent form submission
                }

                return true; // Allow form submission
            }
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

