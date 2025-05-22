namespace Comandos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnEjecutarComando = new System.Windows.Forms.Button();
            this.BtnModificarComando = new System.Windows.Forms.Button();
            this.BtnBorrarComando = new System.Windows.Forms.Button();
            this.BtnAgregarComando = new System.Windows.Forms.Button();
            this.BtnModificarServidor = new System.Windows.Forms.Button();
            this.BtnEliminarServidor = new System.Windows.Forms.Button();
            this.BtnAgregarServidor = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnModificarServidor);
            this.panel1.Controls.Add(this.BtnEliminarServidor);
            this.panel1.Controls.Add(this.BtnAgregarServidor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 100);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Servidores disponibles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comandos del servidor";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BtnEjecutarComando);
            this.panel2.Controls.Add(this.BtnModificarComando);
            this.panel2.Controls.Add(this.BtnBorrarComando);
            this.panel2.Controls.Add(this.BtnAgregarComando);
            this.panel2.Location = new System.Drawing.Point(225, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 55);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Location = new System.Drawing.Point(0, 258);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(715, 195);
            this.panel3.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(715, 195);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "\r\n\r\n\r\n";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(225, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(476, 183);
            this.panel4.TabIndex = 4;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "lblCommands";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(0, 106);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(219, 146);
            this.panel5.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "lblServers";
            // 
            // BtnEjecutarComando
            // 
            this.BtnEjecutarComando.BackColor = System.Drawing.Color.Transparent;
            this.BtnEjecutarComando.FlatAppearance.BorderSize = 0;
            this.BtnEjecutarComando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEjecutarComando.Image = ((System.Drawing.Image)(resources.GetObject("BtnEjecutarComando.Image")));
            this.BtnEjecutarComando.Location = new System.Drawing.Point(195, 4);
            this.BtnEjecutarComando.Name = "BtnEjecutarComando";
            this.BtnEjecutarComando.Size = new System.Drawing.Size(44, 39);
            this.BtnEjecutarComando.TabIndex = 3;
            this.BtnEjecutarComando.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEjecutarComando.UseVisualStyleBackColor = false;
            this.BtnEjecutarComando.Click += new System.EventHandler(this.BtnEjecutarComando_Click_1);
            // 
            // BtnModificarComando
            // 
            this.BtnModificarComando.BackColor = System.Drawing.Color.Transparent;
            this.BtnModificarComando.FlatAppearance.BorderSize = 0;
            this.BtnModificarComando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificarComando.Image = ((System.Drawing.Image)(resources.GetObject("BtnModificarComando.Image")));
            this.BtnModificarComando.Location = new System.Drawing.Point(118, 6);
            this.BtnModificarComando.Name = "BtnModificarComando";
            this.BtnModificarComando.Size = new System.Drawing.Size(44, 39);
            this.BtnModificarComando.TabIndex = 2;
            this.BtnModificarComando.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnModificarComando.UseVisualStyleBackColor = false;
            this.BtnModificarComando.Click += new System.EventHandler(this.BtnModificarComando_Click);
            // 
            // BtnBorrarComando
            // 
            this.BtnBorrarComando.BackColor = System.Drawing.Color.Transparent;
            this.BtnBorrarComando.FlatAppearance.BorderSize = 0;
            this.BtnBorrarComando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBorrarComando.Image = ((System.Drawing.Image)(resources.GetObject("BtnBorrarComando.Image")));
            this.BtnBorrarComando.Location = new System.Drawing.Point(74, 6);
            this.BtnBorrarComando.Name = "BtnBorrarComando";
            this.BtnBorrarComando.Size = new System.Drawing.Size(44, 39);
            this.BtnBorrarComando.TabIndex = 1;
            this.BtnBorrarComando.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBorrarComando.UseVisualStyleBackColor = false;
            this.BtnBorrarComando.Click += new System.EventHandler(this.BtnBorrarComando_Click);
            // 
            // BtnAgregarComando
            // 
            this.BtnAgregarComando.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarComando.FlatAppearance.BorderSize = 0;
            this.BtnAgregarComando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarComando.Image = global::Comandos.Properties.Resources.Captura_de_pantalla_2025_05_19_1127091;
            this.BtnAgregarComando.Location = new System.Drawing.Point(24, 6);
            this.BtnAgregarComando.Name = "BtnAgregarComando";
            this.BtnAgregarComando.Size = new System.Drawing.Size(44, 39);
            this.BtnAgregarComando.TabIndex = 0;
            this.BtnAgregarComando.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregarComando.UseVisualStyleBackColor = false;
            this.BtnAgregarComando.Click += new System.EventHandler(this.BtnAgregarComando_Click_1);
            // 
            // BtnModificarServidor
            // 
            this.BtnModificarServidor.BackColor = System.Drawing.Color.Transparent;
            this.BtnModificarServidor.FlatAppearance.BorderSize = 0;
            this.BtnModificarServidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificarServidor.Image = ((System.Drawing.Image)(resources.GetObject("BtnModificarServidor.Image")));
            this.BtnModificarServidor.Location = new System.Drawing.Point(122, 44);
            this.BtnModificarServidor.Name = "BtnModificarServidor";
            this.BtnModificarServidor.Size = new System.Drawing.Size(44, 39);
            this.BtnModificarServidor.TabIndex = 6;
            this.BtnModificarServidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnModificarServidor.UseVisualStyleBackColor = false;
            this.BtnModificarServidor.Click += new System.EventHandler(this.BtnModificarServidor_Click);
            // 
            // BtnEliminarServidor
            // 
            this.BtnEliminarServidor.BackColor = System.Drawing.Color.Transparent;
            this.BtnEliminarServidor.FlatAppearance.BorderSize = 0;
            this.BtnEliminarServidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminarServidor.Image = ((System.Drawing.Image)(resources.GetObject("BtnEliminarServidor.Image")));
            this.BtnEliminarServidor.Location = new System.Drawing.Point(62, 44);
            this.BtnEliminarServidor.Name = "BtnEliminarServidor";
            this.BtnEliminarServidor.Size = new System.Drawing.Size(44, 39);
            this.BtnEliminarServidor.TabIndex = 5;
            this.BtnEliminarServidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminarServidor.UseVisualStyleBackColor = false;
            this.BtnEliminarServidor.Click += new System.EventHandler(this.BtnEliminarServidor_Click);
            // 
            // BtnAgregarServidor
            // 
            this.BtnAgregarServidor.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarServidor.FlatAppearance.BorderSize = 0;
            this.BtnAgregarServidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarServidor.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregarServidor.Image")));
            this.BtnAgregarServidor.Location = new System.Drawing.Point(12, 44);
            this.BtnAgregarServidor.Name = "BtnAgregarServidor";
            this.BtnAgregarServidor.Size = new System.Drawing.Size(44, 39);
            this.BtnAgregarServidor.TabIndex = 4;
            this.BtnAgregarServidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregarServidor.UseVisualStyleBackColor = false;
            this.BtnAgregarServidor.Click += new System.EventHandler(this.BtnAgregarServidor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(708, 450);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAgregarComando;
        private System.Windows.Forms.Button BtnBorrarComando;
        private System.Windows.Forms.Button BtnEjecutarComando;
        private System.Windows.Forms.Button BtnModificarComando;
        private System.Windows.Forms.Button BtnEliminarServidor;
        private System.Windows.Forms.Button BtnAgregarServidor;
        private System.Windows.Forms.Button BtnModificarServidor;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
    }
}

