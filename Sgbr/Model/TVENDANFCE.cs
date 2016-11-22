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
    
    public partial class TVENDANFCE
    {
        public TVENDANFCE()
        {
            this.TITEMNFCEGRADE = new HashSet<TITEMNFCEGRADE>();
            this.TITEMNFCESERIAL = new HashSet<TITEMNFCESERIAL>();
            this.TITEMVENDANFCE = new HashSet<TITEMVENDANFCE>();
        }
    
        public int CONTROLE { get; set; }
        public Nullable<System.DateTime> DATAEHORACADASTRO { get; set; }
        public Nullable<System.DateTime> DATAEMISSAO { get; set; }
        public Nullable<int> NUMERONFCCE { get; set; }
        public Nullable<int> NUMEROSAT { get; set; }
        public Nullable<int> TIPOAMBIENTE { get; set; }
        public string CHAVENFCE { get; set; }
        public string PROTOCOLO { get; set; }
        public string PROTOCOLOCANCELAMENTO { get; set; }
        public Nullable<int> CODIGOSTATUS { get; set; }
        public string STATUSENVIO { get; set; }
        public string INUTILIZADA { get; set; }
        public Nullable<int> CODCLIENTE { get; set; }
        public string CLIENTE { get; set; }
        public Nullable<int> CODFUNCIONARIO { get; set; }
        public string FUNCIONARIO { get; set; }
        public Nullable<int> CODCENTROCUSTO { get; set; }
        public string CENTROCUSTO { get; set; }
        public Nullable<decimal> VALORPRODUTO { get; set; }
        public Nullable<decimal> PERCACRESCIMO { get; set; }
        public Nullable<decimal> VALORACRESCIMO { get; set; }
        public Nullable<decimal> PERCDESCONTO { get; set; }
        public Nullable<decimal> VALORDESCONTO { get; set; }
        public Nullable<decimal> VALORDESCONTOITEM { get; set; }
        public Nullable<decimal> VALORBCICMS { get; set; }
        public Nullable<decimal> VALORICMS { get; set; }
        public Nullable<decimal> VALORBCST { get; set; }
        public Nullable<decimal> VALORST { get; set; }
        public Nullable<decimal> VALORPIS { get; set; }
        public Nullable<decimal> VALORCOFINS { get; set; }
        public Nullable<decimal> VALORSEGURO { get; set; }
        public Nullable<decimal> VALOROUTROS { get; set; }
        public Nullable<decimal> VALORBCSERVICO { get; set; }
        public Nullable<decimal> VALORISS { get; set; }
        public Nullable<decimal> VALORSERVICO { get; set; }
        public Nullable<decimal> VALORTOTALNFCE { get; set; }
        public string NATUREZAOPERACAO { get; set; }
        public Nullable<int> MODELO { get; set; }
        public Nullable<int> SERIE { get; set; }
        public Nullable<System.DateTime> DATASAIDAENTRADA { get; set; }
        public Nullable<System.TimeSpan> HORASAIDAENTRADA { get; set; }
        public string TIPOEMISSAO { get; set; }
        public string FONECLIENTE { get; set; }
        public string CEPCLIENTE { get; set; }
        public string ENDERECOCLIENTE { get; set; }
        public string COMPLEMENTOCLIENTE { get; set; }
        public string UFCLIENTE { get; set; }
        public string CIDADECLIENTE { get; set; }
        public string CODCIDADEIBGECLIENTE { get; set; }
        public string CPFCLIENTE { get; set; }
        public string CNPJCLIENTE { get; set; }
        public string IMCLIENTE { get; set; }
        public string CNAECLIENTE { get; set; }
        public string NUMEROCLIENTE { get; set; }
        public string BAIRROCLIENTE { get; set; }
        public string JUSTIFICATIVACANCELAMENTO { get; set; }
        public Nullable<System.DateTime> DATAEHORACANCELAMENTO { get; set; }
        public string EMAIL { get; set; }
        public Nullable<int> CODCOMANDA { get; set; }
        public string CODDAV { get; set; }
        public Nullable<int> CODPREVENDA { get; set; }
        public string NUMERODAV { get; set; }
        public Nullable<decimal> VALORTROCO { get; set; }
        public Nullable<int> CODOS { get; set; }
        public string JAFATURADO { get; set; }
        public string SAT { get; set; }
        public string INFORMACAOADICIONAL { get; set; }
        public string IDENTIFICACAO { get; set; }
        public string OBS { get; set; }
        public int CODOPERADOR { get; set; }
        public string OPERADOR { get; set; }
    
        public virtual TCENTROCUSTO TCENTROCUSTO { get; set; }
        public virtual TCLIENTE TCLIENTE { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO { get; set; }
        public virtual ICollection<TITEMNFCEGRADE> TITEMNFCEGRADE { get; set; }
        public virtual ICollection<TITEMNFCESERIAL> TITEMNFCESERIAL { get; set; }
        public virtual ICollection<TITEMVENDANFCE> TITEMVENDANFCE { get; set; }
    }
}