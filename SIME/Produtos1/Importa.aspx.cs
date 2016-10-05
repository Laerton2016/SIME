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
    public partial class Importa : System.Web.UI.Page
    {
        private static LeituraXML xml1;
        private static ProdutosNFe listaProdutosNFE;
        private string saveDir = @"Uploads\";
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btImport_Click(object sender, EventArgs e)
        {
            plnImprimi.Show();
        }

      
        protected void BtAtualizaLista_Click(object sender, EventArgs e)
        {
            CombArquivos.Items.Clear();
            DirectoryInfo diretorio = new DirectoryInfo(@"c:\xml");
            FileInfo[] arquivos = diretorio.GetFiles("*.xml");
            foreach (FileInfo item in arquivos)
            {
                CombArquivos.Items.Add(item.Name);
            }
        }

        protected void BtLer_Click(object sender, EventArgs e)
        {

            lerXML(@"c:/xml/" + CombArquivos.SelectedValue);
            UPdadosNota1.Visible = true;

        }

        protected void BtAddForncedor_Click(object sender, EventArgs e)
        {

        }

        protected void btBuscaItem_Click(object sender, EventArgs e)
        {
            algoritimoBuscaProduto busca = new algoritimoBuscaProduto();

            String textoItem = "", EAN = "";
            Int32 id_produto = 0;
            try
            {
                textoItem = ListNfe.SelectedItem.Text;
                labErro.Text = "";
            }
            catch (Exception)
            {
                labErro.Text = "Não foi selecionado nenhum item para busca.";
                labErro.Visible = true;
                return;
            }
                
                
                
                ListBuscaR1.Visible = true;
                //Leitura do arquivo XML 
                EAN = listaProdutosNFE.getEAN(Convert.ToInt32(ListNfe.SelectedValue));

                

            //Busca por EAN
            if (!EAN.Equals(""))
            {
                id_produto = busca.BuscaProdutopporEAN(EAN);
                if (id_produto != 0)
                {
                    Produto produto = new Produto(id_produto, new Conexao().getDb4());
                    ListBuscaR1.Items.Clear();
                    ListBuscaR1.Items.Add(new ListItem(produto.getDescricao(), produto.getID().ToString()));

                }
                else
                {
                    buscaSemelhante(busca, textoItem);
                }
            }
            else
            {
                buscaSemelhante(busca, textoItem);
            }
            //Libera a atualização do PainelUpdate
            upListaBusca1.Update();
            SIME.Class.NFe.nota_entrada nota = new Class.NFe.nota_entrada(LabChave.Text);
            ataulizaLista(nota);
        }

        protected void btAdd1_Click(object sender, EventArgs e)
        {
            SIME.Class.NFe.nota_entrada nota = new Class.NFe.nota_entrada(LabChave.Text);
            Int32 ItemNFE = Convert.ToInt32(ListNfe.SelectedValue), Id_Produto = Convert.ToInt32(ListBuscaR1.SelectedValue);
            string EAN = listaProdutosNFE.getEAN(ItemNFE);
            String NCM = listaProdutosNFE.getNCM(ItemNFE);
            String ValorUnitario = listaProdutosNFE.getValorUnitario(ItemNFE).ToString();
            String IPI = listaProdutosNFE.getAiqIPI(ItemNFE).ToString(), ICMS = listaProdutosNFE.getAiqICMS(ItemNFE).ToString(), ST = listaProdutosNFE.getValorICMSST(ItemNFE).ToString();
            String Entrada = listaProdutosNFE.getQuantidadeProduto(ItemNFE).ToString() + "-" + xml1.getNota().getNumeroNF() + "-" + xml1.getFornecedor().getFornecedor().getID().ToString()
                + "-" + xml1.getNota().getData();

            //procedimentos na Base de dados Notas;
            nota.setItem(ItemNFE, Id_Produto);
            nota.salvar();

            Int32 itemSelecionado = ListNfe.SelectedIndex;
            ataulizaLista(nota);
            
            if (ListNfe.SelectedIndex < ListNfe.Items.Count - 1)
            {
                ListNfe.SelectedIndex = ListNfe.SelectedIndex + 1;
            }

            
            Response.Redirect("~/Produtos/produtos.aspx?ID=" + ListBuscaR1.SelectedValue + "&EAN=" + EAN + "&NCM=" + NCM +
            "&Valor=" + ValorUnitario + "&IPI=" + IPI + "&ICMS=" + ICMS + "&ST=" + ST + "&entrada=" + Entrada, "_blank", "menubar=0,width=1000,height=800");
            ListBuscaR1.Items.Clear();
            
        }

        protected void btAdd3_Click(object sender, EventArgs e)
        {

        }

        private  void lerXML(String caminho)
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

            LabChave.Text = nota.getChave();//Armazena a chave da NF-e
            listaProdutosNFE = xml1.getProdutosNfe();
            ListNfe.Items.Clear();

            String CNPJ = xml1.getFornecedor().getCNPJ();

            ataulizaLista(nota, chaveCadastrada, listaProdutosNFE);//Verifica se já há registros de vinculo com a Tabela de Notas de entrada

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

            FormaPagamento formas = xml1.getFormasPagamento();


            List<String[]> lista = new List<String[]>();
            for (int i = 0; i < formas.getNumeroParcelas(); i++)
            {
                lista.Add(new String[] { (i + 1) + "ª", formas.getDtVencimento(i).ToString(), " Valor: " + formas.getValorParcela(i).ToString("N") });
            }

            UteisWeb util = new UteisWeb();
            LabForncedor0.Text = util.montaTab(lista, "N° de parcelas: " + formas.getNumeroParcelas(), System.Drawing.Color.LightBlue);
            LabForncedor1.Text = "N° da NF: " + xml1.getNota().getNumeroNF().ToString() + " Data da NF: " + xml1.getNota().getData().ToString();


        }

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

        protected void BtSelecao_Click1(object sender, EventArgs e)
        {

            String arq = "";
            String extensao = "";
            DirectoryInfo diretorio = new DirectoryInfo(@"c:\xml");
            diretorio.FullName.Replace(" ", "_");

            if (!diretorio.Exists)
            {
                diretorio.Create();
            }

            if (FileUpload1.HasFile)
            {

                arq = Server.HtmlEncode(FileUpload1.FileName);
                extensao = System.IO.Path.GetExtension(arq);
                labErro.Text = "";
                if (extensao.ToUpper().Equals(".XML"))
                {
                    FileUpload1.PostedFile.SaveAs(diretorio.FullName + @"/" + arq);
                    BtAtualizaLista_Click(sender, e);
                    CombArquivos.SelectedValue = arq;
                    BtLer_Click(sender, e);
                    
                }
                else
                {
                    labErro.Text = "Arquivo selecionado não é um XML.";
                }
            }
            else
            {
                labErro.Text = "Nenhum arquivo selecionado.";
            }


        }

    }
}