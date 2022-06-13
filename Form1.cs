using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DenwerManager
{

    public partial class Form1 : Form
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


        public Form1()
        {
            this.Opacity = 0.99; //прозрачность 100%

            string Host = System.Net.Dns.GetHostName();
            string IP = System.Net.Dns.GetHostByName(Host).AddressList[0].ToString();
            InitializeComponent();
            IPv4.Text = IP;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process iStartProcess = new Process(); // новый процесс
            iStartProcess.StartInfo.FileName = @"C:\WebServers\denwer\run.exe"; // путь к запускаемому файлу
            iStartProcess.StartInfo.Arguments = ""; // эта строка указывается, если программа запускается с параметрами (здесь указан пример, для наглядности)
            iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // эту строку указываем, если хотим запустить программу в скрытом виде
            iStartProcess.Start(); // запускаем программу
 //           iStartProcess.WaitForExit(120000); // эту строку указываем, если нам надо будет ждать завершения программы определённое время, пример: 2 мин. (указано в миллисекундах - 2 мин. * 60 сек. * 1000 м.сек.)
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process iStartProcess = new Process(); // новый процесс
            iStartProcess.StartInfo.FileName = @"C:\WebServers\denwer\restart.exe"; // путь к запускаемому файлу
            iStartProcess.StartInfo.Arguments = ""; // эта строка указывается, если программа запускается с параметрами (здесь указан пример, для наглядности)
            iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // эту строку указываем, если хотим запустить программу в скрытом виде
            iStartProcess.Start(); // запускаем программу
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process iStartProcess = new Process(); // новый процесс
            iStartProcess.StartInfo.FileName = @"C:\WebServers\denwer\stop.exe"; // путь к запускаемому файлу
            iStartProcess.StartInfo.Arguments = ""; // эта строка указывается, если программа запускается с параметрами (здесь указан пример, для наглядности)
            iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // эту строку указываем, если хотим запустить программу в скрытом виде
            iStartProcess.Start(); // запускаем программу
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process iStartProcess = new Process(); // новый процесс
            iStartProcess.StartInfo.FileName = @"C:\WebServers\denwer\CONFIGURATION.txt"; // путь к запускаемому файлу
            iStartProcess.StartInfo.Arguments = ""; // эта строка указывается, если программа запускается с параметрами (здесь указан пример, для наглядности)
 //           iStartProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // эту строку указываем, если хотим запустить программу в скрытом виде
            iStartProcess.Start(); // запускаем программу
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] strArray = File.ReadAllLines(@"C:\WebServers\denwer\CONFIGURATION.txt");//В строковый массив считываем построчно текстовый файл
            listBox1.Items.Clear();
            listBox1.Items.AddRange(strArray); //при нажатии кнопочки лист бокс заполнится строками
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] strArray = File.ReadAllLines(@"C:\WebServers\denwer\CONFIGURATION.txt");//В строковый массив считываем построчно текстовый файл
            listBox1.Items.Clear();
            listBox1.Items.AddRange(strArray); //при нажатии кнопочки лист бокс заполнится строками

            this.Region = new Region(
RoundedRect(
new Rectangle(0, 0, this.Width, this.Height)
, 10
)
);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            //           Close();
            Hide();
        }
    }
}
