<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student Details.aspx.cs" Inherits="AdmissionManagement.Student_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                STUDENT NAME
            </td>
            <td>
                <asp:TextBox ID="txtstudentname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                MOBILE NUMBER
            </td>
            <td>
                <asp:TextBox ID="txtmobno" runat="server" MaxLength="10"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                COLLEGE NAME
            </td>
            <td>
                <asp:TextBox ID="txtcollname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                FEES
            </td>
            <td>
                <asp:TextBox ID="txtfees" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                BATCH ID
            </td>
            <td>
                <asp:TextBox ID="txtbatchid" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                REFERENCE NUMBER
            </td>
            <td>
                <asp:TextBox ID="txtrefno" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnsave" runat="server" Text="SAVE" OnClick="btnsave_Click" />
            </td>
            <td>
                <asp:Button ID="btnupdate" runat="server" Text="UPDATE" OnClick="btnupdate_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
