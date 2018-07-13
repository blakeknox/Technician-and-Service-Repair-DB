<%@ Page Title="" Language="C#" MasterPageFile="~/ReportsMaster.Master" AutoEventWireup="true" CodeBehind="ReportDisplay.aspx.cs" Inherits="Project1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvReports" runat="server" OnSelectedIndexChanged="gvReports_SelectedIndexChanged" style="z-index: 1; left: 303px; top: 205px; position: absolute; height: 378px; width: 593px">
</asp:GridView>
<p>
</p>
<asp:Button ID="btnReports" runat="server" OnClick="btnReports_Click" style="z-index: 1; left: 163px; top: 130px; position: absolute; width: 174px" Text="Return to Reports" />
<asp:Label ID="lblError" runat="server" ForeColor="Red" style="z-index: 1; left: 239px; top: 621px; position: absolute"></asp:Label>
</asp:Content>
