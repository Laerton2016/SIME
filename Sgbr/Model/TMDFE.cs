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
    
    public partial class TMDFE
    {
        public TMDFE()
        {
            this.TCARREGAMENTOMDFE = new HashSet<TCARREGAMENTOMDFE>();
            this.TLACREMDFE = new HashSet<TLACREMDFE>();
            this.TPERCURSOMDFE = new HashSet<TPERCURSOMDFE>();
        }
    
        public int CONTROLE { get; set; }
        public Nullable<int> TIPOAMBIENTE { get; set; }
        public string SERIE { get; set; }
        public string NUMEROMDFE { get; set; }
        public string MODAL { get; set; }
        public Nullable<System.DateTime> DATAEHORAEMISSAO { get; set; }
        public string TIPOEMISSAO { get; set; }
        public string UFCARREGAMENTO { get; set; }
        public string UFDESCARREGAMENTO { get; set; }
        public Nullable<System.DateTime> DATAEHORAINICIOVIAGEM { get; set; }
        public string PROTOCOLO { get; set; }
        public string CHAVEMDFE { get; set; }
        public string QTDECTE { get; set; }
        public string QTDENFE { get; set; }
        public string QTDEMDFE { get; set; }
        public Nullable<decimal> VALORTOTALCARGA { get; set; }
        public string UN { get; set; }
        public Nullable<decimal> PESOBRUTOCARGA { get; set; }
        public string OBS { get; set; }
        public string PROTOCOLOCANCELAMENTO { get; set; }
        public string CODIGOSTATUS { get; set; }
        public string STATUS { get; set; }
        public string CODIGOINTERNOVEICULO { get; set; }
        public string PLACA { get; set; }
        public string RENAVAM { get; set; }
        public Nullable<decimal> TARAKG { get; set; }
        public Nullable<decimal> CAPACIDADEKG { get; set; }
        public Nullable<decimal> CAPACIDADEM3 { get; set; }
        public string CPFPROPRIETARIO { get; set; }
        public string RNTRCPROPRIETARIO { get; set; }
        public string RAZAOSOCIALPROPRIETARIO { get; set; }
        public string IEPROPRIETARIO { get; set; }
        public string UFPROPRIETARIO { get; set; }
        public string TIPOPROPRIETARIO { get; set; }
        public string CIOT { get; set; }
        public string RNTRC { get; set; }
        public string PROPRIEDADEVEICULO { get; set; }
        public string PROTOCOLOEVENTO { get; set; }
        public string TIPOCARROCERIAPROPRIETARIO { get; set; }
        public string CNPJPROPRIETARIO { get; set; }
        public string TIPOEMITENTE { get; set; }
    
        public virtual ICollection<TCARREGAMENTOMDFE> TCARREGAMENTOMDFE { get; set; }
        public virtual ICollection<TLACREMDFE> TLACREMDFE { get; set; }
        public virtual ICollection<TPERCURSOMDFE> TPERCURSOMDFE { get; set; }
    }
}
