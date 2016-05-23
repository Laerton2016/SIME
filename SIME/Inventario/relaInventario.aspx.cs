using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIME.Class;
using System.Drawing;

namespace SIME.Inventario
{
    public partial class relaInventario : System.Web.UI.Page
    {
        Inventario2013 dados = new Inventario2013();
        SIME.Class.UteisWeb util = new Class.UteisWeb();
        Boolean diverge = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            diverge = Convert.ToBoolean(Request.QueryString["diverge"]);
            if (diverge) 
            {
                labDados.Text = montaTab(dados.getItensDivergentes(), "ITENS JÁ CONTADOS", System.Drawing.Color.Bisque);
            } 
            else 
            {
                labDados.Text = montaTab(dados.getItensCadastrados(), "ITENS JÁ CONTADOS", System.Drawing.Color.Bisque);
            }
        }

        public String montaTab(List<String[]> dadosInternos, String rotulo, System.Drawing.Color cor)
        {
            String retorno = "";
            String cabeca = "<span style='font-size: medium'>" + rotulo + "</span>";
            String inicioTabela = "<table style='width:100%;'>";
            String fimTabela = "</table>";
            String inicioLinha = "<tr>";
            String fimLinha = "</tr>";
            String[] linha;

            retorno = cabeca + inicioTabela;
            for (int i = 0; i < dadosInternos.Count; i++)
            {
                retorno += inicioLinha;
                linha = dadosInternos[i];
                for (int j = 0; j < linha.Count(); j++)
                {
                    if (i % 2 != 0) // Verifica se a linha é colorida ou branca
                    {
                        if (j == 0 && i > 0)
                        {
                            retorno += montaCelula(linha[j], false, EnunAlinhamentos.RIGHT, Color.White, "a", (j.ToString() + i.ToString()));
                        }
                        else
                        {
                            retorno += montaCelula(linha[j], false, EnunAlinhamentos.RIGHT, Color.White);
                        }
                    }
                    else
                    {
                        if (j == 0 && i > 0)
                        {
                            retorno += montaCelula(linha[j], false, EnunAlinhamentos.RIGHT, cor, "a", (j.ToString() + i.ToString()));
                        }
                        else
                        {
                            retorno += montaCelula(linha[j], false, EnunAlinhamentos.RIGHT, cor);
                        }
                    }
                }
                retorno += fimLinha;
               
            }

            retorno += fimTabela;
            return retorno;
        }

        private String[] estraiDados(String linha)
        {
            return linha.Split(',');
        }

        private String montaCelula(String texto, Boolean negrito, EnunAlinhamentos alinhamento, System.Drawing.Color cor)
        {
            String retorno = "";
            retorno = "<td align='" + alinhamento.ToString() + "'" +
                "bgcolor='" + cor.ToKnownColor() + "'" + " >" +
                ((negrito) ? "<B>" : "") + texto + ((negrito) ? "</B>" : "") + "</td>";
            return retorno;
        }

        private String montaCelula(String texto, Boolean negrito, EnunAlinhamentos alinhamento, System.Drawing.Color cor, String tipo, String ID)
        {
            String retorno = "";
            retorno = "<td align='" + alinhamento.ToString() + "'" +
                "bgcolor='" + cor.ToKnownColor() + "' >" +
                 "<"+ tipo + " href='"+ "' target='_blank'server' >" + texto +"</"+tipo+">" ;
            return retorno;
        }
        private String montaCelula(String texto)
        {
            return montaCelula(texto, false, EnunAlinhamentos.LEFT, Color.Cyan);
        }
    }
}