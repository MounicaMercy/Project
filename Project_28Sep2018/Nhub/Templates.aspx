<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Templates.aspx.cs" Inherits="Nhub.Templates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Welcome to templates page..</p>
    <p style="font-size: large">
        Sources :</p>
    <p style="font-size: large">
        <asp:TreeView ID="TreeView1" runat="server">
        </asp:TreeView>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </p>
    <p>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </p>
    <p class="text-right">
        <asp:Button ID="AddTmpltBtn" runat="server" OnClick="AddTmpltBtn_Click" Text="Add Template" />
    </p>
</asp:Content>
