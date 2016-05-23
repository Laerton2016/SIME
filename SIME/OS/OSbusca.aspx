<%@ Page Title="" Language="C#" MasterPageFile="~/OS/OS_Sime.master" AutoEventWireup="true" CodeBehind="OSbusca.aspx.cs" Inherits="SIME.OSbusca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="Label2" runat="server" Text="Selecione o cliente:"></asp:Label>
        <br />
        <select id="Select1" name="D1" style="width: 526px">
            <option></option>
        </select><asp:Button ID="BtBuscar1" runat="server" Text="Buscar" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Selecione o N° a OS.:"></asp:Label>
        <br />
        <select id="Select2" name="D2" style="width: 163px">
            <option></option>
        </select><asp:Button ID="BtBuscar2" runat="server" Text="Buscar" />
</p>
</asp:Content>
