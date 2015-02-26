using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fysikprojekt3
{
    public partial class Form1 : Form
    {
        Game1 game;
        public Form1(Game1 game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public bool GetSpeedValue1(out float speed)
        {
            return float.TryParse(textBox1.Text, out speed);
        }
        public bool GetSpeedValue2(out float speed)
        {
            return float.TryParse(textBox2.Text, out speed);
        }

        public bool GetFriction(out float fric)
        {
            return float.TryParse(textBox3.Text, out fric);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


    }
}
