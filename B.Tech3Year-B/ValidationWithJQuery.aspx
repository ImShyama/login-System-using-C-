<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationWithJQuery.aspx.cs" Inherits="B.Tech3Year_B.ValidationWithJQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation</title>
    <script src="Scripts/JQuery1.10.2.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSubmit").click(function () {
                var firstName = $("#txtFirstname").val();
                var lastName = $("#txtLastname").val();
                var emailId = $("#txtEmailid").val();
                var password = $("#txtPassword").val();

                if (firstName == "") {
                    alert("Please insert first name.")
                    return false; 
                }
                if (lastName == "") {
                    alert("Please insert last name.")
                    return false;
                }
                if (emailId == "") {
                    alert("Please insert EmailID.")
                    return false;
                }
                if (password == "") {
                    alert("Please insert Password.")
                    return false;
                }
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center><h1>Registration Form</h1></center>
        </div>
        <div>
            <div>
                <table>
                    <tr>
                        <td>First Name</td>
                        <td><asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Last Name</td>
                        <td><asp:TextBox ID="txtLastname" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Email Id</td>
                        <td><asp:TextBox ID="txtEmailid" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button ID="btnSubmit" runat="server" Text="Button" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
