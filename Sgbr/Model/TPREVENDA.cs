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
    
    public partial class TPREVENDA
    {
        public TPREVENDA()
        {
            this.TITEMPREVENDAGRADE = new HashSet<TITEMPREVENDAGRADE>();
            this.TITEMPREVENDASERIAL = new HashSet<TITEMPREVENDASERIAL>();
        }
    
        public int CONTROLE { get; set; }
        public string CLIENTE { get; set; }
        public Nullable<int> CODCLIENTE { get; set; }
        public Nullable<int> CODFUNCIONARIO { get; set; }
        public string FUNCIONARIO { get; set; }
        public Nullable<decimal> VALORTOTAL { get; set; }
        public Nullable<decimal> VALORACRESCIMO { get; set; }
        public Nullable<decimal> VALORDESCONTO { get; set; }
        public string CONTROLEVARCHAR { get; set; }
        public Nullable<System.DateTime> DATAHORACADASTRO { get; set; }
        public Nullable<int> CODSEQUENCIA { get; set; }
        public string CNPJCPF { get; set; }
        public string STATUS { get; set; }
        public string MESCLAR { get; set; }
        public string SENHAINTERNA { get; set; }
    
        public virtual TCLIENTE TCLIENTE { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO { get; set; }
        public virtual ICollection<TITEMPREVENDAGRADE> TITEMPREVENDAGRADE { get; set; }
        public virtual ICollection<TITEMPREVENDASERIAL> TITEMPREVENDASERIAL { get; set; }
    }
}