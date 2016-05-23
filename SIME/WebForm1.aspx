<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SIME.WebForm1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divResultado" runat="server" style="border: 1px solid #d5a9f7; border-radius: 4px;">
        <h1 style="height: 26px; text-align: center; Width:100%;">Campanha dos Toner Premium</h1>
        <h3 style="height: 100%; text-align: center; Width:100%;" runat="server" >Digite o codigo do cliente:</h3><br />
        <div runat="server" style="text-align: center;">
            <asp:TextBox ID="id_cliente" runat="server" Style="text-align:center;" ></asp:TextBox>
            <asp:Button ID="btBusca" Text="Buscar" runat="server" CssClass="botao" Width="50px" OnClick="btBusca_Click" />
            <br />
        </div>
        <div style="left:100px;">
            <asp:Label ID="labresultado" runat="server"></asp:Label>
        </div>
    </div>

</asp:Content>
