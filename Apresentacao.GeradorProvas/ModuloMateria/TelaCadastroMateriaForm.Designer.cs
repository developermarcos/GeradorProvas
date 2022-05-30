namespace GeradorProvas.ModuloMateria
{
    partial class TelaCadastroMateriaForm
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
            this.cBoxDiciplina = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxSerie = new System.Windows.Forms.ComboBox();
            this.txtboxMateria = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtBoxNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cBoxDiciplina
            // 
            this.cBoxDiciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxDiciplina.FormattingEnabled = true;
            this.cBoxDiciplina.Location = new System.Drawing.Point(90, 57);
            this.cBoxDiciplina.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cBoxDiciplina.Name = "cBoxDiciplina";
            this.cBoxDiciplina.Size = new System.Drawing.Size(210, 23);
            this.cBoxDiciplina.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Diciplina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Série";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Matéria";
            // 
            // cBoxSerie
            // 
            this.cBoxSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSerie.FormattingEnabled = true;
            this.cBoxSerie.Location = new System.Drawing.Point(90, 95);
            this.cBoxSerie.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cBoxSerie.Name = "cBoxSerie";
            this.cBoxSerie.Size = new System.Drawing.Size(88, 23);
            this.cBoxSerie.TabIndex = 4;
            // 
            // txtboxMateria
            // 
            this.txtboxMateria.Location = new System.Drawing.Point(90, 133);
            this.txtboxMateria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtboxMateria.Name = "txtboxMateria";
            this.txtboxMateria.Size = new System.Drawing.Size(312, 23);
            this.txtboxMateria.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::Apresentacao.GeradorProvas.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(244, 188);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(134, 54);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Image = global::Apresentacao.GeradorProvas.Properties.Resources.add;
            this.btnGravar.Location = new System.Drawing.Point(53, 188);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(134, 54);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // txtBoxNumero
            // 
            this.txtBoxNumero.Enabled = false;
            this.txtBoxNumero.Location = new System.Drawing.Point(90, 20);
            this.txtBoxNumero.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxNumero.Name = "txtBoxNumero";
            this.txtBoxNumero.Size = new System.Drawing.Size(56, 23);
            this.txtBoxNumero.TabIndex = 9;
            this.txtBoxNumero.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Numero";
            // 
            // TelaCadastroMateriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 256);
            this.Controls.Add(this.txtBoxNumero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.txtboxMateria);
            this.Controls.Add(this.cBoxSerie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBoxDiciplina);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroMateriaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroMateriaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxDiciplina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxSerie;
        private System.Windows.Forms.TextBox txtboxMateria;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtBoxNumero;
        private System.Windows.Forms.Label label4;
    }
}