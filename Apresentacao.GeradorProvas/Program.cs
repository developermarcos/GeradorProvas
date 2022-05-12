using Infra.GeradorProvas.Compartilhado;
using Infra.GeradorProvas.Compartilhado.Serializador;
using System;
using System.Windows.Forms;

namespace Apresentacao.GeradorProvas
{
    internal static class Program
    {
        static SerializadorDadosEmJsonDotnet serializador = new SerializadorDadosEmJsonDotnet();
        static DataContext contextoDados = new DataContext(serializador);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
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
