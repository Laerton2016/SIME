using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIME.Class.DAO;
using SIME.Class.ProdutoClass;
using SIME.Class.primitivo;

namespace SIME.Class
{
    public class FronteCamapanha
    {
        private DAOItemVenda daoItem;
        private DAOCliente daoCliente;
        private DAOProduto daoProduto;
             
        

        public FronteCamapanha()
        {
            daoItem = FactoryDAO.CriaDAOItemVenda();
            daoCliente = FactoryDAO.CriaDAOCliente();
            daoProduto = FactoryDAO.CriaDAOProduto();
        
        }

        
        public NetProduto BuscaProduto(Int64 idProduto)
        {
            if (idProduto <= 0)
            {
                throw new Exception("O código do produto informado não pode ser um valor menor igual a zero!");
            }
            var produto = daoProduto.Buscar(idProduto);
            if (produto == null)
            {
                throw new Exception("Não foi localizado nenhum produto com o código informado.");
            }
            return produto;
        }

        public NetCliente BuscaCliente(Int64 idCliente)
        {
            if (idCliente <= 0)
            {
                throw new Exception("O código do cliente informado não pode ser um valor menor igual a zero!");
            }
            var cliente = daoCliente.Buscar(idCliente);
            if (cliente == null)
            {
                throw new Exception("Não foi localizado nenhum produto com o código informado.");
            }
            return cliente;
        }

        public List<NetCliente> BuscaClientes(String termo)
        {
            if (termo.Trim().Equals(""))
            {
                throw new Exception("Não foi fornecido dados para busca de clientes.");
            }
            if  (new Uteis().ContemPontuacao(termo))
            {
                throw new Exception("Não pode ser usado caracteres especiais.");
            }

            List<NetCliente> lista = daoCliente.Buscar(termo);
            if (lista.Count == 0)
            {
                throw new Exception("Não foram encontrados clientes com os dados repassados.");
            }

            return lista;

        }

        internal String monta(NetCliente cliente, NetProduto produto, Int32 qBonificar)
        {
            var itensBonificado = daoItem.ItemBonificado(cliente.DataFidelizacao, DateTime.Now, produto.ID, cliente.Cod);
            Int64 q = 0, q1 = 0;
            foreach (var item in itensBonificado)
            {
                q += item.Quantidade;
            }

            var itensComprados = daoItem.ItensVendidosPeriodo(cliente.DataFidelizacao, DateTime.Now, produto.ID, cliente.Cod);
            foreach (var item in itensComprados)
            {
                q1 += item.Quantidade;
            }

            String montagem = "<li>Produto:" + produto.Descricao + "<ul><il><il> Quantidade comprado: " + q1 + "</il></li><li> Bonus no período: " + (q1 / qBonificar) + " </li><li>Bonus usuado: " + q + "</li><li> Bonus disponíveis: " + ((q1 / qBonificar) - q) + "</li></ul></li>";

            
            return montagem;
        }

     
    }
}