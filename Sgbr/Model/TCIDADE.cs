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
    
    public partial class TCIDADE
    {
        public TCIDADE()
        {
            this.TALUGUEL = new HashSet<TALUGUEL>();
            this.TCLIENTE = new HashSet<TCLIENTE>();
            this.TCONDICIONAL = new HashSet<TCONDICIONAL>();
            this.TCONTABANCARIA = new HashSet<TCONTABANCARIA>();
            this.TCONVENIO = new HashSet<TCONVENIO>();
            this.TEMITENTE = new HashSet<TEMITENTE>();
            this.TPEDIDOVENDA = new HashSet<TPEDIDOVENDA>();
            this.TTRANSPORTADORA = new HashSet<TTRANSPORTADORA>();
            this.TVENDAECF = new HashSet<TVENDAECF>();
        }
    
        public int CONTROLE { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string PAIS { get; set; }
        public Nullable<int> CODCIDADE { get; set; }
        public Nullable<int> CODIGOPAIS { get; set; }
    
        public virtual ICollection<TALUGUEL> TALUGUEL { get; set; }
        public virtual ICollection<TCLIENTE> TCLIENTE { get; set; }
        public virtual ICollection<TCONDICIONAL> TCONDICIONAL { get; set; }
        public virtual ICollection<TCONTABANCARIA> TCONTABANCARIA { get; set; }
        public virtual ICollection<TCONVENIO> TCONVENIO { get; set; }
        public virtual ICollection<TEMITENTE> TEMITENTE { get; set; }
        public virtual ICollection<TPEDIDOVENDA> TPEDIDOVENDA { get; set; }
        public virtual ICollection<TTRANSPORTADORA> TTRANSPORTADORA { get; set; }
        public virtual ICollection<TVENDAECF> TVENDAECF { get; set; }
    }
}
