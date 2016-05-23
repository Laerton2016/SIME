<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SIME._Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style3
        {
            width: 150px;
            font-size: small;
        }
        .style4
        {
            width: 648px;
            height: 33px;
        }
        .style5
        {}
        .style6
        {
            width: 648px;
            height: 316px;
            font-size: x-small;
        }
        .style9
    {
        width: 323px;
        font-size: x-small;
    }
    .style10
    {
        width: 324px;
        font-size: x-small;
    }
        .style12
        {
            height: 72px;
            font-size: large;
        }
        .style16
        {
            height: 21px;
            font-size: large;
            }
        .style20
        {
            font-size: small;
            font-family: Tahoma;
        }
        .style21
        {
            height: 6px;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <h4>
            <p>
                &nbsp;</p>
        </h4>

        <table style="width:100%;">
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="2" align="center">
                    &nbsp;</td>
                <td class="style5" rowspan="4">
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style6" rowspan="2" colspan="2">
                    <table style="width: 100%; height: 304px;">
                        <tr>
                            <td class="style16" align="center">
                    
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/Sime1.png" />
                            </td>
                        </tr>
                        <tr>
                            <td style="background-image: inherit"> 
                            
                                <table style="border-style: none none groove none; width: 100%;">
                                    <tr>
                                        <td class="style12" rowspan="2">
                                            &nbsp;</td>
                                        <td align="center">
                                            &nbsp;</td>
                                        <td align="center">
                <iframe src="http://youtu.be/VUIttbsVrs8" frameborder="0" allowfullscreen id="I1" name="I1" 
                                                style="height: 202px; width: 308px"></iframe>
                                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style21" colspan="2" align="right">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="style20" colspan="2">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style9" align="center">
                    <br />
                    <br />
                    <asp:Image ID="Image2" 
                        runat="server" ImageUrl="~/Imagens/Sime4.png" />
                            </td>
                <td class="style10" align="center">
                VEJA A COTAÇÃO DO DOLAR E DO EURO EM TEMPO REAL
                    <asp:Panel ID="Panel3" 
                        runat="server" Height="114px" style="margin-left: 0px; margin-bottom: 2px;" 
                                    Width="268px" BorderColor="#000066" CssClass="style6">
                                    <script language="javascript" src="http://www.debit.com.br/resumogratuito.php?info=novo_dolar"></script>
                                </asp:Panel>
                            </td>
            </tr>
        </table>
    </h2>
    <p>
        &nbsp;</p>
    </asp:Content>
