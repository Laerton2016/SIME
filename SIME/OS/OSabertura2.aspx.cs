using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIME
{
    public partial class OSaberturap2 : System.Web.UI.Page
    {
        private Class.Cliente clienteSelecionado;
        private TiposAparelhos tipoAparelhos = new TiposAparelhos();
        private Class.Seguradora seguradoras = new Class.Seguradora();
        private Class.Marcas marcas = new Class.Marcas();
        private Class.Atendimento atendiemnto = new Class.Atendimento();
        private Class.lojas lojas = new Class.lojas();
        private tipoEstoque estoque = new tipoEstoque();
        private Class.Aparelho aparelho = new Class.Aparelho();
        private Aparelhos aparelhos = new Aparelhos();
        protected void Page_Load(object sender, EventArgs e)
        {

            //CheckBox1.CheckedChanged += new System.EventHandler(CheckBox1_CheckedChanged);

            if (clienteSelecionado == null)
            {
                clienteSelecionado = Master.getClienteSelecionado();
            }
            if (clienteSelecionado != null)
            {
                labDadosCliente.Text = "<b>Nome: </b>" + clienteSelecionado.getNome() + " <b> Documento: </b>" + clienteSelecionado.getCPFCNPJ();


            }
            //Informações para os combos
            if (!IsPostBack)
            {
                montaCombVoltagem();
            }

            if (CombTipo.Items.Count == 0)
            {
                montaCombs(CombTipo, tipoAparelhos.getListaTiposAparelho());
            }

            if (CombMarca.Items.Count == 0)
            {
                montaCombs(CombMarca, marcas.getListaTiposMarcas());
            }

            if (CombAtendimento.Items.Count == 0)
            {
                montaCombs(CombAtendimento, atendiemnto.getListaAtendimento());
                CombAtendimento.Items.FindByValue("1");
            }
            if (combLojas.Items.Count == 0)
            {
                montaCombs(combLojas, lojas.getListaLojas());
            }

            if (combEstoque.Items.Count == 0)
            {
                montaCombs(combEstoque, estoque.getListaEstoque());
                combEstoque.Items.FindByValue("1"); // Como padrão deve ser balcão
                if (Master.getClienteSelecionado() != null)
                {
                    if (Master.getClienteSelecionado().getPessoaJuridica() == false)
                    {
                        combEstoque.Enabled = false;
                    }
                    else
                    {
                        combEstoque.Enabled = true;
                    }
                }
            }
            //Preenchendo os dados de aparelho caso seja uma OS já aberta.

            if (Master.getAparelhoAtual() != null)
            {
                aparelho = Master.getAparelhoAtual();
                if (txtDefeito.Text.Equals(""))
                {
                    preencherdados();
                }
            }
        }

        private void preencherdados()
        {
            CheckBox1.Checked = aparelho.Garantia;
            if (aparelho.Garantia) {
                CheckBox1_CheckedChanged(new Object(), new EventArgs());
                txtNSerie.Enabled = true;
                txtNF.Enabled = true;
                combSeguradora.Enabled = true ;
                txtDataNF.Enabled = true;
                combLojas.Enabled = true;
            }else{
                txtNSerie.Enabled = false;
                txtNF.Enabled = false;
                combSeguradora.Enabled = false ;
                txtDataNF.Enabled = false;
                combLojas.Enabled = false;
            }
            combSeguradora.SelectedValue = Convert.ToString (aparelho.ID_Seguradora);
            CombTipo.SelectedValue = (Convert.ToString(aparelho.IDTipoAparelho));
            CombMarca.SelectedValue =Convert.ToString(aparelho.IDMarca);
            txtModelo.Text = aparelho.Modelo;
            CombVoltagem.SelectedValue=(aparelho.Voltagem);
            CombAtendimento.SelectedValue=(Convert.ToString(aparelho.IDatendimento));
            txtNSerie.Text = aparelho.Serie;
            if (aparelho.Serie !=null){
                
            }

            Chk_retorno.Checked = aparelho.Retorno;
            if (aparelho.Retorno)
            {
                CombRetorno.Enabled = true;
                CombRetorno.SelectedValue=(Convert.ToString(aparelho.IDOSRetorno));
            }

            txtNF.Text = aparelho.Nf;
            txtDataNF.Text = aparelho.DataNF.ToShortDateString();
            combLojas.SelectedValue=(Convert.ToString(aparelho.IDloja));
            combEstoque.SelectedValue=(Convert.ToString(aparelho.IDEstoque));
            String[] acessorios = aparelho.getAcessorios();
            for (int i = 0; i < acessorios.Length; i++)
            {
                if (acessorios[i].Equals("2"))
                {
                    CheckBox2.Checked = true;
                }
                else if (acessorios[i].Equals("3"))
                {
                    CheckBox3.Checked = true;

                }
                else if (acessorios[i].Equals("4"))
                {
                    CheckBox4.Checked = true;
                }
                else if (acessorios[i].Equals("5"))
                {
                    CheckBox5.Checked = true;
                }
                else if (acessorios[i].Equals("6"))
                {
                    CheckBox6.Checked = true;
                }
                else if (acessorios[i].Equals("7"))
                {
                    CheckBox7.Checked = true;
                }
                else if (acessorios[i].Equals("8"))
                {
                    CheckBox8.Checked = true;
                }
                else if (acessorios[i].Equals("9"))
                {
                    CheckBox9.Checked = true;
                }
                else if (acessorios[i].Equals("10"))
                {
                    CheckBox10.Checked = true;
                }
                else if (acessorios[i].Equals("11"))
                {
                    CheckBox11.Checked = true;
                }
                else if (acessorios[i].Equals("12"))
                {
                    CheckBox12.Checked = true;
                }
                else if (acessorios[i].Equals("13"))
                {
                    CheckBox13.Checked = true;
                }
                else if (acessorios[i].Equals("14"))
                {
                    ChkOutros.Checked = true;
                    txtAcessorio.Enabled = true;
                    txtAcessorio.Text = Convert.ToString(acessorios[i + 1]);
                    break;
                }
            }

            txtAvaria.Text = aparelho.Avarias;
            txtDefeito.Text = aparelho.Defeito;



        }
        private void montaCombVoltagem()
        {
                CombVoltagem.Items.Clear();
                CombVoltagem.Items.Add(new ListItem("Bivolt", "automatico"));
                CombVoltagem.Items.Add(new ListItem("220V", "220"));
                CombVoltagem.Items.Add(new ListItem("110V", "110"));
                CombVoltagem.Items.FindByText("Bivolt");
        }
        private void montaCombs(DropDownList combo, List<String[]> lista)
        {
            if (lista.Count >= 1)
            {
                combo.Items.Clear();
                foreach (String[] item in lista)
                {
                    combo.Items.Add(new ListItem() { Value = Convert.ToString(item[0]), Text = item[1].ToUpper() });
                }

            }
        }

        protected void Bt_retornar_Click(object sender, EventArgs e)
        {
            Master.setClienteSelecionado(clienteSelecionado);
            Response.Redirect("~/OS/OSabertura.aspx");
        }




        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                combSeguradora.Enabled = true;
                montaCombs(combSeguradora, seguradoras.getListaSeguradoras());
                combSeguradora.Items.FindByValue("0");
                txtNF.Enabled = true;
                combLojas.Enabled = true;
                txtDataNF.Enabled = true;
                Bt_IncluirLoja.Enabled = true;
                combSeguradora.Focus();
            }
            else
            {
                combSeguradora.Items.Clear();
                combSeguradora.Enabled = false;
                txtNF.Enabled = false;
                combLojas.Enabled = false;
                txtDataNF.Enabled = false;
                Bt_IncluirLoja.Enabled = false;
                CombTipo.Focus();
            }

        }

        protected void ChkRetorno_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_retorno.Checked)
            {
                CombRetorno.Enabled = true;
                List<String[]> lista = aparelhos.get_listaAparelhosRretorno(Master.getClienteSelecionado().getCod(), Convert.ToString(CombTipo.SelectedItem), Convert.ToString(CombMarca.SelectedItem), txtModelo.Text);

                if (lista.Count >= 1)
                {
                    CombRetorno.Items.Clear();
                    foreach (String[] item in lista)
                    {
                        CombRetorno.Items.Add(new ListItem() { Value = Convert.ToString(item[0]), Text = item[0] + " Data: " + Convert.ToDateTime(item[4]).ToShortDateString() });
                    }

                }
                CombRetorno.Focus();

            }

            else
            {
                CombRetorno.Items.Clear();
                CombRetorno.Enabled = false;
            }

        }
        protected void bt_proximo_Click(object sender, EventArgs e)
        {

            if (tratamentoErros())
            {
                //Registrando informações no aparelho

                aparelho.Acessorios = coletaAcessorios();
                aparelho.Arranhado = (txtAvaria.Text.Equals("")) ? false : true;
                aparelho.Avarias = txtAvaria.Text;
                if (CheckBox1.Checked)
                {
                    aparelho.DataNF = Convert.ToDateTime(txtDataNF.Text);
                    aparelho.Nf = txtNF.Text;
                    aparelho.Serie = txtNSerie.Text;
                }
                aparelho.Defeito = txtDefeito.Text;

                aparelho.DtAberturaOS = DateTime.Now; // ver tratamento para clientes que abre a OS
                if (Master.getUsarioAtual().getTipo() != 8)
                {
                    aparelho.DtRecebimento = DateTime.Now;
                    aparelho.IDOPRecebedor = Master.getUsarioAtual().getCod();
                }
                aparelho.Garantia = CheckBox1.Checked;
                if (combSeguradora.SelectedValue != "")
                {
                    aparelho.ID_Seguradora = Convert.ToInt16(combSeguradora.SelectedValue);
                }
                aparelho.IDatendimento = Convert.ToInt16(CombAtendimento.SelectedValue);
                aparelho.IDcliente = clienteSelecionado.getCod(); // identificação cliente
                aparelho.IDEstoque = Convert.ToInt16(combEstoque.SelectedValue);
                aparelho.IDloja = Convert.ToInt16(combLojas.SelectedValue);
                aparelho.IDMarca = Convert.ToInt16(CombMarca.SelectedValue);
                aparelho.IDOperador = Master.getUsarioAtual().getCod(); // identificação do operador que abriu a OS
                aparelho.Retorno = Chk_retorno.Checked;
                if (Chk_retorno.Checked)
                {
                    aparelho.IDOSRetorno = Convert.ToInt16(CombRetorno.SelectedValue);
                }
                aparelho.IDTipoAparelho = Convert.ToInt16(CombTipo.SelectedValue);
                aparelho.Modelo = txtModelo.Text;
                aparelho.Voltagem = Convert.ToString(CombVoltagem.SelectedValue);
                Master.setAparelhoatual(aparelho);
                Response.Redirect("~/OS/OSAbertura3.aspx");
            }
        }

        /// <summary>
        /// Método que verifica os checkbos de acessórios criando uma string que contém todos os acessórios.
        /// </summary>
        /// <returns>String contendo os acessórios</returns>
        private string coletaAcessorios()
        {
            string retorno = "";
            if (CheckBox2.Checked)
            {
                retorno += "2;";
            }

            if (CheckBox3.Checked)
            {
                retorno += "3;";
            }

            if (CheckBox4.Checked)
            {
                retorno += "4;";
            }

            if (CheckBox5.Checked)
            {
                retorno += "5;";
            }

            if (CheckBox6.Checked)
            {
                retorno += "6;";
            }

            if (CheckBox7.Checked)
            {
                retorno += "7;";
            }
            if (CheckBox8.Checked)
            {
                retorno += "8;";
            }

            if (CheckBox9.Checked)
            {
                retorno += "9;";
            }

            if (CheckBox10.Checked)
            {
                retorno += "10;";
            }

            if (CheckBox11.Checked)
            {
                retorno += "11;";
            }

            if (CheckBox12.Checked)
            {
                retorno += "12;";
            }

            if (CheckBox13.Checked)
            {
                retorno += "13;";
            }

            if (ChkOutros.Checked)
            {
                retorno += "14;" + txtAcessorio.Text;
            }


            return retorno;
        }

        private bool tratamentoErros()
        {

            if (CheckBox1.Checked)
            {
                if (txtNSerie.Text.Equals("") || txtNSerie.Text == null)
                {
                    CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "Número de série não informado.");
                    txtNSerie.Focus();
                    return false;
                }

                if (txtNF.Text.Equals("") || txtNF.Text == null)
                {
                    CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "Número da nota fiscal ou cupom fiscal não informado.");
                    txtNF.Focus();
                    return false;
                }

                if (txtDataNF.Text.Equals("") || txtDataNF.Text == null)
                {
                    CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "Data da nota fiscal ou cupom fiscal não informada.");
                    txtDataNF.Focus();
                    return false;
                }

                if (combLojas.SelectedValue.Equals("0"))
                {
                    CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "Não foi selecionado uma loja fornecedora.");
                    combLojas.Focus();
                    return false;
                }


            }

            //Campos gerais
            if (txtModelo.Text.Equals("") || txtModelo.Text == null)
            {
                CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "Não foi informado o modelo do aparelho..");
                txtModelo.Focus();
                return false;
            }

            if (CombTipo.SelectedValue.Equals("0"))
            {
                CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "Não foi selecionado o tipo do aparelho.");
                CombTipo.Focus();
                return false;
            }

            if (CombMarca.SelectedValue.Equals("0"))
            {
                CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "Não foi selecionado a Marca do aparelho.");
                CombMarca.Focus();
                return false;
            }

            if (Chk_retorno.Checked && CombRetorno.SelectedValue.Equals("0"))
            {
                CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "A OS trata-se de um retorno, deve ser seleionado o n° da OS anterior.");
                CombRetorno.Focus();
                return false;
            }

            if (txtDefeito.Text.Equals("") || txtDefeito.Text == null)
            {
                CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "Não foi informado o defeito do Aparelho.");
                txtDefeito.Focus();
                return false;
            }


            return true;
        }

        protected void Bt_IncluirLoja_Click(object sender, EventArgs e)
        {
            plnPopUp_ModalPopupExtender.Show();
        }

        protected void cmdFechar_Click(object sender, EventArgs e)
        {
            plnPopUp_ModalPopupExtender.Hide();
            txtLoja.Text = "";
            txt_cnpj_loja.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Processo de verificação de cadastro de fornecedor
            Class.Uteis util = new Class.Uteis();
            Boolean resp = true;

            if (util.validaCNPJ(txt_cnpj_loja.Text) == false)
            {
                CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "CNPJ inválido.");
                resp = false;
            }

            if (txtLoja.Text.Equals("") || txtLoja.Text == null)
            {
                CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "Razão social não informado.");
                resp = false;

            }

            if (resp)
            {
                lojas = new Class.lojas();
                if (lojas.getLoja(txt_cnpj_loja.Text) != null)
                {
                    CaixaMensagem1.Mostar(Apresentacao.Controles.Mensagem.Tipo.Erro, "Loja já cadastrada.");

                }
                else
                {
                    lojas.setLoja(txt_cnpj_loja.Text, txtLoja.Text);

                }
                montaCombs(combLojas, lojas.getListaLojas());
                combLojas.Items.FindByValue(txt_cnpj_loja.Text);
                cmdFechar_Click(sender, e);


            }
            else
            {


            }

            combLojas.Focus();
        }

        protected void CheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkOutros.Checked)
            {
                txtAcessorio.Enabled = true;
                txtAcessorio.Focus();
            }
            else
            {
                txtAcessorio.Text = "";
                txtAcessorio.Enabled = false;
                txtAvaria.Focus();
            }
        }

        
    }
}