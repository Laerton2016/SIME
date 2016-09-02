using SIME.Class.primitivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIME.Class.DAO
{
    public class DAOCliente : IDAO<NetCliente>
    {

        public NetCliente Buscar(long id)
        {
            String SQL = "Seletc * from clientes where cod_cliente = " + id + ";";
            return null;
                 
        }

        public void Excluir(NetCliente t)
        {
            throw new NotImplementedException();
        }

        public NetCliente Salvar(NetCliente t)
        {
            throw new NotImplementedException();
        }
    }
}
