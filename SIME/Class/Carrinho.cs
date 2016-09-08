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
        private CassandraItem _daoVenda;
        private Uteis u = new Uteis();
        public Carrinho (Usuario user)
        {
            _user = user;
            _venda = ConexRedis.ResgataCarrinhRedis(user.getCod());
            _daoProduto = new DAOProduto();
            _daoVenda = new CassandraItem();
        }

        public NetVenda GetVenda()
        {
            return _venda;
        }

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
        public void AddItem(NetItemVenda item)
        {
            _venda.AddItemVenda(item);
            RedisCarrinho();

        }


        public void RemItem (NetItemVenda item)
        {
            _venda.RemItemVenda(item);
            RedisCarrinho();
        }

        public void UpItem(NetItemVenda item)
        {
            _venda.UpItemVenda(item);
            RedisCarrinho();
        }

        public void LimpaCarrinho()
        {
            _venda = new NetVenda(_user.getCod());
            ConexRedis.LimpaCarrinho(_user.getCod());
        }


        public void SetCliente(Int64 id_cliente)
        {
            _venda.Idcliente= id_cliente;
            RedisCarrinho();
        }

        private void RedisCarrinho()
        {
            ConexRedis.GravaCarrinhoRedis(_user.getCod(), _venda, 45);
        }

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

        private String VerificaEstoque(NetItemVenda item)
        {
            NetProduto p = _daoProduto.Buscar(item.Id_produto);
            if (p.QuantEstoque < item.Quantidade)
            {
                return "O produto : " + p.Descricao + " tem somente " + p.QuantEstoque + " em estoque." ;
            }
            return "";
        }

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