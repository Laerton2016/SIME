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
    
    public partial class TVEICULO
    {
        public TVEICULO()
        {
            this.TCTEVEICULO = new HashSet<TCTEVEICULO>();
        }
    
        public int CONTROLE { get; set; }
        public string PLACA { get; set; }
        public string TARA { get; set; }
        public Nullable<int> CAPACIDADEKG { get; set; }
        public Nullable<decimal> CAPACIDADEM3 { get; set; }
        public string PROPRIEDADE { get; set; }
        public string TIPOVEICULO { get; set; }
        public string TIPORODADO { get; set; }
        public string TIPOCARROCERIA { get; set; }
        public string UFLICENCIAMENTO { get; set; }
        public Nullable<int> CODTRANSPORTADORA { get; set; }
        public string RENAVAM { get; set; }
        public string CODIGOINTERNO { get; set; }
    
        public virtual ICollection<TCTEVEICULO> TCTEVEICULO { get; set; }
        public virtual TTRANSPORTADORA TTRANSPORTADORA { get; set; }
    }
}
