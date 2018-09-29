<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TemplateAdd.aspx.cs" Inherits="Nhub.TemplateAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <table class="nav-justified">
        <style>
        .switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}

.switch input {display:none;}

.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 34px;
}

.slider.round:before {
  border-radius: 50%;
}
            .auto-style1 {
                position: relative;
                display: inline-block;
                width: 60px;
                height: 34px;
                left: 1px;
                top: 2px;
            }
            .auto-style2 {
                font-size: medium;
            }
            .auto-style3 {
                font-size: large;
            }
            .auto-style4 {
                width: 188px;
                height: 38px;
            }
            .auto-style5 {
                height: 38px;
            }
            .auto-style6 {
                width: 188px;
                height: 32px;
            }
            .auto-style7 {
                height: 32px;
            }
            .auto-style8 {
                width: 188px;
            }
            .auto-style9 {
                height: 20px;
                width: 188px;
            }
            .auto-style10 {
                font-size: large;
                width: 188px;
            }
            .auto-style11 {
                width: 188px;
                height: 36px;
            }
            .auto-style12 {
                height: 36px;
            }
            .auto-style13 {
                width: 188px;
                height: 33px;
            }
            .auto-style14 {
                height: 33px;
            }
        </style>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="SLlbl" runat="server" Text="Service Line:" CssClass="auto-style3"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:DropDownList ID="ServiceLineDDL" runat="server" Height="25px" Width="220px" CssClass="auto-style3" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Id], [Name] FROM [ServiceLine]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="Notlbl" runat="server" Text="Notification" CssClass="auto-style3"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:DropDownList ID="NotificationDDL" runat="server" Height="25px" Width="220px" CssClass="auto-style3" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Name], [Id], [SourceId], [Mandatory] FROM [Event]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:Label ID="TempNamelbl" runat="server" Text="Template Name" CssClass="auto-style3"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:TextBox ID="TemplateName" runat="server" Width="220px" CssClass="auto-style3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:Label ID="MElbl" runat="server" Text="Mandatory Event" CssClass="auto-style3"></asp:Label>
            </td>
            <td class="auto-style14">

<label class="auto-style1">
  <input type="checkbox" checked class="auto-style3">
  <span class="slider round"></span>
</label>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:Label ID="Schnlbl" runat="server" Text="Select Channel" CssClass="auto-style3"></asp:Label>
                <span class="auto-style3">:</span></td>
            <td class="auto-style12">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2">
                <span class="auto-style3"><asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                &nbsp;&nbsp;&nbsp;&nbsp; </span>
                </td>
        </tr>
        <tr class="auto-style2">
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td>
                <asp:Button ID="CreateBtn" runat="server" CssClass="auto-style3" Text="Create" Width="106px" OnClick="CreateBtn_Click" />
                <span class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                <asp:Button ID="CancelBtn" runat="server" CssClass="auto-style3" OnClick="CancelBtn_Click" Text="Cancel" Width="111px" />
            </td>
        </tr>
        <tr class="auto-style2">
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        </table>
</asp:Content>
