using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADODB;

namespace SIME
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SIME.Class.Usuario userAtual;
        private Boolean podeesxcluir = false;

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
                SIME.Class.Cliente cliente = new Class.Cliente(Int32.Parse(id_cliente.Text), new Conexao().getDb4());

                //6720 - Toner Universal 85A 
                //6660 - Toner 83A

                String resultada =  monta(cliente, 6190);
                resultada += "<br/>" + monta(cliente, 6804);
                resultada += "<br/>" + monta(cliente, 6660);
                resultada += "<br/>" + monta(cliente, 6805);
                //Montando a grade

                labresultado.Text = resultada;

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