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
using System.Xml.Linq;

namespace Comandos
{
    public partial class FormEditarComandos : Form
    {
        public string ComandoEditado { get; private set; }
        private string nombreServidor;
        private string comandoOriginal;


        public FormEditarComandos(string comandoActual, string nombreServidor)
        {
            InitializeComponent();
            txtComando.Text = comandoActual;
            this.nombreServidor = nombreServidor;
            this.comandoOriginal = comandoActual;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtComando.Text))
                {
                    MessageBox.Show("Por favor ingrese un comando válido", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ComandoEditado = txtComando.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error modificando el comando\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtComando.Text))
                {
                    MessageBox.Show("Ha ocurrido un error modificando el comando.\nCampo vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool exito = ModificarComando(txtComando.Text);

                if (exito)
                {
                    this.Close();
                    MessageBox.Show($"Se ha modificado la información del comando", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error modificando el comando", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error modificando el comando " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ModificarComando(string nuevoComando)
        {
            try
            {
                string rutaArchivo = Path.Combine(Application.StartupPath, "servidores.xml");

                XDocument doc = XDocument.Load(rutaArchivo);

                // Buscar el servidor con el nombre recibido (ignorando mayúsculas)
                var servidor = doc.Descendants("Servidor")
                                  .FirstOrDefault(s => string.Equals((string)s.Element("Nombre"), nombreServidor, StringComparison.OrdinalIgnoreCase));

                if (servidor == null)
                    throw new Exception($"No se encontró el servidor '{nombreServidor}' en el archivo XML.");

                // Buscar el comando que coincide con el comando original (antes de editar)
                var comandoElement = servidor.Descendants("Comando")
                                            .FirstOrDefault(c => c.Value.Trim() == comandoOriginal.Trim());

                if (comandoElement == null)
                    throw new Exception("No se encontró el comando especificado en el servidor.");

                // Actualizar el comando con el nuevo texto
                comandoElement.Value = nuevoComando;

                // Guardar cambios
                doc.Save(rutaArchivo);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error modificando el comando\nDescripción técnica: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}