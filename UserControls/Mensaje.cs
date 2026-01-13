namespace UserControls
{
    public partial class Mensaje : UserControl
    {
        public Mensaje(String texto, bool ia, double anchoMax)
        {
            InitializeComponent();
            lblMensaje.MaximumSize = new Size((int)(anchoMax*0.90),0);
            lblMensaje.Text = texto;
            lblMensaje.Dock = ia ? DockStyle.Left : DockStyle.Right;
            lblMensaje.BackColor = ia ? Color.LightSteelBlue : Color.CornflowerBlue;
            Width = (int) anchoMax;
            Height = lblMensaje.Height;
        }

        private void Mensaje_Load(object sender, EventArgs e)
        {

        }
    }
}
