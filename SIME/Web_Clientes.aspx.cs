using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sime;
using SIME.Class;
namespace SIME
{
    public partial class Clientes : System.Web.UI.Page
    {
        private Cliente clienteSelecionado;
        private Class.Clientes todos;
        private SIME.Class.Usuario userAtual;
        private Boolean podeesxcluir = false;
        private Int16 cod_Cliente = 0;
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");
        protected void Page_Load(object sender, EventArgs e)
        {
            todos = new Class.Clientes();
            userAtual = this.Master.getUsarioAtual();

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

            TxtUF.Attributes.Add("onblur", this.Page.ClientScript.GetPostBackEventReference(this.montaListaCidades, ""));
        }


        private void preencheComboOperadoras()
        {
            CobOperadora.Items.Add("CLARO");
            CobOperadora.Items.Add("TIM");
            CobOperadora.Items.Add("OI");
            CobOperadora.Items.Add("VIVO");
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
        protected void btBuscar_Click(object sender, EventArgs e)
        {
            //Tratamento
            if (TxtBusca.Text.Equals("") || TxtBusca.Text == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('Informe um mome, CPF ou CNPJ no campo de busca.');", true);
                return;
            }

            Uteis util = new Uteis();
            bool retorno = false;
            UpPanel_busca.Visible = true;

            if (util.Sonumeros(TxtBusca.Text)) // Verifica se foi informado somente números para buscar por cpf ou cnpj
            {
                // Avaliação por CPF e tratamento
                if (TxtBusca.Text.Length == 11 || (TxtBusca.Text.Length == 14 && TxtBusca.Text.Contains(".")))
                {
                    if (util.validaCPF(TxtBusca.Text))
                    {
                        retorno = todos.preencheCombo(TxtBusca.Text, ref ComboClientes);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('CPF incorreto.');", true);
                        TxtBusca.Focus();
                        return;
                    }
                }
                //Avaliação por CNPJ e tratamento
                else if (TxtBusca.Text.Length == 18 || (TxtBusca.Text.Length == 14 && !TxtBusca.Text.Contains(".")))
                {
                    if (util.validaCNPJ(TxtBusca.Text))
                    {
                        retorno = todos.preencheCombo(TxtBusca.Text, ref ComboClientes);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('CNPJ incorreto.');", true);
                        TxtBusca.Focus();
                        return;
                    }
                }
                //Caso em que nada é válido - tratamento
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('Dados inválidos.');", true);
                    TxtBusca.Focus();
                }


            }
            //Casos de busca por nome.
            else
            {
                retorno = todos.preencheCombo(TxtBusca.Text, ref ComboClientes, true);
            }

            //Resutado das buscas
            if (retorno)
            {
                UpPanel_resultado.Visible = true;
                ComboClientes.Focus();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('CPF ou CNPJ não localizado, sistema abrirá o cadastro para inclusão deste novo cliente.');", true);
                clienteSelecionado = new Cliente(new Conexao().getDb4());
                UpPanel_resultado.Visible = false;
            }
        }
        /// <summary>
        /// Processo de busca de dados de cliente pelo CPF ou CNPJ 
        /// Processo deve montar um combo com a lista de clientes encontrados 
        /// Isso só é possível porque os dados já existiam no banco de dados e por isso pode ocorrer a duplicdade de CPF ou CNPJ
        /// Mas as inclusões não são mais possíveis.
        /// </summary>
        private void exibiporCPFCNPJ()
        {
            List<String[]> dados = todos.filtraCPFCNPJ(TxtBusca.Text);
            if (dados.Count >= 1)
            {
                ComboClientes.Items.Clear();
                foreach (String[] item in dados)
                {
                    ComboClientes.Items.Add(new ListItem() { Value = Convert.ToString(item[0]), Text = item[1].ToUpper() });
                }
                UpPanel_resultado.Visible = true;
                ComboClientes.Focus();
            }
            else
            {
                //Cliente não cadastrado direcionando para um novo cliente.
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('CPF ou CNPJ não localizado, sistema abrirá o cadastro para inclusão deste novo cliente.');", true);
                clienteSelecionado = new Cliente(new Conexao().getDb4());
                UpPanel_resultado.Visible = false;
            }
        }
        /// <summary>
        /// Processo semelhante ao de busca pelo CPF ou CNPJ, só que desta vez a busca é por nome ou parte dele.
        /// O resultado deve ser mostrado em um combo;
        /// </summary>

        private void exibiporNome()
        {
            List<String[]> dados = todos.filtraNome(TxtBusca.Text, true);
            if (dados.Count >= 1)
            {
                ComboClientes.Items.Clear();
                foreach (String[] item in dados)
                {
                    ComboClientes.Items.Add(new ListItem() { Value = Convert.ToString(item[0]), Text = item[1].ToUpper() });
                }
                UpPanel_resultado.Visible = true;
                //UpPanel_dados.Visible = false;
                ComboClientes.Focus();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('Nome não localzado, para que seja incluido um novo cliente digite o seu CPF ou CNPJ no campo de busca.');", true);
                UpPanel_resultado.Visible = false;
                //UpPanel_dados.Visible = false;
            }
        }

        protected void Bt_editar_Click(object sender, EventArgs e)
        {
            // exibe o painel de informações.
            UpPanel_informacoes.Visible = true;
            //seleciona o cliente baseado no combofix.
            try
            {
                cod_Cliente = Convert.ToInt16(ComboClientes.SelectedItem.Value);
                clienteSelecionado = new Cliente(cod_Cliente, new Conexao().getDb4());
                preencheDados();
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('Deve-se selecionar um nome antes de clicar em editar.');", true); ;
            }


        }

        protected void Bt_Retorna_busca_Click(object sender, EventArgs e)
        {
            UpPanel_informacoes.Visible = false;
            UpPanel_resultado.Visible = false;
        }

        private void preencheDados()
        {

            lbDados.Text = Convert.ToString(cod_Cliente);
            TxtNome.Text = clienteSelecionado.getNome();
            TxtEnd.Text = clienteSelecionado.getEnd();
            chkFiel.Checked = clienteSelecionado.Fidelidade;


            String doc = clienteSelecionado.getCPFCNPJ();
            Uteis ferramenta = new Uteis();
            doc = doc.Replace(".", "");
            doc = doc.Replace("-", "");
            doc = doc.Replace("/", "");
            maskCPF.Mask = (clienteSelecionado.getPessoaJuridica()) ? "99.999.999/9999-99" : "999.999.999-99";
            maskTele.Mask = "(99)9999-9999";

            txtCPF.Text = doc;

            txtIE.Text = clienteSelecionado.getIE();
            TxtBairro.Text = clienteSelecionado.getBairro();

            txtCEP.Text = clienteSelecionado.getCEP();

            //Tratamento para não encontrar UF na lista
            String UF = clienteSelecionado.getUF().ToUpper().Trim();
            if (TxtUF.Items.Contains(new ListItem() { Text = UF }))
            {
                TxtUF.Text = clienteSelecionado.getUF().ToUpper().Trim();
                new Uteis().listaCidades(TxtUF.Text, TxtCidade);
                if (TxtCidade.Items.Contains(new ListItem() { Value = clienteSelecionado.getCidade().ToUpper().Trim(), Text = clienteSelecionado.getCidade().ToUpper().Trim() }))
                {
                    TxtCidade.Text = clienteSelecionado.getCidade().ToUpper().Trim();
                }

            }
            else
            {
                TxtUF.Text = "";
                TxtCidade.Text = "";
            }

            txtNasc.Text = Convert.ToString(clienteSelecionado.getDataNascimento(), culture).Replace("00:00:00", "").Replace("/", "");
            chkTipo.Checked = clienteSelecionado.getPessoaJuridica();
            txtPonto.Text = clienteSelecionado.getReferencia();
            string telefone = clienteSelecionado.getTelefone().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            //tratamento para os telefones que foram cadastrados com 0 no DDD.
            Uteis util = new Uteis();

            if (util.esquerda(telefone, 0).Equals("0"))
            {
                telefone = util.direita(telefone, 9);
            }
            txtTel.Text = telefone;
            String opCliente = clienteSelecionado.getOperadora().ToUpper();
            if (opCliente == "OI" || opCliente == "TIM" || opCliente == "CLARO" || opCliente == "VIVO")
            {
                CobOperadora.Text = clienteSelecionado.getOperadora().ToUpper();
            }
            txtEmail.Text = clienteSelecionado.getEmail();
            txtPai.Text = clienteSelecionado.getPai();
            txtMae.Text = clienteSelecionado.getMae();
            

        }
        /// <summary>
        /// Processo de busca de dados de cep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtCep_Click(object sender, ImageClickEventArgs e)
        {
            //Tratamento para envitar error de digitação de CEP.
            if (txtCEP.Text.ToString().Equals("") || txtCEP.Text.ToString().Length != 8)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('Cep não informado ou incorreto.');", true);
                txtCEP.Focus();
                return;
            }


            try
            {

                DadosCEP cep = new DadosCEP(txtCEP.Text.ToString());
                if (cep.getCep() == null)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('CEP inválido!');", true);
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('CEP inválido!');", true);
                    return;
                }
                TxtUF.SelectedValue = cep.getUf().ToUpper();
                TxtCidade.SelectedValue = cep.getCidade().ToUpper();
                if (!cep.getTipoLogradouro().Equals(""))
                {
                    TxtEnd.Text = cep.getTipoLogradouro() + " " + cep.getEndereco();
                    TxtBairro.Text = cep.getBairro();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Aviso!", "alert('Cep não contém registro de rua ou bairro.');", true); ;
                }

            }
            catch (Exception erro)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Aviso!", "alert('" + erro.Message + "');", true); ;
            }
        }

        protected void txtGravar_Click(object sender, EventArgs e)
        {
            //Processo de gravação dos dados. 
            //Nescessário algumas avalaiações antes de começar.
            if (!txtEmail.Text.Equals(""))
            {
                if (!txtEmail.Text.Contains('@'))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('E-mail cadastrado inválido.');", true);
                    txtEmail.Focus();
                    return;
                }
            }

            //Verificação de telefone
            if (txtTel.Text.Equals("(__)_____-____"))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('Telefone não ifnormado.');", true);
                txtTel.Focus();
                return;
            }

            if (txtTel.Text.Contains('_'))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('Número de telefone incompleto.');", true);
                txtTel.Focus();
                return;
            }

            if (txtIE.Text.Equals(""))
            {
                txtIE.Text = "Isento";
            }

            if (TxtBairro.Text.Equals(""))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('Bairro não informado.');", true);
                TxtBairro.Focus();
                return;
            }

            if (TxtEnd.Text.Equals(""))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('Endereço não informado.');", true);
                TxtEnd.Focus();
                return;
            }

            if (!(new Uteis().validaCPF(txtCPF.Text))) //não é um CPF válido
            {
                if (!(new Uteis().validaCNPJ(txtCPF.Text)))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('CPF ou CNPJ inválido.');", true);
                    txtCPF.Focus();
                    return;
                }
            }

            if (TxtNome.Text.Length > 35 || TxtNome.Text.Length < 5)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Aviso!", "alert('O Campo nome não pode conter menos de 5 letras ou mais de 35.'); ", true);
                TxtNome.Focus();
                return;
            }
            if (txtNasc.Text.Equals("__/__/____"))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('O campo data de nascimento é obrigatório!'); ", true);
                txtNasc.Focus();
                return;
            }
            DateTime data1 = Convert.ToDateTime(txtNasc.Text);
            DateTime date2 = DateTime.Now;
            TimeSpan ts = date2.Subtract(data1);

            if ((ts.Days / 365) > 130 || (ts.Days / 365) < 6)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('Data de nasciemnto informada inválida.); ", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('Data de nascimento informada inválida.');", true);
                txtNasc.Focus();
                return;
            }

            //Processo de gravação.
            cod_Cliente = Convert.ToInt16(lbDados.Text);
            if (cod_Cliente == 0)
            {
                clienteSelecionado = new Cliente(new Conexao().getDb4());
            }
            else
            {
                clienteSelecionado = new Cliente(cod_Cliente, new Conexao().getDb4());
            }

            clienteSelecionado.setBairro(TxtBairro.Text);
            clienteSelecionado.setCep(txtCEP.Text);
            clienteSelecionado.setCidade(TxtCidade.SelectedValue.ToString());
            clienteSelecionado.setCPFCNPJ(txtCPF.Text);
            if (clienteSelecionado.getDataCadastro() == null)
            {
                clienteSelecionado.setDataCadastro(DateTime.Now);
            }

            clienteSelecionado.setDataNascimento(Convert.ToDateTime(txtNasc.Text));
            try
            {
                clienteSelecionado.setEmail(txtEmail.Text);
            }
            catch (Exception erro)
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Concluido!", "alert('" + erro.Message + "'); ", true);
            }

            clienteSelecionado.setEnd(TxtEnd.Text);
            try
            {
                clienteSelecionado.setIE(txtIE.Text);
            }
            catch (Exception erro)
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Concluido!", "alert('" + erro.Message + "'); ", true);
            }
            clienteSelecionado.setPessoaJuridica(chkTipo.Checked);
            clienteSelecionado.setMae(txtMae.Text);
            clienteSelecionado.setMala(true);
            clienteSelecionado.setNone(TxtNome.Text);
            clienteSelecionado.setOperadora(CobOperadora.SelectedValue.ToString());
            clienteSelecionado.setPai(txtPai.Text);
            clienteSelecionado.setPessoaJuridica(new Uteis().validaCNPJ(txtCPF.Text));
            clienteSelecionado.setReferecia(txtPonto.Text);
            clienteSelecionado.setTelefone(txtTel.Text);
            clienteSelecionado.setUF(TxtUF.SelectedValue.ToString());
            clienteSelecionado.Dt_inicializacao = (clienteSelecionado.Fidelidade == false) ? DateTime.Now : clienteSelecionado.Dt_inicializacao;
            clienteSelecionado.Fidelidade = chkFiel.Checked;
            try
            {
                clienteSelecionado.salvar();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Concluido!", "alert('Cadastro concluido com sucesso!'); ", true);
            }
            catch (Exception erro)
            {

                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('" + erro.Message + "'); ", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Erro!", "alert('" + erro.Message + "');", true);

            }


        }

        protected void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            String texto = txtCPF.Text;
            if (chkTipo.Checked){
                 
                maskCPF.Mask = "99.999.999/9999-99";
            }else{
                maskCPF.Mask = "999.999.999-99";
            }
            txtCPF.Text = texto;
            
        }
    }





}