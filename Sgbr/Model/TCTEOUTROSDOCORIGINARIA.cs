//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sgbr.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TCTEOUTROSDOCORIGINARIA
    {
        public int CONTROLE { get; set; }
        public string TIPODOCUMENTO { get; set; }
        public string DESCRICAO { get; set; }
        public string NUMERO { get; set; }
        public Nullable<System.DateTime> DATAEMISSAO { get; set; }
        public Nullable<decimal> VALORDOCUMENTO { get; set; }
        public Nullable<System.DateTime> DATAENTREGA { get; set; }
        public Nullable<int> CODCTE { get; set; }
    
        public virtual TCTE TCTE { get; set; }
    }
}