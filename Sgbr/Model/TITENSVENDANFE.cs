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
    
    public partial class TITENSVENDANFE
    {
        public TITENSVENDANFE()
        {
            this.TITEMNFEVEICULO = new HashSet<TITEMNFEVEICULO>();
            this.TITENNFEGRADE = new HashSet<TITENNFEGRADE>();
            this.TITENNFESERIAL = new HashSet<TITENNFESERIAL>();
        }
    
        public int CONTROLE { get; set; }
        public string CODPRODUTO { get; set; }
        public string PRODUTO { get; set; }
        public string CODBARRA { get; set; }
        public string NCM { get; set; }
        public string CFOP { get; set; }
        public string UNCOMERCIAL { get; set; }
        public Nullable<decimal> QTDECOMERCIAL { get; set; }
        public Nullable<decimal> VALORUNITARIO { get; set; }
        public Nullable<decimal> TOTALPRODUTOS { get; set; }
        public Nullable<int> CODUNIDADEMEDIDA { get; set; }
        public string UNTRIBUTAVEL { get; set; }
        public Nullable<decimal> QTDETRIBUTAVEL { get; set; }
        public Nullable<decimal> VALORUNITARIOTRIBUTACAO { get; set; }
        public string INDICACAOVALOR { get; set; }
        public string ORIGEM { get; set; }
        public string MODALIDADEBCICMS { get; set; }
        public Nullable<decimal> VALORBCICMS { get; set; }
        public Nullable<decimal> ALIQUOTAICMS { get; set; }
        public Nullable<decimal> VALORICMS { get; set; }
        public Nullable<decimal> PERCREDUCAOICMSST { get; set; }
        public Nullable<decimal> VALORBCICMSST { get; set; }
        public Nullable<decimal> ALIQUOTAICMSST { get; set; }
        public Nullable<decimal> VALORICMSST { get; set; }
        public Nullable<decimal> PERCREDUCAOICMS { get; set; }
        public string MODALIDADEBCICMSST { get; set; }
        public Nullable<decimal> PERCREDUCAOBC { get; set; }
        public Nullable<decimal> PERCBCOPERACAOPROPRIA { get; set; }
        public string CSTIPI { get; set; }
        public Nullable<decimal> VALORBCIPI { get; set; }
        public Nullable<decimal> ALIQUOTAIPI { get; set; }
        public Nullable<decimal> VALORIPI { get; set; }
        public string CSTPIS { get; set; }
        public Nullable<decimal> PERCPIS { get; set; }
        public Nullable<decimal> VALORBCPIS { get; set; }
        public Nullable<decimal> VALORPIS { get; set; }
        public Nullable<decimal> VALORBCPISST { get; set; }
        public Nullable<decimal> PERCPISST { get; set; }
        public Nullable<decimal> VALORPISST { get; set; }
        public string CSTCOFINS { get; set; }
        public Nullable<decimal> VALORBCCOFINS { get; set; }
        public Nullable<decimal> ALIQUOTACOFINS { get; set; }
        public Nullable<decimal> VALORCOFINS { get; set; }
        public Nullable<decimal> VALORBCCOFINSST { get; set; }
        public Nullable<decimal> ALIQUOTASCOFINSST { get; set; }
        public Nullable<decimal> VALORCOFINSST { get; set; }
        public string TIPOOPERACAO { get; set; }
        public string USAGRADE { get; set; }
        public string USASERIAL { get; set; }
        public Nullable<int> CODNFE { get; set; }
        public string CANCELADO { get; set; }
        public System.DateTime DATACADASTRO { get; set; }
        public System.TimeSpan HORACADASTRO { get; set; }
        public Nullable<decimal> VALORCREDITOICMSAPROVEITADO { get; set; }
        public Nullable<decimal> ALIQUOTACREDITOSIMPLESNACIONAL { get; set; }
        public Nullable<decimal> VALORFRETE { get; set; }
        public Nullable<decimal> VALORSEGURO { get; set; }
        public Nullable<decimal> VALORDESCONTO { get; set; }
        public Nullable<decimal> OUTRASDESPESAS { get; set; }
        public Nullable<int> LOTE { get; set; }
        public Nullable<int> SEQUENCIAITEM { get; set; }
        public Nullable<decimal> VALORBASECALCULOICMSSTRETIDO { get; set; }
        public Nullable<decimal> VALORICMSSTRETIDO { get; set; }
        public string MENSAGEM { get; set; }
        public Nullable<int> CODMENSAGEMNFE { get; set; }
        public string CODAPLICACAOPRODUTO { get; set; }
        public string AMBIENTE { get; set; }
        public string GRAVOUNANOTA { get; set; }
        public string ENVIADA { get; set; }
        public string REJEITADA { get; set; }
        public Nullable<decimal> PERCDESCONTO { get; set; }
        public Nullable<decimal> VALORDESCONTOITEM { get; set; }
        public string INFORMACAOADICIONAL { get; set; }
        public string MOVIMENTAESTOQUE { get; set; }
        public Nullable<decimal> PERCIMPOSTOMEDIO { get; set; }
        public Nullable<decimal> VALORTOTALIMPOSTOMEDIO { get; set; }
        public Nullable<decimal> PRECOCUSTOITEM { get; set; }
        public Nullable<decimal> TOTALIQUIDO { get; set; }
        public Nullable<decimal> BASECALCULOISSQN { get; set; }
        public Nullable<decimal> ALIQUOTAISSQN { get; set; }
        public Nullable<decimal> VALORISSQN { get; set; }
        public string CODIGOLISTASERVICO { get; set; }
        public string SITUACAOTRIBUTARIAISSQN { get; set; }
        public Nullable<decimal> VALORTOTALSERVICOS { get; set; }
        public string OBSITEM { get; set; }
        public Nullable<decimal> PERCCOMISSAO { get; set; }
        public string CODIGOANP { get; set; }
        public string CSOSNCST { get; set; }
        public string NUMEROPEDIDO { get; set; }
        public Nullable<int> NUMEROITEMPEDIDO { get; set; }
        public Nullable<decimal> BCICMSUFDEST { get; set; }
        public Nullable<decimal> VALORICMSUFDEST { get; set; }
        public Nullable<decimal> VALORICMSUFREMET { get; set; }
        public Nullable<decimal> ALIQUOTAINTERESTADUAL { get; set; }
        public Nullable<decimal> ALIQUOTAINTERNADESTINO { get; set; }
        public string CODIGOENQUADRAMENTOIPI { get; set; }
        public Nullable<decimal> TOTALCOMISSAO { get; set; }
        public string CEST { get; set; }
        public Nullable<int> CODTABELAPRECO { get; set; }
        public string TABELAPRECO { get; set; }
        public Nullable<decimal> PERCICMSDIFERIDO { get; set; }
    
        public virtual ICollection<TITEMNFEVEICULO> TITEMNFEVEICULO { get; set; }
        public virtual ICollection<TITENNFEGRADE> TITENNFEGRADE { get; set; }
        public virtual ICollection<TITENNFESERIAL> TITENNFESERIAL { get; set; }
        public virtual TVENDANFE TVENDANFE { get; set; }
        public virtual TTABELAPRECO TTABELAPRECO { get; set; }
    }
}
