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
    
    public partial class TIMPOSTO
    {
        public TIMPOSTO()
        {
            this.TEMITENTE = new HashSet<TEMITENTE>();
        }
    
        public int CONTROLE { get; set; }
        public Nullable<System.DateTime> DATAEHORACADASTRO { get; set; }
        public Nullable<decimal> PERCICMS { get; set; }
        public Nullable<decimal> PERCISS { get; set; }
        public Nullable<decimal> IRPJICMS { get; set; }
        public Nullable<decimal> IRPJISS { get; set; }
        public Nullable<decimal> CSLLISS { get; set; }
        public Nullable<decimal> CSLLICMS { get; set; }
        public Nullable<decimal> COFINSICMS { get; set; }
        public Nullable<decimal> COFINSISS { get; set; }
        public Nullable<decimal> PISPASEPICMS { get; set; }
        public Nullable<decimal> PISPASEPISS { get; set; }
        public Nullable<decimal> CPPICMS { get; set; }
        public Nullable<decimal> CPPISS { get; set; }
        public Nullable<decimal> ALIQUOTATOTALISS { get; set; }
        public Nullable<decimal> ALIQUOTATOTALICMS { get; set; }
        public string MESVALIDADE { get; set; }
        public string ANOVALIDADE { get; set; }
        public string DESCRICAO { get; set; }
    
        public virtual ICollection<TEMITENTE> TEMITENTE { get; set; }
    }
}