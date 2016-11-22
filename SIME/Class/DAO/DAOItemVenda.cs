using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIME.Class.primitivo;
using System.Data.OleDb;

namespace SIME.Class.DAO
{
    public class DAOItemVenda : IDAO<NetItemVenda>
    {
        public NetItemVenda Buscar(long id)
        {
            String SQL = "Select * from saída where cont =" + id + ";";
            NetItemVenda item = null;
            OleDbConnection connect = (OleDbConnection)NetConexao.Instance().GetSimeConnect();
            {
                connect.Open();
                OleDbCommand command = new OleDbCommand(SQL, connect);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        item = MontaItemVenda(dr);
                    }
                }
            }
            return item;
        }
        public List<NetItemVenda> BuscaItensPorVenda(long id)
        {
            List<NetItemVenda> lista = new List<NetItemVenda>();
            String SQL = "Select * from saída where cod_sai =" + id + ";";
            OleDbConnection connect = (OleDbConnection)NetConexao.Instance().GetSimeConnect();
            {
                if(connect.State == System.Data.ConnectionState.Closed) connect.Open();
                OleDbCommand command = new OleDbCommand(SQL, connect);
                using (OleDbDataReader dr= command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(MontaItemVenda(dr));
                    }
                    
                }
            }
            return lista;
        }

        private NetItemVenda MontaItemVenda(OleDbDataReader dr)
        {
            NetItemVenda item = new NetItemVenda();
            item.Id_fornecedor = Int64.Parse(dr["Fornecedor"].ToString());
            item.Id = Int64.Parse(dr["cont"].ToString());
            item.Id_produto = Int64.Parse(dr["Cod do cd"].ToString());
            item.Id_venda = Int64.Parse(dr["cod_sai"].ToString());
            item.Loja = Int64.Parse(dr["loja"].ToString());
            item.Nf = dr["nf"].ToString();
            item.Quantidade = Int64.Parse(dr["quantidade"].ToString());
            item.Valor = float.Parse(dr["desconto"].ToString());
            return item;
        }
        /// <summary>
        /// Exluir um item de venda a partir do objeto repassado como aparamentro
        /// </summary>
        /// <param name="t">Item de venda a ser exclido</param>
        public void Excluir(NetItemVenda t)
        {
            OleDbConnection connect = (OleDbConnection)NetConexao.Instance().GetSimeConnect();
            {
                if (connect.State == System.Data.ConnectionState.Closed) connect.Open();
                OleDbTransaction trans = connect.BeginTransaction();
                try
                {
                    Excluir(t, connect, trans);
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback(); 
                    throw new Exception(e.Message);
                }
                
            }
        }
        /// <summary>
        /// Exlui um item de venda a partir dos paramentros repassados
        /// </summary>
        /// <param name="t">Item a ser excluido</param>
        /// <param name="connection">Objeto de conexão</param>
        /// <param name="trans">Objeto de transação.</param>
        public void Excluir (NetItemVenda t, OleDbConnection connection, OleDbTransaction trans)
        {
            String SQL = "Delete from saída where cont =" + t.Id + ";";
            OleDbCommand command = new OleDbCommand(SQL, connection, trans);
            command.ExecuteNonQuery();
        }

        public NetItemVenda Salvar(NetItemVenda t)
        {
            OleDbConnection connect = (OleDbConnection)NetConexao.Instance().GetSimeConnect();
            {
                if (connect.State == System.Data.ConnectionState.Closed) connect.Open();
                OleDbTransaction trans = connect.BeginTransaction();
                return Salvar(t, connect, trans);
            }
        }

        public NetItemVenda Salvar(NetItemVenda t, OleDbConnection connection, OleDbTransaction trans)
        {
            String SQL = null;
            if (t.Id == 0)
            {
                SQL = "Insert into saída ([cod do cd], quantidade, desconto, cod_sai, custo, loja, Fornecedor, NF ) values (?,?,?,?,?,?,?,?);";
            }else
            {
                SQL = "Update saída set [cod do cd] =?, quantidade = ?, desconto = ?, cod_sai = ?, loja = ?, fornecedor = ?, NF = ? where cont =?; ";
            }
            return Persiste(SQL, t, connection, trans);
        }

        public List<NetItemVenda> ItemBonificado (DateTime dtinicio, DateTime dtFim, Int64 idProduto, Int64 idCLiente)
        {
            String SQL = "SELECT Saída.*" +
                         "FROM Cod_sai INNER JOIN Saída ON Cod_sai.Cod_sai = Saída.cod_sai " +
                         "WHERE(((Cod_sai.Data)Between #" + dtinicio.ToString("dd/MM/yyyy") + "# And #" + dtFim.ToString("dd/MM/yyyy") + "#) and saída.desconto = 0 AND ((Cod_sai.Cod_cliente)=" + idCLiente + ") AND ((Saída.[Cod do CD])=" + idProduto + "));";
            return buscaItensVendaPeriodo(SQL);
            
        }
        /// <summary>
        /// Método efetua uma busca de itens vendidos a partir de uma instrução SQL repassado como paramentro de entrada
        /// </summary>
        /// <param name="SQL">Instrução SQL </param>
        /// <returns>Lista de resultados de NetItensVendido</returns>
        private List<NetItemVenda> buscaItensVendaPeriodo(String SQL)
        {
            List<NetItemVenda> retorno = new List<NetItemVenda>();

            using (var connection = (OleDbConnection)NetConexao.Instance().GetSimeConnect())
            {
                connection.Open();
                var command = new OleDbCommand(SQL, connection);
                OleDbDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    retorno.Add(MontaItemVenda(dr));
                }
            }

            return retorno;
        }
        /// <summary>
        /// Busca itens vendidos a partir de uma faixa de data, código do produto e do cliente
        /// </summary>
        /// <param name="dtinicio">Data de inicio de busca</param>
        /// <param name="dtFim">Data de fim de busca</param>
        /// <param name="idProduto">Id do produto</param>
        /// <param name="idCLiente">Id do Cliente</param>
        /// <returns></returns>
        public List<NetItemVenda> ItensVendidosPeriodo(DateTime dtinicio, DateTime dtFim, Int64 idProduto, Int64 idCLiente)
        {
            String SQL = "SELECT Saída.* " +
                         "FROM Cod_sai INNER JOIN Saída ON Cod_sai.Cod_sai = Saída.cod_sai " +
                         "WHERE(((Cod_sai.Data)Between #" + dtinicio.ToString("dd/MM/yyyy") + "# And #" + dtFim.ToString("dd/MM/yyyy") + "#) and saída.desconto > 0 AND ((Cod_sai.Cod_cliente)=" + idCLiente + ") AND ((Saída.[Cod do CD])=" + idProduto + "));";
            return buscaItensVendaPeriodo(SQL);
        }

        private NetItemVenda Persiste(String SQL, NetItemVenda t, OleDbConnection connection, OleDbTransaction trans)
        {
            OleDbCommand command = new OleDbCommand(SQL, connection, trans);
            command.Parameters.AddWithValue("@[cod do cd]", t.Id_produto);
            command.Parameters.AddWithValue("@quantidade", t.Quantidade);
            command.Parameters.AddWithValue("@desconto", t.Valor);
            command.Parameters.AddWithValue("@cod_sai", t.Id_venda);
            command.Parameters.AddWithValue("@loja", t.Loja);
            command.Parameters.AddWithValue("@fornecedor", t.Id_fornecedor);
            command.Parameters.AddWithValue("@nf", t.Nf);
            if (t.Id != 0)
            {
                command.Parameters.AddWithValue("@cont", t.Id);
            }
            command.ExecuteNonQuery();
            if (t.Id == 0)
            {
                SQL = "select max([cod do cd]) as Id from saída;";
                OleDbCommand command1 = new OleDbCommand(SQL, connection);
                command1.CommandText = SQL;
                OleDbDataReader dr = command1.ExecuteReader();
                while (dr.Read())
                {
                    t.Id = Int32.Parse(dr["id"].ToString());
                }
                dr.Close();
            }
            return t;
        }
    }
}