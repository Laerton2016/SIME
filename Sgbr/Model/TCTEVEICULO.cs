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
    
    public partial class TCTEVEICULO
    {
        public int CONTROLE { get; set; }
        public string PLACA { get; set; }
        public string TARA { get; set; }
        public Nullable<int> CAPACIDADEKG { get; set; }
        public Nullable<decimal> CAPACIDADEM3 { get; set; }
        public string PROPRIEADADE { get; set; }
        public string TIPOVEICULO { get; set; }
        public string TIPORODADO { get; set; }
        public string TIPOCORROCERIA { get; set; }
        public string UFLICENCIAMENTO { get; set; }
        public Nullable<int> CODCTE { get; set; }
        public string RENAVAM { get; set; }
        public Nullable<int> CODVEICULO { get; set; }
        public string CODIGOINTERNO { get; set; }
    
        public virtual TCTE TCTE { get; set; }
        public virtual TVEICULO TVEICULO { get; set; }
    }
}
