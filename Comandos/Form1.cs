using System;
using System.Drawing;            
using System.Windows.Forms;
using Renci.SshNet;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
namespace Comandos
{
    public partial class Form1 : Form
    {
        private ListBox lbServers;
        private ListBox lbCommands;

        public Form1()
        {
            InitializeComponent();

            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = Color.Lime;
            textBox1.Font = new Font("Consolas", 10);

            this.Load += Form1_Load;
            BtnEjecutarComando.Click += BtnEjecutarComando_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // — SERVIDORES —
            panel5.Controls.Clear();
            lbServers = new ListBox
            {
                Dock = DockStyle.Fill,
                DisplayMember = "Nombre"
            };
            panel5.Controls.Add(lbServers);
            label4.Visible = false;

            lbServers.SelectedIndexChanged += LbServers_SelectedIndexChanged;

            CargarServidoresDesdeXml();

            // — COMANDOS —
            panel4.Controls.Clear();
            lbCommands = new ListBox
            {
                Dock = DockStyle.Fill,
                DisplayMember = "Texto"
            };
            panel4.Controls.Add(lbCommands);
            label3.Visible = false;
        }

        private async void BtnEjecutarComando_Click(object sender, EventArgs e)
        {
            if (lbServers.SelectedItem == null || lbCommands.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione el servidor y comando que desea ejecutar", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var srv = (Servidor)lbServers.SelectedItem;
            var cmd = (Comando)lbCommands.SelectedItem;
            string passwordDescifrada = DecifrarPassword(srv.Password);
            textBox1.Clear();

            try
            {
                await Task.Run(() =>
                {
                    Invoke((Action)(() => textBox1.AppendText($"Conectando a {srv.IP}...\r\n")));

                    using (var client = new SshClient(srv.IP, srv.Usuario, passwordDescifrada))
                    {
                        client.Connect();
                        Invoke((Action)(() => textBox1.AppendText("Conexión establecida.\r\n")));

                        // Escapar comillas simples y ejecutar en bash
                        var comandoShell = $"/bin/bash -c '{cmd.Texto.Replace("'", "'\\''")}'";
                        Invoke((Action)(() => textBox1.AppendText($"Ejecutando: {cmd.Texto}\r\n")));
                        var sshCmd = client.CreateCommand(comandoShell);
                        string salida = sshCmd.Execute();

                        Invoke((Action)(() => textBox1.AppendText(salida + "\r\n")));

                        client.Disconnect();
                        Invoke((Action)(() => textBox1.AppendText("Desconectado.\r\n")));
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar comando:\n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class Servidor
        {
            public string Nombre { get; set; }
            public string IP { get; set; }
            public string Usuario { get; set; }
            public string Password { get; set; }
            public List<Comando> Comandos { get; set; } = new List<Comando>();
        }

        private class Comando
        {
            public string Texto { get; set; }

            public override string ToString()
            {
                return Texto;
            }
        }

        private void BtnAgregarServidor_Click(object sender, EventArgs e)
        {
            using (FormAgregar agregar = new FormAgregar())
            {
                if (agregar.ShowDialog() == DialogResult.OK)
                {
                    CargarServidoresDesdeXml(seleccionarUltimo: true);
                }
            }
        }

        private void CargarServidoresDesdeXml(bool seleccionarUltimo = false)
        {
            lbServers.Items.Clear();
            string xmlPath = System.IO.Path.Combine(Application.StartupPath, "servidores.xml");
            if (!System.IO.File.Exists(xmlPath))
                return;

            var doc = new System.Xml.XmlDocument();
            doc.Load(xmlPath);

            foreach (System.Xml.XmlNode nodo in doc.SelectNodes("//Servidor"))
            {
                var servidor = new Servidor
                {
                    Nombre = nodo["Nombre"]?.InnerText,
                    IP = nodo["IP"]?.InnerText,
                    Usuario = nodo["Usuario"]?.InnerText,
                    Password = nodo["Password"]?.InnerText
                };

                var comandosNodo = nodo.SelectSingleNode("Comandos");
                if (comandosNodo != null)
                {
                    foreach (System.Xml.XmlNode cmdNodo in comandosNodo.SelectNodes("Comando"))
                    {
                        servidor.Comandos.Add(new Comando { Texto = cmdNodo.InnerText });
                    }
                }

                lbServers.Items.Add(servidor);
            }

            if (lbServers.Items.Count > 0 && seleccionarUltimo)
                lbServers.SelectedIndex = lbServers.Items.Count - 1;
        }

        private void LbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbCommands.Items.Clear();
            if (lbServers.SelectedItem is Servidor servidor)
            {
                foreach (var cmd in servidor.Comandos)
                {
                    lbCommands.Items.Add(cmd);
                }
            }
        }

        private string DecifrarPassword(string passwordCifrada)
        {
            if (string.IsNullOrEmpty(passwordCifrada))
                return string.Empty;
            try
            {
                byte[] data = Convert.FromBase64String(passwordCifrada);
                return System.Text.Encoding.UTF8.GetString(data);
            }
            catch
            {
                return passwordCifrada;
            }
        }

        private void BtnEliminarServidor_Click(object sender, EventArgs e)
        {
            if (lbServers.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un servidor", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show("¿Desea eliminar el servidor?", "Confirmación",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                var servidorSeleccionado = (Servidor)lbServers.SelectedItem;
                string xmlPath = System.IO.Path.Combine(Application.StartupPath, "servidores.xml");

                if (System.IO.File.Exists(xmlPath))
                {
                    var doc = new System.Xml.XmlDocument();
                    doc.Load(xmlPath);

                    var nodoServidor = doc.SelectSingleNode(
                        $"//Servidor[Nombre='{servidorSeleccionado.Nombre}' and IP='{servidorSeleccionado.IP}' and Usuario='{servidorSeleccionado.Usuario}']"
                    );

                    if (nodoServidor != null && nodoServidor.ParentNode != null)
                    {
                        nodoServidor.ParentNode.RemoveChild(nodoServidor);
                        doc.Save(xmlPath);
                    }
                }
                lbServers.Items.Remove(servidorSeleccionado);
                lbCommands.Items.Clear();
            }
        }

        private void BtnModificarServidor_Click(object sender, EventArgs e)
        {
            if (lbServers.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un servidor", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lbServers.SelectedItem is Servidor servidor)
            {
                using (var form = new FormAgregar(servidor.Nombre, servidor.IP, servidor.Usuario, servidor.Password))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CargarServidoresDesdeXml();
                    }
                }
            }
        }

        private void BtnAgregarComando_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (lbServers.SelectedItem == null)
                {
                    MessageBox.Show("Por favor seleccione un servidor primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var form = new FormAgregarComandos())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var nuevoComando = new Comando { Texto = form.NuevoComando };
                        lbCommands.Items.Add(nuevoComando);

                        var servidorSeleccionado = (Servidor)lbServers.SelectedItem;
                        servidorSeleccionado.Comandos.Add(nuevoComando);

                        string xmlPath = Path.Combine(Application.StartupPath, "servidores.xml");
                        XmlDocument doc = new XmlDocument();
                        doc.Load(xmlPath);

                        XmlNode nodoServidor = doc.SelectSingleNode(
                            $"//Servidor[Nombre='{servidorSeleccionado.Nombre}' and IP='{servidorSeleccionado.IP}' and Usuario='{servidorSeleccionado.Usuario}']");

                        if (nodoServidor != null)
                        {
                            XmlNode comandosNodo = nodoServidor.SelectSingleNode("Comandos");
                            if (comandosNodo == null)
                            {
                                comandosNodo = doc.CreateElement("Comandos");
                                nodoServidor.AppendChild(comandosNodo);
                            }

                            XmlElement nuevoComandoNodo = doc.CreateElement("Comando");
                            nuevoComandoNodo.InnerText = form.NuevoComando;
                            comandosNodo.AppendChild(nuevoComandoNodo);

                            doc.Save(xmlPath);
                        }

                        MessageBox.Show("Se ha agregado un nuevo comando", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error agregando el comando \n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBorrarComando_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbServers.SelectedItem == null)
                {
                    MessageBox.Show("Por favor seleccione un servidor primero.", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lbCommands.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor seleccione un comando", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show("¿Desea eliminar el comando?", "Confirmar eliminación",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    var servidorSeleccionado = (Servidor)lbServers.SelectedItem;
                    var comandoSeleccionado = (Comando)lbCommands.SelectedItem;

                    servidorSeleccionado.Comandos.Remove(comandoSeleccionado);
                    lbCommands.Items.Remove(comandoSeleccionado);

                    string xmlPath = Path.Combine(Application.StartupPath, "servidores.xml");

                    if (File.Exists(xmlPath))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(xmlPath);

                        XmlNode nodoServidor = doc.SelectSingleNode(
                            $"//Servidor[Nombre='{servidorSeleccionado.Nombre}' and IP='{servidorSeleccionado.IP}' and Usuario='{servidorSeleccionado.Usuario}']");

                        if (nodoServidor != null)
                        {
                            XmlNode comandosNodo = nodoServidor.SelectSingleNode("Comandos");

                            if (comandosNodo != null)
                            {
                                XmlNode comandoNodo = null;
                                foreach (XmlNode nodo in comandosNodo.ChildNodes)
                                {
                                    if (nodo.InnerText == comandoSeleccionado.Texto)
                                    {
                                        comandoNodo = nodo;
                                        break;
                                    }
                                }

                                if (comandoNodo != null)
                                {
                                    comandosNodo.RemoveChild(comandoNodo);
                                    doc.Save(xmlPath);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error eliminando el comando \n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificarComando_Click(object sender, EventArgs e)
        {
            if (lbCommands.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione un comando", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Servidor servidorActual = lbServers.SelectedItem as Servidor;
            if (servidorActual == null)
            {
                MessageBox.Show("No hay servidor seleccionado", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string comandoActual = lbCommands.SelectedItem.ToString();

            FormEditarComandos formEditar = new FormEditarComandos(comandoActual, servidorActual.Nombre);

            if (formEditar.ShowDialog() == DialogResult.OK)
            {
                int index = lbCommands.SelectedIndex;
                lbCommands.Items[index] = formEditar.ComandoEditado;

                servidorActual.Comandos[index].Texto = formEditar.ComandoEditado;

                MessageBox.Show("Se ha modificado la información del comando", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            //Dejarlo quedito
        }

        private void BtnEjecutarComando_Click_1(object sender, EventArgs e)
        {

        }
    }
}
