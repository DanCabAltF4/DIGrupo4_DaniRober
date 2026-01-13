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

            // Conectamos el bot�n Enviar al evento
            btn_Enviar.Click += btn_Enviar_Click;

            // Configuramos el FlowLayoutPanel para que sea vertical
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.WrapContents = false;
        }

        // Evento que se ejecuta al pulsar Enviar
        private async void btn_Enviar_Click(object? sender, EventArgs e)
        {
            btn_Enviar.Enabled = false;        // Bloqueamos bot�n
            _cts = new CancellationTokenSource();

            try
            {
                // Leemos lo que escribi� el usuario
                string prompt = rtbox_prompt.Text.Trim();

                if (string.IsNullOrWhiteSpace(prompt))
                {
                    MessageBox.Show("Escribe un mensaje antes de enviar.");
                    return;
                }

                // Limpiamos el textbox
                rtbox_prompt.Clear();

                // Creamos un label temporal de "pensando..."
                Label lblCargando = CrearLabel("? Pensando...");

                // A�adimos el label al panel
                flowLayoutPanel2.Controls.Add(lblCargando);
                flowLayoutPanel2.ScrollControlIntoView(lblCargando);

                // Enviamos el prompt a Ollama
                string respuesta = await _clienteOllama.EnviarPromptAsync(prompt, _cts.Token);

                // Sustituimos el texto por la respuesta real
                lblCargando.Text = respuesta;

                lblCargando.Refresh();
                flowLayoutPanel2.ScrollControlIntoView(lblCargando);
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

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            var prompt = rtbox_prompt.Text;
            rtbox_prompt.Text = string.Empty;
            annadirMensaje(prompt, false);

        }

        public void annadirMensaje(string mensaje, bool ia) {
            flowLayout.Controls.Add(new Mensaje(mensaje, ia, flowLayout.Width * 0.99));
        }
    }
}