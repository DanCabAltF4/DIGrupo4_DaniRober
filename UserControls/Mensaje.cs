namespace UserControls
{
    public partial class Mensaje : UserControl
    {
        private string _texto;
        public string Texto { 
            get => _texto; 
            set { _texto = value; 
                lblMensaje.Text = value;
                AjustarTamaño();
            }
        }

        private void AjustarTamaño()
        {
            Height = lblMensaje.Height;
        }

        public Mensaje(String texto, bool ia, double anchoMax)
        {
            InitializeComponent();
            lblMensaje.MaximumSize = new Size((int)(anchoMax*0.90),0);
            lblMensaje.Text = texto;
            lblMensaje.Dock = ia ? DockStyle.Left : DockStyle.Right;
            lblMensaje.BackColor = ia ? Color.LightSteelBlue : Color.CornflowerBlue;
            Width = (int) anchoMax;
            AjustarTamaño();
        }

        private void Mensaje_Load(object sender, EventArgs e)
        {

        }
    }
}
