using SIME.Class.primitivo;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace SIME.Class.DAO
{
    /// <summary>
    /// Classe incompleta
    /// </summary>
    public class DAOCliente : IDAO<NetCliente>
    {

        /// <summary>
        /// Busca por um cliente a partir do Id repassado
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Retorna cliente, caso não retorna null</returns>
        public NetCliente Buscar(long id)
        {
            String SQL = "select * from clientes where cod_cliente = " + id + ";";
            NetCliente resposta = null;
            using (OleDbConnection connection =(OleDbConnection) NetConexao.Instance().GetSimeConnect())
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(SQL, connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        resposta = MontaCliente(dr);
                    }
                }
            }
            return resposta;     
        }

        /// <summary>
        /// Lista todos os clientes cadastrados por ordem alfabética
        /// </summary>
        /// <returns>Lista de todos os clientes, caso não haja retorna uma lista vazia.</returns>
        public List<NetCliente> AllClientes()
        {
            return Buscar("");
        }

        /// <summary>
        /// Retorna uma lista de clientes filtrado pelo termo repassado em ordem alfabética.
        /// </summary>
        /// <param name="termo">Termo para pesquisa</param>
        /// <returns>Lista de clientes localizados a partir do termo, caso não haja resultados, retorna uma lista vazia.</returns>
        public List<NetCliente> Buscar(String termo)
        {
            String SQL = "Select * from clientes where nome like '%" + termo + "%' order by nome;";
            List<NetCliente> retorno = new List<NetCliente>();
            using (OleDbConnection connect =(OleDbConnection) NetConexao.Instance().GetSimeConnect())
            {
                connect.Open();
                OleDbCommand command = new OleDbCommand(SQL, connect);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retorno.Add(MontaCliente(dr));
                    }
                    
                }
            }
            return retorno;
        }

        /// <summary>
        /// Monta um cliente a partir dos dados repassados do DataReader
        /// </summary>
        /// <param name="dr">Data reader com os dados do cliente</param>
        /// <returns>Cliente com os dados preenchidos.</returns>
        private NetCliente MontaCliente(OleDbDataReader dr)
        {
            NetCliente cliente = new NetCliente();
            
            
            cliente.Cod = Int64.Parse( dr["cod_cliente"].ToString());
            cliente.Nome = dr["Nome"].ToString();
            //Incompleto para ser realizado o trabalho de BDNC primeiro
            //....
            cliente.Bairro = dr["bairro"].ToString();
            cliente.Cep = dr["Cep"].ToString();
            cliente.Cidade = dr["cidade"].ToString();
            cliente.Classificacao = dr["classificação"].ToString();
            return cliente;
            
        }

        /// <summary>
        /// Exlui um cliente do banco de dados.
        /// </summary>
        /// <param name="t">Cliente que será exluido</param>
        public void Excluir(NetCliente t)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Persiste os dados de um cliente no banco de dados.
        /// </summary>
        /// <param name="cliente">Cliente que terá os dados persistidos</param>
        /// <returns>Cliente após dados persistidos</returns>
        public NetCliente Salvar(NetCliente cliente)
        {

            throw new NotImplementedException();
        }
    }
}
