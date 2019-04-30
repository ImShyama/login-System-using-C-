<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationData.aspx.cs" Inherits="B.Tech3Year_B.RegistrationData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Data</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></h1>
    <div>
        <h1>Registration Data</h1>
        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
            <table>
                <thead>
                    <tr>
                        <td>Id</td>
                        <td>First Name</td>
                        <td>Last Name</td>
                        <td>Email Id</td>
                        <td>Password</td>
                        <td>Mobile Number</td>
                        <td>State</td>
                        <td>City</td>
                        <td>Pincode</td>
                        <td>Gender</td>
                        <td>Programming</td>
                        <td></td>
                        <td></td>
                    </tr>
                    <%for(int i = 0 ; i < registrationObj.Count ; i++){ %>
                    <tr>
                        <td><%= registrationObj[i].Id %></td>
                        <td><%= registrationObj[i].firstName %></td>
                        <td><%= registrationObj[i].lastName %></td>
                        <td><%= registrationObj[i].emailId %></td>
                        <td><%= registrationObj[i].password %></td>
                        <td><%= registrationObj[i].mobileno %></td>
                        <td><%= registrationObj[i].state %></td>
                        <td><%= registrationObj[i].city %></td>
                         <td><%= registrationObj[i].pincode %></td>
                        <td><%= registrationObj[i].gender%></td>
                        <td><%= registrationObj[i].programming %></td>
                        <td>
                            <a href="EditRegistrationdata.aspx?Id=<%=registrationObj[i].Id %>">Edit</a>
                        </td>
                         <td>
                            <a href="DeleteRegistrationData.aspx?Id=<%=registrationObj[i].Id %>">Delete</a>
                        </td>
                    </tr>
                    <% } %>
                </thead>
            </table>
    </div>
    </form>
</body>
</html>
