using CrazyRecycling.Controllers.Memento;
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
        CurrentProfile currentProfile = new CurrentProfile();
        Profile profile = null;

        public GameStart()
        {
            if (profile == null)
            {
                profile = new Profile("CrazyRecyclingProfile.txt");
            }
            currentProfile.RestoreProfile(profile);
            InitializeComponent();
            textBox1.Text = currentProfile.PlayerName;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            form1.Closed += (s, args) => Close();
            Form1.PlayerName = textBox1.Text;
            if (Form1.PlayerName == "")
            {
                Form1.PlayerName = "Player";
            }
            form1.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Highscores highscores = new Highscores();
            highscores.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            currentProfile.RestoreProfile(profile);
            textBox1.Text = currentProfile.PlayerName;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            profile = currentProfile.SaveProfile("CrazyRecyclingProfile.txt");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            currentProfile.PlayerName = textBox1.Text;
        }
    }
}
