<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdmissionManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 35px;
        }
    </style>
</head>
<body style="height: 112px; width: 304px;">
    <form id="form1" runat="server">
    <div style="background-image: url('login.png'); height: 560px; width: 1199px;">
    <table style="margin: 200px 0px 0px 400px; height: 172px; width: 362px; background-image: url('login.png');">
        <tr>
            <td>
                EMAIL ID
            </td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                PASSWORD
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnlogin" runat="server" Text="LOGIN" OnClick="btnlogin_Click" />
            </td>
        </tr>
            <asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label>
        </table>
    </div>
    </form>
</body>
</html>
