using GeradorProvas.Compartilhado;
using GeradorProvas.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorProvas
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        //private DateContext contextoDados;
        public TelaPrincipalForm()
        {
            InitializeComponent();
            Instancia = this;

            txtRodape.Text = string.Empty;

            InicializarControladores();

        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            txtRodape.Text = mensagem;
        }

        private void menuMateria_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void menuQuestao_Click(object sender, EventArgs e)
        {

        }

        private void menuExame_Click(object sender, EventArgs e)
        {

        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();

        }
            public void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObterConfiguracaoToolbox();

            if(configuracao != null)
            {
                toolStrip.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObterListagem();

            panelConteudo.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelConteudo.Controls.Add(listagemControl);
        }

        private void InicializarControladores()
        {
            //Repositorios aqui

            controladores = new Dictionary<string, ControladorBase>();
            controladores.Add("Materias", new ControladorMateria());
        }
    }
}
