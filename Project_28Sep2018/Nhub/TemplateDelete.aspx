<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TemplateDelete.aspx.cs" Inherits="Nhub.TemplateDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" style="font-size: medium" Text="Template ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="DeleteTemplate" runat="server" Width="161px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><strong>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="font-weight: bold" Text="Delete" Width="134px" />
                    </strong></td>
            </tr>
        </table>
    </p>
</asp:Content>
