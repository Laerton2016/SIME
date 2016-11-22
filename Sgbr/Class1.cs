using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgbr
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Model.TCLIENTE sgbrcliente = new Model.TCLIENTE();
            Model.Entities ente = new Model.Entities();
            sgbrcliente = ente.TCLIENTE.Find(2);
            ente.TCLIENTE.Remove(sgbrcliente);
            ente.SaveChanges();
            Console.WriteLine(sgbrcliente.CLIENTE);
            Console.Read();
           
            
            
        }
    }
}
