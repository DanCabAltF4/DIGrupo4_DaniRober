using UserControls;

namespace DIGrupo4_DaniRober
{
    public partial class Form1 : Form
    {
        // Cliente que se comunica con Ollama
        private readonly ClienteOllama _clienteOllama;

        // Token para controlar la petici�n
        private CancellationTokenSource? _cts;

        public Form1()
        {
            InitializeComponent(); // Carga el dise�ador

            // Creamos el cliente una sola vez
            _clienteOllama = new ClienteOllama();
        }

        // Evento que se ejecuta al pulsar Enviar
        private async void btn_Enviar_Click(object? sender, EventArgs e)
        {
            // Bloqueamos bot�n
            btn_Enviar.Enabled = false;
            // Leemos lo que escribi� el usuario
            var prompt = rtbox_prompt.Text.Trim();
            rtbox_prompt.Text = string.Empty;
            annadirMensaje(prompt, false);
            _cts = new CancellationTokenSource();
            try
            {
                if (string.IsNullOrWhiteSpace(prompt))
                {
                    MessageBox.Show("Escribe un mensaje antes de enviar.");
                    return;
                }
                // Creamos el mensaje de momento"pensando..."
                Mensaje mensajeIA  = annadirMensaje("? Pensando...",true);

                // A�adimos el label al panel
                flowLayout.Controls.Add(mensajeIA);
                flowLayout.ScrollControlIntoView(mensajeIA);

                // Enviamos el prompt a Ollama
                string respuesta = await _clienteOllama.EnviarPromptAsync(prompt, _cts.Token);

                // Sustituimos el texto por la respuesta real
                mensajeIA.Text = respuesta;

                //lblCargando.Refresh();
                flowLayout.ScrollControlIntoView(mensajeIA);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btn_Enviar.Enabled = true; // Reactivamos bot�n
                _cts?.Dispose();
                _cts = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Mensaje annadirMensaje(string mensaje, bool ia) {
            var control = new Mensaje(mensaje, ia, flowLayout.Width * 0.99);
            flowLayout.Controls.Add(control);
            return control;
        }
    }
}