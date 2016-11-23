using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIME.Class
{
    public class Usuario
    {
        private Int16 cod, tipo;
        private String nome, senha;


        public Usuario(Int16 cod, String nome, String senha, Int16 tipo)
        {
            this.Cod = cod;
            this.Tipo = tipo;
            this.Nome = nome;
            this.Senha = senha;
        }

        public Usuario()
        {
            this.Cod = 0;
            this.Tipo = 0;

        }
        public short Cod
        {
            get
            {
                return cod;
            }

            set
            {
                cod = value;
            }
        }

        public short Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        
        /// <summary>
        /// Método que compara se a senha informada confere
        /// </summary>
        /// <param name="senha">Recebe String contendo a senha</param>
        /// <returns>Retorna boolean </returns>
        public Boolean validaSenha(String senha) {
            return this.Senha.Equals(senha);
        }

        public Int16 getTipo() {
            return Tipo;
        }

        public string GetSenha()
        {
            return Senha;
        }

        public Int16 getCod() {
            return Cod;
        }

        public String getNome() {
            return Nome;
        }

        override public String ToString() {
            return Convert.ToString(Cod) + "," + Nome + ","  + Convert.ToString(Tipo);
        }



    }
}