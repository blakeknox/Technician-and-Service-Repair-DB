<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Problems.aspx.cs" Inherits="Project1.Problems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Problem Entry</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblProbEntry" runat="server" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 512px; top: 54px; position: absolute" Text="Problem Entry"></asp:Label>
        <asp:Button ID="btnReturnToService" runat="server" style="z-index: 1; left: 135px; top: 118px; position: absolute" Text="Return to Service" OnClick="btnReturnToService_Click" />
        <asp:Label ID="lblTicketNum" runat="server" style="z-index: 1; left: 206px; top: 222px; position: absolute" Text="Ticket No."></asp:Label>
        <asp:Label ID="lblProbNum" runat="server" style="z-index: 1; left: 174px; top: 269px; position: absolute; width: 123px" Text="Problem No."></asp:Label>
        <asp:Label ID="lblProductNum" runat="server" style="z-index: 1; left: 183px; top: 321px; position: absolute" Text="*Product No:"></asp:Label>
        <asp:Label ID="lblProblem" runat="server" style="z-index: 1; left: 210px; top: 368px; position: absolute" Text="*Problem:"></asp:Label>
        <asp:Label ID="lblTechnician" runat="server" style="z-index: 1; left: 200px; top: 494px; position: absolute" Text="*Technician:"></asp:Label>
        <asp:Label ID="lblRequired" runat="server" ForeColor="Red" style="z-index: 1; left: 165px; top: 555px; position: absolute" Text="*Idicates required feild"></asp:Label>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" style="z-index: 1; left: 108px; top: 621px; position: absolute" Text="Submit" />
        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" style="z-index: 1; left: 287px; top: 622px; position: absolute" Text="Clear" />
        <asp:Label ID="lblTicketCount" runat="server" style="z-index: 1; left: 340px; top: 221px; position: absolute"></asp:Label>
        <asp:Label ID="lblProbCount" runat="server" style="z-index: 1; left: 354px; top: 265px; position: absolute"></asp:Label>
        <asp:DropDownList ID="ddlProduct" runat="server" style="z-index: 1; left: 359px; top: 321px; position: absolute; width: 204px">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlTechnician" runat="server" style="z-index: 1; left: 367px; top: 494px; position: absolute; width: 180px">
        </asp:DropDownList>
        <asp:TextBox ID="txtProbDesc" runat="server" style="z-index: 1; left: 346px; top: 379px; position: absolute; height: 88px; width: 290px" MaxLength="500"></asp:TextBox>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" style="z-index: 1; left: 482px; top: 558px; position: absolute"></asp:Label>
    </form>
</body>
</html>
