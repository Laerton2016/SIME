using SIME.Class.CUteis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace SIME.Class.primitivo
{
    public class NetVenda
    {
        private DateTime _date;
        private Int64 _id_cliente, _id, _id_operador, _id_caixa;
        private float _especie, _cheque, _vale, _cartao;
        private List<NetItemVenda> itens;


        public NetVenda(Int64 idOperador)
        {
            Date = DateTime.Now;
            Id = 0;
            Idcaixa = 0;
            Idcliente = 0;
            Idoperador = idOperador;
            Especie = 0;
            Cheque = 0;
            Vale = 0;
            Cartao = 0;
            Itens = new List<primitivo.NetItemVenda>();
        }

        public void AddItemVenda(NetItemVenda item)
        {
            itens.Add(item);
        }

        public void RemItemVenda(NetItemVenda item)
        {
            foreach (var i in Itens)
            {
                if (i.Equals(item))
                {
                    itens.Remove(i);
                    break;
                }
            }
        }

        public void UpItemVenda(NetItemVenda item)
        {
            RemItemVenda(item);
            AddItemVenda(item);
        }
        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public long Idcliente
        {
            get
            {
                return _id_cliente;
            }

            set
            {
                _id_cliente = value;
            }
        }

        public long Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public long Idoperador
        {
            get
            {
                return _id_operador;
            }

            set
            {
                _id_operador = value;
            }
        }

        public long Idcaixa
        {
            get
            {
                return _id_caixa;
            }

            set
            {
                _id_caixa = value;
            }
        }

        public float Especie
        {
            get
            {
                return _especie;
            }

            set
            {
                _especie = value;
            }
        }

        public float Cheque
        {
            get
            {
                return _cheque;
            }

            set
            {
                _cheque = value;
            }
        }

        public float Vale
        {
            get
            {
                return _vale;
            }

            set
            {
                _vale = value;
            }
        }

        public float Cartao
        {
            get
            {
                return _cartao;
            }

            set
            {
                _cartao = value;
            }
        }

        public List<NetItemVenda> Itens
        {
            get
            {
                return itens;
            }

            set
            {
                itens = value;
            }
        }

        
    }
}