<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="logar.aspx.cs" Inherits="SIME.logar" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        height: 62px;
        text-align: center;
    }
    .style2
    {
        height: 62px;
        width: 73px;
        text-align: center;
    }
    .style3
    {
        height: 62px;
        width: 207px;
        text-align: left;
    }
        .style5
        {
            height: 62px;
            text-align: center;
            width: 71px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <asp:ScriptManager ID="ajaxkit" runat="server">
    </asp:ScriptManager>
    <Ajax:DropShadowExtender ID="dados1" runat = "server" TargetControlID = "Panel3" Opacity = "0.8"
    Rounded = "true" TrackPosition = "true" ></Ajax:DropShadowExtender>
        &nbsp;</p>
<asp:Panel ID="Panel3" runat="server" 
    Height="178px" style="margin-left: 279px" Width="364px">
    <table >
        <tr>
            <td colspan="3" style="font-size: x-large; text-align: center" 
                bgcolor="#CEEBF0">
                Logar</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Image ID="Image1" runat="server" Height="32px" 
                    ImageUrl="~/Imagens/IconeCadeado.png" Width="34px" />
            </td>
            <td class="style3">
                Usuário:
                <br />
                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="laberrousuario" runat="server" EnableTheming="True" 
                    ForeColor="#FF3300"></asp:Label>
                <br />
                Senha:&nbsp;&nbsp;
                <br />
                <asp:TextBox ID="TxtSenha" runat="server" style="margin-left: 1px" 
                    TextMode="Password"></asp:TextBox>
                <br />
                <asp:Label ID="laberosenha" runat="server" EnableTheming="True" 
                    ForeColor="#FF3300"></asp:Label>
            </td>
            <td class="style5">
                <br />
                <br />
                <asp:Button ID="Btlogar" runat="server" Text="Logar" onclick="Btlogar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>
