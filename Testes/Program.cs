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

            DAOItemVenda dao = new DAOItemVenda();
            var lista = dao.ItemBonificado(new DateTime(2000, 01,01), new DateTime(2000, 01, 01), 6190, 77);
            Int64 q = 0;

            foreach (var item in lista)
            {
                q += item.Quantidade;
            }
            Console.WriteLine("Foram vendidos " + q + " unidades do item " + lista[0].Id_produto + " para o cliente do id " + 77);

            Console.ReadKey();
        }
    }
}
