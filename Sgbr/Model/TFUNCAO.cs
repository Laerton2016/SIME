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
    
    public partial class TFUNCAO
    {
        public TFUNCAO()
        {
            this.TFUNCIONARIO = new HashSet<TFUNCIONARIO>();
        }
    
        public int CONTROLE { get; set; }
        public string FUNCAO { get; set; }
        public System.DateTime DATAHORACADASTRO { get; set; }
        public string OBS { get; set; }
    
        public virtual ICollection<TFUNCIONARIO> TFUNCIONARIO { get; set; }
    }
}
