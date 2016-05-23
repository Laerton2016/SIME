using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIME
{
    public class Estorna
    {
        private Int32 _id;
        List<Int64[]> produtos = new List<long[]>();
        public Estorna(Int32 id)
        {
            if (id <= 0) { throw new ArgumentException("Número da venda deve ser um valor positivo."); }
            this._id = id;
            coletadados();
        }
        public Estorna()
        {

        }

        public void Ajustapecos(double valor, double taxa_max, double taxa_min)
        {
            String SQL = "SELECT PRODUTOS.Cod, PRODUTOS.Custo, PRODUTOS.Expr5, PRODUTOS.Expr7, PRODUTOS.Expr6 FROM PRODUTOS WHERE (((PRODUTOS.Expr5) Is Not Null) AND ((PRODUTOS.Expr7) Is Not Null) AND ((PRODUTOS.Expr6) Is Not Null));";

        }

        public bool ajustaprecos(double valor, int grupo)
        {
            String SQL = "UPDATE produtos SET Expr5 = Expr5 * " + valor + ", Expr7 = Expr7 * " + valor + ", Expr6 = Expr6 *" + valor + " WHERE (((produtos.tipo)=" + grupo + "));";
            ADODB.Recordset dados = new ADODB.Recordset();
            dados.Open(SQL, new Conexao().getDb4(), ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

            return true;
        }
        private void coletadados()
        {
            ADODB.Recordset dados = new ADODB.Recordset();
            ADODB.Recordset itens = new ADODB.Recordset();
            String SQL = "SELECT * FROM SAÍDA WHERE (COD_SAI = " + _id + ");";
            String SQLProdutos = "SELECT * FROM PRODUTOS;";
            //Buscando os itens
            dados.Open(SQL, new Conexao().getDb4(), ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);
            itens.Open(SQLProdutos, new Conexao().getDb4(), ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

            while (!(dados.EOF || dados.BOF))
            {
                itens.Find("cod =" + dados.Fields[dados.Fields[0].Name].Value, 0, ADODB.SearchDirectionEnum.adSearchForward);
                if (!(itens.BOF || itens.EOF))
                {
                    itens.Fields[36].Value = Convert.ToInt64(itens.Fields[36].Value) + Convert.ToInt64(dados.Fields[1].Value);
                    itens.Update();
                }
                dados.MoveNext();
            }

            //EXcluindo ITENS
            SQL = "DELETE FROM SAÍDA WHERE (COD_SAI = " + _id + ");";
            dados.Close();
            dados.Open(SQL, new Conexao().getDb4(), ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

            //Excluindo capa
            SQL = "DELETE FROM cod_sai WHERE(COD_SAI = " + _id + ");";
            dados.Open(SQL, new Conexao().getDb4(), ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

        }
    }
}