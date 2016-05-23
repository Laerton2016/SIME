<%@ Page Title="Cadastro de cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Web_Clientes.aspx.cs" Inherits="SIME.Clientes" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Src="Controles/Mensagem.ascx" TagName="Mensagem" TagPrefix="msg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 383px;
        }
        .style4
        {
            width: 281px;
        }
        .style6
        {
            background: #E9E9FE;
            margin-left: 1px;
            height: 20px;
            font-family: Tahoma;
            font-size: 12cpx;
            font-weight: bold;
            width: 101px;
        }
        .style7
        {
            width: 99px;
        }
        .auto-style2 {
            background: #E9E9FE;
            margin-left: 1px;
            height: 20px;
            font-family: Tahoma;
            font-size: 12cpx;
            font-weight: bold;
            width: 64px;
        }
        .auto-style4 {
            width: 265px;
        }
        .auto-style5 {
            width: 140px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpPanel_dados" runat="server" Visible = "true">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td class="rotulo">
                        Cadastro de Cliente
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpPanel_busca" runat="server" Visible = "true">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="rotulo2" Width="120px" >
                                            Buscar/Adicionar:
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="TxtBusca" runat="server" class="caixaTexto"  Height="22px" Width="450px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btBuscar" runat="server" Text="Buscar" class="botao" 
                                                Width="80px" onclick="btBuscar_Click" />
                                            <asp:Label ID="lbMensagem" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpPanel_resultado" runat="server" Visible = "false">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="rotulo2" Width="120px">
                                            Lista de clientes:
                                        </td>
                                        <td class="style2">
                                            <asp:DropDownList ID="ComboClientes" runat="server" class="caixaTexto"  Height="22px" Width="453px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="Bt_editar" runat="server" Text="Editar" class="botao" 
                                                Width="80px" onclick="Bt_editar_Click" />
                                            &nbsp;<asp:Button ID="Bt_Retorna_busca" runat="server" Text="Retornar" 
                                                class="botao" onclick="Bt_Retorna_busca_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpPanel_informacoes" runat="server" Visible ="false">
                            <ContentTemplate>
                                <Ajax:TabContainer ID="TabC_dados" runat="server" ActiveTabIndex="0" Width="908px"   >
                                    <Ajax:TabPanel ID="TabPanel1" runat="server" HeaderText="Dados pessoais" OnDemandMode="Always">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="dados_pessoais" runat="server">
                                                <ContentTemplate>
                                                    <table style="width: 102%;">
                                                        <tr   Height="15px">
                                                            <td class="rotulo" colspan="6">
                                                                COD:
                                                                <asp:Label ID="lbDados" Text ="" runat = "server" />
                                                                </td>
                                                        </tr>
                                                        <tr Height="15px">
                                                            <td  class="rotulo2" >
                                                                Nome:</td>
                                                            <td class="style4">
                                                                <asp:TextBox ID="TxtNome" runat="server" class="caixaTexto" Width="277px"></asp:TextBox>
                                                            </td>
                                                            <td class="auto-style2">
                                                                CPF/CNPJ:
                                                            </td>
                                                            <td class="auto-style4">
                                                                <asp:CheckBox ID="chkTipo" runat ="server" Text ="CNPJ" OnCheckedChanged="chkTipo_CheckedChanged" />
                                                                &nbsp;
                                                                <asp:TextBox ID="txtCPF" runat="server" class="caixaTexto"></asp:TextBox>
                                                                <Ajax:MaskedEditExtender ID="maskCPF" runat="server" 
                                                                    ClearMaskOnLostFocus="false" CultureName="en-US" Mask="999.999.999-99" 
                                                                    TargetControlID="txtCPF" />
                                                            </td>
                                                            <td class="rotulo2">
                                                                CEP:
                                                            </td>
                                                            <td class="auto-style5">
                                                                <asp:TextBox ID="txtCEP" runat="server" class="caixaTexto" Width="80px"></asp:TextBox>
                                                                <Ajax:MaskedEditExtender ID="maskCEP" runat="server" 
                                                                    ClearMaskOnLostFocus="false" CultureName="en-US" Mask="99999999" 
                                                                    TargetControlID="txtCEP" />
                                                                <asp:ImageButton ID="BtCep" runat="server" 
                                                                    ImageUrl="~/imagens/turn-on_16x16.gif" onclick="BtCep_Click" 
                                                                    ToolTip="Busca dasdos do CEP na internet." />
                                                            </td>
                                                        </tr>
                                                        <tr   Height="15px">
                                                            <td class="rotulo2">
                                                                Endereço
                                                            </td>
                                                            <td class="style4">
                                                                <asp:TextBox ID="TxtEnd" runat="server" class="caixaTexto" Width="280px"></asp:TextBox>
                                                            </td>
                                                            <td class="auto-style2">
                                                                Bairro
                                                            </td>
                                                            <td class="auto-style4">
                                                                <asp:TextBox ID="TxtBairro" runat="server" class="caixaTexto"></asp:TextBox>
                                                            </td>
                                                            <td class="rotulo2">
                                                                UF:
                                                            </td>
                                                            <td class="auto-style5">
                                                                <asp:DropDownList ID="TxtUF" runat="server" class="caixaTexto">
                                                                    <asp:ListItem>AC</asp:ListItem>
                                                                    <asp:ListItem>AP</asp:ListItem>
                                                                    <asp:ListItem>AL</asp:ListItem>
                                                                    <asp:ListItem>AM</asp:ListItem>
                                                                    <asp:ListItem>BA</asp:ListItem>
                                                                    <asp:ListItem>CE</asp:ListItem>
                                                                    <asp:ListItem>DF</asp:ListItem>
                                                                    <asp:ListItem>ES</asp:ListItem>
                                                                    <asp:ListItem>GO</asp:ListItem>
                                                                    <asp:ListItem>MA</asp:ListItem>
                                                                    <asp:ListItem>MG</asp:ListItem>
                                                                    <asp:ListItem>MS</asp:ListItem>
                                                                    <asp:ListItem>MT</asp:ListItem>
                                                                    <asp:ListItem>PA</asp:ListItem>
                                                                    <asp:ListItem>PB</asp:ListItem>
                                                                    <asp:ListItem>PE</asp:ListItem>
                                                                    <asp:ListItem>PI</asp:ListItem>
                                                                    <asp:ListItem>PR</asp:ListItem>
                                                                    <asp:ListItem>RJ</asp:ListItem>
                                                                    <asp:ListItem>RN</asp:ListItem>
                                                                    <asp:ListItem>RO</asp:ListItem>
                                                                    <asp:ListItem>RR</asp:ListItem>
                                                                    <asp:ListItem>RS</asp:ListItem>
                                                                    <asp:ListItem>SC</asp:ListItem>
                                                                    <asp:ListItem>SE</asp:ListItem>
                                                                    <asp:ListItem>SP</asp:ListItem>
                                                                    <asp:ListItem>TO</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr   Height="15px">
                                                            <td class="rotulo2">
                                                                Cidade:
                                                            </td>
                                                            <td class="style4">
                                                                <asp:DropDownList ID="TxtCidade" runat="server" class="caixaTexto">
                                                                </asp:DropDownList>
                                                                <div style="display: none;">
                                                                <asp:Button ID="montaListaCidades" runat ="server" Height = "0px" Width ="0px"  OnClick="montaListaCidades_Click" />
                                                                </div>
                                                            </td>
                                                            <td class="auto-style2">
                                                                Referência:
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txtPonto" runat="server" class="caixaTexto"   Width="320px"></asp:TextBox>
                                                                &nbsp; &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr   Height="15px">
                                                            <td class="rotulo2">
                                                                Telefone:
                                                            </td>
                                                            <td class="style4">
                                                                <asp:TextBox ID="txtTel" runat="server" class="caixaTexto"></asp:TextBox>
                                                                <Ajax:MaskedEditExtender ID="maskTele" runat="server" ClearMaskOnLostFocus ="false"  TargetControlID="txtTel" Mask ="(99)9999-9999" />
                                                            </td>
                                                            <td class="auto-style2">
                                                                Operadora:
                                                            </td>
                                                            <td class="auto-style4">
                                                                <asp:DropDownList ID="CobOperadora" runat="server"  Width="157px" class="caixaTexto">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="rotulo2">
                                                                Nascimento:
                                                            </td>
                                                            <td class="auto-style5">
                                                                <asp:TextBox ID="txtNasc" runat="server" class="caixaTexto" Width="100px"></asp:TextBox>
                                                                <Ajax:MaskedEditExtender ID="maskNasc" runat="server" ClearMaskOnLostFocus ="false" TargetControlID ="txtNasc" Mask="99/99/9999" UserDateFormat="DayMonthYear" />
                                                            </td>
                                                        </tr>
                                                        <tr   Height="15px">
                                                            <td class="rotulo2">
                                                                IE/Identidade:
                                                            </td>
                                                            <td class="style4">
                                                                <asp:TextBox ID="txtIE" runat="server" class="caixaTexto"></asp:TextBox>
                                                            </td>
                                                            <td class="auto-style2">
                                                                E-mail:
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txtEmail" runat="server" class="caixaTexto" Width="280px"></asp:TextBox>
                                                                &nbsp;<asp:CheckBox ID="chkFiel" runat ="server" Text="Fidelizado." />
                                                            </td>
                                                        </tr>
                                                        <tr   Height="15px">
                                                            <td colspan="6" class="rotulo">
                                                                Filiação &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr  Height="15px">
                                                            <td class="rotulo2">
                                                                Pai:
                                                            </td>
                                                            <td class="style4">
                                                                <asp:TextBox ID="txtPai" runat="server" class="caixaTexto"   Width="280px"></asp:TextBox>
                                                            </td>
                                                            <td class="auto-style2">
                                                                Mãe:
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txtMae" runat="server" class="caixaTexto"   Width="280px"></asp:TextBox>
                                                                &nbsp;
                                                                <asp:Button ID="txtGravar" runat="server" class="botao" Width="80px" 
                                                                    Text="Gravar" onclick="txtGravar_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                    </Ajax:TabPanel>
                                    <Ajax:TabPanel ID="TabPanel2" runat="server" HeaderText="Dados financeiros" OnDemandMode="Always">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="dados_financeiros" runat="server">
                                                <ContentTemplate>
                                                    teste1...
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                    </Ajax:TabPanel>
                                    <Ajax:TabPanel ID="TabPanel3" runat="server" HeaderText="Informações extras" OnDemandMode="Always">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="Informacoes_extras" runat="server">
                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                    </Ajax:TabPanel>
                                </Ajax:TabContainer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
