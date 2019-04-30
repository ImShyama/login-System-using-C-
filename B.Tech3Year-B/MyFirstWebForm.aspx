<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyFirstWebForm.aspx.cs" Inherits="B.Tech3Year_B.MyFirstWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <style type="text/css">
        .auto-style2 {
            height: 24px;
        }
        .auto-style3 {
            height: 34px;
        }
    </style>
</head>
<body style="height: 498px">
    <form id="form1" runat="server">
        <center>
    <div style="height: 465px">
        <h1>Registration Form</h1>
        <table style="height: 361px; width: 509px">
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="txtfirstName" runat="server" MaxLength="50"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFtxtFirstName" runat="server" ErrorMessage="Please insert First Name" ControlToValidate="txtfirstName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="50"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFtxtLastName" runat="server" ErrorMessage="Please insert Last Name" ControlToValidate="txtLastName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>Email Id</td>
                <td>
                    <asp:TextBox ID="txtEmailId" runat="server" MaxLength="50" TextMode="Email" ToolTip="Email Id"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFtxtEmailId" runat="server" ErrorMessage="Please insert Email Id" ControlToValidate="txtEmailId" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" MaxLength="10"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFtxtPassword" runat="server" ErrorMessage="Please insert Password" ControlToValidate="txtPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>Mobile Number</td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFtxtMobileNo" runat="server" ErrorMessage="Please insert Mobile Number" ControlToValidate="txtMobileNo" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>State </td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">City </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr><tr>
                <td>Pincode</td>
                <td>
                    <asp:TextBox ID="txtPincode" runat="server" MaxLength="10" ReadOnly="true" > </asp:TextBox>
                    
                </td>
                </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <asp:RadioButton ID="rdMale" runat="server" Text="Male" GroupName="gender">
                    </asp:RadioButton>
                    <asp:RadioButton ID="rdFemale" runat="server" Text="Female" GroupName="gender">
                    </asp:RadioButton>
                </td>
            </tr>
            <tr>
                <td>Programming</td>
                <td>
                <asp:CheckBox ID="chkCprogramming" text ="C Programming" runat="server" ></asp:CheckBox>
                <asp:CheckBox ID="chkCplus" Text="C+" runat="server"></asp:CheckBox>
                <asp:CheckBox ID="chkJava" Text="Java" runat="server"></asp:CheckBox>
                <asp:CheckBox ID="chkNet" Text="Dot Net" runat="server"></asp:CheckBox>

                </td>

            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style3">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"> </asp:Label>
                </td>
            </tr>
        </table>
    </div>
            </center>
    </form>
</body>
</html>
