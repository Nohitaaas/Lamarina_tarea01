﻿namespace Comandos
{
    partial class FormEditarComandos
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
            this.txtComando = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtComando
            // 
            this.txtComando.Location = new System.Drawing.Point(43, 39);
            this.txtComando.Name = "txtComando";
            this.txtComando.Size = new System.Drawing.Size(296, 26);
            this.txtComando.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(201, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormEditarComandos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 183);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtComando);
            this.Name = "FormEditarComandos";
            this.Text = "Editar Comandos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtComando;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}