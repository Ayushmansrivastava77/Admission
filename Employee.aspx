<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="AdmissionManagement.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <table>
        <tr>
            <td>
                EMPLOYEE NAME
            </td>
            <td>
                <asp:TextBox ID="txtemployeename" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                EMPLOYEE COMPANY ID
            </td>
            <td>
                <asp:TextBox ID="txtemployeecompID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                EMAIL ID
            </td>
            <td>
                <asp:TextBox ID="txtemailID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                MOBILE NUMBER
            </td>
            <td>
                <asp:TextBox ID="txtmobilenumber" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                DATE OF JOINING
            </td>
            <td>
                <asp:TextBox ID="txtdateofjoin" runat="server" MaxLength="10" ToolTip="dd/mm/yyyy"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                DATE OF LEAVING
            </td>
            <td>
                <asp:TextBox ID="txtdateofleaving" runat="server" MaxLength="10" ToolTip="dd/mm/yyyy"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                EMPLOYEE ROLE ID
            </td>
            <td>
                <asp:DropDownList ID="drproleID" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                PASSWORD
            </td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Button ID="btnsave" runat="server" Text="SAVE" OnClick="btnsave_Click" />
            <asp:Button ID="btnupdate" runat="server" Text="UPDATE" OnClick="btnupdate_Click" />
            </td>
        </tr>
        <tr>
            <asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label>
        </tr>
    </table>
    </div>
</asp:Content>
