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
    
    public partial class TFORNECEDOR
    {
        public TFORNECEDOR()
        {
            this.TCAIXA = new HashSet<TCAIXA>();
            this.TCHEQUEFORNECEDOR = new HashSet<TCHEQUEFORNECEDOR>();
            this.TCODIGOFABRICA = new HashSet<TCODIGOFABRICA>();
            this.TCOMPRA = new HashSet<TCOMPRA>();
            this.TITEMOPCOMPOSICAO = new HashSet<TITEMOPCOMPOSICAO>();
            this.TPAGAR = new HashSet<TPAGAR>();
            this.TPEDIDOCOMPRA = new HashSet<TPEDIDOCOMPRA>();
        }
    
        public int CONTROLE { get; set; }
        public string NOMEFANTASIA { get; set; }
        public string RAZAOSOCIAL { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public Nullable<int> CODCIDADE { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string COMPLEMENTO { get; set; }
        public string TELEFONE { get; set; }
        public string CELULAR { get; set; }
        public string SAC { get; set; }
        public string EMAIL { get; set; }
        public string SITE { get; set; }
        public string OBS { get; set; }
        public string FORMAPAGAMENTO { get; set; }
        public string ATIVO { get; set; }
        public System.DateTime DATAHORACADASTRO { get; set; }
        public string PAIS { get; set; }
        public string NUMERO { get; set; }
        public Nullable<int> CODEMITENTE { get; set; }
        public string NOMECONTATOJURIDICA { get; set; }
        public string CAMPO1 { get; set; }
        public string CAMPO2 { get; set; }
        public string CAMPO3 { get; set; }
        public string CAMPO4 { get; set; }
        public string CAMPO5 { get; set; }
        public string CAMPO6 { get; set; }
        public string CAMPO7 { get; set; }
        public string CAMPO8 { get; set; }
        public string CAMPO9 { get; set; }
        public string CAMPO10 { get; set; }
        public string MARCADO { get; set; }
        public Nullable<int> CODIGOCIDADEIBGE { get; set; }
    
        public virtual ICollection<TCAIXA> TCAIXA { get; set; }
        public virtual ICollection<TCHEQUEFORNECEDOR> TCHEQUEFORNECEDOR { get; set; }
        public virtual ICollection<TCODIGOFABRICA> TCODIGOFABRICA { get; set; }
        public virtual ICollection<TCOMPRA> TCOMPRA { get; set; }
        public virtual TEMITENTE TEMITENTE { get; set; }
        public virtual ICollection<TITEMOPCOMPOSICAO> TITEMOPCOMPOSICAO { get; set; }
        public virtual ICollection<TPAGAR> TPAGAR { get; set; }
        public virtual ICollection<TPEDIDOCOMPRA> TPEDIDOCOMPRA { get; set; }
    }
}