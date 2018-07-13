<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenPoblems.aspx.cs" Inherits="Project1.OpenPoblems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Open Problems</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblOpenProblems" runat="server" Font-Bold="True" style="z-index: 1; left: 520px; top: 46px; position: absolute" Text="Open Problems"></asp:Label>
        <asp:GridView ID="gvProblems" runat="server" style="z-index: 1; left: 307px; top: 255px; position: absolute; height: 225px; width: 634px" OnRowCommand="gvProblems_RowCommand">
        <Columns>
            <asp:ButtonField CommandName="SELECT" Text="Select" />
        </Columns>
        </asp:GridView>
        
        <asp:Button ID="btnReturnMain" runat="server" OnClick="btnReturnMain_Click" style="z-index: 1; left: 240px; top: 149px; position: absolute; width: 168px; height: 41px" Text="Return To Main Menu" />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" style="z-index: 1; left: 231px; top: 499px; position: absolute"></asp:Label>
    </form>
</body>
</html>
