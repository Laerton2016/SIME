using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIME.Class.Conexoes
{
    public interface Iconexoes
    {
        IDbConnection GetContasConnect();
        IDbConnection GetSimeConnect();
        IDbConnection GetSmallConnect();

    }
}
