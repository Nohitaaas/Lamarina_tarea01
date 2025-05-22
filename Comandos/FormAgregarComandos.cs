using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comandos
{
    public partial class FormAgregarComandos : Form
    {
        public string NuevoComando { get; private set; }

        private TextBox txtComando;
        private Button btnAceptar;
        private Button btnCancelar;

        public FormAgregarComandos()
        {
            InitializeComponent();
            this.Load += FormAgregarComando_Load;
        }

        private void FormAgregarComando_Load(object sender, EventArgs e)
        {
            // TextBox para el comando
            txtComando = new TextBox { Width = 250, Top = 20, Left = 20 };
            Controls.Add(txtComando);

            // Botón Aceptar
            btnAceptar = new Button
            {
                Text = "Aceptar",
                Width = 80,
                Height = 30,
                Top = txtComando.Bottom + 20,
                Left = txtComando.Left
            };
            btnAceptar.Click += BtnAceptar_Click;
            Controls.Add(btnAceptar);

            // Botón Cancelar
            btnCancelar = new Button
            {
                Text = "Cancelar",
                Width = 80,
                Height = 30,
                Top = txtComando.Bottom + 20,
                Left = btnAceptar.Right + 10
            };
            btnCancelar.Click += BtnCancelar_Click;
            Controls.Add(btnCancelar);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtComando.Text))
            {
                NuevoComando = txtComando.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Debe digitar un comando.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}