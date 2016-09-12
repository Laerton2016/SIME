using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIME.Class;
using WindowsFormsApplication2;
using TestaSolucao.nfE;
using ADODB;
using System.Threading;
using SIME.Class.DAO;
using SIME.Class.ProdutoClass;

namespace TestaSolucao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               // SIME.Class.DAO.DAOProduto dao = new DAOProduto();
                //NetProduto produto = dao.Buscar(21);
                //Console.WriteLine(produto);
                //Console.Read();
                new SIME.Estorna(39741);
                //SIME.Estorna estorno = new SIME.Estorna();
                //estorno.ajustaprec(1.13, 48);
                //Ajuste ajuste = new Ajuste();
                //ajuste.AjustarAll(3);
                Console.WriteLine("Cancelamento de venda realizado.");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }

    
}
