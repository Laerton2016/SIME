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
    
    public partial class TITEMOPCOMPOSICAO
    {
        public int CONTROLE { get; set; }
        public Nullable<int> CODITEMPRODUCAO { get; set; }
        public Nullable<int> CODPRODUCAO { get; set; }
        public Nullable<int> CODPRODUTO { get; set; }
        public string PRODUTO { get; set; }
        public Nullable<int> CODCOMPRA { get; set; }
        public Nullable<int> CODFUNCIONARIO { get; set; }
        public string FUNCIONARIO { get; set; }
        public Nullable<int> CODFORNECEDOR { get; set; }
        public string FORNECEDOR { get; set; }
        public Nullable<int> NFCOMPRA { get; set; }
        public Nullable<System.DateTime> DATARECEBIMENTOCOMPRA { get; set; }
        public string LOTE { get; set; }
        public Nullable<System.DateTime> VALIDADELOTE { get; set; }
        public System.DateTime DATAHORACADASTRO { get; set; }
        public Nullable<decimal> QTDE { get; set; }
        public string UN { get; set; }
        public Nullable<int> CODPRODUTOCOMPOSICAO { get; set; }
        public Nullable<decimal> QTDEAPRODUZIR { get; set; }
        public string SITUACAO { get; set; }
        public Nullable<decimal> VALORUNITARIO { get; set; }
    
        public virtual TCOMPRA TCOMPRA { get; set; }
        public virtual TESTOQUE TESTOQUE { get; set; }
        public virtual TFORNECEDOR TFORNECEDOR { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO { get; set; }
        public virtual TITEMORDEMPRODUCAO TITEMORDEMPRODUCAO { get; set; }
        public virtual TORDEMPRODUCAO TORDEMPRODUCAO { get; set; }
    }
}
