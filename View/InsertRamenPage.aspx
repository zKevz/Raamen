<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertRamenPage.aspx.cs" Inherits="Raamen.View.InsertRamenPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Insert Ramen</h1>
        <div>
            <asp:Label ID="RamenNameLabel" runat="server" Text="Ramen Name"></asp:Label>
            <asp:TextBox ID="RamenNameTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MeatLabel" runat="server" Text="Meat"></asp:Label>
            <asp:RadioButtonList ID="MeatRadioButton" runat="server"></asp:RadioButtonList>
        </div>
        <div>
            <asp:Label ID="BrothLabel" runat="server" Text="Broth"></asp:Label>
            <asp:TextBox ID="BrothTextbox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="PriceLabel" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="PriceTextbox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="InsertButton" runat="server" Text="Insert" OnClick="OnInsertButtonClicked"/>
            <br />
            <asp:Button ID="BackButton" runat="server" Text="Back" OnClick="OnBackButtonClicked"/>
        </div>
    </div>
</asp:Content>
