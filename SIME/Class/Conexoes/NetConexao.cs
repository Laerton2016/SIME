using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using SIME.Class.Conexoes;
using System.Data;
using FirebirdSql.Data.FirebirdClient;


namespace SIME.Class
{
    /// <summary>
    /// Classe trata da conexão com o banco de dados
    /// <Autor>Laerton Marques de Figueiredo</Autor>
    /// <Data>15/01/2016</Data>
    /// </summary>
    public class NetConexao:ConexoesAbs
    {
        private OleDbConnection _simeconnect;
        private OleDbConnection _contas;
        private FbConnection _smallConect;
        
        protected static NetConexao instance;
        private String sime;
        private String contas;
        

        private NetConexao()
        {
            sime  = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _simeLocal + "BD4.mdb;Persist Security Info=False;Jet OLEDB:Database Password=''";
            contas = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Server.MapPath(" + _simeLocal + "contas.mdb);Persist Security Info=False;Jet OLEDB:Database Password=495798";
            _smallConect = new FbConnection();
            _contas = new OleDbConnection();
            _simeconnect = new OleDbConnection();
            
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
            
            return instance;
        }

        /// <summary>
        /// Método retorna uma cocnexão com o banco de dados DB4 do sime 
        /// </summary>
        /// <returns>Oledb Connection</returns>
        public override  IDbConnection GetSimeConnect()
        {
            if (_simeconnect.State == ConnectionState.Closed) _simeconnect.ConnectionString = sime;
            return _simeconnect;
        }
        /// <summary>
        /// Método retorna uma conexão com o banco de dados Small.GBD
        /// </summary>
        /// <returns>Oldb Connection</returns>
        public override IDbConnection GetSmallConnect()
        {
            if (_smallConect.State == ConnectionState.Closed) _smallConect.ConnectionString=_smallLocal;
            return _smallConect;
        }

        /// <summary>
        /// Método retona uma conexão com o banco de dados contas
        /// </summary>
        /// <returns>Oledb Connection</returns>
        public override IDbConnection GetContasConnect()
        {
            if (_contas.State == ConnectionState.Closed) _contas.ConnectionString = contas;
            return _contas;
        }

    }
}