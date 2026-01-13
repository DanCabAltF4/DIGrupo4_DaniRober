using UserControls;

namespace DIGrupo4_DaniRober
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
