<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Batch.aspx.cs" Inherits="AdmissionManagement.Batch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                BATCH NUMBER
            </td>
            <td>
                <asp:TextBox ID="txtbatchnumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                BATCH COURSE ID
            </td>
            <td>
                <asp:DropDownList ID="drpCourseID" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                FROM DATE
            </td>
            <td>
                <asp:TextBox ID="txtfromdate" runat="server" MaxLength="10" ToolTip="dd/mm/yyyy"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                TO DATE
            </td>
            <td>
                <asp:TextBox ID="txttodate" runat="server" MaxLength="10" ToolTip="dd/mm/yyyy"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnsave" runat="server" Text="SAVE" OnClick="btnsave_Click" />
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
