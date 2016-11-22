using System.Data.OleDb;
using SIME.Class.primitivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SIME.Class.DAO
{
    public class DAOVenda : IDAO<NetVenda>
    {
        public NetVenda Buscar(long id)
        {
            string SQL = "Select * from cod_sai where cod_sai = " + id;
            return Busca(SQL);
        }

        private NetVenda Busca(String SQL)
        {
            using (OleDbConnection connect = (OleDbConnection)NetConexao.Instance().GetSimeConnect())
            {
                connect.Open();
                NetVenda venda = null;
                OleDbCommand command = new OleDbCommand(SQL, connect);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        venda = MontaVenda(dr);
                    }
                } 
                return venda;
            }
        }

        private List<NetVenda> BuscaLista(String SQL)
        {
            using (OleDbConnection connect = (OleDbConnection)NetConexao.Instance().GetSimeConnect())
            {
                connect.Open();
                List<NetVenda> retorno = new List<NetVenda>();

                OleDbCommand command = new OleDbCommand(SQL, connect);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retorno.Add(MontaVenda(dr));
                    }
                }
                
                return retorno;
            }
        }
        private NetVenda MontaVenda(OleDbDataReader dr1)
        {
            NetVenda retorno = new NetVenda(Int64.Parse(dr1["op"].ToString()));
            retorno.Cartao = float.Parse(dr1["cartao"].ToString());
            retorno.Cheque = float.Parse(dr1["cheque"].ToString());
            retorno.Date = DateTime.Parse(dr1["data"].ToString());
            retorno.Especie = float.Parse(dr1["especie"].ToString());
            retorno.Id = Int64.Parse(dr1["cod_sai"].ToString());
            retorno.Idcaixa = Int64.Parse(dr1["cx"].ToString());
            retorno.Idcliente = Int64.Parse(dr1["cod_cliente"].ToString());
            retorno.Vale = float.Parse(dr1["vale"].ToString());
            DAOItemVenda dao = new DAOItemVenda();
            retorno.Itens = dao.BuscaItensPorVenda(retorno.Id);
            return retorno;
            
        }
        /// <summary>
        /// Lista todas as vendas de um caixa
        /// </summary>
        /// <param name="id_caixa">id do caixa</param>
        /// <returns>Lista de vendas de um caixa</returns>
        public List<NetVenda> VendaCaixa(Int64 id_caixa)
        {
            String SQL = "Select * from cod_sai where cx = " + id_caixa;
            return BuscaLista(SQL);
        }

        /// <summary>
        /// Lista de todas as vendas de um cliente
        /// </summary>
        /// <param name="id_cliente">Id do cliente</param>
        /// <returns></returns>
        public List<NetVenda> VendaCliente(Int64 id_cliente)
        {
            String SQL = "Select * from cod_sai where cod_cliente = " + id_cliente;
            return BuscaLista(SQL);
        }
        /// <summary>
        /// Lista de todas as vendas realizadas por um operador em um entervalo de data
        /// </summary>
        /// <param name="id_operador">Id do operador</param>
        /// <param name="inicio">Data inicial da venda</param>
        /// <param name="fim">Data final da venda</param>
        /// <returns>Lista de vendas localizadas por um determinado periodo por um determinado operador</returns>
        public List<NetVenda> VendasOperador(Int64 id_operador, DateTime inicio, DateTime fim)
        {
            String SQL = "Select * from cod_sai where op =" + id_operador + " and data Between #" + inicio.ToString("dd/MM/yyyy") + "# And #" + fim.ToString("dd/MM/yyyy") + "#;";
            return BuscaLista(SQL);
        }
        /// <summary>
        /// Método lista todas as vendas de um determinado periodo
        /// </summary>
        /// <param name="inicio">Inicio do periodo das vendas</param>
        /// <param name="fim">Fim do periodo das vendas</param>
        /// <returns>Lsita de todas as vendasde um determinado periodo</returns>
        public List<NetVenda> VendasPeriodo(DateTime inicio, DateTime fim)
        {
            String SQL = "Select * from cod_sai where data Between #" + inicio.ToString("dd/MM/yyyy") + "# And #" + fim.ToString("dd/MM/yyyy") + "#;";
            return BuscaLista(SQL);
        }

        public List<NetVenda> VendasOperadorCarteira(Int64 id_operador, DateTime inicio, DateTime fim)
        {
            String SQL = "";
            return BuscaLista(SQL);
        }

       /// <summary>
       /// Método exlui uma venda e seus itens do banco de dados 
       /// </summary>
       /// <param name="t">Venda que será excluida</param>
        public void Excluir(NetVenda t)
        {
            String SQL = @"Delete * from cod_sai where cod_sai =" + t.Id + ";";
            DAOItemVenda dao_item = FactoryDAO.CriaDAOItemVenda();
            using ( var connect = (OleDbConnection) NetConexao.Instance().GetSimeConnect())
            {
                connect.Open();
                var transacao = connect.BeginTransaction();
                var command = new OleDbCommand(SQL, connect, transacao);
                try
                {
                    command.ExecuteNonQuery();
                    foreach (var item in t.Itens)
                    {
                        dao_item.Excluir(item, connect, transacao);
                    }
                    transacao.Commit();
                }
                catch (Exception e )
                {
                    transacao.Rollback();
                    throw new Exception (e.Message);
                }
            }
            
        }

        public NetVenda Salvar(NetVenda t)
        {
            String SQL = "";
            if (t.Id == 0)
            {
                SQL = @"Insert into cod_sai (data, dado1, cod_cliente, especie, cheque, vale, op, cx, cartao) values (@data, @dado1, @cod_cliente, @especie, @cheque, @vale, @op, @cx, @cartao); ";
            }
            else
            {
                SQL = @"Update cod_sai set data = @data, dado1 = @dado1, cod_cliente = @cod_cliente, especie = @especie, cheque = @cheque, vale = @vale, op = @op, cx = @cx, cartao = @cartao where cod_sai = @cod_sai;";
            }
            return Persiste(SQL, t);
            
        }
        /// <summary>
        /// Método persiste os dados de uma venda e seus itens no banco de dados.
        /// </summary>
        /// <param name="sQL">Instrução SLQ para a persistencia</param>
        /// <param name="t">Objeto a ser persistido</param>
        /// <returns>Venda com os dados atualizados após apersistencia</returns>
        private NetVenda Persiste(string sQL, NetVenda t)
        {
            DAOItemVenda dao = FactoryDAO.CriaDAOItemVenda();
            
            using (var connect =  (OleDbConnection) NetConexao.Instance().GetSimeConnect())
            {
                connect.Open();
                var transacao = connect.BeginTransaction();
                OleDbCommand command = new OleDbCommand(sQL, connect, transacao);
                command.Parameters.AddWithValue("@data", t.Date);
                command.Parameters.AddWithValue("@dado1", t.Orcamento);
                command.Parameters.AddWithValue("@cod_cliente", t.Idcliente);
                command.Parameters.AddWithValue("@especie", t.Especie);
                command.Parameters.AddWithValue("@cheque", t.Cheque);
                command.Parameters.AddWithValue("@vale", t.Vale);
                command.Parameters.AddWithValue("@op", t.Idoperador);
                command.Parameters.AddWithValue("@cx", t.Idcaixa);
                command.Parameters.AddWithValue("@cartao", t.Cartao);
                if (t.Id != 0)
                {
                    command.Parameters.AddWithValue("@cod_sai", t.Id);
                }
                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "select max(cod_sai) as Id from cod_sai;";
                    var dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        t.Id = long.Parse(dr["id"].ToString());
                    }
                    dr.Close();

                    foreach (NetItemVenda item in t.Itens)
                    {
                        item.Id_venda = t.Id;
                        var gravado = dao.Salvar(item, connect, transacao);
                        item.Id = gravado.Id;
                    }
                    transacao.Commit();
                }
                catch (Exception e )
                {
                    transacao.Rollback();
                    throw new Exception(e.Message);
                }

            }
            return t;
        }
        
    }
}
