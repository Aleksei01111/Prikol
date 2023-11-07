using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prikol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetImageOnWindow();
            PlayMusic();
        }

        void SetImageOnWindow()
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

        void PlayMusic()
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
    }
}
