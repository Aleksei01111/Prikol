using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            Bitmap[] images = new Bitmap[]
            {
                Resource1.zi9,
                Resource1.i7,
                Resource1.XBTU,
                Resource1._1uhE,
            };

            pictureBox1.Image = images[new Random().Next(0, images.Length)];
        }
    }
}
