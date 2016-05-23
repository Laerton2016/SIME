using SIME.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIME
{
    public partial class ConsultaPreco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void clean()
        {
            labProduto.Text
                = "";
            LabPreco.Text = "";
            Labinforme.Text = "";
            Labinforme.CssClass = "black-text";
            Imagem.ImageUrl = "~//Imagens//Imagem.jpg";
        }
        protected void BtBuscar_Click(object sender, EventArgs e)
        {
            Class.Produtos produtos = new Class.Produtos();
            List<String[]> resulte = null;
            Produto produto = new Produto(new Conexao().getDb4());

            painelResulta.Visible = true;
            clean();

            if (txtCodigo.Text.Trim().Equals(""))
            {
                Labinforme.Text = "Código de barras ou de produto não informado!";
                Labinforme.CssClass = "red-text";
                txtCodigo.Text = "";
                txtCodigo.Focus();
                return;
            }

            if (!new Uteis().Sonumeros(txtCodigo.Text.Trim()))
            {
                Labinforme.Text = "Código de barras ou de produto só pode conter números!";
                Labinforme.CssClass = "red-text";
                txtCodigo.Text = "";
                txtCodigo.Focus();
                return;
            }

            if (txtCodigo.Text.Trim().Length > 10 && txtCodigo.Text.Trim().Length <= 13)
            {
                if (txtCodigo.Text.Length == 10)
                {
                    txtCodigo.Text = "000" + txtCodigo.Text;
                }
                else if (txtCodigo.Text.Length == 11)
                {
                    txtCodigo.Text = "00" + txtCodigo.Text;
                }
                else if (txtCodigo.Text.Length == 12)
                {
                    txtCodigo.Text = "0" + txtCodigo.Text;
                }

                if (!produto.chekDigitoEAN(txtCodigo.Text))
                {
                    Labinforme.Text = "Código de barras inválido";
                    Labinforme.CssClass = "red-text";
                    txtCodigo.Text = "";
                    txtCodigo.Focus();
                    return;
                }

                resulte = produtos.getListaProdutos(txtCodigo.Text, true);
                produto = new Produto(Int32.Parse(resulte[0][0].ToString()), new Conexao().getDb4());
            }
            else if (txtCodigo.Text.Length > 13)
            {
                Labinforme.Text = "Código de barras inválido";
                Labinforme.CssClass = "red-text";
                txtCodigo.Text = "";
                txtCodigo.Focus();
                return;
            }
            else
            {
                produto = new Produto(Int32.Parse(txtCodigo.Text.Trim()), new Conexao().getDb4());
            }

            String[] lista = produto.getimagem().Split('\\');
            if (lista.Length >= 2)
            {
                Imagem.ImageUrl = "~\\fotos\\" + lista[2];

            }
            else
            {
                Imagem.ImageUrl = "~\\Imagens\\Imagem.jpg";

            }
            labProduto.Text = produto.getDescricao();
            LabPreco.Text = "R$ " + produto.getvalorVenda().ToString("N");
            Labinforme.Text = "Valor para pagamento em dinheiro : R$ " + produto.getValorVendaDesconto().ToString("N") + "<br/>" +
                produto.getpoliticaVenda();
            txtCodigo.Text = "";
            txtCodigo.Focus();
        }
    }
}