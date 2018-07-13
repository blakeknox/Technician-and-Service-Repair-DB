<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Project1.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Menu</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            <asp:Label ID="lblMain" runat="server" style="z-index: 1; left: 557px; top: 101px; position: absolute; width: 93px" Text="Main Menu" Font-Bold="True"></asp:Label>
        </p>
        <asp:Button ID="btnService" runat="server" OnClick="btnService_Click" style="z-index: 1; left: 555px; top: 141px; position: absolute; width: 96px;" Text="Service" />
        <asp:Button ID="btnProblem" runat="server" style="z-index: 1; left: 552px; top: 179px; position: absolute; width: 98px;" Text="Problem" OnClick="btnProblem_Click" />
        <asp:Button ID="btnReports" runat="server" style="z-index: 1; left: 551px; top: 222px; position: absolute; width: 102px;" Text="Reports" OnClick="btnReports_Click" />
        <asp:Button ID="btnTechnicians" runat="server" style="z-index: 1; left: 549px; top: 267px; position: absolute" Text="Technicians" OnClick="btnTechnicians_Click" />
    </form>
</body>
</html>
