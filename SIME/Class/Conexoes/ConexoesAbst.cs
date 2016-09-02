using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIME.Class.Conexoes
{
    public abstract class ConexoesAbs: Iconexoes
    {
        //Instruções deconexões do banco de dados
        protected readonly string _simeRede = @"\\100.0.0.254\c\novo\";
        protected readonly string _smallRede = @"Dsn=Small;Driver={Firebird/InterBase(r) driver};dbname=100.0.0.250:C:/base/SMALL.GDB;charset=NONE;uid=SYSDBA";
        protected readonly string _simeLocal = @"~\dados\";
        protected readonly string _smallLocal = @"Dsn=Small;Driver={Firebird/InterBase(r) driver};dbname=100.0.0.250:C:/base/SMALL.GDB;charset=NONE;uid=SYSDBA";
        protected readonly string _simeMysql = "";
        protected static Iconexoes instance;
        
        protected ConexoesAbs() { }

        public abstract IDbConnection GetContasConnect();
        public abstract IDbConnection GetSimeConnect();
        public abstract IDbConnection GetSmallConnect();
       

    }
}
