using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIME.Inventario
{
    public partial class iventario : System.Web.UI.Page
    {
        private Inventario.Inventario2013 contagem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master.getUsarioAtual() == null)
            {
                Response.Redirect("~/logar.aspx");
            }
            
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Replace(" ", "").Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('Deve ser informado o código do produto.');", true);
            }
            else if (!(new Class.Uteis().Sonumeros(txtID.Text)))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('O código do produto só pode conter números.');", true);
            }
            else 
            {
                try
                {
                    this.contagem = new Inventario2013(Convert.ToInt32(txtID.Text) , Master.getUsarioAtual().getCod());
                    labDados.Text = contagem.getProduto().ToStringWeb();
                    if (contagem.getProduto().getEAN().Length >= 12) 
                    {
                        txtEAN.Text = contagem.getProduto().getEAN();
                    }
                    labInforma.Text = (contagem.jaregistrado(Convert.ToInt32(txtID.Text)))?"<font color ='red'>PRODUTO JÁ CONTÉM REGISTRO DE CONTAGEM.</font>": "";
                    String[] lista = contagem.getProduto().getimagem().Split('\\');
                    if (lista.Length >= 2)
                    {
                        imgProduto.ImageUrl = "~\\fotos\\" + lista[2];
                    }
                    else 
                    {
                        imgProduto.ImageUrl = "~\\Imagens\\Imagem.jpg";
                    }
                    txtEAN.Focus();
                }
                catch (Exception erro)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('"+ erro.Message +"');", true);
                }

                
            }
        }

        protected void btGravar_Click(object sender, EventArgs e)
        {
                       
                try
                {
                    this.contagem = new Inventario2013(Convert.ToInt32(txtID.Text), Master.getUsarioAtual().getCod());
                    this.contagem.setEAN(txtEAN.Text);
                    if (contagem.jaregistrado(Convert.ToInt32(txtID.Text)))
                    {
                        this.contagem.setQuantidade(Convert.ToInt32(txtQauntidade.Text) + this.contagem.getQuantidade());
                    }
                    else
                    {
                        this.contagem.setQuantidade(Convert.ToInt32(txtQauntidade.Text));
                    }

                    this.contagem.salvar();
                    labInforma.Text = "Registro efetuado com sucesso.";
                    txtEAN.Text = "";
                    txtQauntidade.Text = "" ;
                    txtID.Text = "";
                    this.contagem.getProduto().reload();
                    String informe = "ID: " + contagem.getProduto().getID() + "<br>" +
                   "Descrição: " + contagem.getProduto().getDescricao() + "<br>" +
                   "Cod de Fabrica: " + contagem.getProduto().getCodFabricante() + "<br>" +
                   "<font color ='red'> EAN: " + contagem.getProduto().getEAN() + "</font><br>" +
                   "NCM: " + contagem.getProduto().getNCM() + "<br>" +
                   "<font color ='red'>Estoque: " + contagem.getProduto().getquantEstoque() + "</font><br>" +
                   "Venda: R$ " + contagem.getProduto().getvalorVenda() + "<br>" +
                   "Politica: " + contagem.getProduto().getpoliticaVenda() + "<br>" +
                   "Desconto: " + contagem.getProduto().gettxDesconto();
                    labDados.Text = informe;
                    txtID.Focus();
                    txtID.Text = "";
                }
                catch (Exception erro)
                {
                    labInforma.Text ="<font color ='red'>" + erro.Message + "<br>Registro não gravado! </font>";
                    
                }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Master.getUsarioAtual().getTipo() != 1)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('Usuário não autorizado');", true);
            }
            else
            {
                RegisterStartupScript("Abrir", @"<script language=javascript>window.open('/inventario/relainventario.aspx?diverge=false', '_blank');</script>");
            }
        }

        protected void BtDivergentes_Click(object sender, EventArgs e)
        {
            if (Master.getUsarioAtual().getTipo() != 1)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('Usuário não autorizado');", true);
            }
            else
            {
                RegisterStartupScript("Abrir", @"<script language=javascript>window.open('/inventario/relainventario.aspx?diverge=true', '_blank');</script>");
            }
        }

        protected void btLimpa_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtID.Focus();
        }
    }
}