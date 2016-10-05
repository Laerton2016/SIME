using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIME.Class.DAO;
using SIME.Class.ProdutoClass;
using SIME.Class;

namespace Nteste
{
    class Program
    {
        static void Main(string[] args)
        {
            FronteCamapanha campanha = new FronteCamapanha();
            var produto = campanha.BuscaProduto(6190);
            var produto1 = campanha.BuscaProduto(6804);
            var produto2 = campanha.BuscaProduto(6660);
            var produto3 = campanha.BuscaProduto(6805);
            Console.Write(produto + "" + produto1 + "" + produto2 + "" + produto3);
            Console.ReadKey();

        }
    }
}
