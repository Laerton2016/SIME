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
    
    public partial class TSERIAL
    {
        public TSERIAL()
        {
            this.TITEMCONDICIONALSERIAL = new HashSet<TITEMCONDICIONALSERIAL>();
            this.TITEMECFSERIAL = new HashSet<TITEMECFSERIAL>();
            this.TITEMNFCESERIAL = new HashSet<TITEMNFCESERIAL>();
            this.TITEMORCAMENTOSERIAL = new HashSet<TITEMORCAMENTOSERIAL>();
            this.TITEMPEDIDOVENDASERIAL = new HashSet<TITEMPEDIDOVENDASERIAL>();
            this.TITEMPREVENDASERIAL = new HashSet<TITEMPREVENDASERIAL>();
            this.TITENNFESERIAL = new HashSet<TITENNFESERIAL>();
        }
    
        public int CONTROLE { get; set; }
        public string SERIAL { get; set; }
        public int CODPRODUTO { get; set; }
        public string PRODUTO { get; set; }
        public string DISPONIVEL { get; set; }
    
        public virtual ICollection<TITEMCONDICIONALSERIAL> TITEMCONDICIONALSERIAL { get; set; }
        public virtual ICollection<TITEMECFSERIAL> TITEMECFSERIAL { get; set; }
        public virtual ICollection<TITEMNFCESERIAL> TITEMNFCESERIAL { get; set; }
        public virtual ICollection<TITEMORCAMENTOSERIAL> TITEMORCAMENTOSERIAL { get; set; }
        public virtual ICollection<TITEMPEDIDOVENDASERIAL> TITEMPEDIDOVENDASERIAL { get; set; }
        public virtual ICollection<TITEMPREVENDASERIAL> TITEMPREVENDASERIAL { get; set; }
        public virtual ICollection<TITENNFESERIAL> TITENNFESERIAL { get; set; }
    }
}