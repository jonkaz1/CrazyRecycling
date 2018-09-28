using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = textBox1.Location.X;
            int y = textBox1.Location.Y;

            if (e.KeyCode == Keys.W)
            {
                y--;
                textBox1.Text = "W";
            }
            else if (e.KeyCode == Keys.A)
            {
                x--;
                textBox1.Text = "A";
            }
            else if (e.KeyCode == Keys.S)
            {
                y++;
                textBox1.Text = "S";
            }
            else if (e.KeyCode == Keys.D)
            {
                x++;
                textBox1.Text = "D";
            }
            textBox1.Location = new Point(x, y);
        }
    }
}
