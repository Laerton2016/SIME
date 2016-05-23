using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIME.Produtos
{
    public partial class indexar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SIME.Class.Produto item = new Class.Produto(new Conexao().getDb4());
            item.indexar();
        }
    }
}