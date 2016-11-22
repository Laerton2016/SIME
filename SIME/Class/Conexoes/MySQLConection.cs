using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIME.Class.Conexoes
{
    public class MySQLConection : ConexoesAbs
    {
        protected static Iconexoes instance;

        public override IDbConnection GetContasConnect()
        {
            throw new Exception("Não dispoível para esse tipo de class.");
        }

        public override IDbConnection GetSimeConnect()
        {
            throw new NotImplementedException();
        }

        public override IDbConnection GetSmallConnect()
        {
            throw new Exception("Não dispoível para esse tipo de class.");
        }

        /// <summary>
        /// Cria uma instancia do objeto NetConexao
        /// </summary>
        /// <returns>Objeto netconexao instanciado</returns>
        public static MySQLConection Instance()
        {
            if (instance == null)
            {
                instance = new MySQLConection();
            }
            return (MySQLConection)instance;
        }

        public override IDbConnection GetSGBRConnect()
        {
            throw new NotImplementedException();
        }
    }
}
