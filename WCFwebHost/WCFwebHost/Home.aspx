<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" %>
<%@ Import Namespace="ServiceReference1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        IAgentIntCalcServiceTestClient ad = new IAgentIntCalcServiceTestClient();
        int agbonus;
        agbonus = ad.AgentIntCal(int.Parse(TextBox1.Text), int.Parse(TextBox2.Text));
        Label1.Text = agbonus.ToString();
        Response.Write("ID :" + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            style="z-index: 1; left: 233px; top: 197px; position: absolute" 
            Text="Button" />
    
    </div>
    <p>
        You r in Home Page</p>
    <p>
        <asp:Label ID="Label1" runat="server" 
            style="z-index: 1; left: 62px; top: 199px; position: absolute"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" 
            style="z-index: 1; left: 72px; top: 141px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" 
            style="z-index: 1; left: 255px; top: 140px; position: absolute"></asp:TextBox>
    </p>
    </form>
    </body>
</html>
