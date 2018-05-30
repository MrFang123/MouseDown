using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 喵喵拳
{
    public partial class Form1 : Form
    {
        KeyboardHook kh;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kh = new KeyboardHook();
            kh.SetHook();
            kh.OnKeyDownEvent += kh_OnKeyDownEvent;
        }

        void kh_OnKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
            {
                timer1.Start();
                timer2.Start();
            }
            else if (e.KeyData == Keys.S)
            {
                timer1.Stop();
                timer2.Stop();
            }
           
            //if (e.KeyData == (Keys.A | Keys.Control | Keys.Alt)) { this.Text = "你发现了什么？"; }//Ctrl+Alt+A
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            kh.UnHook();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer2.Interval = (int)numericUpDown1.Value;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Mouse.UpDown();
        }
    }
}