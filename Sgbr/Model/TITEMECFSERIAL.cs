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
    
    public partial class TITEMECFSERIAL
    {
        public int CONTROLE { get; set; }
        public int CODPRODUTO { get; set; }
        public string PRODUTO { get; set; }
        public string SERIAL { get; set; }
        public decimal QTDE { get; set; }
        public int CODITEMECF { get; set; }
        public int CODSERIAL { get; set; }
        public string CANCELADO { get; set; }
        public System.DateTime DATAHORACADASTRO { get; set; }
        public int CODVENDAECF { get; set; }
        public Nullable<int> CONTROLENOPDV { get; set; }
        public string STATUS { get; set; }
    
        public virtual TESTOQUE TESTOQUE { get; set; }
        public virtual TITEMVENDAECF TITEMVENDAECF { get; set; }
        public virtual TVENDAECF TVENDAECF { get; set; }
        public virtual TSERIAL TSERIAL { get; set; }
    }
}
