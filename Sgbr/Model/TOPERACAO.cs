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
    
    public partial class TOPERACAO
    {
        public TOPERACAO()
        {
            this.TCTRC = new HashSet<TCTRC>();
            this.TVENDANFE = new HashSet<TVENDANFE>();
        }
    
        public int CONTROLE { get; set; }
        public string DESCRICAOOPERACAO { get; set; }
        public string TIPOOPERACAO { get; set; }
        public string CFOPDENTRO { get; set; }
        public string CFOPFORRA { get; set; }
        public string CFOPDENTROST { get; set; }
        public string CFOPFORRAST { get; set; }
        public string OBS { get; set; }
        public string MOVIMENTAESTOQUE { get; set; }
        public string MOVIMENTAFINANCEIRO { get; set; }
        public string DESCRICAOCFOPDENTRO { get; set; }
        public string DESCRICAOCFOPDENTROST { get; set; }
        public string DESCRICAOCFOPFORRA { get; set; }
        public string DESCRICAOCFOPFORRAST { get; set; }
        public string FINALIDADEOPERACAO { get; set; }
        public string MODULO { get; set; }
        public Nullable<decimal> ALIQUOTA { get; set; }
    
        public virtual ICollection<TCTRC> TCTRC { get; set; }
        public virtual ICollection<TVENDANFE> TVENDANFE { get; set; }
    }
}