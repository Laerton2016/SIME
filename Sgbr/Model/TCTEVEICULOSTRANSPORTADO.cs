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
    
    public partial class TCTEVEICULOSTRANSPORTADO
    {
        public int CONTROLE { get; set; }
        public Nullable<int> CODCTE { get; set; }
        public string CHASSI { get; set; }
        public string CODIGOCOR { get; set; }
        public string DESCRICAOCOR { get; set; }
        public string CODIGOMARCAMODELO { get; set; }
        public Nullable<decimal> VALORUNITARIO { get; set; }
        public Nullable<decimal> FRETE { get; set; }
    
        public virtual TCTE TCTE { get; set; }
    }
}
