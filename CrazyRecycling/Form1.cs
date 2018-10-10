using CrazyRecycling.Controllers;
using CrazyRecycling.Models;
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
        int bottleCount = 0;
        Random random = new Random();
        PlayerController playerController = new PlayerController();
        Player player = new Player();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.playerObject = pictureBox1;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {           
            playerController.Move(player, e);
        }        

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (bottleCount < 50)
            {
                bottleCount++;
                PictureBox bottle = new PictureBox();
                bottle.Image = global::CrazyRecycling.Properties.Resources.Bottle;
                bottle.Location = new Point(random.Next(16, 640-16), random.Next(16, 480-16));
                bottle.Size = new Size(16, 16);
                this.Controls.Add(bottle);
            }
        }
    }
}
