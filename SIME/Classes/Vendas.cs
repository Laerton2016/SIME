using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADODB;

namespace Sime
{
    public class VendasUsuario
    {
        private int codUsuario;
        private Connection conexao;
        private Recordset dados = new Recordset();
        private String SQL;
        private Double especie = 0, cheque = 0, vale = 0, cartao = 0;
        private Dictionary<DateTime, List<String[]>> dadosVenda = new Dictionary<DateTime, List<string[]>>();
        private Dictionary<DateTime, Double> resumoData = new Dictionary<DateTime, double>();

        public VendasUsuario (int codUsuario, DateTime inicio, DateTime fim, Connection conexao)
        {
             if (inicio > fim) {
                throw new ArgumentException("Data inicial maior que a data final.");
            }
             
            this.codUsuario = codUsuario;
            this.conexao = conexao;
            dados.LockType = LockTypeEnum.adLockBatchOptimistic;
            dados.CursorLocation = CursorLocationEnum.adUseServer;
            SQL = @"SELECT Cod_sai.Data, Cod_sai.Especie, Cod_sai.Cheque, Cod_sai.Vale, Cod_sai.cartao, Cod_sai.OP, Clientes.Nome " +
                  "FROM Cod_sai INNER JOIN Clientes ON Cod_sai.Cod_cliente = Clientes.Cod_cliente " +
                  "WHERE (((Cod_sai.Data) Between #" + (inicio.Month + "/" + inicio.Day + "/" + inicio.Year) + "# And #" + (fim.Month + "/" + fim.Day + "/" + fim.Year)  +"#) AND ((Cod_sai.OP)=" + codUsuario + "));";
            coletaDados();
        }
       
        
        private void coletaDados() {
            abreConexao();
            
            while (!(dados.EOF || dados.BOF )){
                double totalAnterior = especie + cheque + vale + cartao, atual = 0;
                String[] informacoes = new string[5];
                List<String[]> infoVenda = new List<string[]>();
                atual = dados.Fields["especie"].Value + dados.Fields["cheque"].Value + dados.Fields["cartao"].Value + dados.Fields["vale"].Value;

                if (atual > 0)
                {
                    informacoes[1] = Convert.ToString (dados.Fields["especie"].Value) ;
                    especie += Convert.ToDouble(dados.Fields["especie"].Value);
                    informacoes[2] = Convert.ToString (dados.Fields["cheque"].Value);
                    cheque += Convert.ToDouble(dados.Fields["cheque"].Value);
                    informacoes[3] = Convert.ToString (dados.Fields["cartao"].Value);
                    cartao += Convert.ToDouble(dados.Fields["cartao"].Value);
                    informacoes[4] = Convert.ToString (dados.Fields["vale"].Value);
                    vale += Convert.ToDouble(dados.Fields["vale"].Value);
                    informacoes[0] = Convert.ToString (dados.Fields["nome"].Value);
                    

                    if (dadosVenda.ContainsKey(Convert.ToDateTime(dados.Fields["data"].Value)) == false)
                    {   
                        infoVenda.Add(informacoes);
                        dadosVenda.Add(Convert.ToDateTime(dados.Fields["data"].Value), infoVenda);
                        resumoData.Add( (Convert.ToDateTime(dados.Fields["data"].Value) ),atual );
                    }
                    else 
                    { 
                        infoVenda = dadosVenda[Convert.ToDateTime(dados.Fields["data"].Value)];
                        infoVenda.Add(informacoes);
                        dadosVenda[Convert.ToDateTime(dados.Fields["data"].Value)] = infoVenda;
                        resumoData[Convert.ToDateTime(dados.Fields["data"].Value)] += atual;
                    }
                }

                

                dados.MoveNext();
            }
            fechaConexao();
        }
        private void abreConexao() { 
            if (dados.State != 0 ) {
                fechaConexao();
            }
            dados.Open(SQL, conexao);
        }

        private void fechaConexao() {
            if (dados.State != 0) {
                dados.Close();
            }
        }

        public String resumeVendas() {
            String resumo = null;
            resumo = "Especie: R$ " + especie + "\nCheques: R$ "+ cheque + "\nCartão: R$ "+ cartao + "\nVale: R$ "+ vale + "\nTotal: R$ " + (especie + cheque + vale + cartao );
            return resumo;
        }
    }
}