<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resolutions.aspx.cs" Inherits="Project1.Resolutions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblResEntry" runat="server" style="z-index: 1; left: 520px; top: 62px; position: absolute" Text="Resolution Entry"></asp:Label>
        <asp:Button ID="btnReturnOpen" runat="server" style="z-index: 1; left: 177px; top: 108px; position: absolute" Text="Return to Open" OnClick="btnReturnOpen_Click" />
        <asp:Label ID="lblTicket" runat="server" style="z-index: 1; left: 268px; top: 164px; position: absolute" Text="Ticket No:"></asp:Label>
        <asp:Label ID="lblTicketNum" runat="server" style="z-index: 1; left: 389px; top: 164px; position: absolute"></asp:Label>
        <asp:Label ID="lblProb" runat="server" style="z-index: 1; left: 253px; top: 204px; position: absolute" Text="Problem No:"></asp:Label>
        <asp:Label ID="lblProbNum" runat="server" style="z-index: 1; left: 400px; top: 203px; position: absolute"></asp:Label>
        <asp:Label ID="lblRes" runat="server" style="z-index: 1; left: 235px; top: 251px; position: absolute; width: 124px" Text="Resolution No:"></asp:Label>
        <asp:Label ID="lblResolutionNum" runat="server" style="z-index: 1; left: 415px; top: 252px; position: absolute"></asp:Label>
        <asp:Label ID="lblResolution" runat="server" style="z-index: 1; left: 231px; top: 304px; position: absolute; width: 118px" Text="*Resolution:"></asp:Label>
        <asp:TextBox ID="txtResolution" runat="server" style="z-index: 1; left: 383px; top: 317px; position: absolute; width: 247px; height: 94px" MaxLength="250"></asp:TextBox>
        <asp:Label ID="lblTechnician" runat="server" style="z-index: 1; left: 231px; top: 432px; position: absolute; width: 118px" Text="*Technician:"></asp:Label>
        <asp:Label ID="lblHours" runat="server" style="z-index: 1; left: 242px; top: 496px; position: absolute; width: 62px" Text="*Hours:"></asp:Label>
        <asp:Label ID="lblSupplies" runat="server" style="z-index: 1; left: 238px; top: 540px; position: absolute" Text="Supplies:"></asp:Label>
        <asp:Label ID="lblDateFixed" runat="server" style="z-index: 1; left: 234px; top: 585px; position: absolute" Text="Date Fixed:"></asp:Label>
        <asp:TextBox ID="txtHours" runat="server" style="z-index: 1; left: 339px; top: 497px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="txtSupplies" runat="server" style="z-index: 1; left: 341px; top: 546px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="txtDateFixed" placeholder= "MM/DD/YYYY" runat="server" style="z-index: 1; left: 346px; top: 583px; position: absolute"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" style="z-index: 1; left: 156px; top: 661px; position: absolute" Text="Submit" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnClear" runat="server" style="z-index: 1; left: 353px; top: 661px; position: absolute" Text="Clear" OnClick="btnClear_Click" />
        <asp:Label ID="lblMileage" runat="server" style="z-index: 1; left: 582px; top: 499px; position: absolute" Text="Mileage"></asp:Label>
        <asp:Label ID="lblMisc" runat="server" style="z-index: 1; left: 590px; top: 544px; position: absolute" Text="Misc:"></asp:Label>
        <asp:TextBox ID="txtMileage" runat="server" style="z-index: 1; left: 671px; top: 498px; position: absolute; width: 88px"></asp:TextBox>
        <asp:TextBox ID="txtMisc" runat="server" style="z-index: 1; left: 665px; top: 544px; position: absolute; width: 104px"></asp:TextBox>
        <asp:Label ID="lblCostMiles" runat="server" style="z-index: 1; left: 834px; top: 497px; position: absolute" Text="Cost Miles:"></asp:Label>
        <asp:Label ID="lblDateOnsite" runat="server" style="z-index: 1; left: 829px; top: 546px; position: absolute" Text="Date Onsite:"></asp:Label>
        <asp:TextBox ID="txtCostMiles" runat="server" style="z-index: 1; left: 954px; top: 496px; position: absolute; width: 110px"></asp:TextBox>
        <asp:TextBox ID="txtDateOnsite" placeholder= "MM/DD/YYYY" runat="server" style="z-index: 1; left: 953px; top: 544px; position: absolute; width: 111px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 187px; top: 621px; position: absolute" Text="* Indicates Required Feild" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" style="z-index: 1; left: 737px; top: 665px; position: absolute"></asp:Label>
        <asp:CheckBox ID="chkNoCharge" runat="server" OnCheckedChanged="chkNoCharge_CheckedChanged" style="z-index: 1; left: 917px; top: 445px; position: absolute" Text="No Charge" />
        <asp:DropDownList ID="ddlTechnician1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTechnician1_SelectedIndexChanged" style="z-index: 1; left: 379px; top: 435px; position: absolute; width: 168px">
        </asp:DropDownList>
    </form>
</body>
</html>
