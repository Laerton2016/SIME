using SIME.Class.Conexoes;
using SIME.Class.primitivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cassandra;
using Cassandra.Mapping;
using System.IO;
using System.Runtime.Serialization.Json;
using SIME.Class.CUteis;

//using System.Runtime.Serialization.Json;


namespace SIME.Class.DAO
{
    /// <summary>
    /// 
    /// </summary>
    public class CassandraItem : IDAO<NetVenda>
    {
        public NetVenda Buscar(long id)
        {
            String CQL = "Select * from saida where id = " + id + ";";
            NetVenda venda = new NetVenda(0);
            List<String> lista = new List<string>();
            var rs = ConexCassandra.Instance().GetSession().Execute(CQL);
            foreach (var item in rs)
            {
                venda.Id = item.GetValue<long>("id");
                venda.Cartao = (float) item.GetValue<double>("cartao");
                venda.Cheque = (float)item.GetValue<double>("cheque");
                venda.Especie = (float)item.GetValue<double>("especie");
                venda.Idcaixa = item.GetValue<long>("idcaixa");
                venda.Idcliente = item.GetValue<long>("idcliente");
                venda.Idoperador = item.GetValue<int>("idoperador");
                venda.Vale = (float)item.GetValue<double>("vale");
                lista = item.GetValue<List<String>>("itens");
            }
            //MemoryStream stream1 = new MemoryStream();
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NetItemVenda));
            foreach (var item in lista)
            {

                /*DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NetItemVenda));
                MemoryStream ms = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(item));
                NetItemVenda i = (NetItemVenda)js.ReadObject(ms);*/
                venda.AddItemVenda(Json<NetItemVenda>.Deserializa(item));  
            }
            return venda;

        }

        public void Excluir(NetVenda t)
        {
            throw new NotImplementedException();
        }

        public NetVenda Salvar(NetVenda t)
        {
            String CQL = "";
            
            if (t.Id == 0)
            {
                long id = BuscaUltimoId();
                CQL = "insert into saida (id, cartao, cheque, especie, idcaixa, idcliente, idoperador, itens, vale) values (" + id + "," + t.Cartao.ToString().Replace(',', '.') + "," + t.Cheque.ToString().Replace(',', '.') + ", "+ t.Especie.ToString().Replace(',', '.') + "," + t.Idcaixa + ","+ t.Idcliente + "," + t.Idoperador + "," + ItensJson(t.Itens) + "," + t.Vale.ToString().Replace(',', '.') + ");";
                t.Id = id;
            }
            else
            {
                CQL = "update saida set  cartao = "+ t.Cartao.ToString().Replace(',','.') + ", cheque= " + t.Cheque.ToString().Replace(',', '.') + ", especie= " + t.Especie.ToString().Replace(',', '.') + ", idcaixa= " + t.Idcaixa + ", idcliente= " + t.Idcliente + ", idoperador= " + t.Idoperador + ", itens= " + ItensJson(t.Itens) + ", vale= " + t.Vale.ToString().Replace(',', '.') + " where id = "+t.Id+";";
            }
            ConexCassandra.Instance().GetSession().Execute(CQL);
            
            return t;

        }

        private long BuscaUltimoId()
        {
            String CQL = "Select * from saidacont;";
            var rs = ConexCassandra.Instance().GetSession().Execute(CQL);
            Int64 id = 0;

            foreach (var item in rs)
            {
                id = item.GetValue<long>("id");
            }
            if (id == 0)
            {
                CQL = "Insert into saidacont (id) values (1);";
                ConexCassandra.Instance().GetSession().Execute(CQL);
                id = 1;
            }
            else
            {
                CQL = "delete from saidacont where id = " + id + ";";
                ConexCassandra.Instance().GetSession().Execute(CQL);
                id++;
                CQL = "Insert into saidacont (id) values ("+(id)+");";
                ConexCassandra.Instance().GetSession().Execute(CQL);
            }
            return id;

        }
        private string ItensJson(List<NetItemVenda> itens)
        {
                String list = "[";
                int c = 0;
                foreach (var item in itens)
                {
                    c++;
                    String json = Json<NetItemVenda>.Serializa(item);
                    if (c < itens.Count)
                    {
                        list += "'" + json + "',";
                    }
                    else
                    {
                        list += "'" + json + "'";
                    }

                }
                list += "]";
                return list;
            
            
        }
    }
}