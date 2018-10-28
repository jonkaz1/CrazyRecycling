using CrazyRecycling.Controllers;
using CrazyRecycling.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using CrazyRecycling.Models.Bottles;

namespace CrazyRecycling
{
    public partial class Form1 : Form
    {
        PlayerController playerController;
        GenerationController generator = new GenerationController();
        LeaderboardController leaderboard = new LeaderboardController();
        ServerConnector connector = new ServerConnector();
        Player player = new Player();
        List<Player> playerList = new List<Player>();
        List<Bottle> thrownBottles = new List<Bottle>();
        List<RecyclingMachine> recyclingMachines = new List<RecyclingMachine>();

        CancellationTokenSource _cancelationTokenSource;

        delegate void PlayerLocationVoidDelegate(Player player, Point point);
        delegate void PlayerObjectDelegate(PictureBox player);

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }


        /// <summary>
        /// Start method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            player.Name = "John";
            player.playerObject = pictureBox1;
            player.PosX = pictureBox1.Location.X;
            player.PosY = pictureBox1.Location.Y;
            playerList.Add(player);
            CreatePlayer();
                       

            _cancelationTokenSource = new CancellationTokenSource();
            new Task(() => GetPlayerData(), _cancelationTokenSource.Token, TaskCreationOptions.LongRunning).Start();

            playerController = new PlayerController(player);
            playerController.AddCommand(new MoveCommand(connector, player.PosX + ";" + player.PosY));

        }


        /// <summary>
        /// Input controller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                var bottle = playerController.ThrowBottle(e);
                Controls.Add(bottle.picture);
                thrownBottles.Add(bottle);
            }
            playerController.ChangeLocation(e);
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

        public void DeletePlayer(int playerId)
        {
            Task.Run(() => connector.DeleteAction("Player/" + playerId)).Wait();
        }

        /// <summary>
        /// Get player data. Updates player locations and leaderboard. Repeated.
        /// </summary>
        public void GetPlayerData()
        {
            while (!_cancelationTokenSource.Token.IsCancellationRequested)
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
                    point.X = item["posX"].Value<int>();
                    point.Y = item["posY"].Value<int>();
                    if (p == null)
                    {
                        p = new Player()
                        {
                            PlayerId = item["playerId"].Value<int>(),
                            Name = item["name"].Value<string>(),
                            PosX = point.X,
                            PosY = point.Y,
                            isNewlyCreated = true
                        };
                        playerList.Add(p);
                    }
                    else
                    {
                        if (p.PlayerId == player.PlayerId && !IsPlayerTooFar(player.PosX, player.PosY, point.X, point.Y))
                        {
                            continue;
                        }
                        else
                        {
                            p.PosX = point.X;
                            p.PosY = point.Y;
                            p.locationChanged = true;
                        }
                    }
                    leaderboard.UpdateLeaderboard(p);
                }
                _cancelationTokenSource.Token.WaitHandle.WaitOne(200);
            }
        }

        /// <summary>
        /// Gets all shops and recycling machines
        /// </summary>
        private void GetMachines()
        {
            var task = Task.Run(() => connector.GetAction("RecyclingMachine"));
            task.Wait();
            var result = task.Result;
            var array = JArray.Parse(result);
            foreach (var item in array)
            {
                var machine = new RecyclingMachine(
                    item["posX"].Value<int>(), item["posY"].Value<int>(),
                    item["sizeX"].Value<int>(), item["sizeY"].Value<int>());
                recyclingMachines.Add(machine);
                Controls.Add(machine.Image);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeletePlayer(player.PlayerId);
        }

        private bool IsPlayerTooFar(int playerPosX, int playerPosY, int newPosX, int newPosY)
        {
            if (Math.Abs(playerPosX - newPosX) > 50 || Math.Abs(playerPosY - newPosY) > 50)
            {
                return true;
            }
            return false;
        }

        private void ChangePlayerLocation(Player player, Point point)
        {
            if (player.playerObject.InvokeRequired)
            {
                PlayerLocationVoidDelegate d = new PlayerLocationVoidDelegate(ChangePlayerLocation);
                Invoke(d, new object[] { player, point });
            }
            else
            {
                player.playerObject.Location = point;
            }
        }

        private void AddPlayerObject(PictureBox player)
        {
            if (InvokeRequired)
            {
                PlayerObjectDelegate d = new PlayerObjectDelegate(AddPlayerObject);
                Invoke(d, new object[] { player });
            }
            else
            {
                Controls.Add(player);
            }
        }

        private void Timer1_tick(object sender, EventArgs e)
        {
            foreach (var item in playerList)
            {
                if (item.isNewlyCreated)
                {
                    item.playerObject = new PictureBox()
                    {
                        Image = global::CrazyRecycling.Properties.Resources.Player,
                        Size = new Size(16, 16),
                        Location = new Point(item.PosX, item.PosY)
                    };
                    Controls.Add(item.playerObject);
                    item.isNewlyCreated = false;
                }
                if (item.locationChanged)
                {
                    item.playerObject.Location = new Point(item.PosX, item.PosY);
                    item.locationChanged = false;
                }
            }
        }
    }
}
