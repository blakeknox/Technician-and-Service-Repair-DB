<%@ Page Title="" Language="C#" MasterPageFile="~/ReportsMaster.Master" AutoEventWireup="true" CodeBehind="ReportSelection.aspx.cs" Inherits="Project1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" style="z-index: 1; left: 488px; top: 195px; position: absolute" Text="Problem By Instituion" OnClick="Button1_Click" />
<p>
</p>
<asp:Button ID="btnMain" runat="server" OnClick="btnMain_Click" style="z-index: 1; left: 497px; top: 488px; position: absolute" Text="Return To Main Menu" />
<asp:Button ID="btnTechnician" runat="server" style="z-index: 1; left: 478px; top: 404px; position: absolute" Text="Problems By Technician" OnClick="btnTechnician_Click" />
<asp:Button ID="btnProduct" runat="server" style="z-index: 1; left: 495px; top: 329px; position: absolute" Text="Problems By Product" OnClick="btnProduct_Click" />
<asp:Button ID="btnClient" runat="server" style="z-index: 1; left: 508px; top: 266px; position: absolute" Text="Problem By Client" OnClick="btnClient_Click" />
</asp:Content>
