<%@ Page Language="C#" AutoEventWireup="True" Inherits="CS" Codebehind="CS.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <br/>
    <asp:Button ID="btnSave" runat="server" Text="Save to Excel" OnClick="btnSave_Click" />
</form>
</body>
</html>
