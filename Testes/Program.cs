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
using System.Data.OleDb;

namespace Testes
{
    class Program
    {


        static void Main(string[] args)
        {
            
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\agenda2006\final\dados.mdb; Jet OLEDB:Database Password = 495798; ";
            String conectioMySQL = @"";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                String SQL = "Select * from telefones;";
                OleDbCommand command = new OleDbCommand(SQL, connection);
                OleDbDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    using (OleDbConnection conMySQL = new OleDbConnection(conectioMySQL))
                    {

                    }
                }
                dr.Close();
            }
            
            /*
            DAOItemVenda dao = new DAOItemVenda();
            var lista = dao.ItemBonificado(new DateTime(2000, 01,01), new DateTime(2000, 01, 01), 6190, 77);
            Int64 q = 0;

            foreach (var item in lista)
            {
                q += item.Quantidade;
            }
            Console.WriteLine("Foram vendidos " + q + " unidades do item " + lista[0].Id_produto + " para o cliente do id " + 77);

            Console.ReadKey();
            */
        }
    }
}
