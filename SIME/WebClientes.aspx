<%@ Page Title="Cadastro de clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="WebClientes.aspx.cs" Inherits="SIME.Class.WebClientes" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Src="Controles/Mensagem.ascx" TagName="Mensagem" TagPrefix="msg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 52px;
        }
        .style2
        {
            height: 12px;
        }
        #txtCidade
        {
            width: 195px;
            height: 22px;
        }
        #TxtCidade
        {
            width: 243px;
        }
        .style7
        {
            background: #E9E9FE;
            margin-left: 1px;
            height: 20px;
            font-family: Tahoma;
            font-size: large;
            width: 166px;
        }
        .style8
        {
            width: 6px;
        }
        .style11
        {
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ajaxkit" runat="server">
    </asp:ScriptManager>
    
    <Ajax:DropShadowExtender ID="dados1" runat = "server" TargetControlID = "PanelDadosBasicos0" Opacity = "0.5"
    Rounded = "true" TrackPosition = "true" ></Ajax:DropShadowExtender>

     <Ajax:DropShadowExtender ID="DropShadowExtender2" runat = "server" TargetControlID = "PanelDadosFinanceiros0" Opacity = "0.5"
    Rounded = "true" TrackPosition = "true"  ></Ajax:DropShadowExtender>

      <Ajax:DropShadowExtender ID="DropShadowExtender3" runat = "server" TargetControlID = "PanelContatosExtras0" Opacity = "0.5"
    Rounded = "true" TrackPosition = "true"  ></Ajax:DropShadowExtender>
    
    <Ajax:ModalPopupExtender ID="ModalFinanceiro" runat ="server" TargetControlID = "lbFinanceiro" 
    PopupControlID = "PanelDadosFinanceiros0" DropShadow ="true" OkControlID = "btFechar1" ></Ajax:ModalPopupExtender>

    <Ajax:ModalPopupExtender ID="ModalPopupExtender2" runat ="server" TargetControlID = "lbContatos" 
    PopupControlID = "PanelContatosExtras0" DropShadow ="true" OkControlID = "btFechar2" ></Ajax:ModalPopupExtender>
    
    <asp:Panel ID="Panel4" runat="server">
        <table style="width:100%;">
            <tr>
                <td colspan="7" class = "rotulo">
                    Cadastro de clientes
                </td>
            </tr>
            <tr>
            <td id = "linha_incial_busca">
            <asp:UpdatePanel ID="UpPanel_incial" runat="server">
                <ContentTemplate>
                <table>
            <tr>
                <td class="style7">
                    Busca/Adiciona:</td>
                <td class="style8">
                    <asp:TextBox ID="txtcampo" runat="server" Height="20px" Width="448px"></asp:TextBox>
                    <Ajax:BalloonPopupExtender ID="txtcampo_BalloonPopupExtender" runat="server" 
                        BalloonPopupControlID="panelMensagem" TargetControlID="txtcampo">
                    </Ajax:BalloonPopupExtender>
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Buscar" class ="botao" 
                        onclick="Button3_Click"/>
                    <asp:Label ID="labInf1" runat="server"></asp:Label>
                </td>
                </tr>
            </table>
                
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
            </tr>
            <tr>
                <td  colspan="7">
                <asp:UpdatePanel ID="UpPanel_Busca" runat="server">
                    <ContentTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td rowspan="2" class = "style7">
                                    Lista de clientes:&nbsp;&nbsp;<tr ID="tr_busca" runat="server">
                                        <td class="style8">
                                            <asp:DropDownList ID="ComboClientes" runat="server" Height="22px" Width="450px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style11">
                                            <asp:Button ID="Button1" runat="server" class="botao" onclick="Button1_Click1" 
                                                Text="Editar" />
                                            &nbsp;<asp:Button ID="Button5" runat="server" class="botao" onclick="Button2_Click" 
                                                Text="Retornar" />
                                        </td>
                                    </tr>
                                    </td>
                            </tr>
                        </table>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                    
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Height="708px">
        <table style="width: 100%; height: 224px;">
            <tr>
                <td class="style1">
                    <asp:Panel ID="panelInicial" runat="server">
                        <asp:Panel ID="panelMensagem" runat="server">
                            Dica: Para buscar digite o CPF/CNPJ ou parte do nome do cliente.<br />
                            Caso o cliente seja novo ao digitar o CPF/CNPJ uma nova ficha será aberta</asp:Panel>
                    </asp:Panel>
                </td>
            </tr>
            
            <tr>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="PanelBotoes" runat="server"  Width="298px" >
                        <asp:Button ID="BtEditarCliente" runat="server" Text="Editar" class= "botao" 
                            onclick="BtEditarCliente_Click" />
                        <asp:Button ID="BtExcluirCliente" runat="server" Text="Excluir" class = "botao" />
                        <asp:Button ID="BtGravar" runat="server" Text="Gravar" class = "botao" 
                            onclick="BtGravar_Click" />
                        <asp:Button ID="BtVoltar" runat="server" Text="Retornar" class = "botao" 
                            onclick="BtVoltar_Click" />
                    </asp:Panel>
&nbsp;<asp:Panel ID="PanelDados" runat="server" >
                        &nbsp;&nbsp;<asp:LinkButton ID="LBFinanceiro" runat="server" onclick="LBFinanceiro_Click">Dados financeiro</asp:LinkButton>
                        &nbsp;-
                        <asp:LinkButton ID="LBContatos" runat="server">Contatos</asp:LinkButton>
                        <asp:Panel ID="PanelDadosCliente0" runat="server">
                            <asp:Panel ID="PanelDadosBasicos0" runat="server" BackColor="#FFFFCC">
                                &nbsp;
                                <asp:Label ID="Label2" runat="server" Style="text-decoration: underline; font-weight: 700;
                                    color: #3366FF" Text="Dados cliente:"></asp:Label>
                                <br />
                                &nbsp;Nome:&nbsp;<asp:TextBox ID="txtNome" runat="server" Height="22px" 
                                    Style="margin-left: 21px" Width="442px"></asp:TextBox>
                                &nbsp;Pessoa Jurídica:&nbsp;&nbsp; &nbsp;<asp:ImageButton ID="ImgJuridica" runat="server" 
                                    OnClick="ImgJuridica_Click" Width="16px" />
                                &nbsp;&nbsp;Cod.:&nbsp;<asp:Label ID="LabCod0" runat="server"></asp:Label>
                                <br />
                                <br />
                                &nbsp;CPF/CNPJ:
                                <asp:TextBox ID="txtCNPJ" runat="server" Height="22px" 
                                    OnTextChanged="txtCNPJ_TextChanged" Style="margin-left: 0px" Width="198px"></asp:TextBox>
                                <Ajax:MaskedEditExtender ID="txtCNPJ_MaskedEditExtender" runat="server" TargetControlID="txtCNPJ"
                                    Mask="999.999.999-99" ClearMaskOnLostFocus="false" CultureName="en-US">
                                </Ajax:MaskedEditExtender>
                                &nbsp; ID/Insc.Est.:&nbsp;
                                <asp:TextBox ID="TxtInsc" runat="server" Height="22px" Width="207px"></asp:TextBox>
                                <asp:Label ID="LabErro1" runat="server" ForeColor="Red"></asp:Label>
                                <asp:Button ID="btValidar" runat="server" OnClick="Button1_Click" Text="Validar" />
                                <br />
                                <br />
                                &nbsp;Endereço:&nbsp;<asp:TextBox ID="txtEndereco" runat="server" Height="22px" Style="margin-left: 1px"
                                    Width="426px"></asp:TextBox>
                                &nbsp;Bairro:&nbsp;<asp:TextBox ID="TxtBairro" runat="server" Height="22px"></asp:TextBox>
                                &nbsp;Cep:
                                <asp:TextBox ID="TxtCEP" runat="server" Height="22px" Width="111px"></asp:TextBox>
                                <Ajax:MaskedEditExtender ID="TxtCEP1" runat="server" TargetControlID="TxtCEP"
                                    Mask="99999999" ClearMaskOnLostFocus="false" CultureName="en-US">
                                </Ajax:MaskedEditExtender>
                                &nbsp;
                                <asp:ImageButton ID="BTBuscaCep" runat="server"  
                                    ImageUrl="~/Imagens/turn-on_16x16.gif" OnClick="BTBuscaCep_Click" 
                                    style="height: 16px; margin-right: 1px" ToolTip="Busca CEP na Internet" />
                                <br />
                                <br />
                                &nbsp;UF:&nbsp;
                                <asp:DropDownList ID="TxtUF" runat="server" onselectedindexchanged="TxtUF_SelectedIndexChanged" 
                                    >
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
                                &nbsp; Cidade:&nbsp;<asp:DropDownList ID="TxtCidade" runat="server">
                                </asp:DropDownList>
                                
                                <div style="display: none;">
                                    <asp:Button ID="montaListaCidade" runat="server" OnClick="montaListaCidades_Click" />
                                </div>

                                &nbsp;&nbsp;&nbsp;Data Nascimento:
                                <asp:TextBox ID="TxtNascimento" runat="server"></asp:TextBox>
                                <Ajax:MaskedEditExtender ID="TxtNascimento_MaskedEditExtender" runat="server" Mask="99/99/9999"
                                    MaskType="Date" TargetControlID="TxtNascimento">
                                </Ajax:MaskedEditExtender>
                                &nbsp; Data Cadastro:
                                <asp:TextBox ID="TxtCadastro" runat="server" Height="22px" Width="114px"></asp:TextBox>
                                <Ajax:MaskedEditExtender ID="TxtCadastro_MaskedEditExtender" runat="server" Mask="99/99/9999"
                                    MaskType="Date" TargetControlID="TxtCadastro">
                                </Ajax:MaskedEditExtender>
                                <br />
                                <br />
                                &nbsp;Ponto de referência:<br />
                                <asp:TextBox ID="TxtReferencia" runat="server" Height="57px" Style="margin-left: 63px"
                                    Width="761px"></asp:TextBox>
                                <br />
                                <br />
                                &nbsp;Telefone:&nbsp;<asp:TextBox ID="TxtTelefone" runat="server" Style="margin-left: 6px"></asp:TextBox>
                                &nbsp; Operadora:
                                <asp:DropDownList ID="CobOperadora" runat="server" Height="22px" Width="157px">
                                </asp:DropDownList>
                                &nbsp;E-mail:
                                <asp:TextBox ID="txtEmail" runat="server" Height="22px" Width="348px"></asp:TextBox>
                                <br />
                                <br />
                                &nbsp;<asp:Label ID="Label1" runat="server" Style="text-decoration: underline; font-weight: 700;
                                    color: #3366FF" Text="Filiação:"></asp:Label>
                                <br />
                                &nbsp;Pai:<asp:TextBox ID="txtPai" runat="server" Height="22px" OnTextChanged="TextBox2_TextChanged"
                                    Style="margin-left: 42px" Width="510px"></asp:TextBox>
                                <br />
                                <br />
                                &nbsp;Mãe:<asp:TextBox ID="TxtMae" runat="server" Height="22px" Style="margin-left: 32px"
                                    Width="510px"></asp:TextBox>
                                <br />
                                <br />
                                &nbsp;Endereço dos pais:<asp:TextBox ID="TxtEndPais" runat="server" Height="22px" Style="margin-left: 5px"
                                    Width="454px"></asp:TextBox>
                                <br />
                                <br />
                            </asp:Panel>
                            <asp:Panel ID="PanelDadosFinanceiros0" runat="server" BackColor="#EAEAFF">
                                &nbsp;
                                <asp:Label ID="labLimite" runat="server" Text="Limite:"></asp:Label>
                                &nbsp;<asp:TextBox ID="TXTLimite" runat="server" Visible="False"></asp:TextBox>
                                <br />
                                &nbsp;&nbsp;<asp:Label ID="labCapital" runat="server" Text="Label"></asp:Label>
                                <br />
                                <asp:Button ID="btEditarLimite" runat="server" onclick="btEditarLimite_Click" 
                                    Text="Editar" />
                                <asp:Button ID="btSalvarLimite" runat="server" onclick="btSalvarLimite_Click" 
                                    Text="Salvar" />
                                <asp:Button ID="btFechar1" runat="server" onclick="r1_Click" Text="Fechar" />
                            </asp:Panel>
                            <asp:Panel ID="PanelContatosExtras0" runat="server" BackColor="White">
                                teste2<br />
                                <asp:Button ID="btFechar2" runat="server" onclick="r1_Click" Text="Fechar" />
                            </asp:Panel>
                            <br />
                        </asp:Panel>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <msg:Mensagem ID="CaixaMensagem1" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
