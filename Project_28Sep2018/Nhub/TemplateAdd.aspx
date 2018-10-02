<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TemplateAdd.aspx.cs" Inherits="Nhub.TemplateAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <table class="nav-justified">
          <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
        </tr>
          <tr>
            <td class="auto-style4">
                <asp:Label ID="SLlbl" runat="server" Text="Service Line:" CssClass="auto-style3" style="font-size: large"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:DropDownList ID="ServiceLineDDL" runat="server" Height="25px" Width="220px" CssClass="auto-style3" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id" style="font-size: large">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Id], [Name] FROM [ServiceLine]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="Notlbl" runat="server" Text="Notification" CssClass="auto-style3" style="font-size: large"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:DropDownList ID="NotificationDDL" runat="server" Height="25px" Width="220px" CssClass="auto-style3" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Id" style="font-size: large">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Name], [Id], [SourceId], [Mandatory] FROM [Event]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:Label ID="TempNamelbl" runat="server" Text="Template Name" CssClass="auto-style3" style="font-size: large"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:TextBox ID="TemplateName" runat="server" Width="220px" CssClass="auto-style3" style="font-size: large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="MElbl" runat="server" Text="Mandatory Event" CssClass="auto-style3" style="font-size: large"></asp:Label>
            </td>
            <td class="auto-style14">

                <asp:RadioButtonList ID="MandatoryEventRDL" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>YES</asp:ListItem>
                    <asp:ListItem>NO</asp:ListItem>
                </asp:RadioButtonList>

            </td>
        </tr>
        <tr style="font-size: large">
            <td class="auto-style11">
                <asp:Label ID="Schnlbl" runat="server" Text="Select Channel" CssClass="auto-style3"></asp:Label>
                <span class="auto-style3">:</span></td>
            <td class="auto-style12">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11" style="font-size: large">
                &nbsp;</td>
            <td class="auto-style12">
                <asp:DropDownList ID="ChannelDDL" runat="server" CssClass="auto-style3" DataSourceID="SqlDataSource4" DataTextField="Name" DataValueField="Id" Height="25px" Width="220px" style="font-size: large">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Id], [Name] FROM [Channel]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style11" style="font-size: large">
                &nbsp;</td>
            <td class="auto-style12">
                <asp:TextBox ID="URL" runat="server" CssClass="auto-style3" Width="220px" style="font-size: large"></asp:TextBox>
                <asp:Button ID="Upload" runat="server" CssClass="auto-style3" OnClick="Upload_Click" Text="Upload" Width="111px" style="font-size: large" />
                
                <asp:Label ID="uploadlbltxt" runat="server" Text="   "></asp:Label>
                
                <asp:Label ID="Uploadsucces" runat="server" Text="    "></asp:Label>
                
            </td>
        </tr>
        <tr class="auto-style2" style="font-size: large">
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style3">
                <%--<asp:GridView ID="GVChannel" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" OnRowCommand="GVChannel_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Channel Name" SortExpression="Name" />
                    <asp:TemplateField HeaderText="URL">
            <ItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text=""></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="Upload"  ShowHeader="True" Text="Upload" />
                    </Columns>
                </asp:GridView>--%>
         
        
    
                <%--<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Name] FROM [Channel]"></asp:SqlDataSource>--%>
            </td>
        </tr>
        <tr class="auto-style2" style="font-size: large">
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style3">
                <%--<asp:Button ID="Update" runat="server" OnClick="Update_Click" Text="Update" Width="110px" />--%>
            </td>
        </tr>
        <tr class="auto-style2" style="font-size: large">
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10" style="font-size: large">&nbsp;</td>
            <td>
                <asp:Button ID="CreateBtn" runat="server" CssClass="auto-style3" Text="Create" Width="111px" OnClick="CreateBtn_Click" style="font-size: large" />
               
                <asp:Label ID="createlbltxt" runat="server" Text="    "></asp:Label>
                <span class="auto-style3" style="font-size: large">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                <asp:Button ID="CancelBtn" runat="server" CssClass="auto-style3" OnClick="CancelBtn_Click" Text="Cancel" Width="111px" style="font-size: large" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="Templatehome" runat="server" Height="25px" NavigateUrl="~/Templates.aspx" ToolTip="Click me to go back to Templates Home Page" Width="150px">Template Page</asp:HyperLink>
            </td>
        </tr>
        </table>
</asp:Content>
