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
    
    public partial class TITEMPREVENDASERIAL
    {
        public int CONTROLE { get; set; }
        public string PRODUTO { get; set; }
        public Nullable<int> CODPRODUTO { get; set; }
        public string SERIAL { get; set; }
        public Nullable<decimal> QTDE { get; set; }
        public Nullable<int> CODPREVENDA { get; set; }
        public Nullable<int> CODITEMPREVENDA { get; set; }
        public Nullable<int> CODSERIAL { get; set; }
        public Nullable<System.DateTime> DATAHORACADASTRO { get; set; }
        public string CANCELADO { get; set; }
    
        public virtual TITEMPREVENDA TITEMPREVENDA { get; set; }
        public virtual TPREVENDA TPREVENDA { get; set; }
        public virtual TSERIAL TSERIAL { get; set; }
    }
}
