<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Importa.aspx.cs" Inherits="SIME.Produtos.Importa" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <asp:ScriptManager ID="ajaxkit" runat="server">
    </asp:ScriptManager>
    <table style="width: 100%;">
        <tr>
            <td class="style42" rowspan="2">
                &nbsp;
            </td>
            <td class="rotulo" align="center">
                Selecione o arquivo para leitura
            </td>
            <td rowspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="style48">
                
                        <table style="width: 100%;">
                            <tr>
                                <td align="center">
                                    <asp:DropDownList ID="CombArquivos" runat="server" class="caixaTexto">
                                    </asp:DropDownList>
                                    <asp:Button ID="BtAtualizaLista" runat="server" class="botao" OnClick="BtAtualizaLista_Click"
                                        Text="Atualiza lista" />
                                    <asp:Button ID="BtLer" runat="server" class="botao" OnClick="BtLer_Click" Text="Ler" />
                                    <asp:Button ID="btImport" runat="server" class="botao" OnClick="btImport_Click" Text="Importar" />
                                    <br />
                                    <asp:Label ID="labErro" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UPdadosNota1" runat="server" Visible="false" class="caixaTexto">
                                        <ContentTemplate>
                                            <table style="width: 98%;">
                                                <tr>
                                                    <td align="left" class="rotulo2">
                                                        Fornecedor:
                                                    </td>
                                                    <td align="left" class="caixaTexto">
                                                        <asp:Label ID="LabForncedor" runat="server"> </asp:Label>
                                                        &nbsp;<asp:Image ID="imgOk" runat="server" />
                                                    </td>
                                                    <td align="center" class="caixaTextoCentral">
                                                        <asp:UpdatePanel ID="upbuscaFornecedor1" runat="server" Visible="false">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="CombForncedores1" runat="server" class="caixaTexto">
                                                                </asp:DropDownList>
                                                                <br />
                                                                <asp:Button ID="BtAddForncedor" runat="server" class="botao" OnClick="BtAddForncedor_Click"
                                                                    Text="Adiciona" />
                                                                <asp:Button ID="BtAtualiza" runat="server" class="botao" Text="Atualiza" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="rotulo2">
                                                        Duplicatas:
                                                    </td>
                                                    <td align="left" class="caixaTexto">
                                                        <asp:Label ID="LabForncedor0" runat="server" Width="250px"> </asp:Label>
                                                    </td>
                                                    <td align="left" class="style51">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="rotulo2">
                                                        Nota fiscal:
                                                    </td>
                                                    <td align="left" class="caixaTexto">
                                                        <asp:Label ID="LabForncedor1" runat="server"> </asp:Label>
                                                    </td>
                                                    <td align="left" class="style51" rowspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="rotulo2">
                                                        Chave NF-e
                                                    </td>
                                                    <td align="left" class="caixaTexto">
                                                        <asp:Label ID="LabChave" runat="server"> </asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="rotulo2">
                                    Lista de itens na NF-e
                                </td>
                            </tr>
                            <tr>
                                <td class="caixaTextoCentral">
                                    <asp:UpdatePanel ID="upListaItens1" runat="server" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btBuscaItem" EventName="Click" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:ListBox ID="ListNfe" runat="server" class="caixaTexto" Height="100px" Visible="false"
                                                Width="500px"></asp:ListBox>
                                            <br />
                                            <asp:Button ID="btBuscaItem" runat="server" class="botao" OnClick="btBuscaItem_Click"
                                                Text="Buscar" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="rotulo2">
                                    Busca do produto
                                </td>
                            </tr>
                            <tr>
                                <td class="caixaTextoCentral">
                                    <asp:UpdatePanel ID="upListaBusca1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:ListBox ID="ListBuscaR1" runat="server" class="caixaTexto" Height="100px" Visible="false"
                                                Width="500px"></asp:ListBox>
                                            &nbsp;<br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="caixaTextoCentral">
                                    <asp:Button ID="btAdd1" runat="server" class="botao" Text="Atualização" OnClick="btAdd1_Click" />
                                    &nbsp;
                                    <asp:Button ID="btAdd3" runat="server" class="botao" Text="Novo" OnClick="btAdd3_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="caixaTextoCentral">
                                    <asp:UpdatePanel ID="UpBotoes1" runat="server">
                                        <ContentTemplate>
                                            <br />
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="caixaTextoCentral">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        </tr>
                        <tr>
                            <td class="style42">
                                &nbsp;
                            </td>
                            <td class="style43">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                
        </tr>
    </table>
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
</asp:Content>
