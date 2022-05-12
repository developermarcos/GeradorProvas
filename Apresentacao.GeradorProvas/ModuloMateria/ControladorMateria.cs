using Apresentacao.GeradorProvas;
using Dominio.GeradorProvas.ModuloMateria;
using GeradorProvas.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeradorProvas.ModuloMateria
{
    internal class ControladorMateria : ControladorBase
    {
        private TabelaMateriaControl tabelaMateria;
        private IRepositorioMateria repositorioMateria;

        public ControladorMateria(IRepositorioMateria repositorioMateria)
        {
            this.repositorioMateria=repositorioMateria;
        }

        public override void Editar()
        {
            Materia materiaSelecionada = ObtemMateriaSelecionada();

            if(materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma materia primeiro",
                    "Edição de Matéria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroMateriaForm telaCadastro = new TelaCadastroMateriaForm("Editar Matéria");

            telaCadastro.Materia = materiaSelecionada;

            telaCadastro.GravarRegistro = repositorioMateria.Editar;

            DialogResult resultado = telaCadastro.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarMaterias();
        }

        public override void Excluir()
        {
            Materia materiaSelecionada = ObtemMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma materia primeiro",
                    "Edição de Matéria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir essa matéria?", 
                "Excluir matéria", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioMateria.Excluir(materiaSelecionada);
                CarregarMaterias();
            }

        }

        public override void Filtrar()
        {
            TelaFiltroMateriaForm telaFiltro = new TelaFiltroMateriaForm("Filtrar Matérias");
            telaFiltro.ShowDialog();
        }

        public override void Inserir()
        {
            TelaCadastroMateriaForm telaCadastro = new TelaCadastroMateriaForm("Cadastrar Matéria");
            telaCadastro.Materia = new Materia();
            telaCadastro.GravarRegistro = repositorioMateria.Inserir;
            DialogResult resultado = telaCadastro.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarMaterias();
        }

        public override ConfiguracaoToolboxBase ObterConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxMateria();
        }

        public override UserControl ObterListagem()
        {
            tabelaMateria = new TabelaMateriaControl();

            CarregarMaterias();

            return tabelaMateria;
        }
        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            if(materias != null && materias.Count > 0)
                tabelaMateria.AtualizarRegistros(materias);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {materias.Count} materia(s)");
        }

        private Materia ObtemMateriaSelecionada()
        {
            int numeroSelecionado = tabelaMateria.ObtemNumeroCompromissoSelecionado();

            Materia materiaSelecionada = repositorioMateria.SelecionarPorNumero(numeroSelecionado);

            return materiaSelecionada;
        }
    }
}
