<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Raamen.View.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Register</h1>
        <div>
            <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTextbox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTextbox" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ConfirmationPasswordLabel" runat="server" Text="Confirmation Password"></asp:Label>
            <asp:TextBox ID="ConfirmationPasswordTextbox" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTextbox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="GenderLabel" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="GenderRadioButtonList" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="OnRegisterButtonClicked"/>
        </div>
    </div>
</asp:Content>
