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
    
    public partial class TITEMPEDIDOVENDA
    {
        public TITEMPEDIDOVENDA()
        {
            this.TITEMPEDIDOVENDAGRADE = new HashSet<TITEMPEDIDOVENDAGRADE>();
            this.TITEMPEDIDOVENDASERIAL = new HashSet<TITEMPEDIDOVENDASERIAL>();
        }
    
        public int CONTROLE { get; set; }
        public int CODPEDIDOVENDA { get; set; }
        public System.DateTime DATAHORACADASTRO { get; set; }
        public int CODPRODUTO { get; set; }
        public string PRODUTO { get; set; }
        public decimal QTDE { get; set; }
        public string UN { get; set; }
        public decimal VALORUNITARIO { get; set; }
        public decimal VALORDESCONTO { get; set; }
        public decimal VALORACRESCIMO { get; set; }
        public decimal PERCDESCONTO { get; set; }
        public decimal PERCACRESCIMO { get; set; }
        public decimal TOTALLIQUIDO { get; set; }
        public string SITUACAOTRIBUTARIA { get; set; }
        public decimal ALIQUOTA { get; set; }
        public string CANCELADO { get; set; }
        public int DECIMAISQTDE { get; set; }
        public int DECIMAISVALORUNITARIO { get; set; }
        public Nullable<int> CODITEM { get; set; }
        public decimal VALORDESCONTOUNITARIO { get; set; }
        public decimal VALORACRESCIMOUNITARIO { get; set; }
        public Nullable<int> CONTROLEORIGEMMESCLAGEM { get; set; }
        public string NUMERODAV { get; set; }
        public string MD5DAV { get; set; }
        public string MESCLAR { get; set; }
        public string STATUS { get; set; }
        public Nullable<decimal> QTDECONVERTIDA { get; set; }
        public string UNCONVERTIDA { get; set; }
        public string OBS { get; set; }
    
        public virtual TESTOQUE TESTOQUE { get; set; }
        public virtual ICollection<TITEMPEDIDOVENDAGRADE> TITEMPEDIDOVENDAGRADE { get; set; }
        public virtual ICollection<TITEMPEDIDOVENDASERIAL> TITEMPEDIDOVENDASERIAL { get; set; }
    }
}