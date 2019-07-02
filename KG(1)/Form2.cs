using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG_1_
{
    public partial class Form2 : Form
    {
        Form1 form;
        int k = 0;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            form = form1;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar2.Scroll += trackBar2_Scroll;

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int q = trackBar1.Value * 10;
            var bitmap = new Bitmap(form.cop.Image);
            Bitmap bmp = bitmap;
            int r, g, b, q1, q2, q3;
            int w = trackBar2.Value * 5;
            int r1, g1, b1, q4 = 0, q5 = 0, q6 = 0, n = 0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    r = Convert.ToInt32(c.R);
                    g = Convert.ToInt32(c.G);
                    b = Convert.ToInt32(c.B);
                    q1 = r + q;
                    q2 = g + q;
                    q3 = b + q;
                    if (q1 < 0 || q2 < 0 || q3 < 0)
                    {
                        q1 = 0; q2 = 0; q3 = 0;
                    }
                    if (q1 > 255 || q2 > 255 || q3 > 255)
                    {
                        q1 = 255; q2 = 255; q3 = 255;
                    }
                    bmp.SetPixel(i, j, Color.FromArgb(255, q1, q2, q3));
                }
            }
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    r1 = Convert.ToInt32(c.R);
                    g1 = Convert.ToInt32(c.G);
                    b1 = Convert.ToInt32(c.B);
                    if (n < w)
                    {
                        q4 = (r1 * (100 - w) + w * 128) / 100;
                        q5 = (g1 * (100 - w) + w * 128) / 100;
                        q6 = (b1 * (100 - w) + w * 128) / 100;
                    }
                    else
                    {
                        q4 = (r1 * 100 - w * 128) / (100 - w);
                        q5 = (g1 * 100 - w * 128) / (100 - w);
                        q6 = (b1 * 100 - w * 128) / (100 - w);
                    }
                    if (q4 < 0 || q5 < 0 || q6 < 0)
                    {
                        q4 = 0; q5 = 0; q6 = 0;
                    }
                    if (q4 > 255 || q5 > 255 || q6 > 255)
                    {
                        q4 = 255; q5 = 255; q6 = 255;
                    }
                    bitmap.SetPixel(i, j, Color.FromArgb(255, q4, q5, q6));
                    n = w;
                }
            }
            form.copy.Image = bitmap;
        }
    }
}
