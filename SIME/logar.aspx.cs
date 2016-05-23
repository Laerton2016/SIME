using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADODB;
using Sime;
using SIME.Class;

namespace SIME
{
    public partial class logar : System.Web.UI.Page
    {
        private Connection conex;
        private Usuarios usuario;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btlogar_Click(object sender, EventArgs e)
        {
            bool faz = true;
            if (txtUser.Text.Equals("") || txtUser.Text == null)
            {
                laberrousuario.Text = "Usuário não informádo.";
                faz = false;
            }
            else
            {
                laberrousuario.Text = "";
            }

            if (TxtSenha.Text.Equals("") || TxtSenha.Text == null)
            {
                laberosenha.Text = "Senha não fornecida.";
                faz = false;
            }
            else
            {
                laberosenha.Text = "";
            }



            if (faz)
            {
                conex = this.Master.getConex().getContas();
                usuario = new Usuarios(conex);
                Usuario usuarioAtual = usuario.buscaUsuario(txtUser.Text);
                if (usuarioAtual == null)
                {
                    laberrousuario.Text = "Usuário inválido";

                }
                else
                {
                    //usuarioAtual = usuario.buscaUsuario(txtUser.Text);
                    if (!usuarioAtual.validaSenha(TxtSenha.Text))
                    {
                        laberosenha.Text = "Senha inválida";
                    }
                    else
                    {
                        this.Master.setUser(usuario);
                        this.Master.setUsuarioAtual(usuarioAtual);
                        this.Master.boasVindas();
                        Response.Redirect("~/Default.aspx");

                    }
                }
            }


        }
    }
}