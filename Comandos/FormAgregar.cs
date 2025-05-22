using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comandos
{
    public partial class FormAgregar : Form
    {
        // Propiedades para edición
        private string nombreOriginal;
        private string ipOriginal;
        private string usuarioOriginal;
        private string passwordOriginal;
        private bool esEdicion = false;

        public FormAgregar()
        {
            InitializeComponent();
        }

        // Constructor para edición
        public FormAgregar(string nombre, string ip, string usuario, string passwordBase64)
            : this()
        {
            txtNomServer.Text = nombre;
            txtIP.Text = ip;
            txtUsuario.Text = usuario;
            txtcontrasena.Text = DecifrarPassword(passwordBase64);

            nombreOriginal = nombre;
            ipOriginal = ip;
            usuarioOriginal = usuario;
            passwordOriginal = passwordBase64;
            esEdicion = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNomServer.Text) ||
                string.IsNullOrWhiteSpace(txtIP.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtcontrasena.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de IP
            if (!System.Net.IPAddress.TryParse(txtIP.Text, out _))
            {
                MessageBox.Show("La dirección IP no es válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string xmlPath = System.IO.Path.Combine(Application.StartupPath, "servidores.xml");
                var doc = new System.Xml.XmlDocument();

                // Si el archivo existe, cargarlo; si no, crear estructura básica
                if (System.IO.File.Exists(xmlPath))
                {
                    doc.Load(xmlPath);
                }
                else
                {
                    var root = doc.CreateElement("Servidores");
                    doc.AppendChild(root);
                }

                if (esEdicion)
                {
                    // Buscar el nodo exacto por nombre, IP y usuario originales
                    var nodoServidor = doc.SelectSingleNode(
                        $"//Servidor[Nombre='{nombreOriginal}' and IP='{ipOriginal}' and Usuario='{usuarioOriginal}']"
                    );

                    if (nodoServidor != null)
                    {
                        nodoServidor["Nombre"].InnerText = txtNomServer.Text;
                        nodoServidor["IP"].InnerText = txtIP.Text;
                        nodoServidor["Usuario"].InnerText = txtUsuario.Text;
                        nodoServidor["Password"].InnerText = Convert.ToBase64String(Encoding.UTF8.GetBytes(txtcontrasena.Text));
                        // Si tienes comandos, aquí puedes actualizar la lista de comandos si lo deseas

                        doc.Save(xmlPath);
                        MessageBox.Show("Se ha modificado la información del servidor", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el servidor a modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Crear nuevo nodo servidor
                    var servidor = doc.CreateElement("Servidor");

                    var nombre = doc.CreateElement("Nombre");
                    nombre.InnerText = txtNomServer.Text;
                    servidor.AppendChild(nombre);

                    var ip = doc.CreateElement("IP");
                    ip.InnerText = txtIP.Text;
                    servidor.AppendChild(ip);

                    var usuario = doc.CreateElement("Usuario");
                    usuario.InnerText = txtUsuario.Text;
                    servidor.AppendChild(usuario);

                    // Encriptar contraseña (Base64)
                    var password = doc.CreateElement("Password");
                    var plainTextBytes = Encoding.UTF8.GetBytes(txtcontrasena.Text);
                    password.InnerText = Convert.ToBase64String(plainTextBytes);
                    servidor.AppendChild(password);

                    // Agregar al documento
                    doc.DocumentElement.AppendChild(servidor);

                    // Guardar cambios
                    doc.Save(xmlPath);

                    MessageBox.Show("Se ha agregado un nuevo servidor", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (esEdicion)
                    MessageBox.Show($"Ha ocurrido un error modificando el servidor:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Ha ocurrido un error agregando el servidor:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string DecifrarPassword(string passwordCifrada)
        {
            if (string.IsNullOrEmpty(passwordCifrada))
                return string.Empty;
            try
            {
                byte[] data = Convert.FromBase64String(passwordCifrada);
                return Encoding.UTF8.GetString(data);
            }
            catch
            {
                return passwordCifrada;
            }
        }
    }
}
