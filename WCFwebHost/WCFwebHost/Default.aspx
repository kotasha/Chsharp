<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WCFwebHost._Default" %>
<%--<%@ Import System.Namespace %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        This is default aspx</div>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            style="z-index: 1; left: 249px; top: 104px; position: absolute" 
            Text="Agent Bonus" />
        <asp:TextBox ID="TextBox1" runat="server" 
            style="z-index: 1; left: 55px; top: 53px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" 
            style="z-index: 1; left: 271px; top: 51px; position: absolute"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" 
            style="z-index: 1; left: 10px; top: 89px; position: absolute; height: 21px; width: 122px"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
