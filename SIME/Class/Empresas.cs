using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ADODB;

namespace SIME.Class
{
    public class Empresas
    {
        public Empresas() { }
        public void montaComboEmpresas(DropDownList combEmpresas) 
        {
            combEmpresas.Items.Clear();
            Recordset rsDados = new Recordset();
            Connection conex = new Conexao().getContas();
            String sql = "SELECT DESTINO.* FROM DESTINO ORDER BY DESTINO.Descrição; ";
            rsDados.Open(sql, conex, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic);
            while (!(rsDados.BOF|| rsDados.EOF))
            {
                combEmpresas.Items.Add(new ListItem(rsDados.Fields["Descrição"].Value.ToString().ToUpper(), rsDados.Fields["cod"].Value.ToString()));
                rsDados.MoveNext();
            }
        }
    }
}