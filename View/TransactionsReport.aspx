<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionsReport.aspx.cs" Inherits="Raamen.View.TransactionsReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Transactions Report</h1>
        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server" AutoDataBind="true" />
        </div>
    </div>
</asp:Content>
