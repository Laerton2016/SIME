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
    
    public partial class TITEMCOTACAO
    {
        public int CONTROLE { get; set; }
        public string PRODUTO { get; set; }
        public Nullable<int> CODPRODUTO { get; set; }
        public Nullable<int> CODCOTACAO { get; set; }
        public Nullable<decimal> QTDE { get; set; }
        public string UNIDADE { get; set; }
        public string MARCADO { get; set; }
        public Nullable<decimal> PRECOCUSTO { get; set; }
        public Nullable<decimal> VALORTOTAL { get; set; }
        public Nullable<decimal> VALORDESCONTO { get; set; }
        public Nullable<int> CODPEDIDOCOMPRA { get; set; }
        public string REFERENCIA { get; set; }
    
        public virtual TCOTACAO TCOTACAO { get; set; }
    }
}
