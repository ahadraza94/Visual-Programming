WebForm1.aspx
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }
        .form-input {
            margin-bottom: 15px;
        }
        .form-input label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }
        .form-input input[type=text], 
        .form-input input[type=submit] {
            width: calc(100% - 22px); /* Adjust for input padding and border */
            padding: 10px;
            border: 1px solid #ced4da;
            border-radius: 4px;
            box-sizing: border-box;
            margin-top: 5px;
        }
        .form-input input[type=submit] {
            width: 100%; /* Full width */
            background-color: #007bff;
            color: #fff;
            cursor: pointer;
        }
        .form-input input[type=submit]:hover {
            background-color: #0056b3;
        }
        .message-label {
            color: #dc3545; /* Red color for error messages */
            font-size: 14px;
            margin-top: 10px;
        }
        .record-label {
            font-weight: bold;
            color: #007bff;
            margin-bottom: 10px;
        }
        .grid-view {
            border-collapse: collapse;
            width: 100%;
            margin-top: 20px;
        }
        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        .grid-view th {
            background-color: #f2f2f2;
            color: #333;
        }
        .show-all-btn {
            display: block;
            width: 100%;
            margin-top: 10px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 4px;
            padding: 10px;
            cursor: pointer;
            text-align: center;
        }
        .show-all-btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Employee Management</h1>
            <div class="form-input">
                <label for="txtName">Employee ID:</label>
                <asp:TextBox ID="txtid" runat="server" placeholder="Enter Employee ID"></asp:TextBox>
            </div>
            <div class="form-input">
                <label for="txtName">Employee Name:</label>
                <asp:TextBox ID="txtname" runat="server" placeholder="Enter Employee Name"></asp:TextBox>
            </div>
            <div class="form-input">
                <label>Gender:</label>
                <asp:RadioButtonList ID="rblGender" runat="server">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-input">
                <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" OnClick="btnAddEmployee_Click" />
            </div>
                <asp:Label ID="lblMessage" runat="server" CssClass="message-label" Visible="true"></asp:Label> <!-- Set Visible to true by default -->
            <hr />
            <asp:GridView ID="GridViewEmployees" runat="server" CssClass="grid-view" AutoGenerateColumns="true"></asp:GridView>
            <asp:Button ID="btnShowAllRecords" runat="server" CssClass="show-all-btn" Text="Show All Records" OnClick="btnShowAllRecords_Click" />
        </div>
    </form>
</body>
</html>
