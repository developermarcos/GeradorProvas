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
            this.groupBox1.Location = new System.Drawing.Point(118, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 141);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // rBtnTodos
            // 
            this.rBtnTodos.AutoSize = true;
            this.rBtnTodos.Location = new System.Drawing.Point(58, 79);
            this.rBtnTodos.Name = "rBtnTodos";
            this.rBtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rBtnTodos.TabIndex = 2;
            this.rBtnTodos.TabStop = true;
            this.rBtnTodos.Text = "Todos";
            this.rBtnTodos.UseVisualStyleBackColor = true;
            // 
            // rBtnSerie
            // 
            this.rBtnSerie.AutoSize = true;
            this.rBtnSerie.Location = new System.Drawing.Point(58, 56);
            this.rBtnSerie.Name = "rBtnSerie";
            this.rBtnSerie.Size = new System.Drawing.Size(54, 17);
            this.rBtnSerie.TabIndex = 1;
            this.rBtnSerie.TabStop = true;
            this.rBtnSerie.Text = "Séries";
            this.rBtnSerie.UseVisualStyleBackColor = true;
            // 
            // rBtnMateria
            // 
            this.rBtnMateria.AutoSize = true;
            this.rBtnMateria.Location = new System.Drawing.Point(58, 33);
            this.rBtnMateria.Name = "rBtnMateria";
            this.rBtnMateria.Size = new System.Drawing.Size(65, 17);
            this.rBtnMateria.TabIndex = 0;
            this.rBtnMateria.TabStop = true;
            this.rBtnMateria.Text = "Matérias";
            this.rBtnMateria.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::GeradorProvas.Properties.Resources.cancel1;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(241, 271);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 47);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFiltrar.Image = global::GeradorProvas.Properties.Resources.verify;
            this.btnFiltrar.Location = new System.Drawing.Point(77, 271);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(115, 47);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroQuestaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 348);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFiltrar);
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