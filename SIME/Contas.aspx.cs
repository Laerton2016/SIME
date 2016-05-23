using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIME.Class;
using ADODB;
namespace SIME
{
    public partial class Contas : System.Web.UI.Page
    {
        private ContasAPagar contasSIME;
        private static Connection conex;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master.getUsarioAtual() == null)
            {
                Response.Redirect("~/logar.aspx");
            }
            else
            {

                if (this.Master.getUsarioAtual().getTipo() != 1)
                {
                    Response.Redirect("~/naoautorizado.aspx");
                }
                else
                {
                    if (contasSIME == null)
                    {
                        conex = Master.getConex().getContas();
                        contasSIME = new ContasAPagar(conex, true);
                        Labteste.Text = contasSIME.getTabelaDuplicatas();
                    }
                }
            }
        }
    }
}