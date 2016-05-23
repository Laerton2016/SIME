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

        private void coletadados()
        {
            ADODB.Recordset dados = new ADODB.Recordset();
            ADODB.Recordset itens = new ADODB.Recordset();
            String SQL = "SELECT * FROM SAÍDA WHERE (COD_SAI = " + _id + ");";
            String SQLProdutos = "SELECT COD, ESTOQUE FORM PRODUTOS;";
            //Buscando os itens
            dados.Open(SQL, new Conexao().getDb4(), ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);
            itens.Open(SQLProdutos, new Conexao().getDb4(), ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

            while (!(dados.EOF || dados.BOF))
            {
                itens.Find("cod =" + dados.Fields["[cod do CD]"].Value, 0, ADODB.SearchDirectionEnum.adSearchForward);
                if (!(itens.BOF || itens.EOF)) { itens.Fields["Estoque"].Value = Convert.ToInt64(itens.Fields["Estoque"].Value) + Convert.ToInt64(dados.Fields["Qunatidade"].Value); }
                dados.MoveNext();
            }

            //EXcluindo ITENS
            SQL = "DELETE FROM SAÍDA WHERE (COD_SAI = " + _id + ");";
            dados.Close();
            dados.Open(SQL, new Conexao().getDb4(), ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

            //Excluindo capa
            SQL = "DELETE FROM cod_sai WHERE(COD_SAI = " + _id + ");";
            dados.Close();
            dados.Open(SQL, new Conexao().getDb4(), ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

        }
    }
}