<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OS1.aspx.cs" Inherits="SIME.OS.OS1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/style.css" rel="stylesheet" type="text/css" />
    
    
    
    <style type="text/css">
        .style7
        {
            height: 88px;
        }
        .style10
        {
            background: #DDD;
            font-family: Tahoma;
            font-size: large;
            text-align: center;
            border: 1px solid rgb(0,0,0);
            height: 6px;
        }
        .style40
        {
            border: 1px solid rgb(0,0,0);
            background: #E9E9FE;
            margin-left: 1px;
            font-family: Tahoma;
            font-size: smaller;
            }
        .style42
        {
            border: 1px solid rgb(0,0,0);
            background: #E9E9FE;
            margin-left: 1px;
            font-family: Tahoma;
            font-size: smaller;
            width: 9%;
        }
        .style43
        {
            height: 60px;
        }
        .style44
        {
            border: 1px solid #CDD0FE;
            margin-left: 1px;
            font-family: Tahoma;
            font-size: 12px;
            width: 1127px;
        }
        .style45
        {
            border: 1px solid #CDD0FE;
            margin-left: 1px;
            font-family: Tahoma;
            font-size: 12px;
            width: 1270px;
        }
        .style46
        {
            border: 1px solid #CDD0FE;
            margin-left: 1px;
            font-family: Tahoma;
            font-size: 12px;
        }
        .style47
        {
            border: 1px solid #CDD0FE;
            margin-left: 1px;
            font-family: Tahoma;
            font-size: 12px;
            width: 26%;
        }
        .style48
        {
            border: 1px solid #CDD0FE;
            margin-left: 1px;
            font-family: Tahoma;
            font-size: 12px;
            width: 294px;
        }
        </style>
    
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 210mm; height: 100mm">
    
        <table class ="caixaTexto_menor" style="width: 210mm; height: 100mm; border: 1px solid rgb(0,0,0);" >
            <tr>
                <td class="style43"  >
                    </td>
                <td class="style43" >
                    </td>
                <td class="style43" >
                    <b>TV SOM - Com. de TV&#39;s e Peças Gadelha&nbsp;Ltda e/ou 
                    SIL Sousa Informática Ltda.</b><br />
                    End.: Av. Eng. Carlos Pires de Sá,S/N&nbsp;
                    Centro Sousa - PB CEP 58800-280<br />
                    Telefones:(83)3521-1630/3522-2872/2786<br />
                    e-mail: <a href="mailto:tvsom.gadelha@bol.com.br">tvsom.gadelha@bol.com.br</a>&nbsp;
                    Site: <a href="http://www.lojasil.com">www.lojasil.com</a><br />
                    <asp:Label ID="Lab_dadosOS" runat="server" Text="Label"></asp:Label>
                    </td>
                <td class="style43" >
                    <img id="img1" runat="server" 
                        src="" 
                        style="height: 23mm; width: 40mm" /></td>
            </tr>
            <tr>
                <td colspan="2"  class="style10" >
                    <asp:Label ID="Label1" runat="server" Text="Cliente" ></asp:Label>
                </td>
                <td colspan="2"  class="style10" >
                                <asp:Label ID="lab_nome" runat="server" Text="Label"></asp:Label>
                            &nbsp;-
                                <asp:Label ID="Lab_doc" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="caixaTexto_menor" colspan="4">
                    <table style="width:100%;" >
                        
                        <tr>
                            <td class="style40"  >
                                Aparelho:</td>
                            <td class="style44">
                                <asp:Label ID="Lab_aparelho0" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="style40">
                                Marca:</td>
                            <td class="style45">
                                <asp:Label ID="Lab_marca0" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="style42" >
                                Modelo:</td>
                            <td class="style47">
                                <asp:Label ID="Lab_modelo0" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="style40">
                                Garantia:</td>
                            <td class="style46">
                                <asp:Label ID="Lab_garantia0" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="caixaTexto_menor" colspan="8"  >
                                <asp:Label ID="Lab_resumo" runat="server" Text="Label" Font-Size="XX-Small"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    
                </td>  
            </tr>
            <tr>
                <td class="style10" colspan="2">
                    Loja</td>
                <td class="style10" colspan="2">
                                <asp:Label ID="lab_nome0" runat="server" Text="Label"></asp:Label>
                            &nbsp;-
                                <asp:Label ID="Lab_doc0" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="caixaTexto_menor" colspan="4">
                  <table style="width:100%;">
                        <tr>
                            <td class="rotulo_menor">
                                Aparelho:</td>
                            <td class="caixaTexto_menor">
                                <asp:Label ID="Lab_aparelho" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class= "rotulo_menor">
                                Marca:</td>
                            <td class="caixaTexto_menor">
                                <asp:Label ID="Lab_marca" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class= "rotulo_menor" colspan="2">
                                Modelo:</td>
                            <td class="caixaTexto_menor">
                                <asp:Label ID="Lab_modelo" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class= "rotulo_menor">
                                Garantia:</td>
                            <td class = "caixaTexto_menor">
                                <asp:Label ID="Lab_garantia" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class= "rotulo_menor">
                                Loja:</td>
                            <td class="caixaTexto_menor" colspan="3">
                                <asp:Label ID="Lab_loja" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class= "rotulo_menor" colspan="2">
                                Dados NF:</td>
                            <td class="caixaTexto_menor" colspan="3">
                                <asp:Label ID="Lab_NF" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class= "rotulo_menor">
                                Acessórios:</td>
                            <td class="caixaTexto_menor" colspan="8">
                                <asp:Label ID="Lab_acessorios" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class= "rotulo_menor">
                                Defeito:</td>
                            <td class="caixaTexto_menor" colspan="8">
                                <asp:Label ID="Lab_Defeito" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class= "rotulo_menor" rowspan="2">
                                Obs:</td>
                            <td class="caixaTexto_menor" colspan="8">
                               <asp:Label ID="Lab_texto" runat="server" Text="Label" Font-Size="X-Small"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="style48" colspan="4">
                    <asp:Label ID="Lab_assina" runat="server" Text="Dados do cliente para assinar" 
                                    Font-Size="X-Small"></asp:Label>
                            </td>
                            <td class="caixaTexto_menor" colspan="4">
                                Entregue _____/______/______&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; assinatura</td>
                        </tr>
                        </table>
                    </td>
            </tr>
            <tr>
                <td class="style7" colspan="4">
                    <img 
                        src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQC_Q912fdUlO63M2aHs4ptbpSMQxzGAv_OxCSjluTbDmgPeck" 
                        style="height: 101px; width: 155px" id="img2" runat ="server" /><img 
                        src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQC_Q912fdUlO63M2aHs4ptbpSMQxzGAv_OxCSjluTbDmgPeck" 
                        style="height: 101px; width: 155px" id="img3" runat ="server"/><img 
                        src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQC_Q912fdUlO63M2aHs4ptbpSMQxzGAv_OxCSjluTbDmgPeck" 
                        style="height: 101px; width: 155px" id="img4" runat ="server"/></td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
