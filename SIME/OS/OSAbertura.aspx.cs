using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIME.Class;
using Apresentacao.Controles;

namespace SIME
{
    public partial class OSAbertura : System.Web.UI.Page
    {
        private Class.Clientes todos;
        private Usuario userAtual;
        private String nomeSelecionado;
        private Int16 codSelecionado;
        //private Cliente clienteSelecionado;
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");
        //private Boolean inicializado;
        private Uteis util = new Uteis();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (todos == null)
            {
                todos = new Class.Clientes();
            }
            userAtual = this.Master.getUsarioAtual();

            if (userAtual == null)
            {
                Response.Redirect("~/logar.aspx");
            }



            //Preenchimento para caso de retorno
            if (Master.getClienteSelecionado() != null)
            {
                if (txtDoc.Text.Equals(Master.getClienteSelecionado().getCPFCNPJ()) || txtDoc.Text.Equals(""))
                {
                    if (codSelecionado == 0)
                    {
                        codSelecionado = Convert.ToInt16(this.Master.getClienteSelecionado().getCod());
                    }
                    txtDoc.Text = this.Master.getClienteSelecionado().getCPFCNPJ();

                    montaComb(codSelecionado);
                    ComboClientes.Items.FindByValue(Convert.ToString(codSelecionado).Trim());
                    preencheCliente(codSelecionado);
                }

                if (CobOperadora.Items.Count == 0)
                {
                    preencheComboOperadoras();
                }

            }

            CobUF.Attributes.Add("onblur", this.Page.ClientScript.GetPostBackEventReference(this.montaListadeCidades, ""));

            //Preenchimento de operadoras
            if (CobOperadora.Items.Count == 0)
            {
                CobOperadora.Items.Add("CLARO");
                CobOperadora.Items.Add("TIM");
                CobOperadora.Items.Add("OI");
                CobOperadora.Items.Add("VIVO");

            }

        }



        private void mudaMascaraTelefone()
        {
            if (CobUF.SelectedValue == "SP")
            {
                TXTTelefone_MaskedEditExtender.Mask = "(99) 99999-9999";
            }
            else
            {
                TXTTelefone_MaskedEditExtender.Mask = "(99) 9999-9999";
            }
        }

        protected void bt_buscar_Click(object sender, EventArgs e)
        {
            limpaDados();

            //Verifica se o documento é válido

            if (txtDoc.Text == null || valida_doc(txtDoc.Text) == false)
            {
                CaixaMensagem1.Mostar(Mensagem.Tipo.Erro, "Documento inválido!");
                txtDoc.Focus();
                Panel_dados.Visible = false;
            }
            else
            {
                montaComb(txtDoc.Text);
                //Cliente não localizado
                if (todos.count() == 0)
                {
                    //CaixaMensagem1.Mostar(Mensagem.Tipo.Erro, "Cliente não cadastrado");
                    Panel_dados.Visible = false;
                    limpaDados();
                    plnPopUp_Cliente.Show();
                    TXTCPF.Text = txtDoc.Text;
                    ComboClientes.Visible = false;
                }
                else if (todos.count() == 1)
                {
                    ComboClientes.SelectedIndex = 0;
                    preencheCliente(Convert.ToInt16(ComboClientes.SelectedValue));
                }

            }

        }

        private Boolean valida_doc(string doc)
        {

            if ((doc.Length == 14 && !doc.Contains('-')) || doc.Length == 18)
            {
                return util.validaCNPJ(doc);
            }

            if (doc.Length == 14 || doc.Length == 11)
            {
                return util.validaCPF(doc);
            }
            return false;
        }

        private void montaComb(string doc)
        {
            todos = new Class.Clientes();
            List<String[]> dados = todos.filtraCPFCNPJ(doc);
            if (dados.Count >= 1)
            {
                ComboClientes.Items.Clear();
                foreach (String[] item in dados)
                {
                    ComboClientes.Items.Add(new ListItem() { Value = Convert.ToString(item[0]), Text = item[1].ToUpper() });
                }
                ComboClientes.Focus();
            }
        }

        private void montaComb(int ID)
        {
            todos = new Class.Clientes();
            List<String[]> dados = todos.filtraID(ID);
            if (dados.Count >= 1)
            {
                ComboClientes.Items.Clear();
                foreach (String[] item in dados)
                {
                    ComboClientes.Items.Add(new ListItem() { Value = Convert.ToString(item[0]), Text = item[1].ToUpper() });
                }
                ComboClientes.Focus();
            }
        }

        protected void bt_confirma_Click(object sender, EventArgs e)
        {
            preencheCliente(Convert.ToInt16(ComboClientes.SelectedValue));
        }

        private void preencheCliente(Int16 codCliente)
        {
            //Processo que exibe os dados do cliente.
            //clienteSelecionado = todos.getCliente(codCliente);
            Master.setClienteSelecionado(todos.getCliente(codCliente));
            if (Master.getClienteSelecionado() != null)
            {
                LabDados.Text = "<font size=4 color='Red'><u>Confira os dados abaixo:</u></font> <br>" +
                    "<font size=4>" + Master.getClienteSelecionado().ToString() + "</font>" +
                    "<br /> ";
                btProximo.Visible = true;
                btAltera.Visible = true;
                Panel_dados.Visible = true;
            }
        }

        protected void btAltera_Click(object sender, EventArgs e)
        {

        }

        protected void btproximo_Click(object sender, EventArgs e)
        {

        }

        private void limpaDados()
        {
            this.Master.setClienteSelecionado(null); // Limpa os dados de cliente da pagina master
            ComboClientes.Items.Clear();
            btProximo.Visible = false;
            btAltera.Visible = false;
            Panel_dados.Visible = true;
            LabDados.Text = "";

        }

        protected void btProximo_Click1(object sender, EventArgs e)
        {
            
            Master.setClienteSelecionado(todos.getCliente(Convert.ToInt16(ComboClientes.SelectedValue)));
            Response.Redirect("~/OS/OSabertura2.aspx");
        }

        protected void btAltera_Click1(object sender, EventArgs e)
        {

            plnPopUp_Cliente.Show();
            //Preenchendo dados de cliente
            Cliente ClienteSelecionado = Master.getClienteSelecionado();
            txtNome.Text = ClienteSelecionado.getNome();
            TXTEndereco.Text = ClienteSelecionado.getEnd();
            TXTCep.Text = ClienteSelecionado.getCEP();
            TXTCPF.Text = ClienteSelecionado.getCPFCNPJ();
            TXTBairro.Text = ClienteSelecionado.getBairro();
            if (!(ClienteSelecionado.getUF() == null || ClienteSelecionado.getUF() == ""))
            {
                CobUF.SelectedValue = ClienteSelecionado.getUF().ToUpper();
                montaLista();
            }

            if (!(ClienteSelecionado.getCidade() == null || ClienteSelecionado.getCidade() == ""))
            {
                try
                {
                    CobCidade.SelectedValue = ClienteSelecionado.getCidade().ToUpper();
                }
                catch (Exception)
                {
                    //Cidade não selecionada
                }
                
            }
            TXTDOC1.Text = ClienteSelecionado.getIE();
            TXTCPF.Text = ClienteSelecionado.getCPFCNPJ();
            TXTDtNascimento.Text = ClienteSelecionado.getDataNascimento().ToShortDateString();
            TXTTelefone.Text = ClienteSelecionado.getTelefone();
            TXTEmail.Text = ClienteSelecionado.getEmail();
            TXTreferencia.Text = ClienteSelecionado.getReferencia();


        }

        private void limapaDados()
        {
            txtNome.Text = "";
            TXTEndereco.Text = "";
            TXTCep.Text = "";
            TXTCPF.Text = "";
            TXTBairro.Text = "";
            TXTDOC1.Text = "";
            TXTCPF.Text = "";
            TXTDtNascimento.Text = "";
            TXTTelefone.Text = "";
            TXTEmail.Text = "";
            TXTreferencia.Text = "";

        }

        protected void cmdFechar_Click(object sender, EventArgs e)
        {
            plnPopUp_Cliente.Hide();
        }

        protected void btGravar_Click(object sender, EventArgs e)
        {
            cmdFechar_Click(sender, e);
        }

        protected void montaListadeCidades_Click(object sender, EventArgs e)
        {

            montaLista();

        }

        private void montaLista()
        {
            ListItem cidade = CobCidade.SelectedItem;
            new Uteis().listaCidades(CobUF.Text, CobCidade);
            CobCidade.Focus();
            if (CobCidade.Items.Contains(cidade))
            {
                CobCidade.Text = cidade.Text;
            }

        }


        private void preencheComboOperadoras()
        {
            CobOperadora.Items.Add("CLARO");
            CobOperadora.Items.Add("TIM");
            CobOperadora.Items.Add("OI");
            CobOperadora.Items.Add("VIVO");
        }

        protected void BtGravar_Click1(object sender, EventArgs e)
        {
            //Verifica nome
            if (txtNome.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('Campo nome tem preenchimento obrigatório.');", true);
                plnPopUp_Cliente.Show();
                txtNome.Focus();
                return;
            }

            if (txtNome.Text.Length > 35)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('Campo nome não pode ter mais que 35 caractéres.');", true);
                plnPopUp_Cliente.Show();
                txtNome.Focus();
                return;
            }

            //Verificação endereço.
            if (TXTEndereco.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('Campo endereço tem seu preenchiemnto obrigatório.');", true);
                plnPopUp_Cliente.Show();
                TXTEndereco.Focus();
                return;

            }

            if (TXTEndereco.Text.Length > 40)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('Campo endereço não pode ter mais que 40 caracteres.');", true);
                plnPopUp_Cliente.Show();
                TXTEndereco.Focus();
                return;
            }

            //Verificação CPF

            if (TXTCPF.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('Campo CPF/CNPJ tem preenchimento obrigatório.');", true);
                plnPopUp_Cliente.Show();
                TXTCPF.Focus();
                return;

            }

            if (TXTCPF.Text.Length == 14)
            {
                if (!(new Uteis().validaCPF(TXTCPF.Text)))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('CPF inválido!');", true);
                    plnPopUp_Cliente.Show();
                    TXTCPF.Focus();
                    return;
                }
            }
            else if (TXTCPF.Text.Length == 18)
            {
                if (!(new Uteis().validaCNPJ(TXTCPF.Text)))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('CNPJ inválido!');", true);
                    plnPopUp_Cliente.Show();
                    TXTCPF.Focus();
                    return;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('CPF ou CNPJ inválido ou preenchido incorretamente.');", true);
                plnPopUp_Cliente.Show();
                TXTCPF.Focus();
                return;
            }
            
            //Verifica  ponto de referencia 

            if (TXTreferencia.Text == "" || TXTreferencia.Text.Length <= 10)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('Campo ponto de referência não foi preenchido ou contém uma quantidade de informações muito baixa.');", true);
                plnPopUp_Cliente.Show();
                TXTreferencia.Focus();
                return;

            }

            //Verifica Bairro

            if (TXTBairro.Text.Length > 35)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('Campo bairro não pode ter mais que 35 caracteres.');", true);
                plnPopUp_Cliente.Show();
                TXTBairro.Focus();
                return;

            }



            Cliente clienteNovo;
            try
            {
                if (codSelecionado == 0)
                {
                    clienteNovo = new Cliente(new Conexao().getDb4());
                    clienteNovo.setDataCadastro(new DateTime().Date);
                    //dados dos pais não preenchidos no cadastro rápido
                    clienteNovo.setPai(" ");
                    clienteNovo.setMae(" ");
                    clienteNovo.setEndPais(" ");
                    clienteNovo.setLimite(0);

                }
                else
                {
                    clienteNovo = new Cliente(codSelecionado, new Conexao().getDb4());
                }
                clienteNovo.setNone(txtNome.Text);
                clienteNovo.setEnd(TXTEndereco.Text);
                clienteNovo.setBairro(TXTBairro.Text);
                clienteNovo.setUF(CobUF.SelectedValue);
                clienteNovo.setCidade(CobCidade.SelectedValue);
                clienteNovo.setCPFCNPJ(TXTCPF.Text);
                
                if (TXTDtNascimento.Text != "")
                {
                    clienteNovo.setDataNascimento(Convert.ToDateTime(TXTDtNascimento.Text));
                }
                
                clienteNovo.setReferecia(TXTreferencia.Text);
                clienteNovo.setTelefone(TXTTelefone.Text);
                clienteNovo.setOperadora(CobOperadora.SelectedValue);
                if (TXTBairro.Text == "")
                {
                    clienteNovo.setBairro(" ");
                }

                if (TXTEmail.Text == "")
                {
                    clienteNovo.setEmail(" ");
                }
                else 
                {
                    clienteNovo.setEmail(TXTEmail.Text);
                }


                if (TXTCep.Text != "")
                {
                    clienteNovo.setCep(TXTCep.Text);
                }

                clienteNovo.setMala(true);
                //Verificando se é um CPF
                Uteis util = new Uteis();
                if (util.validaCNPJ(TXTCPF.Text))
                {
                    clienteNovo.setPessoaJuridica(true);
                }
                else {
                    if (util.validaCPF(TXTCPF.Text))
                    {
                        clienteNovo.setPessoaJuridica(false);
                    }
                    else {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('CPF ou CNPJ inválido!');", true);
                        return;
                    }
                }

                if (TXTDOC1.Text != "")
                {
                    clienteNovo.setIE(TXTDOC1.Text);
                }
                else
                {
                    clienteNovo.setIE("Isento");
                }

                clienteNovo.setRestrito(false);
                clienteNovo.salvar();
                Master.setClienteSelecionado(clienteNovo);
                txtDoc.Text = TXTCPF.Text;
                bt_buscar_Click(sender, e);


            }
            catch (Exception erro)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('" + erro.Message + "');", true);
                plnPopUp_Cliente.Show();
            }

        }

        protected void BTBuscaCep0_Click(object sender, ImageClickEventArgs e)
        {
            if (TXTCep.Text == "" || TXTCep.Text == null)
            {
                //CaixaMensagem1.Mostar(Mensagem.Tipo.Aviso, "Não foi informado um cep válido.");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('Não foi informado um cep válido.');", true);
                return;
            }
            try
            {
                DadosCEP cep = new DadosCEP(TXTCep.Text);

                TXTEndereco.Text = cep.getEndereco();
                TXTBairro.Text = cep.getBairro();
                CobUF.SelectedValue = cep.getUf().ToUpper();
                montaLista();
                CobCidade.SelectedValue = cep.getCidade().ToUpper();
            }
            catch (Exception)
            {

                //CaixaMensagem1.Mostar(Mensagem.Tipo.Erro, "CEP retorou uma cidade não cadatrada.");
                //CaixaMensagem1.Focus();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Erro!", "alert('CEP não localizado');", true);
            }
            

        }



    }
}