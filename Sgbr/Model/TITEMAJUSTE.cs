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
    
    public partial class TITEMAJUSTE
    {
        public int CONTROLE { get; set; }
        public string CODIGOPART { get; set; }
        public string CODIGOMODELO { get; set; }
        public string SERIE { get; set; }
        public Nullable<int> SUBSERIE { get; set; }
        public Nullable<int> NUMERODOCUMENTO { get; set; }
        public Nullable<System.DateTime> DATADOCUMENTO { get; set; }
        public string CODIGOITEM { get; set; }
        public Nullable<decimal> VALORAJUSTEITEM { get; set; }
        public Nullable<int> CODAJUSTE { get; set; }
    
        public virtual TAJUSTE TAJUSTE { get; set; }
    }
}
