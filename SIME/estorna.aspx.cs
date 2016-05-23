using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIME
{
    public partial class estorna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void consultar_Click(object sender, EventArgs e)
        {
            if (numero.Value.Trim().Equals("") || numero.Value == null) { throw new ArgumentException("Deve ser informado um numero."); }
            
            Venda venda = new Venda(Convert.ToInt32(numero.Value.Trim()));

            labresulta.Text = venda.countItens().ToString();
            for (int i = 0; i < venda.countItens(); i++)
            {
                
            }
        }
    }
}