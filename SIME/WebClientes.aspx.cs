using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apresentacao.Controles;


namespace SIME.Class
{
    public partial class WebClientes : System.Web.UI.Page
    {
        private Clientes todos;
        private SIME.Class.Usuario userAtual;
        private Boolean podeesxcluir = false;
        private Cliente clienteSelecionado;
        private String Limite = "0";

        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");

        protected void Page_Load(object sender, EventArgs e)
        {
            todos = new Clientes();
            labInf1.ForeColor = System.Drawing.Color.Red;

            userAtual = this.Master.getUsarioAtual();

            if (!IsPostBack) {
                PanelBotoes.Visible = false;
                PanelDados.Visible = false;
                UpPanel_Busca.Visible = false;

            }

            if (userAtual == null)
            {
                Response.Redirect("~/logar.aspx");
            }
            else
            {
                podeesxcluir = (userAtual.getTipo() == 1) ? true : false;
            }

            if (CobOperadora.Items.Count == 0)
            {
                preencheComboOperadoras();
            }

            TxtUF.Attributes.Add("onblur", this.Page.ClientScript.GetPostBackEventReference(this.montaListaCidade, ""));


        }

        protected void BtAdd0_Click(object sender, ImageClickEventArgs e)
        {
            Uteis util = new Uteis();
            //Metodo que deve buscar o cliente
            if (txtcampo.Text.Equals("") || txtcampo.Text == null)
            {
                labInf1.Text = "Não foi informado dados para busca ou adicição.";
                labInf1.Visible = true;
                txtcampo.Focus();
                //PanelBusca.Visible = false;
            }
            else
            {
                labInf1.Visible = false;

                if (util.Sonumeros(txtcampo.Text))
                {
                    if (txtcampo.Text.Length == 11 || (txtcampo.Text.Length == 14 && txtcampo.Text.Contains(".")))
                    {
                        if (util.validaCPF(txtcampo.Text))
                        {
                            exibiporCPFCNPJ();
                        }
                        else
                        {
                            labInf1.Text = "CPF inválido";
                            labInf1.Visible = true;
                            txtcampo.Focus();
                        }
                    }
                    else if (txtcampo.Text.Length == 18 || (txtcampo.Text.Length == 14 && !txtcampo.Text.Contains(".")))
                    {
                        if (util.validaCNPJ(txtcampo.Text))
                        {
                            exibiporCPFCNPJ();
                        }
                        else
                        {
                            labInf1.Text = "CNPJ inválido";
                            labInf1.Visible = true;
                            txtcampo.Focus();
                        }
                    }
                    else
                    {
                        labInf1.Text = "Dados inválidos.";
                        labInf1.Visible = true;
                        txtcampo.Focus();
                    }
                }
                else
                {
                    exibiporNome();
                }

            }
        }

        private void exibiporCPFCNPJ()
        {
            List<String[]> dados = todos.filtraCPFCNPJ(txtcampo.Text);
            if (dados.Count >= 1)
            {
                ComboClientes.Items.Clear();
                foreach (String[] item in dados)
                {
                    ComboClientes.Items.Add(new ListItem() { Value = Convert.ToString(item[0]), Text = item[1].ToUpper() });
                }
                //PanelBusca.Visible = true;
                panelInicial.Enabled = false;
                ComboClientes.Focus();
            }
            else 
            {
                CaixaMensagem1.Mostar(Mensagem.Tipo.Aviso, "CPF ou CNPJ não localizado, sistema abrirá o cadastro para inclusão deste novo cliente.", "Ok");
                clienteSelecionado = new Cliente(new Conexao().getDb4());
                PanelDados.Visible = true;
                PanelDados.Enabled = false;
                PanelBotoes.Visible = true;
                //PanelBusca.Enabled = false;
                BTEditaCliente_Click(new object(), new ImageClickEventArgs(1,1));

            
            }

        }



        private void exibiporNome()
        {
            List<String[]> dados = todos.filtraNome(txtcampo.Text, true);
            if (dados.Count >= 1)
            {
                ComboClientes.Items.Clear();
                foreach (String[] item in dados)
                {
                    ComboClientes.Items.Add(new ListItem() { Value = Convert.ToString(item[0]), Text = item[1].ToUpper() });
                }
                ////PanelBusca.Visible = true;
                panelInicial.Enabled = false;
                ComboClientes.Focus();
            }
            else {
                CaixaMensagem1.Mostar(Mensagem.Tipo.Aviso, "Nome não localzado, para que seja incluido um novo cliente digite o seu CPF ou CNPJ no campo de busca", "Ok");
            }

        }

        protected void preencheNome()
        {
            List<String[]> dados = todos.filtraNome(txtcampo.Text, true);
            if (dados.Count != 0)
            {
                //PanelBusca.Visible = true;
                panelInicial.Enabled = false;

            }
            else
            {
                labInf1.Text = "Não foi encontrado nenhum cliente com este dado";
                labInf1.ForeColor = System.Drawing.Color.Red;
                labInf1.Visible = true;
                txtcampo.Focus();
            }
        }

        protected void preencheCPF()
        {
            List<String[]> dados = todos.filtraCPFCNPJ(txtcampo.Text);
            if (dados.Count != 0)
            {
                //PanelBusca.Visible = true;
                panelInicial.Enabled = false;

            }
            else
            {
                labInf1.Text = "Não foi encontrado nenhum cliente com este CPF ou CNPJ";
                labInf1.ForeColor = System.Drawing.Color.Red;
                labInf1.Visible = true;
                txtcampo.Focus();
            }
        }
        protected void BtRetornar_Click(object sender, ImageClickEventArgs e)
        {
            //PanelBusca.Visible = false;
            panelInicial.Enabled = true;
            txtcampo.Focus();
        }

        protected void btEditar_Click(object sender, ImageClickEventArgs e)
        {
            PanelDados.Visible = true;
            PanelDados.Enabled = false;
            PanelBotoes.Visible = true;
            //PanelBusca.Enabled = false;
            clienteSelecionado = todos.getCliente(Convert.ToInt16(ComboClientes.SelectedValue));

            preencheDados();
            BtEditarCliente.Focus();
        }

        private void preencheDados()
        {

            LabCod0.Text = Convert.ToString(clienteSelecionado.getCod());
            txtNome.Text = clienteSelecionado.getNome();
            txtEndereco.Text = clienteSelecionado.getEnd();

            String doc = clienteSelecionado.getCPFCNPJ();
            doc = doc.Replace(".", "");
            doc = doc.Replace("-", "");
            doc = doc.Replace("/", "");

            txtCNPJ.Text = doc;

            TxtInsc.Text = clienteSelecionado.getIE();
            TxtBairro.Text = clienteSelecionado.getBairro();
            TxtCEP.Text = clienteSelecionado.getCEP();
            //Tratamento para não encontrar UF na lista
            String UF = clienteSelecionado.getUF().ToUpper().Trim();
            if (TxtUF.Items.Contains(new ListItem() { Text = UF }))
            {
                TxtUF.Text = clienteSelecionado.getUF().ToUpper().Trim();
                new Uteis().listaCidades(TxtUF.Text, TxtCidade);
                if (TxtCidade.Items.Contains(new ListItem() { Value = clienteSelecionado.getCidade(), Text = clienteSelecionado.getCidade() }))
                {
                    TxtCidade.Text = clienteSelecionado.getCidade();
                }
                Limite = Convert.ToString(clienteSelecionado.getLimite());
                labLimite.Text = "Limite: R$ " + Limite;

            }
            else
            {
                TxtUF.Text = "";
                TxtCidade.Text = "";
            }

            TxtNascimento.Text = Convert.ToString(clienteSelecionado.getDataNascimento(), culture).Replace("00:00:00", "");
            TxtCadastro.Text = Convert.ToString(clienteSelecionado.getDataCadastro(), culture).Replace("00:00:00", "");
            TxtReferencia.Text = clienteSelecionado.getReferencia();
            TxtTelefone.Text = clienteSelecionado.getTelefone();
            String opCliente = clienteSelecionado.getOperadora().ToUpper();
            if (opCliente == "OI" || opCliente == "TIM" || opCliente == "CLARO" || opCliente == "VIVO")
            {
                CobOperadora.Text = clienteSelecionado.getOperadora().ToUpper();
            }
            txtEmail.Text = clienteSelecionado.getEmail();
            txtPai.Text = clienteSelecionado.getPai();
            TxtMae.Text = clienteSelecionado.getMae();
            TxtEndPais.Text = clienteSelecionado.getEndPais();
            ativaFiliacao(!clienteSelecionado.getPessoaJuridica()); // Deve-se colocar invertido pois o mesmo metódo é que verifica qual status anterior.
            ativaMascara();
            this.labCapital.Text = new UteisWeb().montaTab(clienteSelecionado.getInformacoesdeCredito(), "Informações financeira", System.Drawing.Color.AliceBlue);

        }
        protected void BTRetornaCliente_Click(object sender, ImageClickEventArgs e)
        {
            PanelDados.Visible = false;
            PanelBotoes.Visible = false;
            //PanelBusca.Enabled = true;
            ComboClientes.Focus();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BTRetornaCliente_Click1(object sender, ImageClickEventArgs e)
        {
            PanelDados.Visible = false;
            PanelBotoes.Visible = false;
            //PanelBusca.Enabled = true;
            ComboClientes.Focus();

        }

        protected void BTEditaCliente_Click(object sender, ImageClickEventArgs e)
        {
            PanelDados.Enabled = true;
            txtNome.Focus();
        }

        private void preencheComboOperadoras()
        {
            CobOperadora.Items.Add("CLARO");
            CobOperadora.Items.Add("TIM");
            CobOperadora.Items.Add("OI");
            CobOperadora.Items.Add("VIVO");
        }




        public void ativaFiliacao(Boolean ativa)
        {
            if (!ativa) //Estava negado e agora deve ficar positivo
            {
                ImgJuridica.ImageUrl = "~/imagens/ok_16x16.gif";
                txtPai.Enabled = false;
                TxtMae.Enabled = false;
                TxtEndPais.Enabled = false;
            }
            else
            {
                ImgJuridica.ImageUrl = "~/imagens/delete_16x16.gif";
                txtPai.Enabled = ativa;
                TxtMae.Enabled = ativa;
                TxtEndPais.Enabled = ativa;
            }

        }

        private Boolean getJuridica()
        {
            if (ImgJuridica.ImageUrl.Equals("~/imagens/delete_16x16.gif"))
            {
                return false;
            }

            return true;

        }

        protected void ImgJuridica_Click(object sender, ImageClickEventArgs e)
        {
            ativaFiliacao(getJuridica());
            ImgJuridica.Focus();
            ativaMascara();
        }

        protected void BTBuscaCep_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                DadosCEP infCep = new DadosCEP(TxtCEP.Text);
                txtEndereco.Text = (infCep.getEndereco().Equals("")) ? txtEndereco.Text : infCep.getTipoLogradouro() + " " + infCep.getEndereco();
                TxtBairro.Text = (infCep.getBairro().Equals("")) ? TxtBairro.Text : infCep.getBairro();
                TxtUF.Text = (infCep.getUf().Equals("")) ? TxtUF.Text : infCep.getUf();
                montaListaCidades_Click();
                TxtCidade.Text = (infCep.getCidade().Equals("")) ? TxtCidade.Text : infCep.getCidade().ToUpper();

            }
            catch (Exception )
            {
                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('" + erro.Message + "');", true);
                CaixaMensagem1.Mostar(Mensagem.Tipo.Erro, "CEP não localizado.");
            }
            
                
            
        }

        protected void txtCNPJ_TextChanged(object sender, EventArgs e)
        {
            ativaMascara();

        }

        private void ativaMascara()
        {
            txtCNPJ_MaskedEditExtender.MaskType = AjaxControlToolkit.MaskedEditType.Number;
            if (getJuridica())
            {
                txtCNPJ_MaskedEditExtender.Mask = "99.999.999/9999-99";
            }
            else
            {
                txtCNPJ_MaskedEditExtender.Mask = "999.999.999-99";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Uteis validar = new Uteis();
            if (getJuridica())
            {

                if (!TxtInsc.Text.ToUpper().Equals("ISENTO"))
                {

                    if (!TxtInsc.Text.Contains('-') || !validar.ValidaIE(TxtInsc.Text, TxtUF.Text))
                    {
                        CaixaMensagem1.Mostar(Mensagem.Tipo.Erro, "Inscrição inválida.<br>É obrigatório a separação com '-' do dígito de verificação.");
                    }
                }
            }
        }

        protected void montaListaCidades_Click(object sender, EventArgs e)
        {
            montaListaCidades_Click();
        }

        protected void montaListaCidades_Click()
        {
            ListItem cidade = TxtCidade.SelectedItem;
            new Uteis().listaCidades(TxtUF.Text, TxtCidade);
            TxtCidade.Focus();
            if (TxtCidade.Items.Contains(cidade))
            {
                TxtCidade.Text = cidade.Text;
            }

        }

        private void fechaCredito()
        {
           this.ModalFinanceiro.Hide();
           if (TXTLimite.Visible)
           {
               labLimite.Text = "Limite: R$ " + Limite;
               TXTLimite.Visible = false;
           }
        }
        private void abreCredito()
        {
            
            this.ModalFinanceiro.Show();
        }

        protected void r1_Click(object sender, EventArgs e)
        {
            fechaCredito();
        }

        protected void LBFinanceiro_Click(object sender, EventArgs e)
        {

            abreCredito();
        }

        protected void btSalvarLimite_Click(object sender, EventArgs e)
        {
            //Insirir os comandos de salvamento.
            fechaCredito();

        }

        protected void btEditarLimite_Click(object sender, EventArgs e)
        {

            if (!TXTLimite.Visible)
            {
                labLimite.Text = "Limite: ";
                TXTLimite.Visible = true;
                TXTLimite.Text = Limite;
            }
            this.ModalFinanceiro.Show();
        }

        protected void TxtUF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BTSalvar_Click(object sender, ImageClickEventArgs e)
        {
           // if (clienteSelecionado == null) {
           //     clienteSelecionado = new Cliente(new Conexao().getDb4());
           // }

            if (LabCod0.Text == "")
            {
                clienteSelecionado = new Cliente(new Conexao().getDb4());
            }
            else {
                clienteSelecionado = new Cliente(Convert.ToInt16(LabCod0.Text), new Conexao().getDb4());
            }

            clienteSelecionado.setBairro(TxtBairro.Text);
            clienteSelecionado.setCep(TxtCEP.Text);
            clienteSelecionado.setCidade(TxtCidade.Text);
            clienteSelecionado.setCPFCNPJ(txtCNPJ.Text);

            clienteSelecionado.setDataCadastro(Convert.ToDateTime(TxtCadastro.Text));
            clienteSelecionado.setDataNascimento(Convert.ToDateTime(TxtNascimento.Text));
            clienteSelecionado.setEmail(txtEmail.Text);
            clienteSelecionado.setEnd(txtEndereco.Text);
            clienteSelecionado.setEndPais(TxtEndPais.Text);
            clienteSelecionado.setIE(TxtInsc.Text);
            clienteSelecionado.setLimite((TXTLimite.Text== "")? 0 :Convert.ToDouble(TXTLimite.Text));
            clienteSelecionado.setMae(TxtMae.Text);
            clienteSelecionado.setNone(txtNome.Text);
            clienteSelecionado.setOperadora(CobOperadora.SelectedValue);
            clienteSelecionado.setPai(txtPai.Text);
            clienteSelecionado.setPessoaJuridica(getJuridica());
            clienteSelecionado.setReferecia(TxtReferencia.Text);
            clienteSelecionado.setTelefone(TxtTelefone.Text);
            clienteSelecionado.setUF(TxtUF.Text);
            Boolean erro =  clienteSelecionado.salvar();
            if (erro == false) {
                CaixaMensagem1.Mostar(Mensagem.Tipo.Erro, clienteSelecionado.toErro()); 
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Uteis util = new Uteis();
            //Metodo que deve buscar o cliente
            if (txtcampo.Text.Equals("") || txtcampo.Text == null)
            {
                labInf1.Text = "Não foi informado dados para busca ou adicição.";
                labInf1.Visible = true;
                txtcampo.Focus();
                //PanelBusca.Visible = false;
            }
            else
            {
                labInf1.Visible = false;

                if (util.Sonumeros(txtcampo.Text))
                {
                    if (txtcampo.Text.Length == 11 || (txtcampo.Text.Length == 14 && txtcampo.Text.Contains(".")))
                    {
                        if (util.validaCPF(txtcampo.Text))
                        {
                            exibiporCPFCNPJ();
                        }
                        else
                        {
                            labInf1.Text = "CPF inválido";
                            labInf1.Visible = true;
                            txtcampo.Focus();
                        }
                    }
                    else if (txtcampo.Text.Length == 18 || (txtcampo.Text.Length == 14 && !txtcampo.Text.Contains(".")))
                    {
                        if (util.validaCNPJ(txtcampo.Text))
                        {
                            exibiporCPFCNPJ();
                        }
                        else
                        {
                            labInf1.Text = "CNPJ inválido";
                            labInf1.Visible = true;
                            txtcampo.Focus();
                        }
                    }
                    else
                    {
                        labInf1.Text = "Dados inválidos.";
                        labInf1.Visible = true;
                        txtcampo.Focus();
                    }
                }
                else
                {
                    exibiporNome();
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           
            
            clienteSelecionado = todos.getCliente(Convert.ToInt16(ComboClientes.SelectedValue));

            if (clienteSelecionado.getCod() != 0)
            {
                preencheDados();
                PanelDados.Visible = true;
                PanelDados.Enabled = false;
                PanelBotoes.Visible = true;
                UpPanel_Busca.Visible = true;
                BtEditarCliente.Focus();
            }
            else {
                CaixaMensagem1.Mostar(Mensagem.Tipo.Aviso, "Nenhum cadastro localizado.");
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
           //tr_busca.Visible = false;
           UpPanel_Busca.Visible = false;
           txtcampo.Focus();
        }

        protected void BtEditarCliente_Click(object sender, EventArgs e)
        {
            PanelDados.Enabled = true;
            txtNome.Focus();
        }

        protected void BTExcluir_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void BtGravar_Click(object sender, EventArgs e)
        {
            // if (clienteSelecionado == null) {
            //     clienteSelecionado = new Cliente(new Conexao().getDb4());
            // }

            if (LabCod0.Text == "")
            {
                clienteSelecionado = new Cliente(new Conexao().getDb4());
            }
            else
            {
                clienteSelecionado = new Cliente(Convert.ToInt16(LabCod0.Text), new Conexao().getDb4());
            }

            clienteSelecionado.setBairro(TxtBairro.Text);
            clienteSelecionado.setCep(TxtCEP.Text);
            clienteSelecionado.setCidade(TxtCidade.Text);
            clienteSelecionado.setCPFCNPJ(txtCNPJ.Text);

            clienteSelecionado.setDataCadastro(Convert.ToDateTime(TxtCadastro.Text));
            clienteSelecionado.setDataNascimento(Convert.ToDateTime(TxtNascimento.Text));
            clienteSelecionado.setEmail(txtEmail.Text);
            clienteSelecionado.setEnd(txtEndereco.Text);
            clienteSelecionado.setEndPais(TxtEndPais.Text);
            try
            {
                clienteSelecionado.setIE(TxtInsc.Text);
            }
            catch (Exception erro)
            {

                CaixaMensagem1.Mostar(Mensagem.Tipo.Erro, erro.Message);
            }
            
            clienteSelecionado.setLimite((TXTLimite.Text == "") ? 0 : Convert.ToDouble(TXTLimite.Text));
            clienteSelecionado.setMae(TxtMae.Text);
            clienteSelecionado.setNone(txtNome.Text);
            clienteSelecionado.setOperadora(CobOperadora.SelectedValue);
            clienteSelecionado.setPai(txtPai.Text);
            clienteSelecionado.setPessoaJuridica(getJuridica());
            clienteSelecionado.setReferecia(TxtReferencia.Text);
            clienteSelecionado.setTelefone(TxtTelefone.Text);
            clienteSelecionado.setUF(TxtUF.Text);

            try
            {
                clienteSelecionado.salvar();
            }
            catch (Exception erro)
            {

                CaixaMensagem1.Mostar(Mensagem.Tipo.Erro, erro.Message);
            }
        }

        protected void BtVoltar_Click(object sender, EventArgs e)
        {
            PanelDados.Visible = false;
            PanelBotoes.Visible = false;
            //UpPanel_Busca.Enabled = true;
            ComboClientes.Focus();
        }

        protected void TxtCidade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}