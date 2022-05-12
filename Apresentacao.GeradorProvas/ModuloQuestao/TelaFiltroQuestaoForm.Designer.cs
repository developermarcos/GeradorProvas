namespace GeradorProvas.ModuloQuestao
{
    partial class TelaFiltroQuestaoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBtnTodos = new System.Windows.Forms.RadioButton();
            this.rBtnSerie = new System.Windows.Forms.RadioButton();
            this.rBtnMateria = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBtnTodos);
            this.groupBox1.Controls.Add(this.rBtnSerie);
            this.groupBox1.Controls.Add(this.rBtnMateria);
            this.groupBox1.Location = new System.Drawing.Point(138, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(233, 163);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // rBtnTodos
            // 
            this.rBtnTodos.AutoSize = true;
            this.rBtnTodos.Location = new System.Drawing.Point(68, 91);
            this.rBtnTodos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rBtnTodos.Name = "rBtnTodos";
            this.rBtnTodos.Size = new System.Drawing.Size(56, 19);
            this.rBtnTodos.TabIndex = 2;
            this.rBtnTodos.TabStop = true;
            this.rBtnTodos.Text = "Todos";
            this.rBtnTodos.UseVisualStyleBackColor = true;
            // 
            // rBtnSerie
            // 
            this.rBtnSerie.AutoSize = true;
            this.rBtnSerie.Location = new System.Drawing.Point(68, 65);
            this.rBtnSerie.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rBtnSerie.Name = "rBtnSerie";
            this.rBtnSerie.Size = new System.Drawing.Size(55, 19);
            this.rBtnSerie.TabIndex = 1;
            this.rBtnSerie.TabStop = true;
            this.rBtnSerie.Text = "Séries";
            this.rBtnSerie.UseVisualStyleBackColor = true;
            // 
            // rBtnMateria
            // 
            this.rBtnMateria.AutoSize = true;
            this.rBtnMateria.Location = new System.Drawing.Point(68, 38);
            this.rBtnMateria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rBtnMateria.Name = "rBtnMateria";
            this.rBtnMateria.Size = new System.Drawing.Size(70, 19);
            this.rBtnMateria.TabIndex = 0;
            this.rBtnMateria.TabStop = true;
            this.rBtnMateria.Text = "Matérias";
            this.rBtnMateria.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::Apresentacao.GeradorProvas.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(281, 313);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(134, 54);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFiltrar.Image = global::Apresentacao.GeradorProvas.Properties.Resources.verify;
            this.btnFiltrar.Location = new System.Drawing.Point(90, 313);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(134, 54);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroQuestaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 402);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFiltrar);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaFiltroQuestaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaFiltroQuestaoForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtnTodos;
        private System.Windows.Forms.RadioButton rBtnSerie;
        private System.Windows.Forms.RadioButton rBtnMateria;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFiltrar;
    }
}