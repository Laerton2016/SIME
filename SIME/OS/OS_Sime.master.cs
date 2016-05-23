using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIME.Class;
namespace SIME
{
    public partial class OS_Sime : System.Web.UI.MasterPage
    {
        private static Cliente clienteSelecionadoMaster;
        private static Aparelho aparelhoAtualMaster = null;

        public Usuario getUsarioAtual()
        {
            return this.Master.getUsarioAtual();
        }

        public void setClienteSelecionado(Cliente clienteSelecionado)
        {
            clienteSelecionadoMaster = clienteSelecionado;
        }

        internal Cliente getClienteSelecionado()
        {
            return clienteSelecionadoMaster;
        }

        internal Aparelho getAparelhoAtual() {
            return aparelhoAtualMaster;
        }

        internal void setAparelhoatual(Aparelho aparelhoAtual) {
            aparelhoAtualMaster = aparelhoAtual;
        }

        
    }
}