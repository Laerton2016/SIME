<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaPreco.aspx.cs" Inherits="SIME.ConsultaPreco" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Materialize/css/materialize.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

       <asp:ScriptManager ID="ajaxkit" runat="server">
    </asp:ScriptManager>

        <asp:UpdatePanel ID="buscaprecopainel" runat="server">
            <ContentTemplate>
                <div runat="server" id="divbusca" class="center-align">
                    <asp:Label ID="labCodigo" runat="server" Text="Digite o código ou código de barras:"></asp:Label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="caixaTexto" Width="300px"></asp:TextBox>
                    <asp:Button ID="BtBuscar" runat="server" Text="Buscar" OnClick="BtBuscar_Click" />
                </div>
                <asp:UpdatePanel ID="painelResulta" runat="server" Visible="false">
                    <ContentTemplate>
                        <asp:Panel runat="server" class="center-align">
                            <div id="divresulta" runat="server" class="row">
                                <div class="col s3 ">
                                    <asp:Image ID="Imagem" runat="server" CssClass="materialboxed" Width="200" ImageUrl="~/Imagens/Imagem.jpg" />
                                </div>
                                <div class="col s9 #f5f5f5 grey lighten-4">
                                    <!--Central-->
                                    <div class="row">
                                        <div class="col s6">
                                            <asp:Label ID="labProduto" runat="server" Text="" Font-Size="XX-Large"></asp:Label>
                                        </div>
                                        <div class="col s3">
                                            <asp:Label ID="LabPreco" runat="server" Text="" Font-Size="XX-Large"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:Label ID="Labinforme" runat="server" Text="" Font-Size="XX-Large"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <script type="text/javascript" src="Materialize/js/materialize.js"></script>
        <script type="text/javascript" src="Materialize/js/Init.js"></script>



    </form>
</body>
</html>

