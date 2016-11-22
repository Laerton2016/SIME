using SIME.Class.primitivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIME.Class.ProdutoClass;
using SIME.Class.CUteis;

namespace SIME.carrinho
{
    public partial class carrinho : System.Web.UI.Page
    {
        private SIME.Class.Carrinho _carrinho;

        protected void Page_Load(object sender, EventArgs e)
        {
            upItens.UpdateMode = UpdatePanelUpdateMode.Conditional;
            upResult.UpdateMode = UpdatePanelUpdateMode.Conditional;
            _carrinho = this.Master.GetCarrinho();
            MontaLista();   
        }

        private void MontaLista()
        {
            List<NetItemVenda> lista = _carrinho.GetVenda().Itens;
            this.ListaItens.Items.Clear();
            foreach (var item in lista)
            {
                ListaItens.Items.Add(new ListItem(item.Id_produto.ToString(),Json<NetItemVenda>.Serializa(item)));
            }
            this.labTota.Text = "R$ " + _carrinho.totaliza().ToString("N");
            this.upItens.Update();
            this.Master.AtualizaCarrinho();
            
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            if (this.rdEAN.Checked)
            {
                MontaCombo(_carrinho.BuscaProdutoEAN(this.txtTermo.Text));
            }
            else if (this.rdid.Checked)
            {
                MontaCombo(_carrinho.BuscaProdutoID(Int64.Parse( this.txtTermo.Text)));
            }
            else if (this.rdTermo.Checked)
            {
                MontaComboLista(_carrinho.BuscaProdutoTermo(this.txtTermo.Text));
            }
            this.upResult.Update();
            this.result.Visible = true;

        }

        private void MontaComboLista(List<NetProduto> list)
        {
            this.CobResult.Items.Clear();
            foreach (var item in list)
            {
                this.CobResult.Items.Add(new ListItem(item.Descricao,item.ID.ToString()));
            }
        }

        private void MontaCombo(NetProduto netProduto)
        {
            this.CobResult.Items.Clear();
            this.CobResult.Items.Add(new ListItem(netProduto.Descricao, netProduto.ID.ToString()));
        }
        /// <summary>
        /// Método aciciona ao carrinho o produto, sua quantidae e valor vendido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtAdiciona_Click(object sender, EventArgs e)
        {
            NetItemVenda item = new NetItemVenda();
            item.Id_produto = Int64.Parse(this.CobResult.SelectedItem.Value);
            item.Descricao = CobResult.SelectedItem.Text;
            item.Quantidade = Int64.Parse(txtQuantidade.Text);
            item.Valor = float.Parse(txtValor.Text);
            _carrinho.AddItem(item);
            this.Master.SetCarrinho(_carrinho);
            this.Master.AtualizaCarrinho();
            MontaLista();
        }

        protected void btExcluir_Click(object sender, EventArgs e)
        {
            NetItemVenda item = Json<NetItemVenda>.Deserializa(this.ListaItens.SelectedItem.Value);
            _carrinho.RemItem(item);
            this.ListaItens.Items.Remove(this.ListaItens.SelectedItem);
            this.Master.SetCarrinho(_carrinho);
            this.Master.AtualizaCarrinho();
            MontaLista();
        }

        protected void btFinaliza_Click(object sender, EventArgs e)
        {
            _carrinho.Finaliza(float.Parse(txtEspecia.Text), float.Parse(txtCheque.Text), float.Parse(txtCartao.Text), float.Parse(TxtDuplicata.Text));
            this.Master.SetCarrinho(_carrinho);
            this.MontaLista();
        }
    }
}