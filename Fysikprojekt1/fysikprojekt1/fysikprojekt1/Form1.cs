using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fysikprojekt1
{
    public partial class Form1 : Form
    {
        Game1 game;
        public Form1(Game1 game)
        {
            InitializeComponent();
            this.game = game;
        }

        public bool GetXValue(out float x)
        {
            return float.TryParse(textBox1.Text, out x);
        }
        public bool GetYValue(out float y)
        {
            return float.TryParse(textBox2.Text, out y);
        }
        public bool GetAngleValue(out float a)
        {
            return float.TryParse(textBox3.Text, out a);
        }
        public bool GetVelValue(out float v)
        {
            return float.TryParse(textBox6.Text, out v);
        }
        public bool GetVelYValue(out float v0Y)
        {
            return float.TryParse(textBox5.Text, out v0Y);
        }
        public bool GetVelXValue(out float v0X)
        {
            return float.TryParse(textBox4.Text, out v0X);
        }
        //public bool GetVelYValue(out float vy)
        //{
        //    return float.TryParse(textBox5.Text, out vy);
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            game.Spawn();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
