<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="Raamen.View.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Transaction Details</h1>
        <div>
            <asp:Label ID="TransactionInfoLabel1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="TransactionInfoLabel2" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="TransactionInfoLabel3" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="TransactionInfoLabel4" runat="server" Text=""></asp:Label>
            <br />
            <asp:GridView ID="TransactionDetailGridView" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Number" HeaderText="No"></asp:BoundField>
                    <asp:BoundField DataField="RamenName" HeaderText="Ramen Name"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="BackButton" runat="server" Text="Back" OnClick="OnBackButtonClicked"/>
        </div>
    </div>
</asp:Content>
