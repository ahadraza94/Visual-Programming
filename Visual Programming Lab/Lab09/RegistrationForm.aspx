<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="Lab09.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        form {
            max-width: 400px;
            margin: 20px auto;
            background: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            margin-top: 0;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"],
        input[type="password"],
        input[type="email"],
        select {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        input[type="text"]:focus,
        input[type="password"]:focus,
        input[type="email"]:focus,
        select:focus {
            outline: none;
            border-color: #4CAF50;
        }

        input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            width: 100%;
        }

        input[type="submit"]:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registration Form</h2>
            <div>
                <label for="txtEmail">Email:</label>
                <input type="email" id="txtEmail" runat="server" />
            </div>
            <div>
                <label for="txtPassword">Password:</label>
                <input type="password" id="txtPassword" runat="server" />
            </div>
            <div>
                <label for="txtFirstName">First Name:</label>
                <input type="text" id="txtFirstName" runat="server" />
            </div>
            <div>
                <label for="txtLastName">Last Name:</label>
                <input type="text" id="txtLastName" runat="server" />
            </div>
            <div>
                <label for="ddlGender">Gender:</label>
                <select id="ddlGender" runat="server">
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                    <option value="Other">Other</option>
                </select>
            </div>
            <div>
                <label for="txtDateOfBirth">Date of Birth:</label>
                <input type="text" id="txtDateOfBirth" placeholder="YYYY-MM-DD" runat="server" />
            </div>
            <div>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
            <div>
                <asp:Button ID="btnLoginPage" runat="server" Text="Login Here" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
