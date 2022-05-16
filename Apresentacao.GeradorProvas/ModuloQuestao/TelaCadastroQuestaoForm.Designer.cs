namespace GeradorProvas.ModuloQuestao
{
    partial class TelaCadastroQuestaoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxDiciplina = new System.Windows.Forms.ComboBox();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.rBtnFalso = new System.Windows.Forms.RadioButton();
            this.rBtnVerdade = new System.Windows.Forms.RadioButton();
            this.textBoxAlternativa = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.listaAlternativas = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.cBoxMateria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Diciplina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrição";
            // 
            // cBoxDiciplina
            // 
            this.cBoxDiciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxDiciplina.FormattingEnabled = true;
            this.cBoxDiciplina.Location = new System.Drawing.Point(100, 22);
            this.cBoxDiciplina.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cBoxDiciplina.Name = "cBoxDiciplina";
            this.cBoxDiciplina.Size = new System.Drawing.Size(240, 23);
            this.cBoxDiciplina.TabIndex = 1;
            this.cBoxDiciplina.SelectedIndexChanged += new System.EventHandler(this.cBoxDiciplina_SelectedIndexChanged);
            this.cBoxDiciplina.Leave += new System.EventHandler(this.cBoxDiciplina_Leave);
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(100, 92);
            this.textBoxDescricao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(487, 23);
            this.textBoxDescricao.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAdicionar);
            this.groupBox1.Controls.Add(this.rBtnFalso);
            this.groupBox1.Controls.Add(this.rBtnVerdade);
            this.groupBox1.Controls.Add(this.textBoxAlternativa);
            this.groupBox1.Location = new System.Drawing.Point(20, 136);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(568, 102);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alternativa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Descrição";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = global::Apresentacao.GeradorProvas.Properties.Resources.add;
            this.btnAdicionar.Location = new System.Drawing.Point(435, 52);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(122, 46);
            this.btnAdicionar.TabIndex = 7;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // rBtnFalso
            // 
            this.rBtnFalso.AutoSize = true;
            this.rBtnFalso.Checked = true;
            this.rBtnFalso.Location = new System.Drawing.Point(144, 60);
            this.rBtnFalso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rBtnFalso.Name = "rBtnFalso";
            this.rBtnFalso.Size = new System.Drawing.Size(51, 19);
            this.rBtnFalso.TabIndex = 6;
            this.rBtnFalso.TabStop = true;
            this.rBtnFalso.Text = "Falsa";
            this.rBtnFalso.UseVisualStyleBackColor = true;
            // 
            // rBtnVerdade
            // 
            this.rBtnVerdade.AutoSize = true;
            this.rBtnVerdade.Location = new System.Drawing.Point(10, 60);
            this.rBtnVerdade.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rBtnVerdade.Name = "rBtnVerdade";
            this.rBtnVerdade.Size = new System.Drawing.Size(80, 19);
            this.rBtnVerdade.TabIndex = 5;
            this.rBtnVerdade.TabStop = true;
            this.rBtnVerdade.Text = "Verdadeira";
            this.rBtnVerdade.UseVisualStyleBackColor = true;
            // 
            // textBoxAlternativa
            // 
            this.textBoxAlternativa.Location = new System.Drawing.Point(80, 22);
            this.textBoxAlternativa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAlternativa.Name = "textBoxAlternativa";
            this.textBoxAlternativa.Size = new System.Drawing.Size(481, 23);
            this.textBoxAlternativa.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExcluir);
            this.groupBox2.Controls.Add(this.listaAlternativas);
            this.groupBox2.Location = new System.Drawing.Point(20, 250);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(568, 278);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alternativas";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::Apresentacao.GeradorProvas.Properties.Resources.trash;
            this.btnExcluir.Location = new System.Drawing.Point(435, 22);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(122, 46);
            this.btnExcluir.TabIndex = 9;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // listaAlternativas
            // 
            this.listaAlternativas.FormattingEnabled = true;
            this.listaAlternativas.ItemHeight = 15;
            this.listaAlternativas.Location = new System.Drawing.Point(7, 22);
            this.listaAlternativas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listaAlternativas.Name = "listaAlternativas";
            this.listaAlternativas.Size = new System.Drawing.Size(409, 244);
            this.listaAlternativas.TabIndex = 8;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::Apresentacao.GeradorProvas.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(332, 538);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(134, 54);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Image = global::Apresentacao.GeradorProvas.Properties.Resources.pasta;
            this.btnGravar.Location = new System.Drawing.Point(141, 538);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(134, 54);
            this.btnGravar.TabIndex = 10;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // cBoxMateria
            // 
            this.cBoxMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxMateria.FormattingEnabled = true;
            this.cBoxMateria.Location = new System.Drawing.Point(100, 57);
            this.cBoxMateria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cBoxMateria.Name = "cBoxMateria";
            this.cBoxMateria.Size = new System.Drawing.Size(240, 23);
            this.cBoxMateria.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Matéria";
            // 
            // TelaCadastroQuestaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 606);
            this.Controls.Add(this.cBoxMateria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(this.cBoxDiciplina);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroQuestaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroQuestaoForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxDiciplina;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtnFalso;
        private System.Windows.Forms.RadioButton rBtnVerdade;
        private System.Windows.Forms.TextBox textBoxAlternativa;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listaAlternativas;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxMateria;
        private System.Windows.Forms.Label label4;
    }
}