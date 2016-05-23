using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADODB;

namespace SIME.Inventario
{
    public class Inventario2013
    {
        private Int32 idProduto = 0;
        private String EAN;
        private Int32 idUsuario = 0;
        private Int32 quantidade = 0;
        private Int32 qAnterior = 0;
        private DateTime data = DateTime.Now;
        private Recordset rsDados = new Recordset();
        private Connection conex = new Conexao().getDb4();

        private SIME.Class.Produto produto;
        //private SIME.Class.Uteis util = new Class.Uteis();

        public Inventario2013(Int32 idProduto, Int32 idUsuario)
        {
            if (idProduto <=0) { throw new ArgumentException("O código do produto não pode ter valor menor ou igual a zero."); }

            try
            {
                produto = new Class.Produto(idProduto, conex);
            }
            catch (Exception erro)
            {

                throw new ArgumentException(erro.Message);
            }

            this.idProduto = idProduto;
            this.idUsuario = idUsuario;
            this.quantidade = produto.getquantEstoque();
            data = DateTime.Now;
        }

        public String getEAN() { return this.EAN; }
        public Int32 getIdUsuario() { return this.idUsuario; }
        public Int32 getIdProduto() { return this.idProduto; }
        public Int32 getQuantidade() { return this.quantidade; }
        public Int32 getQuantidadeAnterior() { return this.qAnterior; }
        public DateTime getData() { return this.data; }

        public void setEAN(String EAN)
        {
            if (EAN.Equals("") || EAN == null)
            {
                throw new ArgumentNullException("O código de barras EAN não pode ter comprimento nulo ou vazio");
            }

            if (EAN.Length > 13)
            {
                throw new ArgumentException("O código de barras EAN não pode conter mais que 13 dígitos.");
            }
            /**
            if (!(util.Sonumeros(EAN)))
            {
                throw new ArgumentException("O código de barras EAN só pode conter números.");
            }
            **/
            this.EAN = EAN;
        }

        public void setQuantidade(Int32 quantidade)
        {
            if (quantidade < 0)
            {
                throw new ArgumentException("Não pode ser informado quantidade negativa.");
            }
            this.qAnterior = this.quantidade;
            this.quantidade = quantidade;
        }

        public Boolean salvar()
        {
            String SQL = "INSERT INTO inventário2013 ( ID_produto, EAN, ID_usuario, Quantidade, Quantidade_anterior, Data ) " +
                         "SELECT " + idProduto + ",'" + EAN + "'," + idUsuario + ", " + quantidade + ", " + qAnterior + ", #" + data.Month + "/" 
                         + data.Day + "/" + data.Year + "#;";

            try
            {
                produto.setEAN(this.EAN);
                produto.setquantEstoque(this.quantidade);
                produto.salvar(false);
                
                if (rsDados.State != 0)
                {
                    rsDados.Close();
                }

                rsDados.Open(SQL, new Conexao().getDb4(), CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic);

            }
            catch (Exception erro)
            {
                throw new ArgumentException(erro.Message);
            }
            return true;
        }

        public override string ToString()
        {
            return "PRODUTO: " + produto.getDescricao() + Environment.NewLine +
                "EAN: " + EAN + Environment.NewLine +
                "ESTOQUE: " + quantidade + Environment.NewLine +
                "ANTERIOR: " + qAnterior;
        }

        public Boolean jaregistrado(Int32 idProduto)
        {
            String SQL = "SELECT inventário2013.* FROM inventário2013 WHERE (((inventário2013.ID_produto)=" + idProduto + "));";
            
            if (rsDados.State != 0)
            {
                rsDados.Close();
            }
            rsDados.Open(SQL, new Conexao().getDb4() , CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic);
            if (!(rsDados.BOF || rsDados.EOF))
            {
                
                return true;
            }
            
            return false;
        }

        public Boolean jaEAN(String EAN)
        {
            String SQL = "SELECT inventário2013.* FROM inventário2013 WHERE (((inventário2013.EAN)='" + EAN + "'));";
            if (rsDados.State != 0)
            {
                rsDados.Close();
            }
            
            rsDados.Open(SQL, new Conexao().getDb4(), CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic);
            if (rsDados.EOF || rsDados.BOF)
            {
                
                return false;
            }
            
            return true;
        }

        public Class.Produto getProduto() { return this.produto; }

        public List<String[]> getItensCadastrados() 
        {
            List< String[]> retorno = new List<String[]>();
            String SQL1 = "SELECT inventário2013.ID_produto, Sum(inventário2013.Quantidade) AS SomaDeQuantidade FROM inventário2013 GROUP BY inventário2013.ID_produto;";
            Recordset itens = new Recordset();
            Double total = 0;
            
            SIME.Class.Produto produto;
            itens.Open(SQL1, new Conexao().getDb4(), CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic);
                String[] rotulo = new String[8];
                rotulo[0] = "ID";
                rotulo[1] = "DESCRIÇÃO";
                rotulo[2] = "ESTOQUE";
                rotulo[3] = "CONTAGEM";
                rotulo[4] = "DIVERGE";
                rotulo[5] = "UNITÁRIO";
                rotulo[6] = "TOTAL";
                rotulo[7] = "USER'S";
                retorno.Add(rotulo);
                
                while (!(itens.BOF || itens.EOF))
                {
                    produto = new Class.Produto(Convert.ToInt32(itens.Fields["id_produto"].Value.ToString()), new Conexao().getDb4());
                    String[] conteudo = new String[8];
                    conteudo[0] = produto.getID().ToString();
                    conteudo[1] = produto.getDescricao();
                    conteudo[2] = produto.getquantEstoque().ToString();
                    conteudo[3] = itens.Fields["SomaDeQuantidade"].Value.ToString();
                    conteudo[4] = (Convert.ToInt32(itens.Fields["SomaDeQuantidade"].Value.ToString()) != produto.getquantEstoque()) ? "true" : "false";
                    conteudo[5] = "R$ " + produto.getCusto().ToString("N2");
                    conteudo[6] = "R$ " + (produto.getCusto() * produto.getquantEstoque()).ToString("N2");
                    conteudo[7] = getLancamentosPorUsusario(produto.getID());
                    total += (produto.getCusto() * produto.getquantEstoque());
                    retorno.Add(conteudo);
                    itens.MoveNext();
                }
                String[] conteudo1 = new String[7];
                conteudo1[5] = "TOTAL GERAL";
                conteudo1[6] = "R$ " + total.ToString("N2");
                retorno.Add(conteudo1);

             return retorno;
        }
        public List<String[]> getItensDivergentes()
        {
            List<String[]> retorno = new List<String[]>();
            String SQL1 = "SELECT inventário2013.ID_produto, Sum(inventário2013.Quantidade) AS SomaDeQuantidade FROM inventário2013 GROUP BY inventário2013.ID_produto;";
            Recordset itens = new Recordset();
            Double total = 0;

            SIME.Class.Produto produto;
            
            itens.Open(SQL1, new Conexao().getDb4(), CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic);
            String[] rotulo = new String[8];
            rotulo[0] = "ID";
            rotulo[1] = "DESCRIÇÃO";
            rotulo[2] = "ESTOQUE";
            rotulo[3] = "CONTAGEM";
            rotulo[4] = "DIVERGE";
            rotulo[5] = "UNITÁRIO";
            rotulo[6] = "TOTAL";
            rotulo[7] = "USER'S";
            retorno.Add(rotulo);
            
            while (!(itens.BOF || itens.EOF))
            {
                produto = new Class.Produto(Convert.ToInt32(itens.Fields["id_produto"].Value.ToString()), new Conexao().getDb4());
                if (Convert.ToInt32(itens.Fields["SomaDeQuantidade"].Value.ToString()) != produto.getquantEstoque())
                {
                    String[] conteudo = new String[8];
                    conteudo[0] = produto.getID().ToString();
                    conteudo[1] = produto.getDescricao();
                    conteudo[2] = produto.getquantEstoque().ToString();
                    conteudo[3] = itens.Fields["SomaDeQuantidade"].Value.ToString();
                    conteudo[4] = (Convert.ToInt32(itens.Fields["SomaDeQuantidade"].Value.ToString()) != produto.getquantEstoque()) ? "true" : "false";
                    conteudo[5] = "R$ " + produto.getCusto().ToString("N2");
                    conteudo[6] = "R$ " + (produto.getCusto() * produto.getquantEstoque()).ToString("N2");
                    conteudo[7] = getLancamentosPorUsusario(produto.getID());
                    total += (produto.getCusto() * produto.getquantEstoque());
                    retorno.Add(conteudo);
                
                }
                itens.MoveNext();
            }
            String[] conteudo1 = new String[7];
            conteudo1[5] = "TOTAL GERAL";
            conteudo1[6] = "R$ " + total.ToString("N2");
            retorno.Add(conteudo1);
            
            
            return retorno;
        }

        public String getLancamentosPorUsusario(Int32 id_produto)
        {
            String retorno = "";

            Recordset lancamentos = new Recordset();
            Sime.Usuarios usuarios = new Sime.Usuarios(new SIME.Conexao().getContas());
            String SQL2 = "SELECT inventário2013.ID_produto, inventário2013.ID_usuario, Sum(inventário2013.Quantidade) AS SomaDeQuantidade " +
                           "FROM inventário2013 GROUP BY inventário2013.ID_produto, inventário2013.ID_usuario HAVING (((inventário2013.ID_produto)=" + id_produto + "));";
            
            lancamentos.Open(SQL2, new Conexao().getDb4(), CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic);

            while (!(lancamentos.BOF || lancamentos.EOF))
            {

                //String[] conteudo = new String[2];
                Int32 id_usuario = Convert.ToInt32(lancamentos.Fields["id_usuario"].Value.ToString());
                retorno += usuarios.buscaUsuario(id_usuario).getNome() + ": ";
                retorno += lancamentos.Fields["SomaDeQuantidade"].Value.ToString()+ " ";
                //retorno.Add(conteudo);
                lancamentos.MoveNext();

            }
            
            return retorno;
        }
        public Inventario2013() { }
    }
    
}