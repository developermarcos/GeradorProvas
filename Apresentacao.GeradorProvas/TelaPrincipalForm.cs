﻿using GeradorProvas.Compartilhado;
using GeradorProvas.ModuloExame;
using GeradorProvas.ModuloMateria;
using GeradorProvas.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Infra.GeradorProvas.Compartilhado;
using Infra.GeradorProvas.ModuloMateria;
using Infra.GeradorProvas.ModuloQuestao;

namespace Apresentacao.GeradorProvas
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        private DataContext contextoDados;

        public TelaPrincipalForm(DataContext contextoDados)
        {
            InitializeComponent();

            Instancia = this;

            txtRodape.Text = string.Empty;

            this.contextoDados = contextoDados;

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
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void menuExame_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
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
            var repositorioMateria = new RepositorioMateriaEmArquivo(contextoDados);
            var repositorioQuestao = new RepositorioQuestaoEmArquivo(contextoDados);

            controladores = new Dictionary<string, ControladorBase>();
            controladores.Add("Materias", new ControladorMateria(repositorioMateria));
            controladores.Add("Questões", new ControladorQuestao(repositorioQuestao, repositorioMateria));
            controladores.Add("Exames", new ControladorExame());
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }
    }
}
