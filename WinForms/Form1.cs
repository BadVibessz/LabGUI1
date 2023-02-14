using System.Drawing;
using System.Windows.Forms;
using Core;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private readonly Graphics _graphics;

        public Form1()
        {
            InitializeComponent();

            new Trolleybus().Show();
            
            _graphics = panel1.CreateGraphics();
            _graphics.Clear(Color.White);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var letterZ = Letter.GetLetterЗ(new Point(50, 20));
            var letterH = Letter.GetLetterН(new Point(200, 20));
            var letterE = Letter.GetLetterЭ(new Point(350, 20));
            
            letterZ.Draw(_graphics,Color.YellowGreen, Color.White);
            letterH.Draw(_graphics, Color.CornflowerBlue, Color.White);
            letterE.Draw(_graphics, Color.SandyBrown, Color.White);

        }
    }
}