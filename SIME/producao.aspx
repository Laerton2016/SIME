<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="producao.aspx.cs" Inherits="SIME.producao" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">

        .style1
        {
            width: 209px;
            height: 241px;
        }
        .style3
        {
            height: 241px;
            width: 22px;
        }
        .style4
        {
            font-size: xx-large;
        }
        .style5
        {
            font-size: x-large;
        }
        .style6
        {
            width: 225px;
            text-align: justify;
        }
        .style7
        {
            height: 21px;
        }
        .style8
        {
            height: 35px;
        }
        .style9
        {
            width: 766px;
            height: 24px;
            text-align: justify;
            margin-left: 40px;
        }
        .style10
        {
            width: 566px;
            text-align: justify;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel3" runat="server" Height="470px" Width="918px">
        <span class="style4">&nbsp;</span><span class="style5">Produção por usuário</span><table 
            style="width:100%; height: 420px;">
            <tr>
                <td class="style8" colspan="4">
                    <asp:ScriptManager ID="scriptMaster" runat="server">
                    </asp:ScriptManager>
                    Usuário:&nbsp;<asp:DropDownList ID="cobUsuario" CssClass="browser-default" runat="server" Height="20px" 
                        Width="209px">
                    </asp:DropDownList>
                    &nbsp;&nbsp; Inicio:
                    <asp:TextBox ID="txtInicio" runat="server" Height="20px" Width="102px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtInicio_CalendarExtender" runat="server" 
                        Enabled="True" FirstDayOfWeek="Sunday" Format="dd/MM/yyyy" 
                        TargetControlID="txtInicio" TodaysDateFormat="dd/MMMM/yyyy">
                    </asp:CalendarExtender>
                    &nbsp;Fim:
                    <asp:TextBox ID="txtFim" runat="server" Height="20px" Width="102px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFim_CalendarExtender" runat="server" 
                        Enabled="True" FirstDayOfWeek="Sunday" Format="dd/MM/yyyy" 
                        TargetControlID="txtFim" TodaysDateFormat="dd/MMMM/yyyy">
                    </asp:CalendarExtender>
                    &nbsp;<asp:Button ID="BtPesquisar" runat="server" onclick="BtPesquisar_Click" 
                        Text="pesquisar" />
                </td>
            </tr>
            <tr>
                <td class="style1" rowspan="2">
                </td>
                <td class="style6">
                    
                    <asp:Label ID="labAtingido" runat="server" ForeColor="Black"></asp:Label>
                    
                    <br />
                    
                    
                </td>
                <td class="style10">
                    &nbsp;</td>
                <td class="style3" rowspan="2">
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" colspan="2">

                    <asp:Chart ID="Chart1" runat="server" Height="286px" Width="770px">
                        <Series>
                            <asp:Series ChartType="StackedColumn" Name="Series1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX IsLabelAutoFit="False">
                                    <LabelStyle Angle="75" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
            </tr>
            <tr>
                <td class="style7" colspan="4">
                    <asp:Label ID="labResumo" runat="server" ForeColor="Black"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:CollapsiblePanelExtender ID="Panel3_CollapsiblePanelExtender" 
        runat="server" Enabled="True" TargetControlID="Panel3">
    </asp:CollapsiblePanelExtender>
</asp:Content>
