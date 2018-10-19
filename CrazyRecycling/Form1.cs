﻿using CrazyRecycling.Controllers;
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
        PlayerController playerController = new PlayerController();
        GenerationController generator = new GenerationController();
        ServerConnector connector = new ServerConnector();
        Player player = new Player();
        List<Bottle> thrownBottles = new List<Bottle>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.playerObject = pictureBox1;
            playerController.AddCommand(new MoveCommand(connector));
            playerController.player = player;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {           
            if (e.KeyCode == Keys.Space)
            {
                var bottle = playerController.ThrowBottle(e);
                Controls.Add(bottle.picture);
                thrownBottles.Add(bottle);
            }
            playerController.SendAction(e);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (bottleCount < 50)
            {
                bottleCount++;
                Controls.Add(generator.GenerateBottles());
            }
            
            if (thrownBottles.Count > 0)
            {
                foreach (var item in thrownBottles)
                {
                    item.picture.Location = new Point(item.picture.Location.X + item.thrownDirection.X,
                        item.picture.Location.Y + item.thrownDirection.Y);
                    item.despawnTimer -= 0.1f;                    
                }
                thrownBottles.RemoveAll(x => x.despawnTimer < 0);
            }
        }
    }
}
