using Infra.GeradorProvas.Compartilhado;
using Infra.GeradorProvas.Compartilhado.Serializador;
using System;
using System.Windows.Forms;

namespace Apresentacao.GeradorProvas
{
    internal static class Program
    {
        static string caminho = @"C:\Users\marco\source\repos\GeradorProvas\Repositorio.GeradorProvas\Data\data.json";
        //static string caminho = @"C:\Windows\Temp\data.json";
        static SerializadorDadosEmJsonDotnet serializador = new SerializadorDadosEmJsonDotnet(caminho);
        static DataContext contextoDados = new DataContext(serializador);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaPrincipalForm(contextoDados));

            contextoDados.GravarDados();
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            contextoDados.GravarDados();
        }
    }
}
