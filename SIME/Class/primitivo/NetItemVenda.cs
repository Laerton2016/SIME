using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SIME.Class.primitivo
{
    /// <summary>
    /// Classe que cuida de um item de uma venda;
    /// </summary>
    [DataContract]
    public class NetItemVenda
    {
        [DataMember]
        internal Int64 _id_produto;
        [DataMember]
        internal Int64 _quantidade;
        [DataMember]
        internal Int64 _id;
        [DataMember]
        internal Int64 _id_venda;
        [DataMember]
        internal Int64 _loja;
        [DataMember]
        internal Int64 _id_fornecedor;
        [DataMember]
        internal float _valor;
        [DataMember]
        internal String _nf;
        [DataMember]
        internal String _descricao;

        public long Id_produto
        {
            get
            {
                return _id_produto;
            }

            set
            {
                _id_produto = value;
            }
        }

        public long Quantidade
        {
            get
            {
                return _quantidade;
            }

            set
            {
                _quantidade = value;
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

        public long Id_venda
        {
            get
            {
                return _id_venda;
            }

            set
            {
                _id_venda = value;
            }
        }

        public long Loja
        {
            get
            {
                return _loja;
            }

            set
            {
                _loja = value;
            }
        }

        public long Id_fornecedor
        {
            get
            {
                return _id_fornecedor;
            }

            set
            {
                _id_fornecedor = value;
            }
        }

        public float Valor
        {
            get
            {
                return _valor;
            }

            set
            {
                _valor = value;
            }
        }

        public string Nf
        {
            get
            {
                return _nf;
            }

            set
            {
                _nf = value;
            }
        }

        public string Descricao
        {
            get
            {
                return _descricao;
            }

            set
            {
                _descricao = value;
            }
        }

        public override string ToString()
        {
            return "Cod produto: " + this._id_produto + " Descrição: " + _descricao + " Quantidade: "+ this._quantidade + " Valor unitário:" + this.Valor.ToString("N") + " Valor total: " + (this.Valor * this.Quantidade).ToString("N");
        }

        public override bool Equals(object obj)
        {
            if (((NetItemVenda)obj).Id_produto == this.Id_produto && ((NetItemVenda)obj).Quantidade == this.Quantidade && ((NetItemVenda)obj).Id == this.Id)
            {
                return true;
            }
            return false;
        }
        public NetItemVenda()
        {
            Id = 0;
            Id_fornecedor = 0;
            Id_produto = 0;
            Id_venda = 0;
            Quantidade = 0;
            Valor = 0;
            Nf = "0";

        }
    }
}
