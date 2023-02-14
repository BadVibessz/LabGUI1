using System.Drawing;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Trolleybus : Form
    {
        private Graphics _graphics;
        private Core.Trolleybus _trolleybus = new Core.Trolleybus(new Point(20,150));
        public Trolleybus()
        {
            InitializeComponent();

            _graphics = panel1.CreateGraphics();
            _graphics.Clear(Color.White);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            _trolleybus.Draw(_graphics, Color.Gold);
        }
    }
}