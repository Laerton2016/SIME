using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIME
{
    public partial class deslogar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btDeslogar_Click(object sender, EventArgs e)
        {
            //this.Master.setUser(null);
            this.Master.limpaCookie();
            Response.Redirect("~/Default.aspx");
        }
    }
}