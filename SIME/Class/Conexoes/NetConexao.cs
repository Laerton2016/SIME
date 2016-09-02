using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using SIME.Class.Conexoes;
using System.Data;

namespace SIME.Class
{
    /// <summary>
    /// Classe trata da conexão com o banco de dados
    /// <Autor>Laerton Marques de Figueiredo</Autor>
    /// <Data>15/01/2016</Data>
    /// </summary>
    public class NetConexao: ConexoesAbs
    {
        private OleDbConnection _simeconnect;
        private OleDbConnection _contas;
        private OleDbConnection _smallConect;
        
        
        private NetConexao()
        {
            String sime = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _simeRede + "BD4.mdb;Persist Security Info=False;Jet OLEDB:Database Password=''";
            String contas = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Server.MapPath(" + _simeRede + "contas.mdb);Persist Security Info=False;Jet OLEDB:Database Password=495798";
            _simeconnect = new OleDbConnection(sime);
            _smallConect = new OleDbConnection(_smallRede);
            _contas = new OleDbConnection(contas);
        }

        /// <summary>
        /// Cria uma instancia do objeto NetConexao
        /// </summary>
        /// <returns>Objeto netconexao instanciado</returns>
        public static NetConexao Instance()
        {
            if (instance == null)
            {
                instance = new NetConexao();
            }
            return (NetConexao) instance;
        }

        /// <summary>
        /// Método retorna uma cocnexão com o banco de dados DB4 do sime 
        /// </summary>
        /// <returns>Oledb Connection</returns>
        public override IDbConnection GetSimeConnect()
        {
            return _simeconnect;
        }
        /// <summary>
        /// Método retorna uma conexão com o banco de dados Small.GBD
        /// </summary>
        /// <returns>Oldb Connection</returns>
        public override IDbConnection GetSmallConnect()
        {
            return _smallConect;
        }

        /// <summary>
        /// Método retona uma conexão com o banco de dados contas
        /// </summary>
        /// <returns>Oledb Connection</returns>
        public override IDbConnection GetContasConnect()
        {
            return _contas;
        }

    }
}