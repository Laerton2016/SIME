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
    
    public partial class TADICIONALPRODUTO
    {
        public TADICIONALPRODUTO()
        {
            this.TITEMCOMANDAADICIONAL = new HashSet<TITEMCOMANDAADICIONAL>();
        }
    
        public int CONTROLE { get; set; }
        public string ADICIONAL { get; set; }
        public Nullable<decimal> VALOR { get; set; }
    
        public virtual ICollection<TITEMCOMANDAADICIONAL> TITEMCOMANDAADICIONAL { get; set; }
    }
}