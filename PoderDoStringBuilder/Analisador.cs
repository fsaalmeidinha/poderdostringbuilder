using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoderDoStringBuilder
{
    public class Analisador
    {
        static System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        public static void AnalisarResultadoGeracaoRelatorio()
        {
            int qtdUsuarios = 10;

            PrintarAnalise(qtdUsuarios);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            qtdUsuarios = 1000;
            PrintarAnalise(qtdUsuarios);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            qtdUsuarios = 10000;
            PrintarAnalise(qtdUsuarios);
            Console.ReadKey();
        }

        private static void PrintarAnalise(int qtdUsuarios)
        {
            stopwatch.Start();
            string relatorio_ComSB = Usuario.GerarRelatorioAcessoAoSistema_UtilizandoStringBuilder(qtdUsuarios);
            stopwatch.Stop();
            TimeSpan tsTempoGeracaoRelatorio_comSB = stopwatch.Elapsed;
            Console.WriteLine(String.Format("Relatório de {0} usuários COM string builder - Tempo de execução: {1}", qtdUsuarios, tsTempoGeracaoRelatorio_comSB));
            stopwatch.Reset();

            stopwatch.Start();
            string relatorio_SemSB = Usuario.GerarRelatorioAcessoAoSistema_SemUtilizarStringBuilder(qtdUsuarios);
            stopwatch.Stop();
            TimeSpan tsTempoGeracaoRelatorio_semSB = stopwatch.Elapsed;
            Console.WriteLine(String.Format("Relatório de {0} usuários SEM string builder - Tempo de execução: {1}", qtdUsuarios, tsTempoGeracaoRelatorio_semSB));
            stopwatch.Reset();

            double multiplicadorDeTempo = Math.Max(tsTempoGeracaoRelatorio_comSB.Ticks, tsTempoGeracaoRelatorio_semSB.Ticks) / Math.Min(tsTempoGeracaoRelatorio_comSB.Ticks, tsTempoGeracaoRelatorio_semSB.Ticks);
            string metodoMaisRapido = tsTempoGeracaoRelatorio_comSB.Ticks < tsTempoGeracaoRelatorio_semSB.Ticks ? "com string builder" : "sem string builder";
            string metodoMaisLento = tsTempoGeracaoRelatorio_comSB.Ticks < tsTempoGeracaoRelatorio_semSB.Ticks ? "sem string builder" : "com string builder";
            Console.WriteLine(String.Format("--> Gerar o relatório {0} foi {1} vezes mais rapido do que gerar o relatório {2}.", metodoMaisRapido, multiplicadorDeTempo.ToString("N2"), metodoMaisLento));
        }
    }
}
