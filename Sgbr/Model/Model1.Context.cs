﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<TADICIONALPRODUTO> TADICIONALPRODUTO { get; set; }
        public DbSet<TAGENDA> TAGENDA { get; set; }
        public DbSet<TAGENDAMENTOOS> TAGENDAMENTOOS { get; set; }
        public DbSet<TAJUSTE> TAJUSTE { get; set; }
        public DbSet<TAJUSTECSOSN> TAJUSTECSOSN { get; set; }
        public DbSet<TAJUSTEESTOQUE> TAJUSTEESTOQUE { get; set; }
        public DbSet<TALIQUOTA> TALIQUOTA { get; set; }
        public DbSet<TALTERACAODAV> TALTERACAODAV { get; set; }
        public DbSet<TALUGUEL> TALUGUEL { get; set; }
        public DbSet<TANEXOS> TANEXOS { get; set; }
        public DbSet<TAPLICACAOPRODUTO> TAPLICACAOPRODUTO { get; set; }
        public DbSet<TAVISO> TAVISO { get; set; }
        public DbSet<TBANCOCHEQUE> TBANCOCHEQUE { get; set; }
        public DbSet<TBOLETO> TBOLETO { get; set; }
        public DbSet<TBOLETOAGRUPADO> TBOLETOAGRUPADO { get; set; }
        public DbSet<TCAIXA> TCAIXA { get; set; }
        public DbSet<TCARREGAMENTOMDFE> TCARREGAMENTOMDFE { get; set; }
        public DbSet<TCCE> TCCE { get; set; }
        public DbSet<TCENTROCUSTO> TCENTROCUSTO { get; set; }
        public DbSet<TCESTTEMP> TCESTTEMP { get; set; }
        public DbSet<TCFOP> TCFOP { get; set; }
        public DbSet<TCHEQUECLIENTE> TCHEQUECLIENTE { get; set; }
        public DbSet<TCHEQUEFORNECEDOR> TCHEQUEFORNECEDOR { get; set; }
        public DbSet<TCIDADE> TCIDADE { get; set; }
        public DbSet<TCIDADEIBGE> TCIDADEIBGE { get; set; }
        public DbSet<TCLIENTE> TCLIENTE { get; set; }
        public DbSet<TCODIGOFABRICA> TCODIGOFABRICA { get; set; }
        public DbSet<TCOMANDA> TCOMANDA { get; set; }
        public DbSet<TCOMPOSICAO> TCOMPOSICAO { get; set; }
        public DbSet<TCOMPRA> TCOMPRA { get; set; }
        public DbSet<TCONDICIONAL> TCONDICIONAL { get; set; }
        public DbSet<TCONFIGURACAO> TCONFIGURACAO { get; set; }
        public DbSet<TCONSULTASPC> TCONSULTASPC { get; set; }
        public DbSet<TCONTABANCARIA> TCONTABANCARIA { get; set; }
        public DbSet<TCONTAGEMESTOQUE> TCONTAGEMESTOQUE { get; set; }
        public DbSet<TCONTROLEMODULO> TCONTROLEMODULO { get; set; }
        public DbSet<TCONVENIO> TCONVENIO { get; set; }
        public DbSet<TCONVERSAOCFOPENTRADA> TCONVERSAOCFOPENTRADA { get; set; }
        public DbSet<TCOTACAO> TCOTACAO { get; set; }
        public DbSet<TCOTACAOFORNECEDOR> TCOTACAOFORNECEDOR { get; set; }
        public DbSet<TCST> TCST { get; set; }
        public DbSet<TCSTCOFINS> TCSTCOFINS { get; set; }
        public DbSet<TCSTICMS> TCSTICMS { get; set; }
        public DbSet<TCSTIPI> TCSTIPI { get; set; }
        public DbSet<TCSTORIEM> TCSTORIEM { get; set; }
        public DbSet<TCSTPIS> TCSTPIS { get; set; }
        public DbSet<TCTE> TCTE { get; set; }
        public DbSet<TCTEDOCUMENTOANTERIOR> TCTEDOCUMENTOANTERIOR { get; set; }
        public DbSet<TCTENFEORIGINARIA> TCTENFEORIGINARIA { get; set; }
        public DbSet<TCTENFORIGINARIA> TCTENFORIGINARIA { get; set; }
        public DbSet<TCTEOUTROSDOCORIGINARIA> TCTEOUTROSDOCORIGINARIA { get; set; }
        public DbSet<TCTEQTDECARGA> TCTEQTDECARGA { get; set; }
        public DbSet<TCTEVEICULO> TCTEVEICULO { get; set; }
        public DbSet<TCTEVEICULOSTRANSPORTADO> TCTEVEICULOSTRANSPORTADO { get; set; }
        public DbSet<TCTRC> TCTRC { get; set; }
        public DbSet<TDADOCONTABILISTA> TDADOCONTABILISTA { get; set; }
        public DbSet<TDAVD2> TDAVD2 { get; set; }
        public DbSet<TDAVD3> TDAVD3 { get; set; }
        public DbSet<TDESCARREGAMENTOMDFE> TDESCARREGAMENTOMDFE { get; set; }
        public DbSet<TDETALHEREDUCAOZ> TDETALHEREDUCAOZ { get; set; }
        public DbSet<TDOCDESCARREGAMENTOMDFE> TDOCDESCARREGAMENTOMDFE { get; set; }
        public DbSet<TEMITENTE> TEMITENTE { get; set; }
        public DbSet<TENTREGA> TENTREGA { get; set; }
        public DbSet<TENTREGANFE> TENTREGANFE { get; set; }
        public DbSet<TESPECIE> TESPECIE { get; set; }
        public DbSet<TESTADOS> TESTADOS { get; set; }
        public DbSet<TESTADOSICMSSUBS> TESTADOSICMSSUBS { get; set; }
        public DbSet<TESTOQUE> TESTOQUE { get; set; }
        public DbSet<TETIQUETA> TETIQUETA { get; set; }
        public DbSet<TFORMAPAGAMENTOALUGUEL> TFORMAPAGAMENTOALUGUEL { get; set; }
        public DbSet<TFORMAPAGAMENTOCTE> TFORMAPAGAMENTOCTE { get; set; }
        public DbSet<TFORMAPAGAMENTOECF> TFORMAPAGAMENTOECF { get; set; }
        public DbSet<TFORMAPAGAMENTONFCE> TFORMAPAGAMENTONFCE { get; set; }
        public DbSet<TFORMAPAGAMENTONFE> TFORMAPAGAMENTONFE { get; set; }
        public DbSet<TFORMAPAGAMENTONOTAMANUAL> TFORMAPAGAMENTONOTAMANUAL { get; set; }
        public DbSet<TFORMAPAGAMENTOOS> TFORMAPAGAMENTOOS { get; set; }
        public DbSet<TFORNECEDOR> TFORNECEDOR { get; set; }
        public DbSet<TFUNCAO> TFUNCAO { get; set; }
        public DbSet<TFUNCIONARIO> TFUNCIONARIO { get; set; }
        public DbSet<TGRADE> TGRADE { get; set; }
        public DbSet<TGRADEITEMPEDIDOCOMPRA> TGRADEITEMPEDIDOCOMPRA { get; set; }
        public DbSet<TGRUPOCLIENTE> TGRUPOCLIENTE { get; set; }
        public DbSet<TGRUPOESTOQUE> TGRUPOESTOQUE { get; set; }
        public DbSet<THISTORICOSERIAL> THISTORICOSERIAL { get; set; }
        public DbSet<TICMSEMITENTE> TICMSEMITENTE { get; set; }
        public DbSet<TIMPOSTO> TIMPOSTO { get; set; }
        public DbSet<TIMPOSTOISS> TIMPOSTOISS { get; set; }
        public DbSet<TIMPOSTOMEDIO> TIMPOSTOMEDIO { get; set; }
        public DbSet<TIMPRESSAOMOBILE> TIMPRESSAOMOBILE { get; set; }
        public DbSet<TITEMAJUSTE> TITEMAJUSTE { get; set; }
        public DbSet<TITEMALUGUEL> TITEMALUGUEL { get; set; }
        public DbSet<TITEMCOMANDA> TITEMCOMANDA { get; set; }
        public DbSet<TITEMCOMANDAADICIONAL> TITEMCOMANDAADICIONAL { get; set; }
        public DbSet<TITEMCOMPRA> TITEMCOMPRA { get; set; }
        public DbSet<TITEMCOMPRAGRADE> TITEMCOMPRAGRADE { get; set; }
        public DbSet<TITEMCOMPRASERIAL> TITEMCOMPRASERIAL { get; set; }
        public DbSet<TITEMCONDICIONAL> TITEMCONDICIONAL { get; set; }
        public DbSet<TITEMCONDICIONALGRADE> TITEMCONDICIONALGRADE { get; set; }
        public DbSet<TITEMCONDICIONALSERIAL> TITEMCONDICIONALSERIAL { get; set; }
        public DbSet<TITEMCONTAGEMESTOQUE> TITEMCONTAGEMESTOQUE { get; set; }
        public DbSet<TITEMCOTACAO> TITEMCOTACAO { get; set; }
        public DbSet<TITEMDOCUMENTOANTERIORCTE> TITEMDOCUMENTOANTERIORCTE { get; set; }
        public DbSet<TITEMECFGRADE> TITEMECFGRADE { get; set; }
        public DbSet<TITEMECFSERIAL> TITEMECFSERIAL { get; set; }
        public DbSet<TITEMNFCEGRADE> TITEMNFCEGRADE { get; set; }
        public DbSet<TITEMNFCESERIAL> TITEMNFCESERIAL { get; set; }
        public DbSet<TITEMNFEVALIDADEESTOQUE> TITEMNFEVALIDADEESTOQUE { get; set; }
        public DbSet<TITEMNFEVEICULO> TITEMNFEVEICULO { get; set; }
        public DbSet<TITEMNOTACONSUMIDORGRADE> TITEMNOTACONSUMIDORGRADE { get; set; }
        public DbSet<TITEMNOTACONSUMIDORSERIAL> TITEMNOTACONSUMIDORSERIAL { get; set; }
        public DbSet<TITEMOPCOMPOSICAO> TITEMOPCOMPOSICAO { get; set; }
        public DbSet<TITEMOPGRADE> TITEMOPGRADE { get; set; }
        public DbSet<TITEMORCAMENTOGRADE> TITEMORCAMENTOGRADE { get; set; }
        public DbSet<TITEMORCAMENTOSERIAL> TITEMORCAMENTOSERIAL { get; set; }
        public DbSet<TITEMORDEMPRODUCAO> TITEMORDEMPRODUCAO { get; set; }
        public DbSet<TITEMOS> TITEMOS { get; set; }
        public DbSet<TITEMPEDIDOCOMPRA> TITEMPEDIDOCOMPRA { get; set; }
        public DbSet<TITEMPEDIDOVENDA> TITEMPEDIDOVENDA { get; set; }
        public DbSet<TITEMPEDIDOVENDAGRADE> TITEMPEDIDOVENDAGRADE { get; set; }
        public DbSet<TITEMPEDIDOVENDASERIAL> TITEMPEDIDOVENDASERIAL { get; set; }
        public DbSet<TITEMPREVENDA> TITEMPREVENDA { get; set; }
        public DbSet<TITEMPREVENDAGRADE> TITEMPREVENDAGRADE { get; set; }
        public DbSet<TITEMPREVENDASERIAL> TITEMPREVENDASERIAL { get; set; }
        public DbSet<TITEMTABELAPRECO> TITEMTABELAPRECO { get; set; }
        public DbSet<TITEMVENDAECF> TITEMVENDAECF { get; set; }
        public DbSet<TITEMVENDANFCE> TITEMVENDANFCE { get; set; }
        public DbSet<TITENNFEGRADE> TITENNFEGRADE { get; set; }
        public DbSet<TITENNFESERIAL> TITENNFESERIAL { get; set; }
        public DbSet<TITENNOTACONSUMIDOR> TITENNOTACONSUMIDOR { get; set; }
        public DbSet<TITENSORCAMENTO> TITENSORCAMENTO { get; set; }
        public DbSet<TITENSVENDANFE> TITENSVENDANFE { get; set; }
        public DbSet<TLACREMDFE> TLACREMDFE { get; set; }
        public DbSet<TLISTASERVICO> TLISTASERVICO { get; set; }
        public DbSet<TLOGRADOURO> TLOGRADOURO { get; set; }
        public DbSet<TMARCA> TMARCA { get; set; }
        public DbSet<TMDFE> TMDFE { get; set; }
        public DbSet<TMEIOPAGAMENTOVENDAECF> TMEIOPAGAMENTOVENDAECF { get; set; }
        public DbSet<TMENSAGEMNFE> TMENSAGEMNFE { get; set; }
        public DbSet<TMESA> TMESA { get; set; }
        public DbSet<TMOTIVOCANCELAMENTOVENDA> TMOTIVOCANCELAMENTOVENDA { get; set; }
        public DbSet<TMOTORISTA> TMOTORISTA { get; set; }
        public DbSet<TMOTORISTAMDFE> TMOTORISTAMDFE { get; set; }
        public DbSet<TMOVBANCO> TMOVBANCO { get; set; }
        public DbSet<TNFCEINUTILIZADA> TNFCEINUTILIZADA { get; set; }
        public DbSet<TNFEINUTILIZADAS> TNFEINUTILIZADAS { get; set; }
        public DbSet<TNOTACONSUMIDOR> TNOTACONSUMIDOR { get; set; }
        public DbSet<TNOTACTRC> TNOTACTRC { get; set; }
        public DbSet<TOBJETOSOS> TOBJETOSOS { get; set; }
        public DbSet<TOPERACAO> TOPERACAO { get; set; }
        public DbSet<TOPERACAOL> TOPERACAOL { get; set; }
        public DbSet<TOPERADORACARTAO> TOPERADORACARTAO { get; set; }
        public DbSet<TORCAMENTO> TORCAMENTO { get; set; }
        public DbSet<TORDEMPRODUCAO> TORDEMPRODUCAO { get; set; }
        public DbSet<TORIGEM> TORIGEM { get; set; }
        public DbSet<TOS> TOS { get; set; }
        public DbSet<TPAFMD5> TPAFMD5 { get; set; }
        public DbSet<TPAFR06> TPAFR06 { get; set; }
        public DbSet<TPAFR07> TPAFR07 { get; set; }
        public DbSet<TPAFR50> TPAFR50 { get; set; }
        public DbSet<TPAFR54> TPAFR54 { get; set; }
        public DbSet<TPAFR60A> TPAFR60A { get; set; }
        public DbSet<TPAFR60D> TPAFR60D { get; set; }
        public DbSet<TPAFR60I> TPAFR60I { get; set; }
        public DbSet<TPAFR60M> TPAFR60M { get; set; }
        public DbSet<TPAFR60R> TPAFR60R { get; set; }
        public DbSet<TPAFR61> TPAFR61 { get; set; }
        public DbSet<TPAFR61R> TPAFR61R { get; set; }
        public DbSet<TPAGAMENTOVENDAECF> TPAGAMENTOVENDAECF { get; set; }
        public DbSet<TPAGAR> TPAGAR { get; set; }
        public DbSet<TPDV> TPDV { get; set; }
        public DbSet<TPEDIDOCOMPRA> TPEDIDOCOMPRA { get; set; }
        public DbSet<TPEDIDOVENDA> TPEDIDOVENDA { get; set; }
        public DbSet<TPERCURSOMDFE> TPERCURSOMDFE { get; set; }
        public DbSet<TPERFILPAF> TPERFILPAF { get; set; }
        public DbSet<TPLANOCONTA> TPLANOCONTA { get; set; }
        public DbSet<TPREVENDA> TPREVENDA { get; set; }
        public DbSet<TPRODUCAOFINALIZADA> TPRODUCAOFINALIZADA { get; set; }
        public DbSet<TREBOQUEMDFE> TREBOQUEMDFE { get; set; }
        public DbSet<TRECEBER> TRECEBER { get; set; }
        public DbSet<TREDUCAOZ> TREDUCAOZ { get; set; }
        public DbSet<TSEQUENCIA> TSEQUENCIA { get; set; }
        public DbSet<TSERIAL> TSERIAL { get; set; }
        public DbSet<TSITUACAOOS> TSITUACAOOS { get; set; }
        public DbSet<TSUBGRUPOESTOQUE> TSUBGRUPOESTOQUE { get; set; }
        public DbSet<TTABELAPRECO> TTABELAPRECO { get; set; }
        public DbSet<TTEMP> TTEMP { get; set; }
        public DbSet<TTEMP2> TTEMP2 { get; set; }
        public DbSet<TTEMP3> TTEMP3 { get; set; }
        public DbSet<TTEMPCAIXA> TTEMPCAIXA { get; set; }
        public DbSet<TTEMPCOMPRA> TTEMPCOMPRA { get; set; }
        public DbSet<TTEMPM> TTEMPM { get; set; }
        public DbSet<TTEMPNFE> TTEMPNFE { get; set; }
        public DbSet<TTEMPPDV> TTEMPPDV { get; set; }
        public DbSet<TTEMPPDV2> TTEMPPDV2 { get; set; }
        public DbSet<TTEMPPDVALIQUOTAECF> TTEMPPDVALIQUOTAECF { get; set; }
        public DbSet<TTEMPPP> TTEMPPP { get; set; }
        public DbSet<TTRANSPORTADORA> TTRANSPORTADORA { get; set; }
        public DbSet<TUNIDADEMEDIDA> TUNIDADEMEDIDA { get; set; }
        public DbSet<TUSUARIO> TUSUARIO { get; set; }
        public DbSet<TVALIDADEESTOQUE> TVALIDADEESTOQUE { get; set; }
        public DbSet<TVEICULO> TVEICULO { get; set; }
        public DbSet<TVENDAECF> TVENDAECF { get; set; }
        public DbSet<TVENDANFCE> TVENDANFCE { get; set; }
        public DbSet<TVENDANFE> TVENDANFE { get; set; }
        public DbSet<TVENDANFEREFERENCIADA> TVENDANFEREFERENCIADA { get; set; }
        public DbSet<TSEQUENCIANFE> TSEQUENCIANFE { get; set; }
    }
}
