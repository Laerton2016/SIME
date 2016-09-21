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
        protected static readonly string _smallRede = @"User=SYSDBA;" + "Password=masterkey;" + "Database=small.gdb;" + "DataSource=100.0.0.250;" + "Port=3050;" + "Dialect=3;" + "Charset=NONE;" + "Role=;" + "Connection lifetime=15;" + "Pooling=true;" + "MinPoolSize=0;" + "MaxPoolSize=50;" + "Packet Size=8192;" + "ServerType=0";
        protected static readonly string _simeLocal = @"\dados\";
        protected static readonly string _smallLocal = @"User=SYSDBA;" + "Password=masterkey;" + "Database=small.gdb;" + "DataSource=localhost;" + "Port=3050;" + "Dialect=3;" + "Charset=NONE;" + "Role=;" + "Connection lifetime=15;" + "Pooling=true;" + "MinPoolSize=0;" +"MaxPoolSize=50;" +"Packet Size=8192;" +"ServerType=0";
        protected static readonly string _simeMysql = "";
        
        protected ConexoesAbs() { }

        public abstract IDbConnection GetContasConnect();
        public abstract IDbConnection GetSimeConnect();
        public abstract IDbConnection GetSmallConnect();


    }
}
