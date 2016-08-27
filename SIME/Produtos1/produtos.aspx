<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="produtos.aspx.cs" Inherits="SIME.Produtos.web_produtos" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style10
        {
        }
        .style20
        {
            width: 114px;
        }
        .style21
        {
            width: 105px;
        }
        .style24
        {
            width: 135px;
        }
        .style25
        {
            border: 1px solid #CDD0FE;
            margin-left: 0px;
            font-family: Tahoma;
            font-size: 12cpx;
            font-weight: bold;
            text-align: left;
            height: 12px;
        }
        .style27
        {
        }
        .style33
        {
            background: #DDD;
            font-family: Tahoma;
            font-size: small;
            font-weight: bold;
            text-align: left;
            border-top: 1px solid #CCCCCC;
            border-left: 1px solid #CCCCCC;
            border-right: 1px solid #CCCCCC;
            border-bottom-color: #DDD;
            width: 752px;
        }
        .style34
        {
            border: 1px solid #CDD0FE;
            margin-left: 0px;
            font-family: Tahoma;
            font-size: 12cpx;
            font-weight: bold;
            text-align: left;
            width: 752px;
        }
        .style36
        {
            background: #DDD;
            font-family: Tahoma;
            font-size: small;
            font-weight: bold;
            text-align: right;
            border-top: 1px solid #CCCCCC;
            border-left: 1px solid #CCCCCC;
            border-right: 1px solid #CCCCCC;
            border-bottom-color: #DDD;
            width: 83px;
        }
        .style37
        {
            width: 7px;
        }
        .style39
        {
            width: 165px;
        }
        .style40
        {
            width: 189px;
        }
        .style41
        {
        }
        .style42
        {
            width: 84px;
        }
        .style47
        {
            background: #E9E9FE;
            margin-left: 1px;
            font-family: Tahoma;
            font-size: 12cpx;
            font-weight: bold;
            height: 15px;
            width: 773px;
        }
        .style48
        {
            border: 1px solid #CDD0FE;
            margin-left: 1px;
            font-family: Tahoma;
            font-size: 12px;
            width: 773px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <Ajax:ToolkitScriptManager ID="ajaxkit" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:Panel ID="panelProdutos" runat="server">
        <asp:UpdatePanel ID="UpProdutos" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Panel ID="panelCabecalho" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="rotuloPequenoCinza">
                                            Buscar
                                        </td>
                                        <td class="rotuloPequenoCinza">
                                            Tipo de busca
                                        </td>
                                        <td class="rotuloPequenoCinza">
                                            Exibir
                                        </td>
                                        <td class="rotuloPequenoCinza">
                                            Ações
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="caixaTexto" align="center">
                                            <asp:TextBox ID="txtBusca" runat="server" Width="300px" ></asp:TextBox>
                                        </td>
                                        <td class="caixaTexto" align="center">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="style10" RepeatDirection="Horizontal"
                                                Width="180px">
                                                <asp:ListItem Value="DESC">Descrição</asp:ListItem>
                                                <asp:ListItem>ID</asp:ListItem>
                                                <asp:ListItem>EAN</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td class="caixaTexto" align="center">
                                            <asp:CheckBox ID="CHdesc" runat="server" Checked="True" Text="Descontinuado" ToolTip="Exibe os descontinuados" /><br />
                                            <asp:CheckBox ID="CHEstoque" runat ="server" Checked ="true" Text="Sem estoque" ToolTip ="Exibe os que tem estoque" />
                                        </td>
                                        <td class="caixaTexto" align="center">
                                            <asp:Button ID="btBuscar" runat="server" class="botao" OnClick="btBuscar_Click" Text="Buscar" />
                                            &nbsp;<asp:Button ID="btAdcionar" runat="server" class="botao" Text="Add" OnClick="btAdcionar_Click" />
                                            &nbsp;<asp:Button ID="btImport" runat="server" class="botao" Text="Importar" OnClick="btImport_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" class="caixaTexto">
                                            <asp:UpdatePanel ID="UpBusca" runat="server" Visible="false">
                                                <ContentTemplate>
                                                    Resultado: &nbsp;
                                                    <asp:DropDownList ID="combListaProdutos1" runat="server" class="caixaTexto" Width="300px">
                                                    </asp:DropDownList>
                                                    &nbsp; &nbsp;
                                                    <asp:Button ID="BtEditar" runat="server" Text="Editar" class="botao" OnClick="BtEditar_Click" />
                                                    &nbsp;
                                                    <asp:Button ID="BtSalvar1" runat="server" class="botao" OnClick="BtSalvar1_Click"
                                                        Text="Salvar" />
                                                    &nbsp;<asp:Label ID="labErro" runat="server" ForeColor="Red"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="updados" runat="server" Visible="false">
                                <ContentTemplate>
                                    <Ajax:TabContainer ID="tabDadps" runat="server" ActiveTabIndex="1" 
                                        Width="910px">
                                        <Ajax:TabPanel ID="DadosIniciais" runat="server" HeaderText="Dados do produto" OnDemandMode="Always">
                                            <HeaderTemplate>
                                                Dados do produto
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="panelDadosIniciais" runat="server" UpdateMode="Conditional">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btAddImagem" EventName="Click" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="rotuloPequenoCinza" colspan="6">
                                                                    Produto:
                                                                </td>
                                                                <td class="rotuloPequenoCinza" colspan="3">
                                                                    Complemento:
                                                                </td>
                                                                <td class="rotuloPequenoCinza" colspan="2">
                                                                    Imagem:
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="caixaTexto" colspan="6">
                                                                    <asp:TextBox ID="txtDescricao" runat="server" class="caixaTexto" Width="400px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto" colspan="3">
                                                                    <asp:TextBox ID="txtComplemento" runat="server" class="caixaTexto" Width="210px"></asp:TextBox>
                                                                </td>
                                                                <td rowspan="7" align="center" colspan="2">
                                                                    <asp:Image ID="imgProduto" runat="server" Height="178px" ImageUrl="~/Imagens/Imagem.jpg"
                                                                        Style="margin-left: 0px" Width="196px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="rotuloPequenoCinza" colspan="3">
                                                                    EAN:
                                                                </td>
                                                                <td class="rotuloPequenoCinza" colspan="3">
                                                                    NCM:
                                                                </td>
                                                                <td class="rotuloPequenoCinza">
                                                                    Mínimo:
                                                                </td>
                                                                <td class="rotuloPequenoCinza">
                                                                    Cod. de Fabrica:
                                                                </td>
                                                                <td class="rotuloPequenoCinza">
                                                                    ID
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="caixaTexto" colspan="3">
                                                                    <asp:TextBox ID="txtEAN" runat="server" class="caixaTexto" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto" colspan="3">
                                                                    <asp:TextBox ID="txtNCM" runat="server" class="caixaTexto" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto">
                                                                    <asp:TextBox ID="txtMinimo" runat="server" class="caixaTexto" Width="50px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto">
                                                                    <asp:TextBox ID="txtCodFabrica" runat="server" class="caixaTexto" Width="105px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto">
                                                                    <asp:Label ID="labID0" runat="server" class="caixaTexto"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="rotuloPequenoCinza">
                                                                    Peso:
                                                                </td>
                                                                <td class="rotuloPequenoCinza" colspan="4">
                                                                    Grupo:
                                                                </td>
                                                                <td class="rotuloPequenoCinza" colspan="4">
                                                                    Medida:
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="caixaTexto" colspan="2">
                                                                    <asp:TextBox ID="txtPeso" runat="server" class="caixaTextoValor" Width="50px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto" colspan="2">
                                                                    <asp:DropDownList ID="CombGrupo1" runat="server" class="caixaTexto" Width="220px">
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:ImageButton ID="BtAddGrupo" runat="server" ImageUrl="~/Imagens/group.png" ToolTip="Adicionar grupo." />
                                                                </td>
                                                                <td class="caixaTexto" colspan="5">
                                                                    <asp:DropDownList ID="combUnidade" runat="server" class="caixaTexto">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="rotuloPequenoCinza" colspan="6">
                                                                    Política:
                                                                </td>
                                                                <td class="rotuloPequenoCinza" colspan="3">
                                                                    Produto descontinuado:
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="caixaTexto" colspan="6">
                                                                    <asp:TextBox ID="txtPolitica1" runat="server" class="caixaTexto" Width="400px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto" colspan="3">
                                                                    <asp:CheckBox ID="ChbDescontinuado" runat="server" Text="Descontinuado" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    &nbsp;
                                                                </td>
                                                                <td colspan="3">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="style41">
                                                                    <asp:ImageButton ID="btAddImagem" runat="server" ImageUrl="~/Imagens/add.png" OnClick="btAddImagem_Click"
                                                                        ToolTip="Adiciona imagem." />
                                                                    &nbsp;
                                                                    <asp:ImageButton ID="btZoom" runat="server" ImageUrl="~/Imagens/zoomin.png" ToolTip="Amplia a imagem." />
                                                                    &nbsp;
                                                                    <asp:ImageButton ID="btExcluirImg" runat="server" ToolTip="Exclui a imagem atual"
                                                                        ImageUrl="~/Imagens/Recycle.png" />
                                                                    &nbsp;
                                                                </td>
                                                                <td align="right" class="style41">
                                                                    <asp:ImageButton ID="btAnterior" runat="server" ImageUrl="~/Imagens/Backward.png"
                                                                        ToolTip="Exibi a imagem anterior." />
                                                                    &nbsp; &nbsp;<asp:ImageButton ID="btProxima" runat="server" ImageUrl="~/Imagens/Forward.png"
                                                                        ToolTip="Exibi a próxima imagem." />
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </Ajax:TabPanel>
                                        <Ajax:TabPanel ID="TPFinanceiro" runat="server" HeaderText="Financeiro" OnDemandMode="Always">
                                            <HeaderTemplate>
                                                Financeiro
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="UPFinanceiro" runat="server">
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="rotuloPequenoCinza" colspan="2">
                                                                    Produto:
                                                                </td>
                                                                <td colspan="5" class="rotuloPequenoCinza">
                                                                    Calculo de frete:&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style25" colspan="2">
                                                                    <asp:Label ID="LabInforme" runat="server" Text="Produto ainda não gravado." Width="300px"></asp:Label>
                                                                </td>
                                                                <td class="style25" colspan="5">
                                                                    &nbsp;Nota:&nbsp;<asp:TextBox ID="TxtNota" runat="server" class="caixaTextoValor"
                                                                        Width="90px"></asp:TextBox>
                                                                    &nbsp; Frete:<asp:TextBox ID="txtFreteValor" runat="server" class="caixaTextoValor"
                                                                        Width="90px"></asp:TextBox>
                                                                    <asp:CheckBox ID="ChbUsar" runat="server" Text="Usar aliquota" />
                                                                    &nbsp;
                                                                    <asp:Label ID="labAliq" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="rotuloPequenoCinza">
                                                                    Regra:
                                                                </td>
                                                                <td class="rotuloPequenoCinza">
                                                                    Custo:
                                                                </td>
                                                                <td class="rotuloPequenoCinza">
                                                                    IPI:
                                                                </td>
                                                                <td class="rotuloPequenoCinza">
                                                                    Frete:
                                                                </td>
                                                                <td class="rotuloPequenoCinza">
                                                                    ICMS:
                                                                </td>
                                                                <td class="rotuloPequenoCinza">
                                                                    Comissão:
                                                                </td>
                                                                <td class="rotuloPequenoCinza">
                                                                    Desconto:
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="caixaTexto">
                                                                    <asp:DropDownList ID="cobRegra" runat="server" class="caixaTexto" Width="170px">
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:ImageButton ID="btAddRegra" runat="server" ImageUrl="~/Imagens/Dollar.png" ToolTip="Adicionar regra." />
                                                                </td>
                                                                <td class="caixaTexto">
                                                                    <asp:TextBox ID="txtCusto" runat="server" class="caixaTextoValor" Width="90px">0</asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto">
                                                                    <asp:TextBox ID="txtIPI" runat="server" class="caixaTextoValor" Width="90px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto">
                                                                    <asp:TextBox ID="txtFrete" runat="server" class="caixaTextoValor" Width="90px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto">
                                                                    <asp:TextBox ID="txtIcms" runat="server" class="caixaTextoValor" Width="90px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto">
                                                                    <asp:TextBox ID="txtComissao" runat="server" class="caixaTextoValor" Width="90px"></asp:TextBox>
                                                                </td>
                                                                <td class="caixaTexto">
                                                                    <asp:TextBox ID="txtDesconto" runat="server" class="caixaTextoValor" Width="50px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" class="caixaTexto">
                                                                    <asp:UpdatePanel ID="Upcalculo" runat="server">
                                                                        <ContentTemplate>
                                                                            <table style="width: 100%; height: 71px;">
                                                                                <tr>
                                                                                    <td class="rotuloPequenoCinza">
                                                                                        R$ Normal
                                                                                    </td>
                                                                                    <td class="rotuloPequenoCinza">
                                                                                        R$ c/ Desconto
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        <asp:Button ID="btCalcular" runat="server" Text="Calcular" class="botao" OnClick="btCalcular_Click" />
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style21" align="center">
                                                                                        <asp:TextBox ID="txtaliq1" runat="server" class="caixaTextoValor" Width="90px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="style20" align="center">
                                                                                        <asp:TextBox ID="txtaliq2" runat="server" class="caixaTextoValor" Width="90px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        Percentagem
                                                                                    </td>
                                                                                    <td rowspan="10" class="caixaTexto">
                                                                                        <table style="width: 100%;">
                                                                                            <tr class="caixaTexto">
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr class="caixaTexto">
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr class="caixaTexto">
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr class="caixaTexto">
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr class="caixaTexto">
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr class="caixaTexto">
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr class="caixaTexto">
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr class="caixaTexto">
                                                                                                <td>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style21" align="center">
                                                                                        <asp:TextBox ID="txtvalor1" runat="server" class="caixaTextoValor" Width="90px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="style20" align="center">
                                                                                        <asp:TextBox ID="txtvalor2" runat="server" class="caixaTextoValor" Width="90px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        Valor em R$
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style21" align="center">
                                                                                        <asp:Label ID="LabICMS0" runat="server" Text="" class="caixaTextoValor" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style20" align="center">
                                                                                        <asp:Label ID="LabICMS1" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        ICMS
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style21" align="center">
                                                                                        <asp:Label ID="LabFederal1" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style20" align="center">
                                                                                        <asp:Label ID="LabFederal2" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        Federal
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style21" align="center">
                                                                                        <asp:Label ID="Labfrete1" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style20" align="center">
                                                                                        <asp:Label ID="Labfrete2" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        Frete
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style21" align="center">
                                                                                        <asp:Label ID="LabIPI1" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style20" align="center">
                                                                                        <asp:Label ID="LabIPI2" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        IPI
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style21" align="center">
                                                                                        <asp:Label ID="LabFixa1" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style20" align="center">
                                                                                        <asp:Label ID="LabFixa2" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        Tx Despesas fixas
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" class="style21">
                                                                                        <asp:Label ID="labComissao1" runat="server" class="caixaTextoValor" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="center" class="style20">
                                                                                        <asp:Label ID="labComissao2" runat="server" class="caixaTextoValor" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        Comissão
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style21" align="center">
                                                                                        <asp:Label ID="LabLB1" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style20" align="center">
                                                                                        <asp:Label ID="LabLB2" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        Lucro Bruto
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" class="style21">
                                                                                        <asp:Label ID="LabLL1" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td align="center" class="style20">
                                                                                        <asp:Label ID="LabLL2" runat="server" class="caixaTextoValor" Text="" Width="90px"></asp:Label>
                                                                                    </td>
                                                                                    <td class="style24">
                                                                                        Lucro - Descontos
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td align="center" colspan="3">
                                                                    <asp:Image ID="imgProduto0" runat="server" Height="178px" ImageUrl="~/Imagens/Imagem.jpg"
                                                                        Style="margin-left: 0px" Width="196px" />
                                                                    <br />
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </Ajax:TabPanel>
                                        <Ajax:TabPanel ID="TPEstoque" HeaderText="Estoque/Histórico" OnDemandMode="Always"
                                            runat="server">
                                            <HeaderTemplate>
                                                Estoque/Histórico
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="UpEstoque" runat="server">
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="5" class="caixaTexto">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td class="style33">
                                                                                Produto:
                                                                            </td>
                                                                            <td class="rotuloPequenoCinza">
                                                                                Estoque:
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style34">
                                                                                <asp:Label ID="LabIProduto" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td class="caixaTexto">
                                                                                <asp:UpdatePanel ID="Upatualiza" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <table style="width: 100%;">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="LabEstpque" runat="server" Text="Estoque = 0"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:ImageButton ID="BtAtualizaEstoque" runat="server" ImageUrl="~/Imagens/refresh.png"
                                                                                                        ToolTip="Atualiza estoque" OnClick="BtAtualizaEstoque_Click" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style39">
                                                                    &nbsp;
                                                                </td>
                                                                <td colspan="3">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="rotuloPequenoCinza" align="center">
                                                                    Imagem:
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style39">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="right" class="style36">
                                                                    Fornecedor:
                                                                </td>
                                                                <td class="style37">
                                                                    <asp:DropDownList ID="combFornecedor" runat="server" class="caixaTexto" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td class="style40">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" rowspan="8">
                                                                    <asp:Image ID="imgProduto1" runat="server" Height="178px" ImageUrl="~/Imagens/Imagem.jpg"
                                                                        Style="margin-left: 0px" Width="196px" class="caixaTexto" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style39">
                                                                </td>
                                                                <td align="right" class="style36">
                                                                    Nota fiscal:
                                                                </td>
                                                                <td class="style37">
                                                                    <asp:TextBox ID="txtNF" runat="server" class="caixaTexto" Width="100px"> </asp:TextBox>
                                                                </td>
                                                                <td class="style40">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style39">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="right" class="style36">
                                                                    Data Nota:
                                                                </td>
                                                                <td class="style37">
                                                                    <asp:TextBox ID="txtData" runat="server" class="caixaTexto" Width="100px"></asp:TextBox>
                                                                    <Ajax:MaskedEditExtender ID="maskData" runat="server" ClearMaskOnLostFocus="false"
                                                                        Mask="99/99/9999" TargetControlID="txtData" UserDateFormat="DayMonthYear" />
                                                                </td>
                                                                <td class="style40">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style39" rowspan="5">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="right" class="style36">
                                                                    Quantidade:
                                                                </td>
                                                                <td class="style37">
                                                                    <asp:TextBox ID="txtQuantidade" runat="server" class="caixaTexto" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td class="style40">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style36">
                                                                    Empresa:
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="combEmpresa" runat="server" class="caixaTexto" Width="200px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chSN" runat="server" Checked="false" Text="sn" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:Button ID="btSalvarEntrada" runat="server" class="botao" Text="Salvar" OnClick="btSalvarEntrada_Click" />
                                                                    &nbsp;<asp:Button ID="btUCompras" runat="server" class="botao" Text="Compras" />
                                                                    &nbsp;<asp:Button ID="btUVendas" runat="server" class="botao" Text="Vendas" />
                                                                    &nbsp;<asp:Button ID="BtAcerto" runat="server" class="botao" Text="Acerta Estoque" OnClick="BtAcerto_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style27" colspan="5" align="center">
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
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
                            <asp:Panel ID="panelRodape" runat="server">
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Panel ID="PanelImprimi" runat="server" Visible="True" class="caixaSolida" Height="87px"
        Width="487px" CssClass="caixaSolida">
        <table>
            <tr>
                <td class="rotulo">
                    &nbsp;
                </td>
                <td class="rotulo">
                    <asp:Label ID="labFechar" runat="server">Selecione o arquivo XML</asp:Label>
                    <Ajax:ModalPopupExtender ID="plnImprimi" runat="server" CancelControlID="cmdFechar"
                        DropShadow="true" DynamicServicePath="" Enabled="True" PopupControlID="PanelImprimi"
                        PopupDragHandleControlID="PanelImprimi" TargetControlID="labFechar">
                    </Ajax:ModalPopupExtender>
                </td>
                <td class="rotulo" colspan="2">
                    <asp:Button ID="cmdFechar" runat="server" class="botao" Text="X" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 640px;" colspan="2" align="center">
                    <asp:FileUpload ID="FileUpload1" runat="server" class="caixaTexto" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    &nbsp;
                    <asp:Button ID="BtSelecao" runat="server" class="botao" OnClick="BtSelecao_Click1"
                        Text="Cofirma" />
                    &nbsp;
                    <br />
                    <asp:Label ID="LabMens" runat="server" Style="color: Red;"></asp:Label>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="panelImagem" runat="server" Width="486px" class="caixaSolida" CssClass="caixaSolida">
        <table>
            <tr>
                <td class="rotulo">
                    &nbsp;
                </td>
                <td class="rotulo">
                    <asp:Label ID="labFechar1" runat="server">Selecione o arquivo de imagem</asp:Label>
                    <Ajax:ModalPopupExtender ID="plnImagem" runat="server" CancelControlID="cmdFecha1"
                        DropShadow="true" DynamicServicePath="" Enabled="True" PopupControlID="panelImagem"
                        PopupDragHandleControlID="panelImagem" TargetControlID="labFechar1">
                    </Ajax:ModalPopupExtender>
                </td>
                <td class="rotulo" colspan="2">
                    <asp:Button ID="cmdFecha1" runat="server" class="botao" Text="X" />
                </td>
            </tr>
            <tr>
                <td bgcolor="White">
                </td>
                <td style="width: 640px;" colspan="2" align="center" bgcolor="White">
                    <asp:FileUpload ID="FileUpload2" runat="server" class="caixaTexto" />
                </td>
                <td bgcolor="White">
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    &nbsp;
                    <asp:Button ID="BtSelImagem" runat="server" class="botao" Text="Cofirma" OnClick="BtSelImagem_Click" />
                    <br />
                    &nbsp;<asp:Label ID="LabMens2" runat="server" Style="color: Red;"></asp:Label>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
