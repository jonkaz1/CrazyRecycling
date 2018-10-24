using CrazyRecycling.Controllers;
using CrazyRecycling.Models;
using Newtonsoft.Json.Linq;
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
        List<Player> playerList = new List<Player>();
        List<Bottle> thrownBottles = new List<Bottle>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.Name = "John";
            player.playerObject = pictureBox1;
            playerController.AddCommand(new MoveCommand(connector, "0;-1"));
            playerController.AddCommand(new MoveCommand(connector, "-1;0"));
            playerController.AddCommand(new MoveCommand(connector, "0;1"));
            playerController.AddCommand(new MoveCommand(connector, "1;0"));
            playerController.player = player;
            playerList.Add(player);
            CreatePlayer();
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
            GetPlayerData();
        }

        public void CreatePlayer()
        {
            Task<string> create = Task.Run(() => connector.PostAction("Player",
                "{\"Name\":\"" + player.Name + "\"}"));
            create.Wait();
            var result = create.Result;
            var obj = JObject.Parse(result);
            player.PlayerId = obj["playerId"].Value<int>();
        }

        public void DeletePlayer()
        {
            Task.Run(() => connector.DeleteAction("Player/" + player.PlayerId)).Wait();
        }

        public void GetPlayerData()
        {
            Task<string> getPlayers = Task.Run(() => connector.GetAction("Player"));
            getPlayers.Wait();
            var result = getPlayers.Result;
            var array = JArray.Parse(result);
            Player p;
            Point point = new Point();
            foreach (var item in array)
            {
                p = playerList.FirstOrDefault(x => x.PlayerId == item["playerId"].Value<int>());
                if (p == null)
                {
                    point.X = item["posX"].Value<int>();
                    point.Y = item["posY"].Value<int>();
                    p = new Player()
                    {
                        PlayerId = item["playerId"].Value<int>(),
                        Name = item["name"].Value<string>(),
                        PosX = point.X,
                        PosY = point.Y,
                        playerObject = new PictureBox()
                        {
                            Image = global::CrazyRecycling.Properties.Resources.Player,
                            Size = new Size(16, 16),
                            Location = point
                        }
                    };
                    Controls.Add(p.playerObject);
                    playerList.Add(p);
                }
                else
                {
                    point.X = item["posX"].Value<int>();
                    point.Y = item["posY"].Value<int>();
                    p.PosX = point.X;
                    p.PosY = point.Y;
                    p.playerObject.Location = point;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeletePlayer();
        }
    }
}
