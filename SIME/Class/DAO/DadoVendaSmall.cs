using SIME.Class.primitivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;

namespace SIME.Class.DAO
{
    class DadoVendaSmall : DAOVenda
    {
        public NetVenda  SalvarSmall(NetVenda venda)
        {
            string SQL = "";
            using (var connect = (FbConnection)NetConexao.Instance().GetSmallConnect())
            {
                connect.Open();
                var transacao = connect.BeginTransaction();
                FbCommand command = new FbCommand(SQL, connect, transacao);

            }
            return venda;
        }
    }
}
