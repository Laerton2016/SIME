<%@ Page Title="" Language="C#" MasterPageFile="~/OS/OS_Sime.master" AutoEventWireup="true"
    CodeBehind="OSAbertura3.aspx.cs" Inherits="SIME.OSAbertura3" %>

<%@ MasterType VirtualPath="~/OS/OS_Sime.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Src="~/Controles/Mensagem.ascx" TagName="Mensagem" TagPrefix="msg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <table style="width: 100%;">
        <tr>
            <td class="rotulo" colspan="3">
                <asp:Label ID="Label3" runat="server" Text="Informações do cliente:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="labDadosCliente" runat="server"></asp:Label>
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="rotulo" colspan="3">
                <asp:Label ID="Label4" runat="server" Text="Informações do aparelho:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <br />
                <asp:Label ID="labDadosCAparelho" runat="server"></asp:Label>
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 108px; height: 43px;">
                <asp:Button ID="Bt_retornar" runat="server" Text="&lt;&lt; Retornar" class="botao"
                    Width="105px" OnClick="Bt_retornar_Click" />
            </td>
            <td style="width: 787px; margin-left: 40px; height: 43px;">
                <msg:Mensagem ID="CaixaMensagem1" runat="server" />
            </td>
            <td align="left" style="height: 43px">
                <asp:Button ID="BT_Concluir" class="botao" runat="server" Text="Concluir" 
                    onclick="BT_Concluir_Click" />
            </td> 
        </tr>
        <tr>
            <td style="width: 108px">
                &nbsp;
            </td>
            <td style="width: 787px; margin-left: 40px;">

            <Ajax:ModalPopupExtender ID="plnImprimi" runat="server" 
                                    CancelControlID="cmdFechar" DropShadow="true" DynamicServicePath="" 
                                    Enabled="True" PopupControlID="PanelImprimi" PopupDragHandleControlID="PanelImprimi" 
                                    TargetControlID="labFechar">
                                </Ajax:ModalPopupExtender>
            
                <asp:Panel ID="PanelImprimi" runat="server" Visible="True" class="caixaSolida" style="width: 130mm; height: 36mm">
                    <table>
                        <tr>
                            <td colspan="5" class="rotulo">
                                <asp:Label ID="labFechar" runat="server">Modo de impressão</asp:Label>
                            </td>
                            <td class="rotulo" colspan="2">
                                <asp:Button ID="cmdFechar" runat="server" class="botao" Text="X" 
                                     />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 58px;" rowspan="3">
                            </td>
                            <td style="width: 640px; height: 8px;" colspan="5">
                                <asp:RadioButton ID="RBBobina" runat="server" Text="Imprimir em bobina" GroupName="impressao" />
                               
                            </td>
                            <td rowspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="width: 640px; height: 5px;">
                                <asp:RadioButton ID="RBA5" runat="server" Text="Imprimir em A4" GroupName="impressao" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 640px; height: 5px;">
                                <asp:CheckBox ID="CBEtiqueta" runat="server" Text="Gerar Etiqueta" />
                            </td>
                            <td style="width: 62px; height: 5px;" colspan="2">
                                <asp:Label ID="LabQuantidade" runat="server" Text="Quantidade:"></asp:Label>
                            </td>
                            <td style="width: 640px; height: 5px;" colspan="2">
                                <asp:TextBox ID="txtQuantidade" runat="server" class="caixaTexto" Width="30px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2px">
                                &nbsp;
                            </td>
                            <td colspan="2" style="width: 311px">
                                <asp:Button ID="BtImprimir" runat="server" Text="Imprimir" 
                                    onclick="BtImprimir_Click1" class="botao" />

                            </td>
                            <td colspan="4">
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
