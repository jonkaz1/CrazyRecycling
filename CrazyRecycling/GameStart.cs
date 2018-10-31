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
    public partial class GameStart : Form
    {
        Form1 form1 = new Form1();

        public GameStart()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.Closed += (s, args) => this.Close();
            Form1.PlayerName = textBox1.Text;
            form1.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Highscores highscores = new Highscores();
            highscores.Show();
        }
    }
}
