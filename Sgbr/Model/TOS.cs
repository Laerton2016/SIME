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
    
    public partial class TOS
    {
        public TOS()
        {
            this.TITEMOS = new HashSet<TITEMOS>();
        }
    
        public int CONTROLE { get; set; }
        public int CODCLIENTE { get; set; }
        public string CLIENTE { get; set; }
        public Nullable<int> CODFUNCIONARIO { get; set; }
        public string FUNCIONARIO { get; set; }
        public string SOLICITANTE { get; set; }
        public string RG { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string CEP { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public string TELEFONECOMERCIAL { get; set; }
        public string TELEFONERESIDENCIAL { get; set; }
        public string CELULAR { get; set; }
        public string EMAIL { get; set; }
        public string NUMERO { get; set; }
        public string DEFEITO { get; set; }
        public string DESCRICAOOBJETO { get; set; }
        public Nullable<decimal> VALORTOTAL { get; set; }
        public Nullable<decimal> TOTALDESCONTO { get; set; }
        public Nullable<System.DateTime> DATAEHORACADASTRO { get; set; }
        public Nullable<decimal> TOTALACRESCIMO { get; set; }
        public string OBS { get; set; }
        public string CAMPO1 { get; set; }
        public string CAMPO2 { get; set; }
        public string CAMPO3 { get; set; }
        public string CAMPO4 { get; set; }
        public string CAMPO5 { get; set; }
        public string CAMPO6 { get; set; }
        public Nullable<int> CODOBJETO { get; set; }
        public string COMPLEMENTO { get; set; }
        public Nullable<int> CODCIDADE { get; set; }
        public string ENVIADA { get; set; }
        public string SITUACAO { get; set; }
        public string COR { get; set; }
        public string CANCELADA { get; set; }
        public string PROTOCOLO { get; set; }
        public string STATUS { get; set; }
        public Nullable<decimal> VALORSERVICOS { get; set; }
        public Nullable<decimal> VALORTOTALISS { get; set; }
        public string SERIE { get; set; }
        public string SITUACAONFSE { get; set; }
        public Nullable<int> CODLISTASERVICO { get; set; }
        public string CODIGOLISTASERVICO { get; set; }
        public string DESCRICAOLISTASERVICO { get; set; }
        public Nullable<System.DateTime> DATAENTREGA { get; set; }
        public string NUMERONFSE { get; set; }
        public string CODIGOOBRA { get; set; }
        public string CODIGOART { get; set; }
        public Nullable<decimal> VALORENTRADA { get; set; }
        public Nullable<int> NUMEROOS { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public Nullable<decimal> ALIQUOTAISS { get; set; }
        public string FORMAPAGAMENTO { get; set; }
        public string CHASSI { get; set; }
        public string MARCA { get; set; }
        public string ANOFABRICACAO { get; set; }
        public string PLACA { get; set; }
        public string NUMERORENAVAM { get; set; }
        public string MODELO { get; set; }
        public string NUMERODAV { get; set; }
        public string TITULODAV { get; set; }
        public Nullable<int> COO { get; set; }
        public Nullable<int> COOVINCULADO { get; set; }
        public string MARCAECF { get; set; }
        public string MODELOECF { get; set; }
        public Nullable<int> NUMEROECF { get; set; }
        public Nullable<int> CCF { get; set; }
        public string SERIEECF { get; set; }
        public string OFICINA { get; set; }
        public Nullable<int> NUMERORPS { get; set; }
        public string MESCLAR { get; set; }
        public string MD5DAV { get; set; }
        public string TIPOECF { get; set; }
        public string DAVANTERIOR { get; set; }
        public string AVISTA { get; set; }
        public string STATUSENVIO { get; set; }
        public Nullable<decimal> VALORPRODUTOS { get; set; }
        public Nullable<int> NUMEROLOTE { get; set; }
        public Nullable<int> REFERENCIAOS { get; set; }
        public Nullable<System.DateTime> DATAFINALIZACAO { get; set; }
        public string TRIBUTACAO { get; set; }
        public string LAUDOTECNICO { get; set; }
        public Nullable<decimal> TOTALDESCONTOITEM { get; set; }
        public string FATURADATOTAL { get; set; }
        public string NOMEFANTASIA { get; set; }
        public byte[] IMAGEMOBJETO { get; set; }
        public string NATUREZAOPERACAO { get; set; }
        public Nullable<int> CODVENDEDOR { get; set; }
        public string VENDEDOR { get; set; }
    
        public virtual TCLIENTE TCLIENTE { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO { get; set; }
        public virtual TFUNCIONARIO TFUNCIONARIO1 { get; set; }
        public virtual TIMPOSTOMEDIO TIMPOSTOMEDIO { get; set; }
        public virtual ICollection<TITEMOS> TITEMOS { get; set; }
        public virtual TOBJETOSOS TOBJETOSOS { get; set; }
    }
}