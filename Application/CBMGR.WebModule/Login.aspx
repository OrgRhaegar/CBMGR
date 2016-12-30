<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CBMGR.WebModule.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1 style="text-align:center">Login</h1>
    <div>
        <table>
            <tr>
                <td style="text-align:right">
                    User Name:
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    Password:
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtPwd" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ckbRememberMe" runat="server" Checked="false" Text="Remember me" />
                </td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log in" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>