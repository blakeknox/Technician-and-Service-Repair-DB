<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceEvent.aspx.cs" Inherits="Project1.ServiceEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
        <asp:Label ID="lblService" runat="server" style="z-index: 1; left: 562px; top: 45px; position: absolute" Text="Service Event Entry" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblEventDate" runat="server" style="z-index: 1; left: 479px; top: 142px; position: absolute" Text="Event Date:"></asp:Label>
        <asp:Label ID="lblClient" runat="server" style="z-index: 1; left: 494px; top: 172px; position: absolute" Text="*Client:"></asp:Label>
        <asp:Label ID="lblContact" runat="server" style="z-index: 1; left: 490px; top: 202px; position: absolute" Text="*Contact:"></asp:Label>
        <asp:Label ID="lblPhone" runat="server" style="z-index: 1; left: 502px; top: 233px; position: absolute" Text="*Phone:"></asp:Label>
        <asp:Label ID="lblAsterisk" runat="server" style="z-index: 1; left: 394px; top: 264px; position: absolute; width: 248px" Text="* indicates required information" ForeColor="#FF3300"></asp:Label>
        <asp:DropDownList ID="ddlClient" runat="server" style="z-index: 1; left: 571px; top: 175px; position: absolute; width: 193px">
        </asp:DropDownList>
        <asp:TextBox ID="txtContact" runat="server" style="z-index: 1; left: 575px; top: 201px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 573px; top: 230px; position: absolute"></asp:TextBox>
        <asp:Button ID="btnNext" runat="server" style="z-index: 1; left: 440px; top: 304px; position: absolute" Text="Next" OnClick="btnNext_Click" />
        <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 577px; top: 299px; position: absolute" Text="Clear" OnClick="btnClear_Click" />
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 59px; top: 342px; position: absolute" Text="(error messasge)" ForeColor="#FF3300"></asp:Label>
        <asp:Button ID="btnReturn" runat="server" style="z-index: 1; left: 384px; top: 101px; position: absolute; width: 171px; right: 629px;" Text="Return to Main Menu" OnClick="btnReturn_Click" />
            </div>
        
        <asp:Label ID="lblDate" runat="server" style="z-index: 1; left: 596px; top: 140px; position: absolute; width: 247px"></asp:Label>
        
    </form>
</body>
</html>
