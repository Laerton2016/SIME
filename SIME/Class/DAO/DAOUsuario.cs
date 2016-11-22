using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace SIME.Class.DAO
{
    public class DAOUsuario : IDAO<Usuario>
    {

        public Usuario Buscar(long id)
        {
            String SQL = @"Select * from usuarios where cod = " + id + ";";
            Usuario user = null;
            using (var connection = (OleDbConnection) NetConexao.Instance().GetContasConnect())
            {
                connection.Open();
                var command = new OleDbCommand(SQL, connection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    user = MontaUser(dr);
                }
                dr.Close();
            }
            return user;
            
        }
        /// <summary>
        /// Método monta os usuário a parir dos dados de um data reader
        /// </summary>
        /// <param name="dr">Data reader com os dados </param>
        /// <returns>Usuário com os dados montados</returns>
        private Usuario MontaUser(OleDbDataReader dr)
        {
            Usuario user = new Usuario(Int16.Parse(dr["cod"].ToString()), dr["matricula"].ToString(), dr["senha"].ToString(), Int16.Parse(dr["tipo"].ToString()));
            return user;
        }

        public void Excluir(Usuario t)
        {
            using (var connect = (OleDbConnection) NetConexao.Instance().GetSimeConnect())
            {
                connect.Open();
                var transacao = connect.BeginTransaction();
                String SQL = "Delete * from usuarios where cod = " + t.getCod();
                var command = new  OleDbCommand(SQL, connect, transacao);
                try
                {
                    command.ExecuteNonQuery();
                    transacao.Commit();
                }
                catch (Exception e)
                {
                    transacao.Rollback();
                    throw new Exception (e.Message);
                }
            }
        }

        public Usuario Salvar(Usuario t)
        {
            String SQL = "";
            if (t.getCod() == 0)
            {
                SQL = "Insert into usuarios (matricula, senha, tipo) values (@matricula, @senha, @tipo);";
            }else
            {
                SQL = "Update usuarios set matricula = @matricula, senha = @senha, tipo = @tipo where cod = @cod;";
            }
            return Persiste(SQL, t);
        }

        private Usuario Persiste(string sQL, Usuario t)
        {
            using (var connect =(OleDbConnection) NetConexao.Instance().GetSimeConnect())
            {
                connect.Open();
                var transacao = connect.BeginTransaction();
                var command = new OleDbCommand(sQL, connect, transacao);
                command.Parameters.AddWithValue("@matricula", t.getNome());
                command.Parameters.AddWithValue("@senha", t.GetSenha());
                command.Parameters.AddWithValue("@tipo", t.getTipo());
                if (t.getCod() != 0)
                {
                    command.Parameters.AddWithValue("@cod", t.getCod());

                }
                try
                {
                    command.ExecuteNonQuery();
                    transacao.Commit();
                    if (t.getCod() == 0)
                    {
                        sQL = "select max(cod) as Id from usuarios;";
                        command.CommandText = sQL;
                        var dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            t = new Usuario(Int16.Parse(dr["cod"].ToString()), t.getNome(), t.GetSenha(), t.getTipo());
                        }
                        dr.Close();
                    }
                }
                catch (Exception e)
                {
                    transacao.Rollback();
                    throw new Exception (e.Message);
                }
            }
            return t;
        }
    }
}