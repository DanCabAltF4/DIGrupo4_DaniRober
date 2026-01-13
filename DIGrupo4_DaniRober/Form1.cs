using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControls; // <- donde está tu control Mensaje

namespace DIGrupo4_DaniRober
{
    public partial class Form1 : Form
    {
        // Cliente que se comunica con Ollama
        private readonly ClienteOllama _clienteOllama;

        // Token para cancelar la petición (opcional)
        private CancellationTokenSource? _cts;

        public Form1()
        {
            InitializeComponent();

            // Creamos el cliente una sola vez
            _clienteOllama = new ClienteOllama();

            // Aseguramos que el click llama a nuestro handler async
            btn_Enviar.Click -= btn_Enviar_Click;
            btn_Enviar.Click += btn_Enviar_Click;

            // FlowLayoutPanel vertical y con scroll
            flowLayout.AutoScroll = true;
            flowLayout.FlowDirection = FlowDirection.TopDown;
            flowLayout.WrapContents = false;
        }

        // Evento al pulsar Enviar (USUARIO -> IA)
        private async void btn_Enviar_Click(object? sender, EventArgs e)
        {
            btn_Enviar.Enabled = false;
            _cts = new CancellationTokenSource();

            try
            {
                string prompt = rtbox_prompt.Text.Trim();

                if (string.IsNullOrWhiteSpace(prompt))
                {
                    MessageBox.Show("Escribe un mensaje antes de enviar.");
                    return;
                }

                // Limpia el prompt
                rtbox_prompt.Clear();

                // 1) Añadir mensaje del usuario
                annadirMensaje(prompt, ia: false);

                // 2) Añadir mensaje temporal "Pensando..." como IA
                var msgPensando = annadirMensaje("🤖 Pensando...", ia: true);

                // 3) Llamar a Ollama
                string respuesta = await _clienteOllama.EnviarPromptAsync(prompt, _cts.Token);

                // 4) Reemplazar el texto del "Pensando..." por la respuesta real
                //    (lo más limpio es quitar el control y añadir uno nuevo con el texto final)
                flowLayout.Controls.Remove(msgPensando);
                msgPensando.Dispose();

                annadirMensaje(respuesta, ia: true);
            }
            catch (OperationCanceledException)
            {
                annadirMensaje("⚠️ Petición cancelada.", ia: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                annadirMensaje("❌ Error: " + ex.Message, ia: true);
            }
            finally
            {
                btn_Enviar.Enabled = true;
                _cts?.Dispose();
                _cts = null;
            }
        }

        /// <summary>
        /// Añade un mensaje al chat.
        /// ia=false -> usuario
        /// ia=true  -> IA
        /// Devuelve el control creado (por si quieres reemplazarlo luego).
        /// </summary>
        private Control annadirMensaje(string mensaje, bool ia)
        {
            // Mensaje(mensaje, ia, ancho)
            var control = new Mensaje(mensaje, ia, (int)(flowLayout.Width * 0.99));

            flowLayout.Controls.Add(control);
            flowLayout.ScrollControlIntoView(control);

            return control;
        }
    }
}