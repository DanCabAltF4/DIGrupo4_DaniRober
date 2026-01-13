namespace DIGrupo4_DaniRober
{
    public partial class Form1 : Form
    {
        // Cliente que se comunica con Ollama
        private readonly ClienteOllama _clienteOllama;

        // Token para controlar la petición
        private CancellationTokenSource? _cts;

        public Form1()
        {
            InitializeComponent(); // Carga el diseñador

            // Creamos el cliente una sola vez
            _clienteOllama = new ClienteOllama();

            // Conectamos el botón Enviar al evento
            btn_Enviar.Click += btn_Enviar_Click;

            // Configuramos el FlowLayoutPanel para que sea vertical
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.WrapContents = false;
        }

        // Evento que se ejecuta al pulsar Enviar
        private async void btn_Enviar_Click(object? sender, EventArgs e)
        {
            btn_Enviar.Enabled = false;        // Bloqueamos botón
            _cts = new CancellationTokenSource();

            try
            {
                // Leemos lo que escribió el usuario
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

                // Añadimos el label al panel
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
                btn_Enviar.Enabled = true; // Reactivamos botón
                _cts?.Dispose();
                _cts = null;
            }
        }

        // Crea un Label bonito para mostrar texto de la IA
        private Label CrearLabel(string texto)
        {
            Label lbl = new Label();

            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(flowLayoutPanel2.Width - 30, 0);
            lbl.Font = new Font("Segoe UI", 10);
            lbl.Padding = new Padding(10);
            lbl.Margin = new Padding(6);
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.BackColor = Color.Gainsboro;
            lbl.Text = texto;

            return lbl;
        }
    }
}