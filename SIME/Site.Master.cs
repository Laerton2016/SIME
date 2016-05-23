using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADODB;
using Sime;
using SIME.Class;
using System.Web.Caching;


namespace SIME
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private static Conexao conex = new Conexao();
        private static Usuarios user;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            boasVindas();
            
        }

        public Usuarios getUser()
        {
            return user;
        }
        public void setUser(Usuarios userAg)
        {
            user = userAg;
        }
        public Conexao getConex()
        {
            return conex;
        }

        public void boasVindas()
        {
            Usuario usuario = getUsarioAtual();
            
            if (usuario != null)
            {
                if (usuario.getNome() != null)
                {
                    this.labBoasVindas.Text = "Bem vindo " + usuario.getNome() + "!";
                    this.HLlogar.Text = "Sair";
                    this.HLPerfil.Visible = true;
                    this.HLPerfil.NavigateUrl = "~/emconstrucao.aspx";
                    this.HLlogar.NavigateUrl = "~/deslogar.aspx";
                }
            }
            else
            {
                this.HLlogar.Text = "Logar";
                this.HLPerfil.Visible = false;
                this.HLlogar.NavigateUrl = "~/logar.aspx";
                
            }
        }
        public void setUsuarioAtual(Usuario usuarioAtualArg)
        {
           
            HttpCookie cookie = new HttpCookie("UsuarioAtual");
            cookie.Value = usuarioAtualArg.ToString();
            DateTime dt = DateTime.Now;
            TimeSpan tshoras = new TimeSpan(0,45,0);
            cookie.Expires = dt + tshoras;
            Response.Cookies.Add(cookie);
        }

        public Usuario getUsarioAtual()
        {
            HttpCookie cookie = Request.Cookies["UsuarioAtual"];
            if (cookie != null)
            {
                if (cookie.Value.ToString().Equals(""))
                {
                    return null;
                }
                else
                {
                    String[] dadosRetorno = cookie.Value.ToString().Split(',');
                    Usuario retorna = new Usuario(Convert.ToInt16(dadosRetorno[0]), dadosRetorno[1], dadosRetorno[2], Convert.ToInt16(dadosRetorno[3]));
                    return retorna;
                }
            }
            else {
                return null;
            }
        }

        public void limpaCookie() {
            HttpCookie cookie = new HttpCookie("UsuarioAtual");
            Response.Cookies.Add(cookie);
        }

        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }




    }
}
