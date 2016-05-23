using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIME.Class;
using WindowsFormsApplication2;
using TestaSolucao.nfE;
using System.IO;



namespace SIME.Produtos
{
    public partial class web_produtos : System.Web.UI.Page
    {
        private LeituraXML xml1;
        private ProdutosNFe listaProdutosNFE;
        private string saveDir = @"Uploads\";
        private string ID_Produto = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master.getUsarioAtual() == null)
            {
                Response.Redirect("~/logar.aspx");
            }

            if (this.Master.getUsarioAtual().getTipo() != 1)
            {
                Response.Redirect("~/naoautorizado.aspx");
            }

            updados.UpdateMode = UpdatePanelUpdateMode.Conditional;
            

            txtaliq1.Text = valorMoeda(txtaliq1);
            txtaliq2.Text = valorMoeda(txtaliq2);
            txtvalor1.Text = valorMoeda(txtvalor1);
            txtvalor2.Text = valorMoeda(txtvalor2);
            txtFrete.Text = valorMoeda(txtFrete);
            txtFreteValor.Text = valorMoeda(txtFreteValor);
            txtIcms.Text = valorMoeda(txtIcms);
            txtIPI.Text = valorMoeda(txtIPI);
            TxtNota.Text = valorMoeda(TxtNota);
            txtPeso.Text = valorMoeda(txtPeso);
            txtCusto.Text = valorMoeda(txtCusto);
            txtDesconto.Text = valorMoeda(txtDesconto);

            ID_Produto = Request.QueryString["ID"];
            if (ID_Produto != null)
            {
                SelecionaProduto(Convert.ToInt32(ID_Produto));
                if (!txtEAN.Text.Equals(Request.QueryString["EAN"]))
                {
                    txtEAN.Text = Request.QueryString["EAN"];
                    txtEAN.ForeColor = System.Drawing.Color.Red;
                }
                if (!txtNCM.Text.Equals (Request.QueryString["NCM"]))
                {
                    txtNCM.Text = Request.QueryString["NCM"];
                    txtNCM.ForeColor = System.Drawing.Color.Red;
                }

                if (!txtCusto.Text.Equals(Request.QueryString["Valor"]))
                {
                    txtCusto.Text = Request.QueryString["Valor"];
                    txtCusto.ForeColor = System.Drawing.Color.Red;
                }
                if (!txtIPI.Text.Equals(Convert.ToDouble(Request.QueryString["IPI"]).ToString("N")))
                {
                    txtIPI.Text = Convert.ToDouble(Request.QueryString["IPI"]).ToString("N");
                    txtIPI.ForeColor = System.Drawing.Color.Red;
                }

                if (!txtIcms.Text.Equals(Convert.ToDouble(Request.QueryString["ICMS"]).ToString("N")))
                {
                    txtIcms.Text = Convert.ToDouble(Request.QueryString["ICMS"]).ToString("N");
                    txtIcms.ForeColor = System.Drawing.Color.Red;
                }

                if (!Request.QueryString["ST"].Equals("0"))
                {
                    labErro.Text = "Produto com ST verifique cadastro";
                }

                String[] entrada = Request.QueryString["entrada"].Split('-');
                txtQuantidade.Text = entrada[0];
                combFornecedor.SelectedValue = entrada[2];
                txtNF.Text = entrada[1];
                txtData.Text = Convert.ToDateTime(entrada[3]).ToShortDateString();
                UpBusca.Visible = true;
            }

        }

        private String valorMoeda(TextBox caixa) 
        {
            if (caixa.Text == null || caixa.Text.Equals(""))
            {
                return caixa.Text;
            }
            Double valor = Convert.ToDouble(caixa.Text.ToString());
            return valor.ToString("N");
        }

        private void montartodososCombs()
        {
            new Fornecedores().MontaListaFornecedores(combFornecedor);
            new Empresas().montaComboEmpresas(combEmpresa);
            if (combUnidade.Items.Count == 0)
            {
                montaCombUnidade();
            }
            if (CombGrupo1.Items.Count == 0)
            {
                montaCombGrupo();
            }
            if (cobRegra.Items.Count == 0)
            {
                montaCombRegra();
            }
        }


        protected void btBuscar_Click(object sender, EventArgs e)
        {
            SIME.Class.Produtos produtos = new Class.Produtos();
            SIME.Class.Uteis util = new Uteis();
            List<String[]> lista = new List<String[]>();
            
            //Tratamento para campos vazios ou sem seleção.
            if (txtBusca.Text.Equals("") || txtBusca.Text.Trim().Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('Dados de busca inválidos.');", true);
                txtBusca.Focus();
                return;
            }
            
            if (RadioButtonList1.SelectedItem == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('Selecione um tipo de busca.');", true);
                RadioButtonList1.Focus();
                return;
            }
            else if (RadioButtonList1.SelectedItem.Value.Equals("ID"))
            {
                if (util.Sonumeros(txtBusca.Text))
                {
                    try
                    {
                        lista = produtos.getListaProdutos(Convert.ToInt32(txtBusca.Text));
                        montaComboProdutos(lista, CHdesc.Checked);
                        
                    }
                    catch (Exception erro)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('" + erro.Message + "');", true); ;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('ID de busca inválido.');", true);
                }
            }
            else if (RadioButtonList1.SelectedItem.Value.Equals("DESC"))
            {
                try
                {
                    lista = produtos.getListaProdutos(txtBusca.Text.Replace(' ', '%'),false, CHEstoque.Checked);
                    montaComboProdutos(lista, CHdesc.Checked);
                }
                catch (Exception erro)
                {

                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('" + erro.Message + "');", true); ;
                }
            }
            else
            {
                try
                {
                    lista = produtos.getListaProdutos(txtBusca.Text,true);
                    montaComboProdutos(lista, CHdesc.Checked);
                    
                }
                catch (Exception erro)
                {

                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Aviso!", "alert('" + erro.Message + "');", true); ;
                }
            }

            UpBusca.Visible = true;
            updados.Visible = false;
            combListaProdutos1.Focus();
        }

        private void montaComboProdutos(List<String[]> lista) 
        {
            montaComboProdutos(lista, true);
        }

        private void montaComboProdutos(List<string[]> lista, Boolean descontinuado, Boolean semEstoque)
        {
            SIME.Class.Produtos produtos = new Class.Produtos();
            combListaProdutos1.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                if (descontinuado)
                {
                    combListaProdutos1.Items.Add(new ListItem(lista[i][1].ToString(), lista[i][0].ToString()));
                }
                else
                {
                    if (!(Convert.ToBoolean(lista[i][3].ToString())))
                    {
                        combListaProdutos1.Items.Add(new ListItem(lista[i][1].ToString(), lista[i][0].ToString()));
                    }
                }
            }
        }
        private void montaComboProdutos(List<String[]> lista, Boolean descontinuado)
        {

            montaComboProdutos(lista, descontinuado, false);
        }

        protected void BtEditar_Click(object sender, EventArgs e)
        {
            SelecionaProduto(Convert.ToInt32(combListaProdutos1.SelectedValue));
        }

        private void SelecionaProduto(Int32 ID_produto)
        {
            Produto selecionado = new Produto(ID_produto, new Conexao().getDb4());
            preencherDados(selecionado);
            updados.Visible = true;
            labErro.Text = "";
            txtDescricao.Focus();
            TPEstoque.Enabled = true;
        }

        private void preencherDados(Produto selecionado) 
        {
            limpadados();
            montartodososCombs();
            txtDescricao.Text = selecionado.getDescricao();
            txtaliq1.Text = selecionado.gettxLucroMaximo().ToString("N");
            txtaliq2.Text = selecionado.gettxLucroMinimo().ToString("N");
            txtCodFabrica.Text = selecionado.getCodFabricante();
            txtComplemento.Text = selecionado.getComplemento();
            txtCusto.Text = selecionado.getCusto().ToString("N");
            txtDesconto.Text = selecionado.gettxDesconto().ToString("N");
            txtEAN.Text = selecionado.getEAN();
            txtFrete.Text = selecionado.gettaxaFrete().ToString("N");
            txtIcms.Text = (17 + selecionado.getICMSCusto()).ToString("N");
            txtIPI.Text = selecionado.gettaxaIPI().ToString("N");
            txtMinimo.Text = selecionado.getquantMinima().ToString();
            txtNCM.Text = selecionado.getNCM();
            txtPeso.Text = selecionado.getpeso().ToString("N");
            txtPolitica1.Text = selecionado.getpoliticaVenda();
            txtvalor1.Text = selecionado.getvalorVenda().ToString("N");
            txtvalor2.Text = selecionado.getValorVendaDesconto().ToString("N");
            
            String[] lista = selecionado.getimagem().Split('\\');
            if (lista.Length >= 2)
            {
                imgProduto.ImageUrl = "~\\fotos\\" + lista[2];
                imgProduto0.ImageUrl = imgProduto.ImageUrl;
                imgProduto1.ImageUrl = imgProduto.ImageUrl;
            }
            else
            {
                imgProduto.ImageUrl = "~\\Imagens\\Imagem.jpg";
                imgProduto0.ImageUrl = imgProduto.ImageUrl;
                imgProduto1.ImageUrl = imgProduto.ImageUrl;
            }
            CombGrupo1.SelectedValue = selecionado.getGrupo().getID().ToString();
            combUnidade.SelectedValue = selecionado.getidMedida().ToString();
            if (cobRegra.Items.FindByValue(selecionado.getidRegra().ToString())==null)
            {
                cobRegra.SelectedValue = "1";
                calcularCustos(new Regra(1));
            }
            else {
                cobRegra.SelectedValue = selecionado.getidRegra().ToString();
                calcularCustos(selecionado.getRegra());
            }
            labID0.Text = selecionado.getID().ToString();
            LabInforme.Text = "ID = " + selecionado.getID() + "-" + selecionado.getDescricao();
            ChbDescontinuado.Checked = selecionado.getdescontinuado();
            txtComissao.Text = selecionado.getTxComissao().ToString("N");
            LabIProduto.Text = LabInforme.Text;
            LabEstpque.Text = "Estoque: " + selecionado.getquantEstoque();

            
        
        }

        private void montaCombUnidade() 
        {
            this.combUnidade.Items.Clear();
            combUnidade.Items.Add(new ListItem("Kg", "1"));
            combUnidade.Items.Add(new ListItem("g", "2"));
            combUnidade.Items.Add(new ListItem("cm", "3"));
            combUnidade.Items.Add(new ListItem("m", "4"));
            combUnidade.Items.Add(new ListItem("und", "5"));
            combUnidade.Items.Add(new ListItem("pct", "6"));
            combUnidade.Items.Add(new ListItem("Saco", "7"));
            combUnidade.Items.Add(new ListItem("fardo", "8"));
            combUnidade.Items.Add(new ListItem("fls", "9"));
            combUnidade.Items.Add(new ListItem("resma", "10"));
            combUnidade.Items.Add(new ListItem("cx", "11"));


        }

        private void calcularCustos(Regra regra) 
        {
            
            Double  txComissao = 0, alq1, alq2, custo, Vd1, Vd2, Frete, federal1, federal2, ICMSD1, ICMSD2, ICMSC, alICMSC, IPI, LB1, LB2, LL1, LL2, TXFixa1, TXFixa2, comissao1, comissao2;
            custo = Convert.ToDouble(txtCusto.Text.ToString());
            
            alq1 = Convert.ToDouble(txtaliq1.Text.ToString());
            Vd1 = Convert.ToDouble(txtvalor1.Text.ToString());
            
            //Fazendo o valor 2 em relação ao desconto.
            Vd2 = (Convert.ToDouble(txtvalor1.Text.ToString()) - ((Convert.ToDouble(txtDesconto.Text.ToString()) / 100) * Convert.ToDouble(txtvalor1.Text.ToString())));
            alq2 = (((Vd2 - custo) * 100) / custo);

            txtvalor2.Text = Vd2.ToString("N");
            txtaliq2.Text = alq2.ToString("N");
            
            Frete = Convert.ToDouble(txtCusto.Text.ToString()) * ((Convert.ToDouble(txtFrete.Text.ToString())) / 100);
            federal1 = Vd1 * (regra.getFederal() / 100);
            federal2 = Vd2 * (regra.getFederal() / 100);
            alICMSC = Convert.ToDouble(txtIcms.Text.ToString());
            IPI = custo * (Convert.ToDouble(txtIPI.Text.ToString()) / 100);
            LB1 = custo * (alq1 / 100);
            LB2 = custo * (alq2 / 100);
            TXFixa1 = Vd1 * (regra.getTaxaDespesasFixas() / 100);
            TXFixa2 = Vd2 * (regra.getTaxaDespesasFixas() / 100);
            ICMSC = custo * ((18 - alICMSC) / 100); // Mudar quando não usar mais aliquotas negativas para ICMSC
            //Deve-se prepara a regra para Normal e SuperSimples, neste caso só apresentarei o superSimples
            ICMSD1 = 0;
            ICMSD2 = 0;
            txComissao = (txtComissao.Text.Equals("")) ? 0 : (Convert.ToDouble(txtComissao.Text) / 100);
            comissao1 = txComissao * Vd1;
            comissao2 = txComissao * Vd2;

            LL1 = Vd1 - (custo + Frete + federal1 + IPI + ICMSC + ICMSD1 + TXFixa1 + comissao1);
            LL2 = Vd2 - (custo + Frete + federal2 + IPI + ICMSC + ICMSD2 + TXFixa2 + comissao2);

            Labfrete1.Text = Frete.ToString("N");
            Labfrete2.Text = Frete.ToString("N");
            LabICMS0.Text = (ICMSC + ICMSD1).ToString("N");
            LabICMS1.Text = (ICMSC + ICMSD2).ToString("N");
            LabFederal1.Text = federal1.ToString("N");
            LabFederal2.Text = federal2.ToString("N");
            LabIPI1.Text = IPI.ToString("N");
            LabIPI2.Text = IPI.ToString("N");
            LabLB1.Text = LB1.ToString("N");
            LabLB2.Text = LB2.ToString("N");
            LabFixa1.Text = TXFixa1.ToString("N");
            LabFixa2.Text = TXFixa2.ToString("N");
            LabLL1.Text = (LL1 < 0)? "<font color ='red'>" + LL1.ToString("N") + "</font>" : LL1.ToString("N") ;
            LabLL2.Text = (LL2 < 0) ? "<font color ='red'>" + LL2.ToString("N") + "</font>" : LL2.ToString("N");
            labComissao1.Text = comissao1.ToString("N");
            labComissao2.Text = comissao2.ToString("N");



            
            
        }


        private void montaCombGrupo() 
        {
            CombGrupo1.Items.Clear();
            ADODB.Recordset rsDados = new ADODB.Recordset();
            String SQL = "SELECT Tipos.Cod, Tipos.TIPO FROM Tipos ORDER BY Tipos.TIPO;";
            rsDados.Open(SQL, new Conexao().getDb4());
            while (!(rsDados.EOF || rsDados.BOF))
            {
                CombGrupo1.Items.Add(new ListItem(rsDados.Fields["Tipo"].Value.ToString(), rsDados.Fields["cod"].Value.ToString()));
                rsDados.MoveNext();
            }

        }

        private void montaCombRegra()
        {
            cobRegra.Items.Clear();
            ADODB.Recordset rsDados = new ADODB.Recordset();
            String SQL = "SELECT dados_impostos.* FROM dados_impostos ORDER BY dados_impostos.Regra;";
            rsDados.Open(SQL, new Conexao().getContas());
            while (!(rsDados.EOF || rsDados.BOF))
            {
                cobRegra.Items.Add(new ListItem(rsDados.Fields["regra"].Value.ToString(), rsDados.Fields["cod"].Value.ToString()));
                rsDados.MoveNext();
            }
        }

        

        private void limpadados() 
        {
            txtDescricao.Text = "";
            txtaliq1.Text = "";
            txtaliq2.Text = "";
            txtCodFabrica.Text = "";
            txtComplemento.Text = "";
            txtCusto.Text = "0";
            txtDesconto.Text = "";
            txtEAN.Text = "";
            txtFrete.Text = "0";
            //Criar regras.
            txtIcms.Text = "0";
            txtIPI.Text = "0";
            txtMinimo.Text = "0";
            txtNCM.Text = "";
            txtPeso.Text = "0";
            txtPolitica1.Text = "";
            txtvalor1.Text = "0";
            txtvalor2.Text = "0";
            imgProduto.ImageUrl = "~\\Imagens\\Imagem.jpg";
            imgProduto0.ImageUrl = imgProduto.ImageUrl;
            LabEstpque.Text = "0";
            labID0.Text = "0";
            LabInforme.Text = "";
            Labfrete1.Text = "";
            Labfrete2.Text = "";
            LabICMS0.Text = "";
            LabICMS1.Text = "";
            LabFederal1.Text = "";
            LabFederal2.Text = "";
            LabIPI1.Text = "";
            LabIPI2.Text = "";
            LabLB1.Text = "";
            LabLB2.Text = "";
            LabFixa1.Text = "";
            LabFixa2.Text = "";
            LabLL1.Text = "";
            LabLL2.Text = "";

        }

        private void ajustarAliq() 
        {
            Double vd1, vd2, custo;
            vd1 = Convert.ToDouble(txtvalor1.Text.ToString());
            vd2 = Convert.ToDouble(txtvalor2.Text.ToString());
            custo = Convert.ToDouble(txtCusto.Text.ToString());
            txtaliq1.Text = (((vd1 - custo) * 100) / custo).ToString("N");
            txtaliq2.Text = (((vd2 - custo) * 100) / custo).ToString("N");

        }
        protected void btCalcular_Click(object sender, EventArgs e)
        {
            ajustarAliq();
            String valor = cobRegra.SelectedValue;
            Int32 idRegra = Convert.ToInt32(valor);
            Regra regra = new Regra(idRegra);
            calcularCustos(regra);
            cobRegra.SelectedValue = valor;
        }

        protected void btAdcionar_Click(object sender, EventArgs e)
        {
            limpadados();
            updados.Visible = true;
            montartodososCombs();
            TPEstoque.Enabled = false;
            UpBusca.Visible = true;
        }

        protected void BtSalvar1_Click(object sender, EventArgs e)
        {
            Produto selecionado;
            try
            {
                
                if (labID0.Text.Equals("0"))
                {
                    selecionado = new Produto(new Conexao().getDb4());
                }
                else
                {
                    selecionado = new Produto(Convert.ToInt32(labID0.Text.ToString()), new Conexao().getDb4());
                }

                selecionado.setCodFabricante(txtCodFabrica.Text);
                selecionado.setComplemento(txtComplemento.Text);
                selecionado.setCusto(Convert.ToDouble(txtCusto.Text.ToString()));
                selecionado.setdescontinuado(ChbDescontinuado.Checked);
                selecionado.setDescricao(txtDescricao.Text);
                selecionado.setEAN(txtEAN.Text);
                selecionado.setICMSCusto(Convert.ToDouble(txtIcms.Text.ToString())-17);
                selecionado.setidGrupo(Convert.ToInt32(CombGrupo1.SelectedValue));
                selecionado.setidMedida(Convert.ToInt32(combUnidade.SelectedValue));
                selecionado.setidRegra(Convert.ToInt32(cobRegra.SelectedValue));
                selecionado.setimagem(imgProduto.ImageUrl);
                selecionado.setNCM(txtNCM.Text);
                selecionado.setpeso(Convert.ToDouble(txtPeso.Text.ToString()));
                selecionado.setpoliticaVenda(txtPolitica1.Text);
                //selecionado.setquantEstoque(Convert.ToInt32(labEstoque.text.ToString()));
                selecionado.setquantMinima(Convert.ToInt32(txtMinimo.Text.ToString()));
                selecionado.settaxaFrete(Convert.ToDouble(txtFrete.Text.ToString()));
                selecionado.settaxaIPI(Convert.ToDouble(txtIPI.Text.ToString()));
                selecionado.setTxComissao(Convert.ToDouble(txtComissao.Text.ToString()));
                selecionado.settxDesconto(Convert.ToDouble(txtDesconto.Text.ToString()));
                selecionado.settxLucroMaximo(Convert.ToDouble(txtaliq1.Text.ToString()));
                selecionado.settxLucroMinimo(Convert.ToDouble(txtaliq2.Text.ToString()));
                selecionado.setvalorVenda(Convert.ToDouble(txtvalor1.Text.ToString()));
                selecionado.setValorVendaDesconto(Convert.ToDouble(txtvalor2.Text.ToString()));
                selecionado.salvar();
                selecionado.reload();
                labID0.Text = selecionado.getID().ToString();
               
                labErro.Text = "Gravado com sucesso!";
                TPEstoque.Enabled = true;
                LabInforme.Text = selecionado.getID() + " - " + selecionado.getDescricao();
                LabIProduto.Text = LabInforme.Text;
                
                imgProduto0.ImageUrl = imgProduto.ImageUrl;
                imgProduto1.ImageUrl = imgProduto.ImageUrl;
                
            }
            catch (Exception erro)
            {
                
               
                labErro.Text = erro.Message;
                
            }
        }

        protected void btSalvarEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto(Convert.ToInt32(labID0.Text), new Conexao().getDb4());
                produto.setEntradas(Convert.ToInt32(combFornecedor.SelectedValue), txtNF.Text, Convert.ToInt32(txtQuantidade.Text), chSN.Checked, Convert.ToDateTime(txtData.Text)
                    , Master.getUsarioAtual().getCod(), Convert.ToInt32(combEmpresa.SelectedValue));
                LabEstpque.Text = "Estoque: " + produto.getquantEstoque();
                txtData.Text = "__/___/____";
                txtQuantidade.Text = "";
                txtNF.Text = "";
                chSN.Checked = false;
            }
            catch (Exception erro)
            {
                
                labErro.Text = erro.Message;
            }
            
        }

        protected void BtAtualizaEstoque_Click(object sender, ImageClickEventArgs e)
        {
            Produto produto = new Produto(Convert.ToInt32(labID0.Text), new Conexao().getDb4());
            LabEstpque.Text = "Estoque: " + produto.getquantEstoque();
        }

        protected void btAddImagem_Click(object sender, ImageClickEventArgs e)
        {
            plnImagem.Show();
        }
        
        /**
        private void lerXML(String caminho) 
        {
            xml1 = new LeituraXML(caminho);
            SIME.Class.NFe.nota_entrada nota;
            Boolean chaveCadastrada = false;
            //Processo de identificação e gravação da NFe
            try
            {
                nota = new Class.NFe.nota_entrada(xml1.getChave());
                chaveCadastrada = true;
            }
            catch (Exception)
            {
                nota = new Class.NFe.nota_entrada(xml1.getProdutosNfe().Count());
                nota.setChave(xml1.getChave());
                nota.setLocal(caminho);
                nota.setDataEmissao(Convert.ToDateTime(xml1.getNota().getData()));
                nota.salvar();
            }
            LabChave.Text = nota.getChave();
            listaProdutosNFE = xml1.getProdutosNfe();
            ListNfe.Items.Clear();
            
            String CNPJ = xml1.getFornecedor().getCNPJ();

            ataulizaLista(nota, chaveCadastrada, listaProdutosNFE);

            ListBuscaR1.Items.Clear();
            LabForncedor.Text = xml1.getFornecedor().getFantasia() + " - " + xml1.getFornecedor().getNome();
           
            if (chaveCadastrada)
            {
                imgOk.ImageUrl = "~/imagens/ok_16x16.gif";
                upbuscaFornecedor1.Visible = false;
                LabForncedor.Text += "</br> <font Color='RED'> NOTA JÁ CADASTRADA OU INICIADO O CADASTRO. </font>";
            }
            else
            {
                imgOk.ImageUrl = "~/imagens/delete_16x16.gif";
                upbuscaFornecedor1.Visible = true;
                new Fornecedores().MontaListaFornecedores(CombForncedores1);
            }

            FormaPagamento formas  = xml1.getFormasPagamento();
            

            List<String[]> lista = new List<String[]>();
            for (int i =0 ; i < formas.getNumeroParcelas(); i++)
            {
                lista.Add (new String[]{(i + 1) + "ª" , formas.getDtVencimento(i).ToString(), " Valor: " + formas.getValorParcela(i).ToString("N")});
            }
            
            UteisWeb util = new UteisWeb();
            LabForncedor0.Text = util.montaTab( lista, "N° de parcelas: " + formas.getNumeroParcelas(), System.Drawing.Color.LightBlue);
            LabForncedor1.Text = "N° da NF: " + xml1.getNota().getNumeroNF().ToString() + " Data da NF: " + xml1.getNota().getData().ToString();
            
           
        }
        **/
        /**
        private void ataulizaLista(SIME.Class.NFe.nota_entrada nota, Boolean chaveCadastrada, ProdutosNFe listaProdutosNFE)
        {
            for (int i = 0; i < listaProdutosNFE.Count(); i++)
            {

                ListNfe.Visible = true;
                ListItem novoItem = new ListItem(listaProdutosNFE.getDescricaoProduto(i), i.ToString());

                if (chaveCadastrada && (nota.getItem(i) != 0))
                {
                    novoItem.Attributes.CssStyle.Add("Color", "Blue");
                }

                ListNfe.Items.Add(novoItem);
            }
        }

        private void ataulizaLista(SIME.Class.NFe.nota_entrada nota)
        {
            int contador = 0;
            foreach (ListItem item in ListNfe.Items)
            {
                if ((nota.getItem(contador) != 0))
                {
                    item.Attributes.CssStyle.Add("Color", "Blue");
                }
                contador++;
            }
        }
        
        protected void BtAtualizaLista_Click(object sender, EventArgs e)
        {
          
        }
        **/
        protected void BtImpArquivo_Click(object sender, EventArgs e)
        {

            plnImprimi.Show();
            
        }

   

        protected void BtSelecao_Click1(object sender, EventArgs e)
        {
            
            
        }

        protected void btImport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Produtos/importa.aspx");
        }

        /**
        private void buscaSemelhante(algoritimoBuscaProduto busca, string termo) 
        {
            List<String[]> retorno = busca.listaBusca(termo);
            
            
            if (retorno.Count > 0) 
            {
                ListBuscaR1.Items.Clear();
                foreach (var item in retorno)
                {
                    ListItem novoItem = new ListItem(item[1], item[0]);
                    if (Convert.ToDouble(item[2]) >= 70)
                    {
                        novoItem.Attributes.CssStyle.Add("Color", "green");
                    }
                    else if (Convert.ToDouble(item[2]) >= 50 && Convert.ToDouble(item[2]) < 70)
                    {
                        novoItem.Attributes.CssStyle.Add("Color", "goldenrod");
                    }
                    else 
                    {
                        novoItem.Attributes.CssStyle.Add("Color", "red");
                    }
                    ListBuscaR1.Items.Add(novoItem);
                }
            }
            
        }
        **/
        protected void btBuscaItem_Click(object sender, EventArgs e)
        {
           
           
        }

        protected void BtLer_Click(object sender, EventArgs e)
        {

            
        }

        protected void BtAddForncedor_Click(object sender, EventArgs e)
        {
             
        }
        /**
        protected void btAdd1_Click(object sender, EventArgs e)
        {
            SIME.Class.NFe.nota_entrada nota = new Class.NFe.nota_entrada(LabChave.Text);

            nota.setItem(Convert.ToInt32(ListNfe.SelectedValue ) , Convert.ToInt32(ListBuscaR1.SelectedValue));
            nota.salvar();

            Int32 itemSelecionado = ListNfe.SelectedIndex;
            ataulizaLista(nota);
            
            if (ListNfe.SelectedIndex < ListNfe.Items.Count - 1)
            {
                ListNfe.SelectedIndex = ListNfe.SelectedIndex + 1;
            }

            ListBuscaR1.Items.Clear();
        }
        **/
        protected void ListBuscaR1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void BtSelImagem_Click(object sender, EventArgs e)
        {

            String arq = "";
            String extensao = "";
            DirectoryInfo diretorio = new DirectoryInfo(@"c:\imagem");
            diretorio.FullName.Replace(" ", "_");

            if (!diretorio.Exists)
            {
                diretorio.Create();
            }

            if (FileUpload2.HasFile)
            {

                arq = Server.HtmlEncode(FileUpload2.FileName);
                extensao = System.IO.Path.GetExtension(arq);
                labErro.Text = "";
                if (extensao.ToUpper().Equals(".PNG") || extensao.ToUpper().Equals(".JPG") || extensao.ToUpper().Equals(".MPG") || extensao.ToUpper().Equals(".BMP") || extensao.ToUpper().Equals(".TIF") || extensao.ToUpper().Equals(".GIF"))
                {
                    FileUpload2.PostedFile.SaveAs(diretorio.FullName + @"/" + arq);
                    imgProduto.ImageUrl = "~\\fotos\\" + arq;
                    imgProduto0.ImageUrl = imgProduto.ImageUrl;
                    imgProduto1.ImageUrl = imgProduto.ImageUrl;
                }
                else
                {
                    labErro.Text = "Arquivo selecionado não é uma imagem.";
                }
            }
            else
            {
                labErro.Text = "Nenhum arquivo selecionado.";
            }

            
        }

        protected void btAdd3_Click(object sender, EventArgs e)
        {

        }

        protected void BtAcerto_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.Equals(""))
            {
                labErro.Text = "Para acertar estoque o campo quantidade deve ter um valor maior ou igual azero.";
                return;
            }
            if (Int32.Parse( txtQuantidade.Text) < 0) 
            {
                labErro.Text = "Para acertar estoque o campo quantidade deve ter um valor maior ou igual azero.";
                return;
            }
            labErro.Text = "";
            Produto selecionado = new Produto(Convert.ToInt32(labID0.Text.ToString()), new Conexao().getDb4());
            selecionado.setquantEstoque(int.Parse(txtQuantidade.Text));
            selecionado.salvar();
            LabEstpque.Text = "Estoque: " + selecionado.getquantEstoque();
            txtQuantidade.Text = "";
        }
       
      

      

        

    }
}