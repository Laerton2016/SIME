using ADODB;
using SIME;
using SIME.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestaSolucao
{
    public class Ajuste
    {
        private Conexao _conex;
        private Connection _conn;
        
        public Ajuste()
        {
            _conex = new Conexao();
            _conn = _conex.getDb4();
        }

        private void AjustaValor (float valor1, float valor2, Int64 id)
        {
            String SQL = "Update produtos set expr5 = " + valor1.ToString().Replace(',', '.') + ", expr7 =" + valor2.ToString().Replace(',', '.') + " where cod =" + id + ";";
            SQL = "Select expr5, expr7 from produtos where cod = " + id + ";";
            Recordset rs = new Recordset();
            rs.Open(SQL, _conn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic);
            rs.Fields[0].Value = valor1.ToString();
            rs.Fields[1].Value = valor2.ToString();
            rs.Update();
            rs.Close();
        }

        public void AjustarAll (float persentagem)
        {
            Produtos todos = new Produtos();
            List<string[]> lista = todos.getListaProdutos("%");
            Int64 id = 0;
            float valor1 = 0f, valor2 = 0f;
            bool confirma = false;
            foreach (var item in lista)
            {
                valor1 = float.Parse(item[4]);
                valor2 = float.Parse(item[5]);
                if (confirma)
                {
                    valor1 += valor1 * (persentagem/100);
                    valor2 += valor2 * (persentagem/100);
                }
               
                id = Int64.Parse(item[0]);
                if (id == 3986) {
                    confirma = true; 
                }
                AjustaValor(valor1, valor2, id);
                Console.WriteLine(id + " foi atualizado.");
                
            }

        }
    }
}
