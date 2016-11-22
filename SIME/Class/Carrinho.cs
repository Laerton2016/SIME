using SIME.Class.Conexoes;
using SIME.Class.primitivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIME.Class.DAO;
using SIME.Class.ProdutoClass;

namespace SIME.Class
{
    public class Carrinho
    {
        private Usuario _user;
        private NetVenda _venda;
        private DAOProduto _daoProduto;
        private DAOVenda _daoVenda;
        private Uteis u = new Uteis();
        public Carrinho (Usuario user)
        {
            _user = user;
            _venda = ConexRedis.ResgataCarrinhRedis(user.getCod());
            _daoProduto = new DAOProduto();
            _daoVenda = FactoryDAO.CriaDAOVenda();
        }

        /// <summary>
        /// Método retorna a venda a qual pertence o carrinho
        /// </summary>
        /// <returns>NetVenda</returns>
        public NetVenda GetVenda()
        {
            return _venda;
        }
        /// <summary>
        /// Método retorna um produto a partir do id repassado
        /// </summary>
        /// <param name="id">id do produto</param>
        /// <returns>NetProduto</returns>
        public NetProduto BuscaProdutoID(Int64 id)
        {
            NetProduto r = null;
            if (id <= 0)
            {
                throw new Exception("Não foi localizado nenhum produto com esse código.");
            }
            r = _daoProduto.Buscar(id);
            if (r == null)
            {
                throw new Exception("Não foi localizado nenhum produto com esse código.");
            }
            return r;
        }
        /// <summary>
        /// Método busca por um produto a partir do código de barras ean
        /// </summary>
        /// <param name="EAN">Codigo de barras do produto padrão EAN13</param>
        /// <returns>NetProduto</returns>
        public NetProduto BuscaProdutoEAN(String EAN)
        {
            NetProduto r = null;
            Ean13Barcode2005.Ean13 ean = new Ean13Barcode2005.Ean13();
            if (EAN.Trim().Equals(""))
            {
                throw new Exception("Não foi localizado nenhum produto com o EAN informado.");
            }
            
            if (u.ContemPontuacao(EAN))
            {
                throw new Exception("Código EAN inválido.");
            }
            if (!u.Sonumeros(EAN))
            {
                throw new Exception("Código EAN inválido.");
            }
            if (EAN.Length != 13)
            {
                EAN = "0000000000000" + EAN;
                EAN = u.esquerda(EAN, 13);
            }
            if (!ean.chekDigitoEAN(EAN))
            {
                throw new Exception("Código EAN inválido.");
            }
            r = _daoProduto.BuscaEAN(EAN);
            if (r == null)
            {
                throw new Exception("Não foi localizado nenhum produto com o EAN informado.");
            }
            return r;
        }
        /// <summary>
        /// Método retorna uma lista de produtos a partir de uma parde da descrição do mesmo.
        /// </summary>
        /// <param name="termo">Parte da descrição do produto a ser procurado</param>
        /// <returns>Retorna uma lista de NetProdutos com o resultado, caso o resultado seja insucesso retorna uma lista vazia.</returns>
        public List<NetProduto> BuscaProdutoTermo (String termo)
        {
            List<NetProduto> lista = new List<NetProduto>();
            if (termo.Trim().Equals(""))
            {
                throw new Exception("Não foram localizado produtos com esse termo.");
            }
            if (u.ContemPontuacao(termo))
            {
                throw new Exception("Não foram localizado produtos com esse termo");
            }
            lista = _daoProduto.Buscar(termo);
            if (lista.Count == 0 )
            {
                throw new Exception("Não foram localizado produtos com esse termo");
            }

            return lista;
        }
        /// <summary>
        /// Método adiciona um item de venda ao carrinho
        /// </summary>
        /// <param name="item">Item de venda a ser adicionado</param>
        public void AddItem(NetItemVenda item)
        {
            _venda.AddItemVenda(item);
            RedisCarrinho();

        }

        /// <summary>
        /// Método remove o item de venda do carrinho de compras
        /// </summary>
        /// <param name="item">Item a ser removido</param>
        public void RemItem (NetItemVenda item)
        {
            _venda.RemItemVenda(item);
            RedisCarrinho();
        }
        /// <summary>
        /// Método atualiza um item de venda que está no carrinho
        /// </summary>
        /// <param name="item">Item com os dados atualizados</param>
        public void UpItem(NetItemVenda item)
        {
            _venda.UpItemVenda(item);
            RedisCarrinho();
        }
        /// <summary>
        /// Método remove todos os itens do carrinho
        /// </summary>
        public void LimpaCarrinho()
        {
            _venda = new NetVenda(_user.getCod());
            ConexRedis.LimpaCarrinho(_user.getCod());
        }

        /// <summary>
        /// Mátodo seta um cliente ao carrinho 
        /// </summary>
        /// <param name="id_cliente">Id do cliente a ser setado</param>
        public void SetCliente(Int64 id_cliente)
        {
            _venda.Idcliente= id_cliente;
            RedisCarrinho();
        }
        /// <summary>
        /// Método grava os dados do carrinho na conta Redis
        /// </summary>
        private void RedisCarrinho()
        {
            ConexRedis.GravaCarrinhoRedis(_user.getCod(), _venda, 45);
        }
        /// <summary>
        /// Método finaliza uma venda do carrinho definindo as forma de pagamento, a soma das formas de pagamento deve ser o total da quantidade dos itens do carrinho vezes o valor unitário de venda.
        /// </summary>
        /// <param name="especia">Valor positívo maior que zero</param>
        /// <param name="cheque">Valor positívo maior que zero</param>
        /// <param name="cartao">Valor positívo maior que zero</param>
        /// <param name="duplicata">Valor positívo maior que zero</param>
        public void Finaliza(float especia, float cheque, float cartao, float duplicata)
        {
            double total = especia + cheque + cartao + duplicata;
            if (total != totaliza())
            {
                throw new Exception("Valores repassado do totalizador não confere com o tatal dos itens do carrinho.");
            }
            String texto = "";
            foreach (var item in _venda.Itens)
            {
                texto += VerificaEstoque(item);
                if (!texto.Trim().Equals(""))
                {
                    throw new Exception(texto);
                }
            }
            _venda.Cartao = cartao;
            _venda.Cheque = cheque;
            _venda.Especie = especia;
            _venda.Vale = duplicata;
            _daoVenda.Salvar(_venda);
            foreach (var item in _venda.Itens)
            {
                NetProduto p = _daoProduto.Buscar(item.Id_produto);
                p.QuantEstoque -= (int) item.Quantidade;
                _daoProduto.Salvar(p);
            }
            ConexRedis.LimpaCarrinho(_user.getCod());
        }
        /// <summary>
        /// Método verifica se o item de venda contem estoque disponível
        /// </summary>
        /// <param name="item">Item de venda cujo estoque será veriicado</param>
        /// <returns></returns>
        private String VerificaEstoque(NetItemVenda item)
        {
            NetProduto p = _daoProduto.Buscar(item.Id_produto);
            if (p.QuantEstoque < item.Quantidade)
            {
                return "O produto : " + p.Descricao + " tem somente " + p.QuantEstoque + " em estoque." ;
            }
            return "";
        }
        /// <summary>
        /// Método totaliza a venda
        /// </summary>
        /// <returns>Valor do total da venda</returns>
        public double totaliza()
        {
            double total = 0;
            foreach (var item in _venda.Itens)
            {
                total += (item.Quantidade * item.Valor);
            }
            return total;
        }
    }
}