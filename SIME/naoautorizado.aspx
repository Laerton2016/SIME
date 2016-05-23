<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="naoautorizado.aspx.cs" Inherits="SIME.naoautorizado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        height: 171px;
        font-size: xx-large;
        font-family: "Arial Narrow";
        color: #FF3300;
    }
    .style2
    {
        height: 171px;
        width: 118px;
    }
    .style3
    {
        width: 156px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="style3" rowspan="3">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
        <td rowspan="3">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <img alt="" src="Imagens/IconeCadeado.png" /></td>
        <td class="style1">
            Usuário não autorizado para este serviço.<br />
            Contate o administrador do sistema.</td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
