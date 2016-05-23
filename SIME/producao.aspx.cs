using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIME.Class;


namespace SIME
{
    public partial class producao : System.Web.UI.Page
    {
        private Sime.Usuarios _user = new Sime.Usuarios(new Conexao().getContas());
        private SIME.Class.Usuario _userAtual;
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");
        protected void Page_Load(object sender, EventArgs e)
        {          
            _user = this.Master.getUser();
            _userAtual = this.Master.getUsarioAtual();
            
            
            if(_userAtual == null)
            {
                Response.Redirect("~/logar.aspx");
            }
            else
            {

                if (cobUsuario.Text.Equals(""))
                {
                    if (_user == null)
                    {
                        _user = new Sime.Usuarios(new Conexao().getContas());
                    }
                    _user.preencheCombo(cobUsuario, _userAtual);

                }
            }
        }

        protected void BtPesquisar_Click(object sender, EventArgs e)
        {
            //Tratamento para datas
            Boolean confirma = true;
            String erro = "";
            if (txtInicio.Text.Equals("") || txtInicio.Text == null)
            {
                erro = "<br> Não foi informado a data inicial.";
                confirma = false;
            }
            if (txtFim.Text.Equals("") || txtFim.Text == null)
            {
                erro += "<br> Não foi informado a data final.";
                confirma = false;
            }

            if (!txtFim.Text.Equals("") && !txtInicio.Equals(""))
            {
                if (Convert.ToDateTime(txtFim.Text, culture) < Convert.ToDateTime(txtInicio.Text, culture))
                {
                    erro += "<br> Data inicial maior que a final.";
                    confirma = false;
                }
            }

            if (cobUsuario.Text.Equals(""))
            {
                erro += "<br> Usuário não selecionado.";
                confirma = false;
            }

            if (confirma)
            {

                labResumo.ForeColor = System.Drawing.Color.Black;
                labResumo.Text = this._user.producaoUsuario(Convert.ToInt16(cobUsuario.SelectedValue), Convert.ToDateTime(txtInicio.Text, culture), Convert.ToDateTime(txtFim.Text, culture));

                this._user.getVendas().setMetaDia(2173.92);
                this._user.getVendas().geraGrafico(this.Chart1);
                labAtingido.Text = new UteisWeb().montaTab(_user.getVendas().getMetasAtingidas(), "Datas com metas cumpridas", System.Drawing.Color.SkyBlue);

            }
            else
            {
                labResumo.Text = erro;
                labResumo.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}