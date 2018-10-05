<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Templates.aspx.cs" Inherits="Nhub.Templates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </p>
    <p class="text-right">
        <asp:Button ID="AddTmpltBtn" runat="server" OnClick="AddTmpltBtn_Click" Text="Add Template" />
    </p>
</asp:Content>
