namespace Apresentacao.GeradorProvas.ModuloTeste
{
    partial class TelaTipoImpressaoForm
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
            this.groupBoxTipoImpressao = new System.Windows.Forms.GroupBox();
            this.rBtnGabarito = new System.Windows.Forms.RadioButton();
            this.rBtnSemGabarito = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.groupBoxTipoImpressao.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTipoImpressao
            // 
            this.groupBoxTipoImpressao.Controls.Add(this.rBtnGabarito);
            this.groupBoxTipoImpressao.Controls.Add(this.rBtnSemGabarito);
            this.groupBoxTipoImpressao.Location = new System.Drawing.Point(90, 53);
            this.groupBoxTipoImpressao.Name = "groupBoxTipoImpressao";
            this.groupBoxTipoImpressao.Size = new System.Drawing.Size(222, 121);
            this.groupBoxTipoImpressao.TabIndex = 0;
            this.groupBoxTipoImpressao.TabStop = false;
            this.groupBoxTipoImpressao.Text = "Tipo impressão";
            // 
            // rBtnGabarito
            // 
            this.rBtnGabarito.AutoSize = true;
            this.rBtnGabarito.Location = new System.Drawing.Point(60, 69);
            this.rBtnGabarito.Name = "rBtnGabarito";
            this.rBtnGabarito.Size = new System.Drawing.Size(70, 19);
            this.rBtnGabarito.TabIndex = 1;
            this.rBtnGabarito.TabStop = true;
            this.rBtnGabarito.Text = "Gabarito";
            this.rBtnGabarito.UseVisualStyleBackColor = true;
            // 
            // rBtnSemGabarito
            // 
            this.rBtnSemGabarito.AutoSize = true;
            this.rBtnSemGabarito.Location = new System.Drawing.Point(60, 32);
            this.rBtnSemGabarito.Name = "rBtnSemGabarito";
            this.rBtnSemGabarito.Size = new System.Drawing.Size(51, 19);
            this.rBtnSemGabarito.TabIndex = 0;
            this.rBtnSemGabarito.TabStop = true;
            this.rBtnSemGabarito.Text = "Teste";
            this.rBtnSemGabarito.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::Apresentacao.GeradorProvas.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(232, 196);
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
            this.btnGravar.Image = global::Apresentacao.GeradorProvas.Properties.Resources.icon_pdf;
            this.btnGravar.Location = new System.Drawing.Point(40, 196);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(134, 54);
            this.btnGravar.TabIndex = 10;
            this.btnGravar.Text = "Gerar PDF";
            this.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // TelaTipoImpressaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 262);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.groupBoxTipoImpressao);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaTipoImpressaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar PDF";
            this.groupBoxTipoImpressao.ResumeLayout(false);
            this.groupBoxTipoImpressao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTipoImpressao;
        private System.Windows.Forms.RadioButton rBtnGabarito;
        private System.Windows.Forms.RadioButton rBtnSemGabarito;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
    }
}