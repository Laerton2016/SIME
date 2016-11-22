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
    
    public partial class TITEMVENDANFCE
    {
        public TITEMVENDANFCE()
        {
            this.TITEMNFCEGRADE = new HashSet<TITEMNFCEGRADE>();
            this.TITEMNFCESERIAL = new HashSet<TITEMNFCESERIAL>();
        }
    
        public int CONTROLE { get; set; }
        public Nullable<System.DateTime> DATAEHORACADASTRO { get; set; }
        public Nullable<int> NUMEROITEM { get; set; }
        public int CODNFCE { get; set; }
        public int CODPRODUTO { get; set; }
        public string PRODUTO { get; set; }
        public Nullable<decimal> QTDE { get; set; }
        public Nullable<decimal> VALORUNITARIO { get; set; }
        public Nullable<decimal> VALORTOTAL { get; set; }
        public Nullable<decimal> VALORLIQUIDO { get; set; }
        public string CFOP { get; set; }
        public string NCM { get; set; }
        public string UN { get; set; }
        public string CODIGOBARRA { get; set; }
        public Nullable<decimal> VALOROUTROS { get; set; }
        public Nullable<decimal> VALORACRESCIMO { get; set; }
        public Nullable<decimal> VALORSEGURO { get; set; }
        public Nullable<decimal> VALORBCICMS { get; set; }
        public Nullable<decimal> VALORICMS { get; set; }
        public Nullable<decimal> PERCICMS { get; set; }
        public Nullable<decimal> VALORBCICMSST { get; set; }
        public Nullable<decimal> VALORICMSST { get; set; }
        public Nullable<decimal> VALORBCISSQN { get; set; }
        public Nullable<decimal> VALORALIQUOTAISSQN { get; set; }
        public Nullable<decimal> VALORISSQN { get; set; }
        public Nullable<decimal> VALORDESCONTO { get; set; }
        public Nullable<decimal> VALORDESCONTOITEM { get; set; }
        public Nullable<decimal> PERCDESCONTOITEM { get; set; }
        public Nullable<decimal> PERCCOMISSAO { get; set; }
        public Nullable<decimal> TOTALCOMISSAO { get; set; }
        public Nullable<decimal> VALORIMPOSTOMEDIO { get; set; }
        public string USAGRADE { get; set; }
        public string USASERIAL { get; set; }
        public string OBSITEM { get; set; }
        public string MOVIMENTAESTOQUE { get; set; }
        public string CANCELADO { get; set; }
        public Nullable<int> TIPOOPERACAO { get; set; }
        public string CODAPLICACAOPRODUTO { get; set; }
        public Nullable<int> CSOSN { get; set; }
        public Nullable<int> AMBIENTE { get; set; }
        public string ENVIADA { get; set; }
        public Nullable<decimal> PRECOCUSTOITEM { get; set; }
        public string INUTILIZADO { get; set; }
        public string CODIGOANP { get; set; }
        public string CEST { get; set; }
        public string CSTPIS { get; set; }
        public Nullable<decimal> PERCPIS { get; set; }
        public Nullable<decimal> VALORPIS { get; set; }
        public Nullable<decimal> VALORBCPISST { get; set; }
        public Nullable<decimal> PERCPISST { get; set; }
        public Nullable<decimal> VALORPISST { get; set; }
        public string CSTIPI { get; set; }
        public Nullable<decimal> VALORBCIPI { get; set; }
        public Nullable<decimal> VALORIPI { get; set; }
        public string CSTCOFINS { get; set; }
        public Nullable<decimal> PERCCOFINS { get; set; }
        public Nullable<decimal> VALORCOFINS { get; set; }
        public Nullable<decimal> VALORBCCOFINSST { get; set; }
        public Nullable<decimal> PERCCOFINSST { get; set; }
        public Nullable<decimal> VALORCOFINSST { get; set; }
        public string CODIGOENQUADRAMENTOIPI { get; set; }
        public Nullable<decimal> VALORBCPIS { get; set; }
        public Nullable<decimal> VALORBCCOFINS { get; set; }
        public Nullable<decimal> PERCIPI { get; set; }
        public string CODIGOSERVICO { get; set; }
    
        public virtual TESTOQUE TESTOQUE { get; set; }
        public virtual ICollection<TITEMNFCEGRADE> TITEMNFCEGRADE { get; set; }
        public virtual ICollection<TITEMNFCESERIAL> TITEMNFCESERIAL { get; set; }
        public virtual TVENDANFCE TVENDANFCE { get; set; }
    }
}
