<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="Raamen.View.HistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>History Page</h1>
        <div>
            <asp:Label ID="TransactionLabel" runat="server" Text=""></asp:Label>
            <br />
            <asp:GridView ID="TransactionGridView" runat="server" AutoGenerateColumns="false" OnRowCommand="OnTransactionRowCommand">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name"></asp:BoundField>
                    <asp:BoundField DataField="StaffName" HeaderText="Staff Name"></asp:BoundField>
                    <asp:BoundField DataField="Date" HeaderText="Date"></asp:BoundField>
                    <asp:ButtonField CommandName="Select" Text="Detail" ButtonType="Link"></asp:ButtonField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
