using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace computer_graphics_lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Title = "choose an image to import";
            openFileDialog1.Filter = "image files | *.png; *.jpg; *.bmp | All files(*.*) | *.*";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultOfDialog = openFileDialog1.ShowDialog();
            if (resultOfDialog == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                Image image = Image.FromFile(filename);
                pictureBox1.Image = image;
                MessageBox.Show("image loaded");
                return;
            }
            else
                MessageBox.Show("invalid image");
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Inversion.Execute(sourceImage);
                MessageBox.Show("inverse completed");
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Grayscale.Execute(sourceImage);
                MessageBox.Show("grayscale completed");
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Sepia.Execute(sourceImage);
                MessageBox.Show("sepia completed");
            }
        }

        private void brightnessUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = BrightnessUp.Execute(sourceImage);
                MessageBox.Show("brightness up completed");
            }
        }

        private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Shift.Execute(sourceImage);
                MessageBox.Show("shift completed");
            }
        }

        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Embossing.Execute(sourceImage);
                MessageBox.Show("embossing completed");
            }
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = MotionBlur.Execute(sourceImage);
                MessageBox.Show("motion blur completed");
            }
        }

        private void grayWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = GrayWorld.Execute(sourceImage);
                MessageBox.Show("grayworld completed");
            }
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Autolevels.Execute(sourceImage);
                MessageBox.Show("autolevels completed");
            }
        }

        private void perfectReflectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = PerfectReflector.Execute(sourceImage);
                MessageBox.Show("perfect reflector completed");
            }
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Dilation.Execute(sourceImage);
                MessageBox.Show("dilation completed");
            }
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Erosion.Execute(sourceImage);
                MessageBox.Show("erosion completed");
            }
        }

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Median.Execute(sourceImage);
                MessageBox.Show("median filter completed");
            }
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Sobel.Execute(sourceImage);
                MessageBox.Show("sobel filter completed");
            }
        }

        private void scharrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap sourceImage = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = Sobel.Execute(sourceImage);
                MessageBox.Show("scharr filter completed");
            }
        }
    }
}
