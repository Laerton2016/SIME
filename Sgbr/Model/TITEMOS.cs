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
    
    public partial class TITEMOS
    {
        public int CONTROLE { get; set; }
        public Nullable<int> CODOS { get; set; }
        public Nullable<decimal> QUANTIDADE { get; set; }
        public Nullable<decimal> VALORTOTAL { get; set; }
        public string DESCRICAO { get; set; }
        public Nullable<int> CODSERVICO { get; set; }
        public Nullable<decimal> ISS { get; set; }
        public Nullable<decimal> TOTALISS { get; set; }
        public string TECNICO { get; set; }
        public Nullable<int> CODTECNICO { get; set; }
        public Nullable<decimal> DESCONTO { get; set; }
        public Nullable<decimal> ACRESCIMO { get; set; }
        public Nullable<decimal> TOTALDESCONTO { get; set; }
        public Nullable<decimal> TOTALACRESCIMO { get; set; }
        public string CANCELADA { get; set; }
        public string APLICACAOPRODUTO { get; set; }
        public Nullable<System.DateTime> DATAHORACADASTRO { get; set; }
        public Nullable<decimal> PERCCOMISSAO { get; set; }
        public Nullable<decimal> TOTALCOMISSAO { get; set; }
        public Nullable<int> CODAPLICACAOPRODUTO { get; set; }
        public Nullable<decimal> VALORIMPOSTOMEDIO { get; set; }
        public Nullable<decimal> PERCIMPOSTOMEDIO { get; set; }
        public string OBSITEM { get; set; }
        public string UN { get; set; }
        public string SITUACAOTRIBUTARIA { get; set; }
        public Nullable<int> CODITEM { get; set; }
        public string NUMERODAV { get; set; }
        public string MD5DAV { get; set; }
        public string INDICADORCANCELAMENTO { get; set; }
        public string MESCLAR { get; set; }
        public string STATUS { get; set; }
        public string CFOP { get; set; }
        public string HORAINICIAL { get; set; }
        public string HORAFINAL { get; set; }
        public string TOTALHORAS { get; set; }
        public Nullable<System.DateTime> DATAINICIAL { get; set; }
        public Nullable<System.DateTime> DATAFINAL { get; set; }
        public string TOTALEMHORAS { get; set; }
        public string GRAVOU { get; set; }
        public string OBSERVACAOITEM { get; set; }
        public Nullable<decimal> VALORUNITARIO { get; set; }
        public string REFERENCIA { get; set; }
        public Nullable<decimal> PRECOCUSTOITEM { get; set; }
        public string RESERVARPRODUTO { get; set; }
        public string SITUACAO { get; set; }
    
        public virtual TESTOQUE TESTOQUE { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO { get; set; }
        public virtual TOS TOS { get; set; }
    }
}
