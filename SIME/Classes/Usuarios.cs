using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADODB;
using System.Web.UI.WebControls;


namespace Sime
{
    public class Usuarios
    {
        private static ADODB.Connection conexao;
        private static string usuario;
        private static string senha;
        private static Int32 codUsuario;
        private static Int16 tipoUsuario;
        private static Recordset dados = new Recordset();
        private static String SQL;
        private static List<String[]> listUsuarios = new List<string[]>();
        private static VendasUsuario vendas;
        
        /// <summary>
        /// Classe cria um objeto do tipo usuário que contém informações de um determinado usuário do sistema
        /// </summary>
        /// <param name="conexao">recebe um objeto do tipo ADODB.Connection para linkar ao banco de dados</param>
        public Usuarios(Connection conexaoArg) {
            
            conexao = conexaoArg;
            if (dados.State == 0)
            {
                dados.LockType = LockTypeEnum.adLockOptimistic;
                dados.CursorLocation = CursorLocationEnum.adUseClient;
                dados.CursorType = CursorTypeEnum.adOpenDynamic;
            }
            SQL = "SELECT usuarios.* FROM usuarios ORDER BY usuarios.matricula;";
            usuario = null;
            senha = null;
            codUsuario = 0;
            tipoUsuario = 0;
            
            //Lista de usuários
            abreConexao();
            criaListaUsuarios();
            fechaConexao();
        }

       
        /// <summary>
        /// Classe cria um objeto do tipo usuário que contém informações de um determinado usuário do sistema
        /// </summary>
        /// <param name="conexao">Recebe um objeto do tipo ADODB.Connection para linkar ao banco de dados</param>
        /// <param name="usuario">Filtra os dados de um determinado Usuário</param>
        public Usuarios (Connection conexaoArg, String usuarioArg) {
            conexao = conexaoArg;
            usuario = usuarioArg;
            if (dados.State == 0)
            {
                dados.LockType = LockTypeEnum.adLockOptimistic;
                dados.CursorLocation = CursorLocationEnum.adUseClient;
                dados.CursorType = CursorTypeEnum.adOpenDynamic;
            }
            SQL = "SELECT usuarios.* FROM usuarios WHERE (((usuarios.matricula)='" + usuario + "')) ORDER BY usuarios.matricula;";
            abreConexao();

            if (dados.RecordCount == 0) throw new ArgumentException("Usuário não encontrado.");
            

                usuario = usuarioArg;
                senha = dados.Fields["senha"].Value;
                codUsuario = dados.Fields["cod"].Value;
                tipoUsuario = Convert.ToInt16(dados.Fields["Tipo"].Value);


                if (tipoUsuario == 1)
                {
                    fechaConexao();
                    SQL = "SELECT usuarios.* FROM usuarios ORDER BY usuarios.matricula;";
                    abreConexao();
                }

                criaListaUsuarios();
                fechaConexao();

            
            
        }

        public  Int16 buscaCodUsuario(String matricula) {
            for (int i = 0; i < listUsuarios.Count; i++) {
                if (listUsuarios[i][0].Equals(matricula)) {
                    return Convert.ToInt16 (  listUsuarios[i][1]);
                }
            }
            return 0;
        }

        private static  void criaListaUsuarios()
        {
            String item;
            dados.MoveFirst();
            while (!(dados.BOF || dados.EOF))
            {
                item = Convert.ToString(dados.Fields["Matricula"].Value);
                String[] itens = { item.ToUpper() , Convert.ToString(dados.Fields["cod"].Value)} ;
                listUsuarios.Add(itens);
                dados.MoveNext();
            }
        }
        private static  void abreConexao() {
            if (dados.State != 0) {
                fechaConexao();
            }
            
                dados.Open(SQL, conexao);
            
        }

        private static void fechaConexao() {
            if (dados.State != 0)
            {
                dados.Close();
            }
        }

        public  void preencheCombo(System.Web.UI.WebControls.DropDownList combo) {

            combo.Items.Clear();
            String resp = Convert.ToString (combo.Items.Count);

            Int16 Q = Convert.ToInt16 (listUsuarios.Count) ;
                
            for (int I = 0; I < Q; I++) {
                combo.Items.Add(listUsuarios[I][0].ToUpper());
            }
            if (usuario != null)
            {
                combo.Text = usuario.ToUpper();
            }
        }
        
        /// <summary>
        /// Metodo faz um filtro de vendas por periudo para usuário padrão do construtor
        /// É lançado exerção caso o construtor não tenha recebido o argumento do usuário
        /// </summary>
        /// <param name="inicio">Recebe um Obj do tipo DateTime para o inicio do perioudo</param>
        /// <param name="fim">Recebe um Obj do tipo DateTime para o fim do perioudo</param>
        /// <returns></returns>
        public string producaoUsuario(DateTime inicio, DateTime fim)
        {
            if (usuario == null) {
                throw new ArgumentException("Usuário não definido.");
            }   
            return producaoUsuario (codUsuario  , inicio , fim ) ;
        }

        public Boolean confereSenha(String senha) {
            if (senha.Equals(senha)) { return true; }
            return false;
        }
        public string producaoUsuario(int cod, DateTime inicio, DateTime fim)
        {
            String retorno = "Não há movimento.";
            Connection db4 = new Connection();
            string endereco = "\\\\oxbr\\c\\novo\\bd4.mdb";
            db4.ConnectionString =  "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + endereco +";Persist Security Info=False;Jet OLEDB:Database Password=495798";
            db4.Open();
            vendas = new VendasUsuario(cod, inicio, fim, db4);
            retorno = vendas.resumeVendas();
            db4.Close();
            return retorno ;
        }

        public String getUsuario() {
            return usuario;
        }

         public Usuarios ShalonCopy ()
         {
            return  (Usuarios) this.MemberwiseClone();
        }

    }
}