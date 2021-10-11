<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarloTest.aspx.cs" Inherits="BlaAndCamping.CarloTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/calendar.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 404px">
            <asp:Calendar ID="calendar_Main" runat="server" font-style="normal"></asp:Calendar>

            <asp:Label ID="label_ClendarInstruction" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btn_SelectStartDate" runat="server" Text="StartDate" />
            <asp:Button ID="btn_SelectEndDate" runat="server" Text="EndDate" />

            <asp:Label ID="label_StartDate" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="label_EndDate" runat="server" Text="Label"></asp:Label>

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

        </div>
        <div style="height: 166px">
            <asp:Label ID="label_State" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
