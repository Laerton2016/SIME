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
    
    public partial class TUNIDADEMEDIDA
    {
        public TUNIDADEMEDIDA()
        {
            this.TESTOQUE = new HashSet<TESTOQUE>();
            this.TITEMVENDAECF = new HashSet<TITEMVENDAECF>();
        }
    
        public int CONTROLE { get; set; }
        public string DESCRICAO { get; set; }
        public Nullable<System.DateTime> DATAEHORACADASTRO { get; set; }
        public string FRACIONADO { get; set; }
    
        public virtual ICollection<TESTOQUE> TESTOQUE { get; set; }
        public virtual ICollection<TITEMVENDAECF> TITEMVENDAECF { get; set; }
    }
}
