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
    /// <summary>
    /// Classe trata dos dados de um cliente
    /// </summary>
    public partial class TCLIENTE
    {
        public TCLIENTE()
        {
            this.TALUGUEL = new HashSet<TALUGUEL>();
            this.TCAIXA = new HashSet<TCAIXA>();
            this.TCHEQUECLIENTE = new HashSet<TCHEQUECLIENTE>();
            this.TCOMANDA = new HashSet<TCOMANDA>();
            this.TCONDICIONAL = new HashSet<TCONDICIONAL>();
            this.TNOTACONSUMIDOR = new HashSet<TNOTACONSUMIDOR>();
            this.TORCAMENTO = new HashSet<TORCAMENTO>();
            this.TOS = new HashSet<TOS>();
            this.TPEDIDOVENDA = new HashSet<TPEDIDOVENDA>();
            this.TPREVENDA = new HashSet<TPREVENDA>();
            this.TRECEBER = new HashSet<TRECEBER>();
            this.TRECEBER1 = new HashSet<TRECEBER>();
            this.TVENDAECF = new HashSet<TVENDAECF>();
            this.TVENDANFCE = new HashSet<TVENDANFCE>();
            this.TVENDANFE = new HashSet<TVENDANFE>();
        }
    
        public int CONTROLE { get; set; }
        public string CLIENTE { get; set; }
        public string ENDERECO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string BAIRRO { get; set; }
        public Nullable<int> CODCIDADE { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public string PAIS { get; set; }
        public string CEP { get; set; }
        public string NATURALIDADE { get; set; }
        public string TIPOCLIENTE { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public Nullable<System.DateTime> DATANASCIMENTO { get; set; }
        public System.DateTime DATAHORACADASTRO { get; set; }
        public string PAI { get; set; }
        public string MAE { get; set; }
        public string TELEFONE { get; set; }
        public string CELULAR { get; set; }
        public string EMAIL { get; set; }
        public string ESTADOCIVIL { get; set; }
        public string ATIVO { get; set; }
        public string FANTASIA { get; set; }
        public string OBS { get; set; }
        public Nullable<decimal> LIMITECREDITO { get; set; }
        public string NOMECONJUGE { get; set; }
        public Nullable<System.DateTime> DATAULTIMAVENDA { get; set; }
        public Nullable<int> DIASSEMCOMPRAR { get; set; }
        public Nullable<int> CODCONVENIO { get; set; }
        public string CONVENIO { get; set; }
        public string PROFISSAO { get; set; }
        public string EMPRESAQUETRABALHA { get; set; }
        public string FONETRABALHO { get; set; }
        public Nullable<decimal> RENDAMENSAL { get; set; }
        public Nullable<decimal> TOTALVENDIDO { get; set; }
        public string NACIONALIDADE { get; set; }
        public string NUMERO { get; set; }
        public Nullable<int> CODCONSULTASPC { get; set; }
        public string SEXO { get; set; }
        public string CODIGOCIDADEIBGE { get; set; }
        public Nullable<int> CODEMITENTE { get; set; }
        public string NOMECONTATOJURIDICA { get; set; }
        public string EMAIL2 { get; set; }
        public string STATUS { get; set; }
        public string MD5L { get; set; }
        public string SERIAL { get; set; }
        public Nullable<int> CODGRUPO { get; set; }
        public string GRUPO { get; set; }
        public string FOTO { get; set; }
        public string TRIBUTACAO { get; set; }
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
        public Nullable<decimal> ISSMUNICIPIO { get; set; }
        public string DADOSADICIONAIS { get; set; }
        public string SITE { get; set; }
        public string CODIGOPAIS { get; set; }
        public string CSOSN { get; set; }
        public Nullable<decimal> PERCICMSPROPRIOST { get; set; }
        public Nullable<decimal> PERCMVAORIGINAL { get; set; }
        public Nullable<decimal> PERCICMSSTINTERNA { get; set; }
        public Nullable<decimal> PERCREDUCAOBCST { get; set; }
        public string DESCRICAOCSOSN { get; set; }
        public Nullable<int> CODIGOCSTORIGEM { get; set; }
        public string ORIGEM { get; set; }
        public string POSSUIICMSST { get; set; }
        public string ISENTO { get; set; }
        public string TRIBUTADO { get; set; }
        public Nullable<int> CODCSTORIGEM { get; set; }
        public string MENSAGEMFISCAL { get; set; }
        public Nullable<int> CODTABELAPRECO { get; set; }
        public string TABELAPRECO { get; set; }
        public Nullable<int> CODVENDEDOR { get; set; }
        public string VENDEDOR { get; set; }
    
        public virtual ICollection<TALUGUEL> TALUGUEL { get; set; }
        public virtual ICollection<TCAIXA> TCAIXA { get; set; }
        public virtual ICollection<TCHEQUECLIENTE> TCHEQUECLIENTE { get; set; }
        public virtual TCIDADE TCIDADE { get; set; }
        public virtual TCONVENIO TCONVENIO { get; set; }
        public virtual TCONSULTASPC TCONSULTASPC { get; set; }
        public virtual TEMITENTE TEMITENTE { get; set; }
        public virtual TGRUPOCLIENTE TGRUPOCLIENTE { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO { get; set; }
        public virtual ICollection<TCOMANDA> TCOMANDA { get; set; }
        public virtual ICollection<TCONDICIONAL> TCONDICIONAL { get; set; }
        public virtual ICollection<TNOTACONSUMIDOR> TNOTACONSUMIDOR { get; set; }
        public virtual ICollection<TORCAMENTO> TORCAMENTO { get; set; }
        public virtual ICollection<TOS> TOS { get; set; }
        public virtual ICollection<TPEDIDOVENDA> TPEDIDOVENDA { get; set; }
        public virtual ICollection<TPREVENDA> TPREVENDA { get; set; }
        public virtual ICollection<TRECEBER> TRECEBER { get; set; }
        public virtual ICollection<TRECEBER> TRECEBER1 { get; set; }
        public virtual ICollection<TVENDAECF> TVENDAECF { get; set; }
        public virtual ICollection<TVENDANFCE> TVENDANFCE { get; set; }
        public virtual ICollection<TVENDANFE> TVENDANFE { get; set; }
    }
}