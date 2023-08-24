<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Raamen.View.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Login</h1>
        <div>
            <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTextbox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTextbox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="RememberMeLabel" runat="server" Text="Remember me"></asp:Label>
            <asp:CheckBox ID="RememberMeCheckbox" runat="server" />
        </div>
        <div>
            <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="OnLoginButtonClicked"/>
        </div>
    </div>
</asp:Content>
