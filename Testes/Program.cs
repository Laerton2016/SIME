using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIME.Class.DAO;
using SIME.Class.ProdutoClass;
using SIME.Class.primitivo;
using System.Dynamic;
using System.IO;
using System.Runtime.Serialization.Json;



namespace Testes
{
    class Program
    {


        static void Main(string[] args)
        {

            
            
            DAOVenda dao = new DAOVenda();
            NetVenda venda = dao.Buscar(24101);
            CassandraItem dao1 = new CassandraItem();
            venda = dao1.Buscar(24101);
            foreach (var item in venda.Itens)
            {
                Console.WriteLine(venda.Itens);
            }
            
            Console.Read();

        }
    }
}
