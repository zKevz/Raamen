<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionsQueuePage.aspx.cs" Inherits="Raamen.View.TransactionsQueuePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Transactions Queue</h1>
        <div>
            <h2>Unhandled Transactions</h2>
            <asp:Label ID="UnhandledTransactionsInfoLabel" runat="server" Text=""></asp:Label>
            <asp:GridView ID="UnhandledTransactionsGridView" runat="server" AutoGenerateColumns="false" OnRowCommand="OnUnhandledTransactionsRowCommand">
                <Columns>
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer"></asp:BoundField>
                    <asp:BoundField DataField="Date" HeaderText="Date"></asp:BoundField>

                    <asp:ButtonField CommandName="Select" Text="Handle" ButtonType="Button"></asp:ButtonField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <h2>Handled Transactions</h2>
            <asp:Label ID="HandledTransactionsInfoLabel" runat="server" Text=""></asp:Label>
            <asp:GridView ID="HandledTransactionsGridView" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer"></asp:BoundField>
                    <asp:BoundField DataField="StaffName" HeaderText="Staff"></asp:BoundField>
                    <asp:BoundField DataField="Date" HeaderText="Date"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
