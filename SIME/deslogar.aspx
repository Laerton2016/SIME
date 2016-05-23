<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="deslogar.aspx.cs" Inherits="SIME.deslogar" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #dados
        {
            width: 255px;
            text-align: center;
            margin-left: 268px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <Ajax:DropShadowExtender ID="dados1" runat = "server" TargetControlID = "panel3" Opacity = "0.8"
    Rounded = "true" TrackPosition = "true" ></Ajax:DropShadowExtender>
    <div style="height: 158px">
        <div id="dados"  width: 301px; height: 154px; text-align: center; margin-left: 321px">

            <asp:Panel ID="Panel3" runat="server" BackColor="White" 
                style="margin-left: 27px" Width="294px">
                <img alt="" src="Imagens/IconeCadeado.png" 
    style="height: 33px; width: 34px" />
                &nbsp;
                <asp:Label ID="Label1" runat="server" 
                style="font-size: xx-large; text-align: center" 
    Text="Deslogar"></asp:Label>
                <br />
                <br />
                Para deslogar clique abaixo.<br />
                <br />
                <br />
                <asp:Button ID="btDeslogar" runat="server" onclick="btDeslogar_Click" 
                Text="Deslogar" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
