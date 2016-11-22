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
    
    public partial class TNOTACONSUMIDOR
    {
        public TNOTACONSUMIDOR()
        {
            this.TITENNOTACONSUMIDOR = new HashSet<TITENNOTACONSUMIDOR>();
        }
    
        public int CONTROLE { get; set; }
        public string MODELO { get; set; }
        public string SERIE { get; set; }
        public string CLIENTE { get; set; }
        public string ENDERECO { get; set; }
        public Nullable<System.DateTime> DATAEMISSAO { get; set; }
        public Nullable<decimal> TOTALNOTA { get; set; }
        public string RAZAOSOCIALEMITENTE { get; set; }
        public string ENDERECOEMITENTE { get; set; }
        public string CEPEMITENTE { get; set; }
        public string UFEMITENTE { get; set; }
        public string FONEEMITENTE { get; set; }
        public string CNPJEMITENTE { get; set; }
        public string IEEMITENTE { get; set; }
        public Nullable<int> CODCLIENTE { get; set; }
        public Nullable<int> CODNOTADACONCUMIDOR { get; set; }
        public string DESCRICAOOPERACAO { get; set; }
        public int NUMERONOTA { get; set; }
        public string CANCELADO { get; set; }
        public string CSTICMS { get; set; }
        public string CFOP { get; set; }
        public Nullable<decimal> VALORBASECALCULOICMS { get; set; }
        public Nullable<decimal> VALORICMS { get; set; }
        public Nullable<decimal> VALORREDUCAOBASECALCULO { get; set; }
        public Nullable<decimal> ALIQUOTAICMS { get; set; }
        public string SUBSERIE { get; set; }
        public Nullable<decimal> VALORISENTOOUNAOTRIBUTADO { get; set; }
        public Nullable<decimal> OUTROSVALORES { get; set; }
        public Nullable<decimal> VALORENTRADA { get; set; }
        public Nullable<int> CONTROLENOPDV { get; set; }
        public Nullable<int> CCF { get; set; }
        public Nullable<int> COO { get; set; }
        public Nullable<System.DateTime> DATAECF { get; set; }
        public Nullable<System.TimeSpan> HORAECF { get; set; }
        public Nullable<int> CODFUNCIONARIO { get; set; }
        public string FUNCIONARIO { get; set; }
        public Nullable<decimal> DESCONTO { get; set; }
        public string TIPODESCONTO { get; set; }
        public string FATURADA { get; set; }
        public string JAFATURADA { get; set; }
        public Nullable<System.DateTime> DATAEHORACADASTRO { get; set; }
        public Nullable<System.DateTime> DATAFATURADA { get; set; }
        public Nullable<System.TimeSpan> HORAFATURADA { get; set; }
        public Nullable<int> CODMODULO { get; set; }
        public string MODULO { get; set; }
        public Nullable<decimal> TROCO { get; set; }
        public Nullable<decimal> VALORRECEBIDO { get; set; }
        public Nullable<decimal> PESOBRUTO { get; set; }
        public Nullable<decimal> PESOLIQUIDO { get; set; }
        public string ESPECIE { get; set; }
        public Nullable<decimal> QTDECAIXA { get; set; }
        public string CIDADE { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string TELEFONE { get; set; }
        public string CELULAR { get; set; }
        public string BAIRRO { get; set; }
        public string NUMERO { get; set; }
        public string EMAIL { get; set; }
        public Nullable<int> CODESPECIE { get; set; }
        public Nullable<int> CODPLANOCONTA { get; set; }
        public string PLANOCONTA { get; set; }
        public Nullable<int> CODFORMAPAGAMENTO { get; set; }
        public string ESPECIECAIXA { get; set; }
        public Nullable<decimal> TOTALBRUTO { get; set; }
    
        public virtual TCLIENTE TCLIENTE { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO { get; set; }
        public virtual ICollection<TITENNOTACONSUMIDOR> TITENNOTACONSUMIDOR { get; set; }
    }
}
