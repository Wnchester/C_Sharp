using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yılanoyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        yilanoyunu yilanim;
        yonu yonum;
        PictureBox[] pcyilanparcalari;
        bool yemkontrol = false;
        PictureBox pcyem;
        Random rastgele = new Random();
        int skor = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            yenioyun();
        }
        private void yenioyun()
        {
            yilanim = new yilanoyunu();
            yonum = new yonu(-10, 0);
            pcyilanparcalari = new PictureBox[0];
            for (int i = 0; i < 3; i++)
            {
                Array.Resize(ref pcyilanparcalari, pcyilanparcalari.Length + 1);
                pcyilanparcalari[i] = pcekle();
            }
            button1.Enabled = false;
            timer1.Start();
        }
        private PictureBox pcekle()
        {
            PictureBox pc = new PictureBox();
            pc.Size = new Size(10, 10);
            pc.BackColor = Color.Blue;
            pc.Location = yilanim.pozisyon(pcyilanparcalari.Length - 1);
            panel1.Controls.Add(pc);
            return pc;
        }
        private void guncelle()
        {
            for (int i = 0; i < pcyilanparcalari.Length; i++)
            {
                pcyilanparcalari[i].Location = yilanim.pozisyon(i);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (yonum.yon_y != 10)
                {
                    yonum = new yonu(0, -10);
                }
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (yonum.yon_y != -10)
                {
                    yonum = new yonu(0, 10);
                }
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (yonum.yon_x != 10)
                {
                    yonum = new yonu(-10, 0);
                }
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (yonum.yon_x != -10)
                {
                    yonum = new yonu(10, -0);
                }
            }
        }
        public void yem()
        {
            if (!yemkontrol)
            {
                skor += 0;
                PictureBox pc = new PictureBox();
                pc.BackColor = Color.Red;
                pc.Size = new Size(10, 10);
                pc.Location = new Point(rastgele.Next(panel1.Width / 10) * 10, rastgele.Next(panel1.Height / 10) * 10);
                pcyem = pc;
                yemkontrol = true;
                panel1.Controls.Add(pc);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Skor:" + skor.ToString();
            yilanim.yilanilerle(yonum);
            guncelle();
            yem();
            yemiye();
            duvaracarpma();
        }

        public void yemiye()
        {
            if (yilanim.pozisyon(0) == pcyem.Location)
            {
                skor += 2;
                yilanim.yilanboyu();
                Array.Resize(ref pcyilanparcalari, pcyilanparcalari.Length + 1);
                pcyilanparcalari[pcyilanparcalari.Length - 1] = pcekle();
                yemkontrol = false;
                panel1.Controls.Remove(pcyem);
            }
        }
        public void duvaracarpma()
        {
            Point pz = yilanim.pozisyon(0);
            if (pz.X < 0 || pz.X > panel1.Width - 10 || pz.Y < 0 || pz.Y > panel1.Width - 10)
            {
                timer1.Stop();
                MessageBox.Show("Game Over!");
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yenioyun();
        }
    }
}
