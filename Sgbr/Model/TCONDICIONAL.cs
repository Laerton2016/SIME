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
    
    public partial class TCONDICIONAL
    {
        public TCONDICIONAL()
        {
            this.TITEMCONDICIONAL = new HashSet<TITEMCONDICIONAL>();
            this.TITEMCONDICIONALGRADE = new HashSet<TITEMCONDICIONALGRADE>();
            this.TITEMCONDICIONALSERIAL = new HashSet<TITEMCONDICIONALSERIAL>();
        }
    
        public int CONTROLE { get; set; }
        public int CODCLIENTE { get; set; }
        public string CLIENTE { get; set; }
        public string RG { get; set; }
        public string TELEFONE { get; set; }
        public string LOCALENTREGA { get; set; }
        public decimal VALORTOTAL { get; set; }
        public Nullable<int> QTDEITENS { get; set; }
        public Nullable<System.DateTime> DATADEVOLUCAO { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string COMPLEMENTO { get; set; }
        public Nullable<int> CODCIDADE { get; set; }
        public string CIDADE { get; set; }
        public string CEP { get; set; }
        public string OBSERVACAO { get; set; }
        public Nullable<int> COO { get; set; }
        public Nullable<int> CCF { get; set; }
        public string SERIEECF { get; set; }
        public string MARCAECF { get; set; }
        public string MODELOECF { get; set; }
        public string TITULODAV { get; set; }
        public Nullable<int> COOVINCULADO { get; set; }
        public Nullable<int> NUMEROECF { get; set; }
        public Nullable<int> CODFUNCIONARIO { get; set; }
        public string FUNCIONARIO { get; set; }
        public string EMAIL { get; set; }
        public string UF { get; set; }
        public string CELULAR { get; set; }
        public string NUMERO { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string CONTROLEVARCHAR { get; set; }
        public Nullable<int> CODSEQUENCIA { get; set; }
        public string CANCELADO { get; set; }
        public Nullable<System.DateTime> DATAPREVISTADEVOLUCAO { get; set; }
        public Nullable<System.DateTime> DATAEHORACADASTRO { get; set; }
        public string SITUACAO { get; set; }
        public string TIPOECF { get; set; }
        public string MESCLAR { get; set; }
        public string STATUS { get; set; }
        public string MD5DAV { get; set; }
        public Nullable<System.DateTime> DATA { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public Nullable<int> CODNFE { get; set; }
        public Nullable<int> CODVENDEDOR { get; set; }
        public string VENDEDOR { get; set; }
    
        public virtual TCIDADE TCIDADE { get; set; }
        public virtual TCLIENTE TCLIENTE { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO { get; set; }
        public virtual TSEQUENCIA TSEQUENCIA { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO1 { get; set; }
        public virtual ICollection<TITEMCONDICIONAL> TITEMCONDICIONAL { get; set; }
        public virtual ICollection<TITEMCONDICIONALGRADE> TITEMCONDICIONALGRADE { get; set; }
        public virtual ICollection<TITEMCONDICIONALSERIAL> TITEMCONDICIONALSERIAL { get; set; }
    }
}