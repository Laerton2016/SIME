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
    
    public partial class TCTEDOCUMENTOANTERIOR
    {
        public TCTEDOCUMENTOANTERIOR()
        {
            this.TITEMDOCUMENTOANTERIORCTE = new HashSet<TITEMDOCUMENTOANTERIORCTE>();
        }
    
        public int CONTROLE { get; set; }
        public Nullable<int> CODCTE { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string IE { get; set; }
        public string UF { get; set; }
        public string NOME { get; set; }
        public string CHAVECTE { get; set; }
    
        public virtual TCTE TCTE { get; set; }
        public virtual ICollection<TITEMDOCUMENTOANTERIORCTE> TITEMDOCUMENTOANTERIORCTE { get; set; }
    }
}
