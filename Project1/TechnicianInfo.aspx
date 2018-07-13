<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicianInfo.aspx.cs" Inherits="Project1.TechnicianInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Technician Maintenance</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAsterisk" runat="server" style="z-index: 1; left: 421px; top: 374px; position: absolute" Text="*indicates required feild" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblHourlyRate" runat="server" style="z-index: 1; left: 423px; top: 342px; position: absolute; height: 18px" Text="*Hourly Rate:"></asp:Label>
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 381px; top: 409px; position: absolute" Text="(error message)" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblTitle" runat="server" style="z-index: 1; left: 600px; top: 17px; position: absolute" Text="Technician Maintenance"></asp:Label>
            <asp:Button ID="btnReturn" runat="server" style="z-index: 1; left: 420px; top: 52px; position: absolute" Text="Return to Main Menu" OnClick="btnReturn_Click" />
            <asp:Label ID="lblTechnician" runat="server" style="z-index: 1; left: 443px; top: 100px; position: absolute" Text="Technician:"></asp:Label>
            <asp:TextBox ID="txtFname" runat="server" style="z-index: 1; left: 563px; top: 131px; position: absolute"></asp:TextBox>
            <asp:Label ID="lblFName" runat="server" style="z-index: 1; left: 437px; top: 133px; position: absolute" Text="*First Name:"></asp:Label>
            <asp:Label ID="lblMI" runat="server" style="z-index: 1; left: 434px; top: 166px; position: absolute" Text="Middle Intial:"></asp:Label>
            <asp:Label ID="lblLName" runat="server" style="z-index: 1; left: 437px; top: 196px; position: absolute" Text="*Last Name:"></asp:Label>
            <asp:Label ID="lblEmail" runat="server" style="z-index: 1; left: 433px; top: 230px; position: absolute" Text="Email:"></asp:Label>
            <asp:Label ID="lblDepartment" runat="server" style="z-index: 1; left: 430px; top: 261px; position: absolute" Text="Department:"></asp:Label>
            <asp:Label ID="lblPhone" runat="server" style="z-index: 1; left: 432px; top: 295px; position: absolute" Text="*Phone:"></asp:Label>
            <asp:DropDownList ID="ddlTechnician" runat="server" style="z-index: 1; left: 564px; top: 96px; position: absolute; height: 19px; width: 126px;" AutoPostBack="True" OnSelectedIndexChanged="ddlTechnician_SelectedIndexChanged"></asp:DropDownList>
            <asp:TextBox ID="txtMI" runat="server" style="z-index: 1; left: 561px; top: 166px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtLname" runat="server" style="z-index: 1; left: 559px; top: 200px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" style="z-index: 1; left: 560px; top: 234px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDepartment" runat="server" style="z-index: 1; left: 560px; top: 261px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtPhone" runat="server" style="z-index: 1; left: 563px; top: 289px; position: absolute" OnTextChanged="txtPhone_TextChanged"></asp:TextBox>
            <asp:TextBox ID="txtHourlyRate" runat="server" style="z-index: 1; left: 556px; top: 336px; position: absolute"></asp:TextBox>
            <asp:Button ID="btnAccept" runat="server" style="z-index: 1; left: 266px; top: 435px; position: absolute" Text="Accept" OnClick="btnAccept_Click" />
            <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: 365px; top: 435px; position: absolute" Text="Cancel" OnClick="btnCancel_Click" />
            <asp:Button ID="btnRemove" runat="server" style="z-index: 1; left: 465px; top: 435px; position: absolute" Text="Remove" OnClick="btnRemove_Click" onclientclick="return confirm('Are you sure you want to delete tecnician?');"/>
            <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 566px; top: 435px; position: absolute; width: 47px;" Text="Clear" OnClick="btnClear_Click" />
            <asp:Button ID="btnNewTech" runat="server" style="z-index: 1; left: 784px; top: 89px; position: absolute" Text="New Technician" OnClick="btnNewTech_Click" />
        </div>
        
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
