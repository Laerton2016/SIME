using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIME.Class.Conexoes
{
    public abstract class ConexoesAbs : Iconexoes
    {
        //Instruções deconexões do banco de dados
        protected static readonly string _simeRede = @"\\100.0.0.254\c\novo\";
        /// <summary>
        /// Instrução do banco de dados Small em rede
        /// </summary>
        protected static readonly string _smallRede = @"User=SYSDBA;" + "Password=masterkey;" + "Database=small.gdb;" + "DataSource=100.0.0.250;" + "Port=3050;" + "Dialect=3;" + "Charset=NONE;" + "Role=;" + "Connection lifetime=15;" + "Pooling=true;" + "MinPoolSize=0;" + "MaxPoolSize=50;" + "Packet Size=8192;" + "ServerType=0";
        /// <summary>
        /// Instruções do banco de dados sime local
        /// </summary>
        protected static readonly string _simeLocal = @"e:\dados\";
        /// <summary>
        /// Instruções do banco de dados small local
        /// </summary>
        protected static readonly string _smallLocal = @"User=SYSDBA;" + "Password=masterkey;" + "Database=small.gdb;" + "DataSource=localhost;" + "Port=3050;" + "Dialect=3;" + "Charset=NONE;" + "Role=;" + "Connection lifetime=15;" + "Pooling=true;" + "MinPoolSize=0;" +"MaxPoolSize=50;" +"Packet Size=8192;" +"ServerType=0";
        protected static readonly string _simeMysql = "";

        protected static readonly string _sgbrRede = @"User=SYSDBA;" + "Password=masterkey;" + @"Database=c:\base\BASESGMASTER.fdb;" + "DataSource=100.0.0.250;" + "Port=3050;" + "Dialect=3;" + "Charset=NONE;" + "Role=;" + "Connection lifetime=15;" + "Pooling=true;" + "MinPoolSize=0;" + "MaxPoolSize=50;" + "Packet Size=8192;" + "ServerType=0";

        protected static readonly string sime  = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _simeLocal + "BD4.mdb;Persist Security Info=False;Jet OLEDB:Database Password=''";

        protected static readonly string contas = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _simeLocal + "contas.mdb;Persist Security Info=False;Jet OLEDB:Database Password=495798";

        protected ConexoesAbs() { }

        public abstract IDbConnection GetContasConnect();
        public abstract IDbConnection GetSimeConnect();
        public abstract IDbConnection GetSmallConnect();
        public abstract IDbConnection GetSGBRConnect();

    }
}
