<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="B.Tech3Year_B.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <h1>Login</h1>                   
                <table>
                    <tr>
                        <td>Email Id :</td>
                        <td>
                            <asp:TextBox ID="txtEmailId" runat="server">
                            </asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Password :</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server">
                            </asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnLogin" runat="server" Text="LogIn" OnClick="btnLogin_Click" />
                            <asp:Button ID="btnSignIn" runat="server" Text="SignIn" OnClick="btnSignIn_Click"></asp:Button>
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
    </div>
        </center>
    </form>
</body>
</html>
