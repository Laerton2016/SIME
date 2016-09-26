using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADODB;
using SIME.Class;

namespace SIME
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SIME.Class.Usuario userAtual;
        private Boolean podeesxcluir = false;
        private FronteCamapanha campanha = new FronteCamapanha();
        protected void Page_Load(object sender, EventArgs e)
        {
            userAtual = this.Master.getUsarioAtual();

            if (userAtual == null)
            {
                Response.Redirect("~/logar.aspx");
            }
            else
            {
                podeesxcluir = (userAtual.getTipo() == 1) ? true : false;
            }
        }

        protected void btBusca_Click(object sender, EventArgs e)
        {


            if (id_cliente.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('Deve ser informado um código de cliente.'); ", true);
                return;
            }

            try
            {
                //Montando a grade*/
                var cliente = campanha.BuscaCliente(Int64.Parse(id_cliente.Text));
                if (cliente.Fidelizado)
                {
                    labresultado.Text = "<div><h1>" + cliente.Nome + "<h1>" +
                "<h3>Cliente fidelizado desde: " + cliente.DataFidelizacao.ToShortDateString() + "</h3><ul>";

                    Int64[] codigos = { 6190, 6804, 6660, 6805 };

                    for (int i = 0; i < codigos.Length; i++)
                    {
                        labresultado.Text += campanha.monta(cliente, campanha.BuscaProduto(codigos[i]), 4);
                    }
                    
                }
                else
                {
                    labresultado.Text = "<div><h1>" + cliente.Nome + "<h1>" +
                "<h3>Cliente não fidelizado </h3><ul>";

                }

                labresultado.Text += "</ul></div>";


            }
            catch (Exception E)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('" + E.Message + "'); ", true);
                return;
            }


        }
        private String monta(SIME.Class.Cliente cliente, Int32 IDProduto)
        {
            List<string[]> contagem = new List<string[]>();
            SIME.Class.Clientes busca = new SIME.Class.Clientes();
            contagem = busca.getProdutoporCliente(cliente, IDProduto);
            
            if (contagem.Count == 0) { return ""; }
            String montagem  = "<div><h1>" + cliente.getNome() + "<h1>" +
                "<h3>Cliente fidelizado desde: " + cliente.Dt_inicializacao.ToShortDateString() + "</h3><ul>";

            for (int i = 0; i < contagem.Count; i++)
            {
                montagem += "<li>Produto:" + contagem[i][0] + "<ul><il><il> Quantidade comprado: " + contagem[i][1] + "</il></li><li> Bonus no período: " +
                    contagem[i][2] + "</li><li>Bonus usuado: " + contagem[i][3] + "</li><li> Bonus disponíveis: " + contagem[i][4] + "</li></ul></li>";
            }

            montagem += "</ul></div>";

            return montagem;
        }
    }
}