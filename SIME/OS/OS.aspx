<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OS.aspx.cs" Inherits="SIME.Relatorio.OS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            width: 401px;
            height: 476px;
            
        }
        .style1
        {
            width: 19px;
        }
        .style2
        {
            width: 351px;
        }
        .style3
        {
            height: 14px;
        }
        .style4
        {
            height: 12px;
        }
        .style5
        {
            height: 10px;
        }
        .style6
        {
            height: 2px;
        }
        .style7
        {
            width: 22px;
        }
        .style8
        {
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%; height: 311px; font-family: 'Dotum';">
        <tr>
            <td class="style3" colspan="3">
                ---------------------------------------<br />
&nbsp;TV SOM - Com. de TV&#39;s e Peças Gadelha
                <br />
&nbsp;Ltda e/ou SIL Sousa Informática Ltda.
                <br />
                ---------------------------------------</td>
        </tr>
        <tr>
            <td class="style4" colspan="3">
&nbsp;End.: Av. Eng. Carlos Pires de Sá,S/N<br />
&nbsp;Centro Sousa - PB CEP 58800-280<br />
&nbsp;Telefones:(83)3521-1630/3522-2872/2786<br />
                ---------------------------------------</td>
        </tr>
        <tr>
            <td class="style5" colspan="3">
&nbsp;e-mail: <a href="mailto:tvsom.gadelha@bol.com.br">tvsom.gadelha@bol.com.br</a><br />
&nbsp;Site: <a href="http://www.lojasil.com">www.lojasil.com</a><br />
                ---------------------------------------</td>
        </tr>
        <tr>
            <td class="style6" colspan="3">
&nbsp;<asp:Label ID="labDadosOS" runat="server" Text="Dados OS" 
                    ></asp:Label>
                <br />
                =======================================</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="labDadosAparelho" runat="server" Text="Dados aparelho"></asp:Label>
            </td>
            <td class="style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8" colspan="3">
                =======================================<br />
                <br />
                __________________________<br />
                <asp:Label ID="labDadosCliente" runat="server" Text="Dados Cliente"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8" colspan="3">
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
