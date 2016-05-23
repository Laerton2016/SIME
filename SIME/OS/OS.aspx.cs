using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Printing;

namespace SIME.Relatorio
{
    public partial class OS : System.Web.UI.Page
    {
        private String N_OS;
        private PrintDocument pd = new PrintDocument();
        private int n_impr = 0;
        SIME.Class.Aparelho aparelho;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            N_OS = Request.QueryString["OS"];
            aparelho = new Class.Aparelho(Convert.ToInt32(N_OS));
            labDadosOS.Text = aparelho.WebDadosOS();
            labDadosAparelho.Text = aparelho.webDadosAparelho();
            labDadosCliente.Text =  new Class.Cliente(aparelho.IDcliente, new Conexao().getDb4()).ToString();
        }
    }
}