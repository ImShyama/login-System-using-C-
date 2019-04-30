<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRegistrationdata.aspx.cs" Inherits="B.Tech3Year_B.EditRegistrationdata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Registration data</title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Edit Registration Data</h1>
        <table>
            <tr style="display:none;">
                <td>
                    <asp:Label ID="lblId" runat="server" Text=""></asp:Label></td>
                <td></td>
            </tr>
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="txtfirstName" runat="server" MaxLength="50">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFtxtFirstName" runat="server" ErrorMessage="Please insert First Name" ControlToValidate="txtfirstName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="50">
                    </asp:TextBox>
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
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="10">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFtxtPassword" runat="server" ErrorMessage="Please insert Password" ControlToValidate="txtPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>Mobile Number</td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10">
                    </asp:TextBox>
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
            </tr>
            <tr>
                <td class="auto-style1">Pincode</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPincode" runat="server" MaxLength="10" ReadOnly="true">
                    </asp:TextBox>
                   
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
                <td></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red">
                    </asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
