using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoderDoStringBuilder
{
    public class Usuario
    {
        private static int id = 1;
        private static Random random = new Random();

        #region Campos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int AcessosAoSistema { get; set; }
        #endregion Campos

        public static string GerarRelatorioAcessoAoSistema_UtilizandoStringBuilder(int qtdUsuarios)
        {
            StringBuilder sbRelatorio = new StringBuilder();
            List<Usuario> usuariosSistema = ListarUsuariosDoSistema(qtdUsuarios);

            foreach (Usuario usuarioSistema in usuariosSistema)
            {
                sbRelatorio.AppendLine(String.Format("Id:{0} - Nome: {1} - Email: {2} - Número de acessos: {3}",
                    usuarioSistema.Id, usuarioSistema.Nome, usuarioSistema.Email, usuarioSistema.AcessosAoSistema));
            }

            return sbRelatorio.ToString();
        }

        public static string GerarRelatorioAcessoAoSistema_SemUtilizarStringBuilder(int qtdUsuarios)
        {
            string relatorio = String.Empty;
            List<Usuario> usuariosSistema = ListarUsuariosDoSistema(qtdUsuarios);

            foreach (Usuario usuarioSistema in usuariosSistema)
            {
                relatorio += String.Format("Id:{0} - Nome: {1} - Email: {2} - Número de acessos: {3} {4}",
                    usuarioSistema.Id, usuarioSistema.Nome, usuarioSistema.Email, usuarioSistema.AcessosAoSistema, Environment.NewLine);
            }

            return relatorio;
        }

        public static List<Usuario> ListarUsuariosDoSistema(int qtdUsuarios)
        {
            List<Usuario> usuariosSistema = new List<Usuario>();

            for (int i = 0; i < qtdUsuarios; i++)
            {
                usuariosSistema.Add(CriarUsuario());
            }

            return usuariosSistema;
        }

        private static Usuario CriarUsuario()
        {
            string guid = Guid.NewGuid().ToString();
            return new Usuario()
            {
                Id = id++,
                Nome = guid,
                Email = String.Format("{0}@email.com.br", guid),
                AcessosAoSistema = random.Next(0, 9999)
            };
        }
    }
}
