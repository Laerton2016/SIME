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
    
    public partial class TCONVENIO
    {
        public TCONVENIO()
        {
            this.TCLIENTE = new HashSet<TCLIENTE>();
        }
    
        public int CONTROLE { get; set; }
        public string EMPRESA { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string CNPJ { get; set; }
        public string PESSOARESPONSAVEL { get; set; }
        public Nullable<int> DIAPAGAMENTO { get; set; }
        public string ENDERECO { get; set; }
        public string NUMERO { get; set; }
        public Nullable<int> CODCIDADE { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string TELEFONE { get; set; }
        public string FAX { get; set; }
        public string EMAIL { get; set; }
        public string SITE { get; set; }
        public Nullable<int> QTDEFUNCIONARIOS { get; set; }
        public Nullable<decimal> LIMITECREDITO { get; set; }
        public string OBS { get; set; }
        public string PAIS { get; set; }
        public Nullable<int> CODESPECIE { get; set; }
        public string ESPECIE { get; set; }
    
        public virtual TCIDADE TCIDADE { get; set; }
        public virtual ICollection<TCLIENTE> TCLIENTE { get; set; }
        public virtual TESPECIE TESPECIE { get; set; }
    }
}