<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageRamenPage.aspx.cs" Inherits="Raamen.View.ManageRamenPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Manage Ramen</h1>
        <div>
            <div>
                <asp:GridView ID="ManageRamenGridView" runat="server" OnRowCommand="OnManageRamenGridViewRowCommand" AutoGenerateColumns="false" OnRowDeleting="ManageRamenGridView_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="RamenName" HeaderText="Ramen Name"></asp:BoundField>
                    <asp:BoundField DataField="Meat" HeaderText="Meat"></asp:BoundField>
                    <asp:BoundField DataField="Broth" HeaderText="Broth"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price"></asp:BoundField>
                    <asp:ButtonField CommandName="Select" Text="Update" ButtonType="Link"></asp:ButtonField>
                    <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Button"></asp:ButtonField>
                </Columns>
            </asp:GridView>
            </div>
            <br />
            <div>
                <asp:Button ID="InsertRamenButton" runat="server" Text="Insert Ramen" OnClick="OnInsertRamenButtonClicked"/>
            </div>
        </div>
    </div>
</asp:Content>
