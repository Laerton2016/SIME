using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIME.Class;
using WindowsFormsApplication2;
using TestaSolucao.nfE;
using ADODB;
using System.Threading;

namespace TestaSolucao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new SIME.Estorna(39680);
                //SIME.Estorna estorno = new SIME.Estorna();
                // estorno.ajustaprec(1.13, 48);
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
