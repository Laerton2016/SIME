using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIME
{
    public partial class OSAbertura3 : System.Web.UI.Page
    {
        private Class.Cliente clienteSelecionado;
        private Class.Aparelho aparelho;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clienteSelecionado == null)
            {
                clienteSelecionado = Master.getClienteSelecionado();
            }
            if (clienteSelecionado != null)
            {
                labDadosCliente.Text = "<b>Nome: </b>" + clienteSelecionado.getNome() + " <b> Documento: </b>" + clienteSelecionado.getCPFCNPJ();


            }

            if (aparelho == null)
            {
                aparelho = Master.getAparelhoAtual();
            }

            if (aparelho != null)
            {
                labDadosCAparelho.Text = aparelho.ToStringWeb();
            }
        }

        protected void Bt_retornar_Click(object sender, EventArgs e)
        {
            Master.setAparelhoatual(aparelho);
            Response.Redirect("~/OS/OSAbertura2.aspx");
        }


        


        protected void BT_Concluir_Click(object sender, EventArgs e)
        {
            aparelho.salvar();
            plnImprimi.Show();

        }

        protected void BtImprimir_Click1(object sender, EventArgs e)
        {
            if (RBBobina.Checked)
            {
                RegisterStartupScript("Abrir", @"<script language=javascript>window.open('/OS/OS.aspx?OS=" + aparelho.getID() + "', '_blank');</script>");
            }
            else
            {
                RegisterStartupScript("Abrir", @"<script language=javascript>window.open('/OS/OS1.aspx?OS=" + aparelho.getID() + "', '_blank');</script>");
            }
        }
    }
}