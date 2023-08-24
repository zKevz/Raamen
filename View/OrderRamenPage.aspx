<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrderRamenPage.aspx.cs" Inherits="Raamen.View.OrderRamenPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Order Ramen</h1>
        <div>
            <h2>Ramen's List</h2>
            <asp:GridView ID="RamenGridView" runat="server" OnRowCommand="OnRamenGridViewRowCommand">
                <Columns>
                    <asp:BoundField DataField="RamenName" HeaderText="Ramen Name"></asp:BoundField>
                    <asp:BoundField DataField="Meat" HeaderText="Meat"></asp:BoundField>
                    <asp:BoundField DataField="Broth" HeaderText="Broth"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price"></asp:BoundField>
                    <asp:ButtonField CommandName="Select" Text="Add to cart" ButtonType="Button"></asp:ButtonField>
                </Columns>
            </asp:GridView>
        </div>

        <br />

        <div>
            <h2>Cart</h2>
            <asp:Label ID="CartLabel" runat="server" Text=""></asp:Label>
            <asp:GridView ID="CartGridView" runat="server" OnRowCommand="OnCartGridViewRowCommand">
                <Columns>
                    <asp:BoundField DataField="RamenName" HeaderText="Ramen Name"></asp:BoundField>
                    <asp:BoundField DataField="Meat" HeaderText="Meat"></asp:BoundField>
                    <asp:BoundField DataField="Broth" HeaderText="Broth"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity"></asp:BoundField>
                    <asp:ButtonField CommandName="Remove" Text="Remove" ButtonType="Button"></asp:ButtonField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="TotalLabel" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="ClearCartButton" runat="server" Text="Clear Cart" OnClick="OnClearCartButtonClicked"/>
            <br />
            <asp:Button ID="BuyCartButton" runat="server" Text="Buy Cart" OnClick="OnBuyCartButtonClicked"/>
        </div>
    </div>
</asp:Content>
