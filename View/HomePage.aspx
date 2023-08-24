<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Raamen.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Home Page</h1>
        <h2 runat="server" id="RoleHeader">Your Role: </h2>

        <div runat="server" id="CustomerDiv" visible="false">
            <h3>Customer's List</h3>
            <asp:Label ID="CustomerListInfoLabel" runat="server" Text=""></asp:Label>
            <asp:GridView ID="CustomerGrid" runat="server"></asp:GridView>
        </div>
        <br />
        <div runat="server" id="StaffDiv" visible="false">
            <h3>Staff's List</h3>
            <asp:Label ID="StaffListInfoLabel" runat="server" Text=""></asp:Label>
            <asp:GridView ID="StaffGrid" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
