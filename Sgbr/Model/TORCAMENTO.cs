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
    
    public partial class TORCAMENTO
    {
        public TORCAMENTO()
        {
            this.TITEMORCAMENTOGRADE = new HashSet<TITEMORCAMENTOGRADE>();
            this.TITEMORCAMENTOSERIAL = new HashSet<TITEMORCAMENTOSERIAL>();
            this.TITENSORCAMENTO = new HashSet<TITENSORCAMENTO>();
        }
    
        public int CONTROLE { get; set; }
        public int CODCLIENTE { get; set; }
        public string NOMECLIENTE { get; set; }
        public string ENDERECO { get; set; }
        public string NUMERO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string COMPLEMENTO { get; set; }
        public string TELEFONE { get; set; }
        public string CELULAR { get; set; }
        public string EMAIL { get; set; }
        public string RG { get; set; }
        public int CODFUNCIONARIO { get; set; }
        public string FUNCIONARIO { get; set; }
        public Nullable<System.DateTime> DATA { get; set; }
        public Nullable<System.TimeSpan> HORA { get; set; }
        public Nullable<System.DateTime> DATAHORACADASTRO { get; set; }
        public string CONDICAOPAGAMENTO { get; set; }
        public string OBSERVACAO { get; set; }
        public Nullable<decimal> VALOR { get; set; }
        public Nullable<decimal> DESCONTO { get; set; }
        public Nullable<decimal> VALORTOTAL { get; set; }
        public string TIPODESCONTO { get; set; }
        public Nullable<decimal> ACRESCIMO { get; set; }
        public string SERIEECF { get; set; }
        public string TIPOECF { get; set; }
        public string MARCAECF { get; set; }
        public string MODELOECF { get; set; }
        public Nullable<int> COO { get; set; }
        public string TITULODAV { get; set; }
        public Nullable<int> COOVINCULADO { get; set; }
        public Nullable<int> NUMEROECF { get; set; }
        public Nullable<System.DateTime> DATAVENCIMENTO { get; set; }
        public Nullable<int> DIASVENCIMENTO { get; set; }
        public string CONTROLEVARCHAR { get; set; }
        public Nullable<int> CODSEQUENCIA { get; set; }
        public string CANCELADO { get; set; }
        public string STATUS { get; set; }
        public string TIPOCLIENTE { get; set; }
        public string MESCLAR { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string MD5DAV { get; set; }
        public Nullable<int> CODNFE { get; set; }
        public string INDICADOR { get; set; }
        public Nullable<int> CODVENDEDOR { get; set; }
        public string VENDEDOR { get; set; }
    
        public virtual TCLIENTE TCLIENTE { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO1 { get; set; }
        public virtual ICollection<TITEMORCAMENTOGRADE> TITEMORCAMENTOGRADE { get; set; }
        public virtual ICollection<TITEMORCAMENTOSERIAL> TITEMORCAMENTOSERIAL { get; set; }
        public virtual ICollection<TITENSORCAMENTO> TITENSORCAMENTO { get; set; }
        public virtual TSEQUENCIA TSEQUENCIA { get; set; }
    }
}
