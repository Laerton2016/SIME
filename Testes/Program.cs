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
using SIME.Class.Conexoes;

namespace Testes
{
    class Program
    {


        static void Main(string[] args)
        {
            CassandraItem dao = new CassandraItem();
            NetVenda venda = ConexRedis.ResgataCarrinhRedis(1);
            ConexRedis.GravaCarrinhoRedis(1,venda,1);
            Console.WriteLine(venda.Id);
            Console.Read();

            

        }
    }
}
