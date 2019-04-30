<%@ Page  Language="C#" AutoEventWireup="true" CodeBehind="validationwithjquery.aspx.cs" Inherits="B.Tech3Year_B.validationwithjquery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation</title>
    <script src="script/jquery%201.10.2.js"></script>
    <script type="text/javascript"> 
        $(document).ready(function () {
            $("#btnSubmit").click(function () {
                var firstname = $("#txtFname").val();
                var lastname = $("#txtLname").val();
                var emailid = $("#txtEmail").val();
                var password = $("#txtPassword").val();


                if (firstname == "") {
                    alert("Please insert First name");
                    return false;
                }
                if (lastname == "") {
                    alert("Please insert last name");
                    return false;
                }
                if (emailid == "") {
                    alert("Please insert EmailId");
                    return false;
                }
                if (password =="") {
                    alert("Please insert Password");
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
            <table>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="txtFname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="txtLname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email Id</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Button"  /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
