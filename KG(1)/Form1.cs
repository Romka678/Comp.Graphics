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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public PictureBox pl = new PictureBox();
        public PictureBox copy = new PictureBox();
        public PictureBox cop = new PictureBox();
        public void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                copy = pictureBox1;
                copy.Image = pictureBox1.Image;
                cop.Image = pictureBox1.Image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pl.Image = pictureBox1.Image;
            var bitmap = new Bitmap(pictureBox1.Image);
            Random rnd = new Random();
            for (int i = 0; i < bitmap.Width; i+=3)
            {
                for (int j = 0; j < bitmap.Height; j+=10)
                {
                    Color color = bitmap.GetPixel(i, j);
                    int r = (byte)(rnd.Next(0, 2));
                    int g, b;
                    if (r == 0)
                    {
                        r = 0;
                        g = 0;
                        b = 0;
                    }
                    else
                    {
                        r = 255;
                        g = 255;
                        b = 255;
                    }
                    bitmap.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }
            pictureBox1.Image = bitmap;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Сохранить картинку как...";
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(sfd.FileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }

        int[] BubbleSort(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A.Length - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }
            return A;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Image);
            int n = 9;                            
            int cR_, cB_, cG_;              
            int k = 0;

            int[] cR = new int[n];
            int[] cB = new int[n];
            int[] cG = new int[n];

            for(int l = 0; l < bitmap.Width-3; l += 3)
            {
                for(int f = 0; f < bitmap.Height-3; f += 3)
                {
                    Color c = bitmap.GetPixel(l, f);
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l, f + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l, f + 2);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    k++;
                    /////////////////////////////
                    c = bitmap.GetPixel(l + 1, f);
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 1, f + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 1, f + 2);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    k++;
                    /////////////////////////////
                    c = bitmap.GetPixel(l + 2, f);
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 2, f + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 2, f + 2);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    /////////////////////////////
                    k = 0;
                                      BubbleSort(cR);
                                       BubbleSort(cG);
                                       BubbleSort(cB);
                                       int n_ = (int)(n / 2);
                    /* int a = 0, b = 0, v = 0;
                     for (int i = 0; i < n; i++)
                     {
                         a += cR[i];
                         b += cG[i];
                         v += cB[i];

                     }
                     a /= 9;
                     b /= 9;
                     v /= 9;
                     cR_ = a;
                     cG_ = b;
                     cB_ = v;*/
                    cR_ = cR[n_];
                    cG_ = cG[n_];
                    cB_ = cB[n_];
                    bitmap.SetPixel(l, f, Color.FromArgb(cR_, cG_, cB_));
                    bitmap.SetPixel(l, f + 1, Color.FromArgb(cR_, cG_, cB_));
                    bitmap.SetPixel(l, f + 2, Color.FromArgb(cR_, cG_, cB_));
                    bitmap.SetPixel(l + 1, f, Color.FromArgb(cR_, cG_, cB_));
                    bitmap.SetPixel(l + 1, f + 1, Color.FromArgb(cR_, cG_, cB_));
                    bitmap.SetPixel(l + 1, f + 2, Color.FromArgb(cR_, cG_, cB_));
                    bitmap.SetPixel(l + 2, f, Color.FromArgb(cR_, cG_, cB_));
                    bitmap.SetPixel(l + 2, f + 1, Color.FromArgb(cR_, cG_, cB_));
                    bitmap.SetPixel(l + 2, f + 2, Color.FromArgb(cR_, cG_, cB_));
                }
            }
            pictureBox1.Image = bitmap;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pl.Image = pictureBox1.Image;
            var bitmap = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                      int r = (color.R + color.G + color.B) / 3;
                      int b = (color.R + color.G + color.B) / 3; 
                      int g = (color.R + color.G + color.B) / 3;
                   /* int r = Math.Max(color.R, color.B);
                    int r1 = Math.Max(color.R, color.G);
                    int res = Math.Max(r, r1);
                    int b = Math.Max(color.R, color.B);
                    int b1 = Math.Max(color.R, color.G);
                    int bes = Math.Max(b, b1);
                    int g = Math.Max(color.R, color.B);
                    int g1 = Math.Max(color.R, color.G);
                    int ges = Math.Max(g, g1);*/

                    bitmap.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }
            pictureBox1.Image = bitmap;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pl.Image = pictureBox1.Image;
            var bitmap = new Bitmap(pictureBox1.Image);
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    if((c.R>a||c.G>a||c.B>a)&& (c.R < b || c.G < b || c.B < b))
                    {
                      bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255, 255));
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(255, 0, 0, 0));
                    }
                }

            }
            pictureBox1.Image = bitmap;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            pl.Image = pictureBox1.Image;
            var bitmap = new Bitmap(pictureBox1.Image);
            int n = 4;
            int p = 15;
            int k = 0, gx1, gx2, gx3, gy1, gy2, gy3;
            int[] cR = new int[n];
            int[] cB = new int[n];
            int[] cG = new int[n];
            for (int i = 0; i < bitmap.Width-1; i+=2)
            {
                for (int j = 0; j < bitmap.Height-1; j+=2)
                {////////////////////////5
                    Color c = bitmap.GetPixel(i, j);
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    //////////////////////////////9
                    c = bitmap.GetPixel(i + 1, j + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    gx1 = cR[0] - cR[1];gx2 = cG[0] - cG[1];gx3 = cB[0] - cB[1];
                    if (gx1 > p || gx2 > p || gx3 > p)
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255, 255));
                        bitmap.SetPixel(i + 1, j + 1, Color.FromArgb(255, 255, 255, 255));
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, Color.FromArgb(255, 0, 0, 0));
                        bitmap.SetPixel(i + 1, j + 1, Color.FromArgb(255, 0, 0, 0));
                    }
                    ///////////////////////////////8
                    c = bitmap.GetPixel(i, j + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    /////////////////////////////6
                    c = bitmap.GetPixel(i + 1, j);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    gy1 = cR[2] - cR[3]; gy2 = cG[2] - cG[3]; gy3 = cB[2] - cB[3];
                    if (gy1 > p || gy2 > p || gy3 > p)
                    {
                        bitmap.SetPixel(i + 1, j, Color.FromArgb(255, 255, 255, 255));
                        bitmap.SetPixel(i, j + 1, Color.FromArgb(255, 255, 255, 255));
                    }
                    else
                    {
                        bitmap.SetPixel(i + 1, j, Color.FromArgb(255, 0, 0, 0));
                        bitmap.SetPixel(i, j + 1, Color.FromArgb(255, 0, 0, 0));
                    }
                    k = 0;
                }
            }
            pictureBox1.Image = bitmap;
        }

        public void button8_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pl.Image;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Image);
            int k = 0, n = 9;
            int[] cR = new int[n];
            int[] cB = new int[n];
            int[] cG = new int[n];
            for (int l = 0; l < bitmap.Width - 3; l += 3)
            {
                for (int f = 0; f < bitmap.Height - 3; f += 3)
                {
                    Color c = bitmap.GetPixel(l, f);
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l, f + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l, f + 2);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    k++;
                    /////////////////////////////
                    c = bitmap.GetPixel(l + 1, f);
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 1, f + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 1, f + 2);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    k++;
                    /////////////////////////////
                    c = bitmap.GetPixel(l + 2, f);
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 2, f + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 2, f + 2);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    /////////////////////////////
                    k = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if ((cR[i] == 0) && (cG[i] == 0) && (cB[i] == 0))
                            continue;
                        else
                        {
                            if ((cR[i] != 255) && (cG[i] != 255) && (cB[i] != 255))
                            {
                                cR[i] = 255; cG[i] = 255; cB[i] = 255;
                            }
                        }
                        bitmap.SetPixel(l, f, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l, f + 1, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l, f + 2, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 1, f, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 1, f + 1, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 1, f + 2, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 2, f, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 2, f + 1, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 2, f + 2, Color.FromArgb(cR[i], cG[i], cB[i]));
                    }
                }
            }
            pictureBox1.Image = bitmap;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(pictureBox1.Image);
            int k = 0, n = 9;
            int[] cR = new int[n];
            int[] cB = new int[n];
            int[] cG = new int[n];
            for (int l = 0; l < bitmap.Width - 3; l += 3)
            {
                for (int f = 0; f < bitmap.Height - 3; f += 3)
                {
                    Color c = bitmap.GetPixel(l, f);
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l, f + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l, f + 2);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    k++;
                    /////////////////////////////
                    c = bitmap.GetPixel(l + 1, f);
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 1, f + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 1, f + 2);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    k++;
                    /////////////////////////////
                    c = bitmap.GetPixel(l + 2, f);
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 2, f + 1);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    c = bitmap.GetPixel(l + 2, f + 2);
                    k++;
                    cR[k] = Convert.ToInt32(c.R);
                    cG[k] = Convert.ToInt32(c.G);
                    cB[k] = Convert.ToInt32(c.B);
                    /////////////////////////////
                    k = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if ((cR[i] == 255) && (cG[i] == 255) && (cB[i] == 255))
                            continue;
                        else
                        {
                            if ((cR[i] != 0) && (cG[i] != 0) && (cB[i] != 0))
                            {
                                cR[i] = 0; cG[i] = 0; cB[i] = 0;
                            }
                        }
                        bitmap.SetPixel(l, f, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l, f + 1, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l, f + 2, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 1, f, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 1, f + 1, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 1, f + 2, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 2, f, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 2, f + 1, Color.FromArgb(cR[i], cG[i], cB[i]));
                        bitmap.SetPixel(l + 2, f + 2, Color.FromArgb(cR[i], cG[i], cB[i]));
                    }
                }
            }
            pictureBox1.Image = bitmap;
        }
    }
}
