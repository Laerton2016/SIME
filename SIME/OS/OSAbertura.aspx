<%@ Page Title="Abertura OS" Language="C#" enableEventValidation="true" MasterPageFile="~/OS/OS_Sime.master" AutoEventWireup="true" CodeBehind="OSAbertura.aspx.cs" Inherits="SIME.OSAbertura" %>
<%@ MasterType VirtualPath="~/OS/OS_Sime.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Src="~/Controles/Mensagem.ascx" TagName="Mensagem" TagPrefix="msg" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:ScriptManager ID="ajaxkit" runat="server">
    </asp:ScriptManager>
     
    <table style="width: 100%;">
        
        <tr>

            <td class="rotulo" colspan="3">
                <asp:Label ID="Label3" runat="server"  Text="Informações do cliente:"></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td colspan="3">
    
    <asp:Label ID="Label1" runat="server" Text="Digite o CPF ou CNPJ do cliente." 
                    ></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 271px">
                <asp:TextBox ID="txtDoc" runat="server"  Width="275px" class ="caixaTexto" ></asp:TextBox>
            </td>
            <td>
<asp:Button 
    ID="bt_buscar" runat="server" Text="Buscar" onclick="bt_buscar_Click" 
                    style="margin-left: 0px" class="botao"  />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
<asp:Panel ID="Panel_dados" runat="server" Height="29px" Width="915px" 
        Visible="False">
    <table style="width:100%; height: 101px;">
        <tr>
            <td 
                style="" 
                colspan="3">
                Confira o nome ou selecione o nome do cliente e clique em confirma<br />
                <asp:DropDownList ID="ComboClientes" runat="server"  Width="450px" class = "caixaTexto">
                </asp:DropDownList>
                <asp:Button ID="bt_confirma" runat="server" Text="Confirma" 
                    onclick="bt_confirma_Click" class="botao" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LabDados" runat="server"></asp:Label>
                
                &nbsp;<br />
                                
            </td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btAltera" runat="server" onclick="btAltera_Click1" 
                    Text="Altera" Visible="False" Width="105px" class="botao" />
            </td>
            <td >
                <asp:Button ID="btProximo" runat="server" onclick="btProximo_Click1" 
                    Text="Proximo&gt;&gt;" Visible="False" Width="105px"  class="botao" />
            </td>
        </tr>
        <tr>
            <td  style="width: 197px">
                <msg:Mensagem ID="CaixaMensagem1" runat="server" />
                <br />
            </td>

            <td  style="width: 819px">
            <Ajax:ModalPopupExtender ID="plnPopUp_Cliente" runat="server" 
                                    CancelControlID="cmdFechar" DropShadow="true" DynamicServicePath="" 
                                    Enabled="True" PopupControlID="Panel_Cliente" PopupDragHandleControlID="Panel_Cliente" 
                                    TargetControlID="labFechar">
                                </Ajax:ModalPopupExtender>
                <asp:Panel ID="Panel_Cliente" runat="server" class="caixaSolida">
                    <table  cellpadding="2" border="0px" >
                        <tr>
                            <td colspan="6"   class = "rotulo" rowspan="1" >
                                Cadastro rápido de cliente</td>
                            <td class="rotulo"   >
                                <asp:Label ID="labFechar" runat="server"></asp:Label>
                                
                                <asp:Button ID="cmdFechar" runat="server" Text="X" class = "botao" 
                                    />
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 171px" class="rotulo2">
                                *Nome:</td>
                            <td colspan="2" style="width: 299px">
                                <asp:TextBox ID="txtNome" runat="server" Width="318px" class= "caixaTexto"></asp:TextBox>
                            </td>
                            <td colspan="2" class="rotulo2">
                                CEP:</td>
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TXTCep" runat="server" class="caixaTexto" Width="101px"></asp:TextBox>
                                        <Ajax:MaskedEditExtender ID="TXTCEP_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" 
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                            Mask="99999-999" TargetControlID="TXTCep">
                                        </Ajax:MaskedEditExtender>
                                        <asp:ImageButton ID="BTBuscaCep0" runat="server" 
                                            ImageUrl="~/Imagens/turn-on_16x16.gif" onclick="BTBuscaCep0_Click" 
                                            style="height: 16px; margin-right: 1px" ToolTip="Busca CEP na Internet" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 171px" class="rotulo2">
                                *Endereço:</td>
                            <td colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TXTEndereco" runat="server" class="caixaTexto" Width="319px"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="rotulo2" style="width: 123px">
                                Bairro:</td>
                            <td colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TXTBairro" runat="server" class="caixaTexto"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 171px" class="rotulo2">
                                *Estado:</td>
                            <td colspan="6">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="CobUF" runat="server" class="caixaTexto" 
                                            onselectedindexchanged="montaListadeCidades_Click">
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
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 171px" class="rotulo2">
                                *Cidade:</td>
                            <td colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="CobCidade" runat="server" class="caixaTexto" 
                                            Width="321px">
                                        </asp:DropDownList>
                                        <asp:Button ID="montaListadeCidades" runat="server" onclick="montaListadeCidades_Click" style="display: none;"  />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td colspan="3">
                                Modelo: 000000-0</td>
                        </tr>
                        <tr>
                            <td style="width: 171px; height: 19px;" class="rotulo2">
                                *CPF/CNPJ:</td>
                            <td colspan="2" style="width: 299px; height: 19px;">
                                <asp:TextBox ID="TXTCPF" runat="server" Width="201px" class= "caixaTexto"></asp:TextBox>
                            </td>
                            <td colspan="2" class="rotulo2" style="height: 19px">
                                Ident. / IE.:</td>
                            <td colspan="2" style="height: 19px">
                                <asp:TextBox ID="TXTDOC1" runat="server" class= "caixaTexto"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 171px" class="rotulo2">
                                Nascimento:</td>
                            <td colspan="6">
                                <asp:TextBox ID="TXTDtNascimento" runat="server" class= "caixaTexto"></asp:TextBox>
                                <Ajax:MaskedEditExtender ID="TXTDtNascimento_MaskedEditExtender" runat="server" Mask="99/99/9999"
                                    MaskType="Date" TargetControlID="TXTDtNascimento" 
                                    ClearMaskOnLostFocus="False" ClearTextOnInvalid="True" 
                                    UserDateFormat="DayMonthYear">
                                </Ajax:MaskedEditExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 171px" class="rotulo2">
                                *Telefone:</td>
                            <td colspan="2">
                                <asp:TextBox ID="TXTTelefone" runat="server" class= "caixaTexto"  ></asp:TextBox>
                                <Ajax:MaskedEditExtender ID="TXTTelefone_MaskedEditExtender" runat="server" 
                                    Mask="(99) 9999-9999" TargetControlID="TXTTelefone" 
                                    ClearMaskOnLostFocus="False" ClearTextOnInvalid="True">
                                </Ajax:MaskedEditExtender>
                            </td>
                            <td colspan="2" class="rotulo2" >
                                *Operadora:</td>
                            <td colspan="2">
                                <asp:DropDownList ID="CobOperadora" runat="server" class="caixaTexto">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 171px; height: 20px;" class="rotulo2">
                                E-mail:</td>
                            <td colspan="6" style="height: 20px">
                                <asp:TextBox ID="TXTEmail" runat="server" Width="320px" class= "caixaTexto"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 171px" class="rotulo2">
                                *Ponto de referência:</td>
                            <td colspan="6">
                                <asp:TextBox ID="TXTreferencia" runat="server" Width="530px" class= "caixaTexto"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 171px">
                                &nbsp;</td>
                            <td align="center">
                                <asp:Button ID="BtGravar" runat="server" class="botao" Text="Gravar" 
                                    onclick="BtGravar_Click1" />
                            </td>
                            <td colspan="5">
                                * Campos de preenchimento obrigatório.</td>
                        </tr>
                    </table>
                    <br />
                </asp:Panel>
            </td>
            <td  align="right">
                </td>
        </tr>
    </table>
</asp:Panel>
            </td>
        </tr>
</table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
                </asp:Content>
