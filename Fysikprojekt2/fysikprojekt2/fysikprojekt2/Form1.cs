using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fysikprojekt2
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

        public bool GetXValue(out float x)
        {
            return float.TryParse(textBox1.Text, out x);
        }
        public bool GetAValue(out float y)
        {
            return float.TryParse(textBox2.Text, out y);
        }
        public bool GetFValue(out float z)
        {
            return float.TryParse(textBox3.Text, out z);
        }

        public bool GetMValue(out float m)
        {
            return float.TryParse(textBox4.Text, out m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.Spawn();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.DeSpawn();
        }
    }
}
