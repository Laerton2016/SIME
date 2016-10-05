<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="iventario.aspx.cs" Inherits="SIME.Inventario.iventario" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
        }
        .style5
        {
            background: #E9E9FE;
            margin-left: 1px;
            height: 20px;
            font-family: Tahoma;
            font-size: 12cpx;
            font-weight: bold;
            width: 191px;
        }
        .style6
        {
            width: 191px;
        }
        .style7
        {
        }
        .style14
        {
            width: 135px;
        }
        .style15
        {
            width: 241px;
        }
        .style16
        {
            width: 99px;
        }
        .style17
        {
            width: 78px;
        }
        .style19
        {
            width: 161px;
        }
        .style20
        {
            width: 133px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ajaxkit" runat="server">
    </asp:ScriptManager>
    
<asp:Panel ID= "inventario2014" runat ="server">
    <table style="width:100%;">
        <tr>
            <td colspan="9" class="rotulo">
                Invetário 2014</td>
        </tr>
        <tr>
            <td  colspan="9">
                <asp:Button ID="BtRelatorio" runat="server" class ="botao" Text ="Relatório" 
                    onclick="Button1_Click" />
                    
                    <asp:Button ID ="BtDivergentes" runat ="server" class ="botao" 
                    Text = "Divergentes" onclick="BtDivergentes_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style19">
                &nbsp;</td>
            <td class="style5">
                Digitite o codigo do produto:</td>
            <td class="style14">
            <asp:Panel ID="panelCod" runat ="server" >
                <asp:UpdatePanel ID="upCod" runat ="server" >
                    <ContentTemplate>
                        <asp:TextBox ID="txtID" runat="server" class="caixaTexto" Width="131px"></asp:TextBox>
                       <ajax:FilteredTextBoxExtender ID="ftxtID" runat="server" FilterType="Numbers, Custom" ValidChars="," TargetControlID="txtID" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            </td>
            <td class="style20">
            <asp:Button ID="btBuscar" runat="server" class="botao" Text="Buscar" 
                    onclick="btBuscar_Click" />
                &nbsp;<asp:Button ID="btLimpa" runat ="server" class ="botao" Text="Limpar" 
                    onclick="btLimpa_Click" />
                </td>
            <td class="style17">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style19">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style14">
                &nbsp;</td>
            <td class="style20">
                &nbsp;</td>
            <td class="style17">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style19">
                &nbsp;</td>
            <td class="style1" colspan="3" rowspan="2">
                <asp:Panel ID="panelDados" runat ="server" class="caixaTexto">
                    <asp:UpdatePanel ID="updados" runat ="server">
                        <ContentTemplate>
                        <asp:Label ID="labDados" runat ="server" Text =" ">
                        </asp:Label>
                            <table style="width:100%;">
                                <tr>
                                    <td class="rotulo2">
                                        EAN:</td>
                                    <td class="style15">
                                        <asp:TextBox ID="txtEAN" runat = "server" Width="189px" class="caixaTexto"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FtxtEAN" runat="server" FilterType="Numbers, Custom" ValidChars="," TargetControlID="txtEAN" />
                                        </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="rotulo2">
                                        Quantidade:</td>
                                    <td class="style15">
                                        <asp:TextBox ID="txtQauntidade" runat = "server" Width="85px" class="caixaTexto" ></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FtxtQuantidade" runat="server" FilterType="Numbers, Custom" ValidChars="," TargetControlID="txtQauntidade" />
                                        </td>
                                    <td>
                                        <asp:Button id="btGravar" runat = "server" class ="botao" Text ="Gravar" 
                                            onclick="btGravar_Click" /></td>
                                </tr>
                                <tr>
                                    <td class="style7" colspan="3">
                                        <asp:Label ID="labInforma" runat ="server" Text=" " ></asp:Label>
                                        </td>
                                </tr>
                            </table>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
            <td colspan="2">
                <asp:Panel ID="panelImg" runat ="server" >
                    <asp:UpdatePanel ID="UpImagem" runat ="server">
                    <ContentTemplate>
                    <asp:Image ID="imgProduto" runat="server" Height="162px" 
                            ImageUrl="~/Imagens/Imagem.jpg" Width="198px"/>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style19">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style19">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style14">
                &nbsp;</td>
            <td class="style20">
                &nbsp;</td>
            <td class="style17">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
</asp:Panel>
    </asp:Content>
