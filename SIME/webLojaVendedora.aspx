<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webLojaVendedora.aspx.cs" Inherits="SIME.Class.webLojaVendedora" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de loja vendedora</title>
    <style type="text/css">
        .style1
        {
            font-family: "Arial Narrow";
            font-size: x-large;
        }
        .style2
        {
            width: 235px;
        }
        .style3
        {
            width: 485px;
        }
        .style4
        {
        }
        .style5
        {
            width: 108px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td align="center" bgcolor="#99CCFF" class="style1" colspan="4">
                    Cadastro de loja vendedora</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="Label1" runat="server" 
                        style="font-family: 'Arial Narrow'; font-size: medium" Text="Razão Social:"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox1" runat="server" Height="25px" 
                        style="font-family: 'Arial Narrow'; font-size: medium" Width="479px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Label ID="Label2" runat="server" 
                        style="font-family: 'Arial Narrow'; font-size: medium" Text="CNPJ:"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox2" runat="server" Height="25px" 
                        style="font-family: 'Arial Narrow'; font-size: medium" Width="479px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td align="center" class="style4" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Gravar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
