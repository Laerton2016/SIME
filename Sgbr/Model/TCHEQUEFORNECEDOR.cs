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
    
    public partial class TCHEQUEFORNECEDOR
    {
        public int CONTROLE { get; set; }
        public int CODFORNECEDOR { get; set; }
        public string FORNECEDOR { get; set; }
        public System.DateTime DATAHORACADASTRO { get; set; }
        public Nullable<int> CODBANCO { get; set; }
        public string DESCRICAOBANCO { get; set; }
        public string AGENCIA { get; set; }
        public string CONTA { get; set; }
        public string NUMEROCHEQUE { get; set; }
        public string CRUZADO { get; set; }
        public string NOMINAL { get; set; }
        public string NOMINALPARA { get; set; }
        public Nullable<System.DateTime> EMISSAO { get; set; }
        public Nullable<System.DateTime> BOMPARA { get; set; }
        public string DEPOSITADO { get; set; }
        public Nullable<System.DateTime> DEVOLVIDODATA { get; set; }
        public string MOTIVODEVOLVIDO { get; set; }
        public string FONECONTATO { get; set; }
        public Nullable<int> CODBANCODEPOSITADO { get; set; }
        public string BANCODEPOSITADO { get; set; }
        public string CONTADEPOSITADO { get; set; }
        public string AGENCIADEPOSITADO { get; set; }
        public Nullable<System.DateTime> DATADEPOSITADO { get; set; }
        public Nullable<decimal> VALOR { get; set; }
        public string CMC7 { get; set; }
        public string DOCUMENTO { get; set; }
        public byte[] OBS { get; set; }
    
        public virtual TFORNECEDOR TFORNECEDOR { get; set; }
    }
}