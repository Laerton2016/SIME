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
    
    public partial class TESPECIE
    {
        public TESPECIE()
        {
            this.TCAIXA = new HashSet<TCAIXA>();
            this.TCONVENIO = new HashSet<TCONVENIO>();
            this.TFORMAPAGAMENTOALUGUEL = new HashSet<TFORMAPAGAMENTOALUGUEL>();
            this.TFORMAPAGAMENTOCTE = new HashSet<TFORMAPAGAMENTOCTE>();
            this.TFORMAPAGAMENTONFCE = new HashSet<TFORMAPAGAMENTONFCE>();
            this.TPAGAMENTOVENDAECF = new HashSet<TPAGAMENTOVENDAECF>();
            this.TPAGAR = new HashSet<TPAGAR>();
            this.TRECEBER = new HashSet<TRECEBER>();
        }
    
        public int CONTROLE { get; set; }
        public string ESPECIE { get; set; }
        public string OBS { get; set; }
        public string ASSOCIADAECF { get; set; }
        public string CODASSOCIADAECF { get; set; }
        public string PERMITECUPOMVINCULADO { get; set; }
        public string TIPOLANCAMENTOFINANCEIRO { get; set; }
        public string TIPOCARTAO { get; set; }
        public string NFCE { get; set; }
        public string ASSOCIACAONFCE { get; set; }
        public Nullable<int> ORDEMAPRESENTACAO { get; set; }
    
        public virtual ICollection<TCAIXA> TCAIXA { get; set; }
        public virtual ICollection<TCONVENIO> TCONVENIO { get; set; }
        public virtual ICollection<TFORMAPAGAMENTOALUGUEL> TFORMAPAGAMENTOALUGUEL { get; set; }
        public virtual ICollection<TFORMAPAGAMENTOCTE> TFORMAPAGAMENTOCTE { get; set; }
        public virtual ICollection<TFORMAPAGAMENTONFCE> TFORMAPAGAMENTONFCE { get; set; }
        public virtual ICollection<TPAGAMENTOVENDAECF> TPAGAMENTOVENDAECF { get; set; }
        public virtual ICollection<TPAGAR> TPAGAR { get; set; }
        public virtual ICollection<TRECEBER> TRECEBER { get; set; }
    }
}
