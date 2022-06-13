using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace DenwerManager
{
    public partial class Form2 : Form
    {
        public static GraphicsPath RoundedRect(Rectangle baseRect, int radius)
        {
            var diameter = radius * 2;
            var sz = new Size(diameter, diameter);
            var arc = new Rectangle(baseRect.Location, sz);
            var path = new GraphicsPath();

            // Верхний левый угол
            path.AddArc(arc, 180, 90);

            // Верхний правый угол
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Нижний правый угол
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Нижний левый угол
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        public Form2()
        {
            this.Opacity = 0.99; //прозрачность 100%
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] strArray = File.ReadAllLines(@"C:\WebServers\denwer\CONFIGURATION.txt");//В строковый массив считываем построчно текстовый файл


            this.Region = new Region(
RoundedRect(
new Rectangle(0, 0, this.Width, this.Height)
, 10
)
);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Frm1 = new Form1();
            Frm1.Show();
            this.Close();

        }
    }
}
