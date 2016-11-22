<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="carrinho.aspx.cs" Inherits="SIME.carrinho.carrinho" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ajaxkit" runat="server">
    </asp:ScriptManager> 
    <div id="Cabecalho">
        <div id="Menu">
            <asp:Label Text= "Defina qual cliente pertence esta pré-venda:" CssClass="textEntry" runat ="server"></asp:Label><br />
            <asp:TextBox ID="txtTermoCliente" CssClass ="caixaTexto" Width ="90%" runat="server" Visible ="true"></asp:TextBox>
            <asp:Button Id="BtBusca" CssClass="botao" runat="server" Text="Busca" Visible="true"/>
            <asp:DropDownList ID="CobCliente" CssClass="caixaTexto" Width ="90%" runat="server" Visible ="false"></asp:DropDownList><br />
            <asp:Label Text="Digite informações sobre o produto que deseja buscar:" CssClass="textEntry" runat ="server"></asp:Label><br />
            <asp:TextBox ID="txtTermo" runat="server" CssClass="caixaTexto" Width="40%"></asp:TextBox>
            <asp:RadioButton ID="rdid" Text ="Por código" runat="server" /> 
            <asp:RadioButton ID="rdEAN" Text ="Por código EAN" runat="server" /> 
            <asp:RadioButton ID="rdTermo" Text ="Por termo" runat="server" /> 
            <asp:Button ID="btBuscar" Text ="Buscar" runat ="server" CssClass="botao" OnClick="btBuscar_Click" /><br />
            <asp:Panel ID="pnResult" runat ="server">
                <asp:UpdatePanel ID="upResult" runat="server">
                    <ContentTemplate>
                        <div id="result" runat ="server" visible="false">
                            <div style="width:50%">
                                <asp:Label ID="labitens" Text="Itens localizados:" runat="server"></asp:Label>
                                <asp:DropDownList ID="CobResult" runat="server" Width="90%" CssClass="caixaTexto" ></asp:DropDownList>
                            </div>
                            <div style="width:50%">
                                <asp:Label ID="Label1" Text="Quantidade" runat="server"></asp:Label>
                                <asp:TextBox ID="txtQuantidade" runat ="server" CssClass="caixaTexto"></asp:TextBox><br />
                                <asp:Label ID="Label2" Text="R$" runat="server"></asp:Label>
                                <asp:TextBox ID="txtValor" runat ="server" CssClass="caixaTexto"></asp:TextBox><br />
                                <asp:Button ID="BtAdiciona" runat="server" CssClass="botao" Text="Adiciona" OnClick="BtAdiciona_Click" />
                            </div>
                        </div>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Panel ID="pnItens" runat="server">
                <asp:UpdatePanel ID="upItens" runat="server">
                    <ContentTemplate>
                        <div>
                            <div>
                                <asp:ListBox ID="ListaItens" runat ="server" CssClass ="caixaTexto" Width ="80%"/>
                            </div>
                            <div>
                                <asp:Label ID="labTotal" Text="Total:" runat="server"></asp:Label><br />
                                <asp:Label ID="labTota" Text="R$" runat="server"></asp:Label>
                            </div>
                            
                        </div>
                        <div >
                            <asp:Button ID="btExcluir" runat ="server" Text="Excluir" CssClass ="botao" OnClick="btExcluir_Click"/>
                            
                        </div>
                        <div id="totais" runat ="server" visible="true">
                            <asp:Label Text="Espécie:" runat="server"></asp:Label>
                            <asp:TextBox id="txtEspecia" runat="server"></asp:TextBox>
                            <asp:Label Text="Cheque:" runat="server"></asp:Label>
                            <asp:TextBox id="txtCheque" runat="server"></asp:TextBox>
                            <asp:Label Text="Cartão:" runat="server"></asp:Label>
                            <asp:TextBox id="txtCartao" runat="server"></asp:TextBox>
                            <asp:Label Text="Duplicata:" runat="server"></asp:Label>
                            <asp:TextBox id="TxtDuplicata" runat="server"></asp:TextBox>
                            <asp:Button ID="btFinaliza" runat ="server" Text="Finaliza" CssClass ="botao" OnClick="btFinaliza_Click"/>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            
        </div>
    </div>
    <div id ="Itens">

    </div>
</asp:Content>
