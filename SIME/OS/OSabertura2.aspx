<%@ Page Title="" Language="C#" MasterPageFile="~/OS/OS_Sime.master" AutoEventWireup="true"
    CodeBehind="OSabertura2.aspx.cs" Inherits="SIME.OSaberturap2" %>

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
            <td colspan="2">
                <asp:Label ID="labDadosCliente" runat="server" ></asp:Label>
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="rotulo" colspan="3">
                <asp:Label ID="Label4" runat="server"  Text="Informações do aparelho:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 108px">
                <br />
                <br />
            </td>
            <td style="width: 787px">
                <asp:Panel ID="Panel3" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 196px"  class ="rotulo2">
                                <asp:Label ID="Label18" runat="server" Text="Em garantia:" ></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked="false" OnCheckedChanged="CheckBox1_CheckedChanged"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td style=" width: 196px" class="rotulo2">
                                <asp:Label ID="Label27" runat="server" Text="Seguradora:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="combSeguradora" runat="server" class ="caixaTexto"
                                    Width="208px" Enabled="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class="rotulo2">
                                <asp:Label ID="Label20" runat="server" Text="Tipo:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="CombTipo" runat="server"  Width="208px" class="caixaTexto">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class ="rotulo2">
                                <asp:Label ID="Label9" runat="server" Text="Marca:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="CombMarca" runat="server"  Width="208px" class="caixaTexto">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class ="rotulo2">
                                <asp:Label ID="Label10" runat="server" Text="Modelo:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:TextBox ID="txtModelo" runat="server" class="caixaTexto"  Width="209px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class="rotulo2">
                                <asp:Label ID="Label29" runat="server" Text="Voltagem:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="CombVoltagem" runat="server" class= "caixaTexto" Width="208px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class ="rotulo2">
                                <asp:Label ID="Label28" runat="server"  Text="Atendimento:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="CombAtendimento" runat="server" class="caixaTexto" Width="208px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class = "rotulo2">
                                <asp:Label ID="Label11" runat="server"  Text="N° de série:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:TextBox ID="txtNSerie" runat="server" Width="209px" class="caixaTexto" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class="rotulo2">
                                <asp:Label ID="Label5" runat="server"  Text="Retorno:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:CheckBox ID="Chk_retorno" runat="server" AutoPostBack="true" Checked="false"
                                    OnCheckedChanged="ChkRetorno_CheckedChanged" />
                                &nbsp;<asp:Label ID="Label26" runat="server"  Text="OS:"></asp:Label>
                                &nbsp;<asp:DropDownList ID="CombRetorno" runat="server" class= "caixaTexto" Width="208px" Enabled="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class="rotulo2">
                                <asp:Label ID="Label12" runat="server"  Text="NF ou Cupom fiscal:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:TextBox ID="txtNF" runat="server" class="caixaTexto" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class="rotulo2">
                                <asp:Label ID="Label13" runat="server"  Text="Data da compra:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:TextBox ID="txtDataNF" runat="server"  Width="209px" class="caixaTexto" Enabled="False"></asp:TextBox>
                                <Ajax:MaskedEditExtender ID="txtDataNF_MaskedEditExtender" runat="server" Mask="99/99/9999"
                                    MaskType="Date" TargetControlID="txtDataNF">
                                </Ajax:MaskedEditExtender>
                                <Ajax:CalendarExtender ID="txtDataNF_CalendarExtender" runat="server" FirstDayOfWeek="Sunday"
                                    Format="dd/MM/yyyy" TargetControlID="txtDataNF">
                                </Ajax:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class = "rotulo2">
                                <asp:Label ID="Label14" runat="server"  Text="Loja de venda:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="combLojas" runat="server" Enabled="False" class="caixaTexto" Width="365px">
                                </asp:DropDownList>
                                <asp:Button ID="Bt_IncluirLoja" runat="server" class="botao" 
                                    Text="Incluir loja" Width="87px" onclick="Bt_IncluirLoja_Click" 
                                    Enabled="False"  />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class ="rotulo2">
                                <asp:Label ID="LabTipoEstoque" runat="server" Text="Tipo de estoque"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="combEstoque" runat="server" class="caixaTexto" Width="365px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" rowspan="3" class="rotulo2">
                                <asp:Label ID="Label21" runat="server"  Text="Acessórios:"></asp:Label>
                            </td>
                            <td style="margin-left: 80px">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Fonte" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="Cabos" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox4" runat="server" Text="Bolsa" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox5" runat="server" Text="Cd's" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox6" runat="server" Text="Mouse" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox7" runat="server" Text="Teclado" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBox8" runat="server" Text="Embalagem" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox9" runat="server" Text="Isopor" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox10" runat="server" Text="Antena" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox11" runat="server" Text="Controle remoto" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox12" runat="server" Text="Caixa de som" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox13" runat="server" Text="Copo" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="ChkOutros" runat="server" AutoPostBack = "true"
                                    oncheckedchanged="CheckBox18_CheckedChanged" Text="Outros" />
                            </td>
                            <td colspan="5">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtAcessorio" runat="server" Enabled="False" 
                                            class="caixaTexto" Width="383px"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class="rotulo2">
                                <asp:Label ID="Label22" runat="server" Text="Avarias:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:TextBox ID="txtAvaria" runat="server"  Width="532px" class="caixaTexto"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 196px" class="rotulo2">
                                <asp:Label ID="Label24" runat="server"  Text="Defeito descrito:"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:TextBox ID="txtDefeito" runat="server"  Width="535px" class="caixaTexto"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 108px; height: 43px;">
                <asp:Button ID="Bt_retornar" runat="server" Text="&lt;&lt; Retornar" OnClick="Bt_retornar_Click"
                    class="botao" Width="105px" />
            </td>
            <td style="width: 787px; margin-left: 40px; height: 43px;">
                <msg:Mensagem ID="CaixaMensagem1" runat="server" />
            </td>
            <td align="left" style="height: 43px">
                <asp:Button ID="bt_proximo" runat="server" OnClick="bt_proximo_Click" Text="Próximo &gt;&gt;&gt;"
                    class ="botao" />
            </td>
        </tr>
        <tr>
            <td style="width: 108px">
                &nbsp;
            </td>
            <td style="width: 787px; margin-left: 40px;">
            <Ajax:ModalPopupExtender ID="plnPopUp_ModalPopupExtender" runat="server" 
                                    CancelControlID="cmdFechar" DropShadow="true" DynamicServicePath="" 
                                    Enabled="True" PopupControlID="plnPopUp" PopupDragHandleControlID="plnPopUp" 
                                    TargetControlID="labFechar">
                                </Ajax:ModalPopupExtender>
                <asp:Panel ID="plnPopUp"  runat="server" Width="566px" class ="caixaSolida">
                    <table>
                        <tr>
                            <td  class="rotulo" colspan="2">
                                &nbsp;</td>
                            <td class="rotulo">
                                Cadastro de loja vendedora<asp:Label ID="labFechar" runat="server"></asp:Label>
                                
                            </td>
                            <td class="rotulo" style="width: 4px">
                                <asp:Button ID="cmdFechar" runat="server" onclick="cmdFechar_Click" Text="X" />
                            </td>
                        </tr>
                        <tr>
                            <td class="rotulo2">
                                &nbsp;
                            </td>
                            <td class="rotulo2" style="width: 1098px">
                                <asp:Label ID="Label1" runat="server" 
                                    Text="Razão Social:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLoja" runat="server" class ="caixaTexto" Width="419px"></asp:TextBox>
                            </td>
                            <td style="width: 4px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="rotulo2">
                                &nbsp;
                            </td>
                            <td class="rotulo2" style="width: 1098px">
                                <asp:Label ID="Label2" runat="server" 
                                    Text="CNPJ:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_cnpj_loja" runat="server" class="caixaTexto" 
                                    Width="419px" ></asp:TextBox>
                            </td>
                            <td style="width: 4px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                &nbsp;
                            </td>
                            <td align="center" class="style4" colspan="2">
                                <asp:Button ID="Button1" runat="server" Text="Gravar" onclick="Button1_Click" class="botao" />
                            </td>
                            <td style="width: 4px">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
