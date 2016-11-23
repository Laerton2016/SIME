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
using SIME.Class.DAO;

namespace SIME
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private static Conexao conex = new Conexao();
        private static Usuarios user;
        private static Carrinho _carrinho;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            boasVindas();
            
        }

        public Carrinho GetCarrinho()
        {
            return _carrinho;
        }

        public void SetCarrinho(Carrinho carrinho)
        {
            _carrinho = carrinho;
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
                if (usuario.getTipo() <= 4)
                {
                    _carrinho = new Carrinho(usuario);
                    this.HLQCarrinho.Text = _carrinho.GetVenda().Itens.Count.ToString();
                    this.HLCarrinho.Visible = true;
                    this.HLQCarrinho.Visible = true;
                }
            }
            else
            {
                this.HLlogar.Text = "Logar";
                this.HLPerfil.Visible = false;
                this.HLlogar.NavigateUrl = "~/logar.aspx";
                this.HLCarrinho.Visible = false;
                this.HLQCarrinho.Visible = false;

            }
        }
        public void AtualizaCarrinho()
        {

            this.HLQCarrinho.Text = _carrinho.GetVenda().Itens.Count.ToString();
            //this.upLogin.Update();
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

                    //-Usuario retorna = new Usuario(Convert.ToInt16(dadosRetorno[0]), dadosRetorno[1], dadosRetorno[2], Convert.ToInt16(dadosRetorno[3]));
                    Usuario retorna = FactoryDAO.CriaDAOUsuario().Buscar(Convert.ToInt16(dadosRetorno[0]));
                    
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
