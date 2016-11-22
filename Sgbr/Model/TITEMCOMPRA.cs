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
    
    public partial class TITEMCOMPRA
    {
        public TITEMCOMPRA()
        {
            this.TITEMCOMPRAGRADE = new HashSet<TITEMCOMPRAGRADE>();
            this.TITEMCOMPRASERIAL = new HashSet<TITEMCOMPRASERIAL>();
        }
    
        public int CONTROLE { get; set; }
        public int CODCOMPRA { get; set; }
        public System.DateTime DATAHORACADASTRO { get; set; }
        public Nullable<System.DateTime> DATARECEBIMENTO { get; set; }
        public int NOTACOMPRA { get; set; }
        public Nullable<int> CODITEM { get; set; }
        public Nullable<int> CODPRODUTOASSOCIACAO { get; set; }
        public Nullable<int> CODPRODUTO { get; set; }
        public string PRODUTO { get; set; }
        public string UN { get; set; }
        public string NCM { get; set; }
        public string CODIGOBARRA { get; set; }
        public string REFERENCIA { get; set; }
        public string CODIGOANP { get; set; }
        public string CEST { get; set; }
        public string CFOP { get; set; }
        public string CST { get; set; }
        public string CFOPCONVERTIDO { get; set; }
        public string CSOSN { get; set; }
        public Nullable<decimal> QTDECOMPRA { get; set; }
        public string OPERADORFATORCONVERSAOUSADO { get; set; }
        public Nullable<decimal> VALORCONVERSORUSADO { get; set; }
        public Nullable<decimal> QTDE { get; set; }
        public Nullable<decimal> VALORUNITARIOCOMPRA { get; set; }
        public Nullable<decimal> VALORUNITARIO { get; set; }
        public Nullable<decimal> PERCLUCROESTOQUE { get; set; }
        public Nullable<decimal> PRECOVENDAESTOQUE { get; set; }
        public Nullable<decimal> PERCLUCROCOMPRA { get; set; }
        public Nullable<decimal> PRECOVENDACOMPRA { get; set; }
        public Nullable<decimal> VALORDESCONTO { get; set; }
        public Nullable<decimal> OUTRASDESPESAS { get; set; }
        public Nullable<decimal> VALORFRETE { get; set; }
        public Nullable<decimal> VALORSEGURO { get; set; }
        public Nullable<decimal> BASECALCICMS { get; set; }
        public Nullable<decimal> PERCICMS { get; set; }
        public Nullable<decimal> REDUCAOICMS { get; set; }
        public Nullable<decimal> VALORICMS { get; set; }
        public Nullable<decimal> BASECALICMSST { get; set; }
        public Nullable<decimal> VALORICMSST { get; set; }
        public string CSTIPI { get; set; }
        public Nullable<decimal> BASECALCIPI { get; set; }
        public Nullable<decimal> PERCIPI { get; set; }
        public Nullable<decimal> VALORIPI { get; set; }
        public string CSTPIS { get; set; }
        public Nullable<decimal> BASECALCPIS { get; set; }
        public Nullable<decimal> PERCPIS { get; set; }
        public Nullable<decimal> VALORPIS { get; set; }
        public string CSTCOFINS { get; set; }
        public Nullable<decimal> BASECALCCOFINS { get; set; }
        public Nullable<decimal> PERCCOFINS { get; set; }
        public Nullable<decimal> VALORCOFINS { get; set; }
        public Nullable<decimal> VALORTOTAL { get; set; }
        public string USAGRADE { get; set; }
        public string USASERIAL { get; set; }
        public string OPERADORFATORCONVERSAOESTOQUE { get; set; }
        public Nullable<decimal> VALORCONVERSORESTOQE { get; set; }
        public string OBS { get; set; }
        public Nullable<int> TIPOOPERACAO { get; set; }
        public string TIPOCADASTRO { get; set; }
        public string CONFIRMADO { get; set; }
        public string MOVIMENTAESTOQUE { get; set; }
    
        public virtual TCOMPRA TCOMPRA { get; set; }
        public virtual ICollection<TITEMCOMPRAGRADE> TITEMCOMPRAGRADE { get; set; }
        public virtual ICollection<TITEMCOMPRASERIAL> TITEMCOMPRASERIAL { get; set; }
    }
}