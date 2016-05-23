<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="estorna.aspx.cs" Inherits="SIME.estorna" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ MasterType VirtualPath="~/OS/OS_Sime.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <div>
        <h1>Informe os dados para realizar o estorno:</h1><br />

        <label>Número da venda:</label>
        <input id ="numero" type="text" runat ="server" class="caixaTexto" style="width:100px" />
        <asp:Button ID ="consultar" Text ="Consultar" CssClass="botao" runat ="server" OnClick="consultar_Click" />
        <asp:Panel ID ="resultado" runat ="server">
            <asp:UpdatePanel ID ="Upresultado" runat ="server">
                <ContentTemplate>
                    <div>
                        <asp:Label ID="labresulta" runat ="server">Lista de itens da venda:</asp:Label><br />
                        <br />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>


    </div>
</asp:Content>
