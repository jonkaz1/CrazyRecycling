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
using CrazyRecycling.Models.Props;
using CrazyRecycling.Controllers;

namespace CrazyRecycling
{
    //context
    public partial class Form1 : Form
    {
        Facade Facade = new Facade();
        public static string PlayerName;

        Player MainPlayer = new Player();
        List<Player> PlayerList = new List<Player>();
        List<Bottle> ThrownBottles = new List<Bottle>();
        List<Bottle> GroundBottles = new List<Bottle>();
        List<Machine> Machines = new List<Machine>();


        CancellationTokenSource _cancelationTokenSourcePlayers;
        CancellationTokenSource _cancelationTokenSourceBottles;

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
            SpawnProps();
            MainPlayer.Name = PlayerName;
            MainPlayer.playerObject = pictureBox1;
            pictureBox1.BackColor = Color.Transparent;
            MainPlayer.PosX = pictureBox1.Location.X;
            MainPlayer.PosY = pictureBox1.Location.Y;
            PlayerList.Add(MainPlayer);
            CreatePlayer();



            _cancelationTokenSourcePlayers = new CancellationTokenSource();
            _cancelationTokenSourceBottles = new CancellationTokenSource();
            new Task(() => GetPlayerData(), _cancelationTokenSourcePlayers.Token, TaskCreationOptions.LongRunning).Start();
            new Task(() => GetBottleData(), _cancelationTokenSourceBottles.Token, TaskCreationOptions.LongRunning).Start();
            GetMachines();

            Facade.AttachPlayer(MainPlayer);
            Facade.AddCommand(MainPlayer.PosX + ";" + MainPlayer.PosY);
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
                var bottle = Facade.GetBottle(e);
                Controls.Add(bottle.Image);
                ThrownBottles.Add(bottle);
            }
            Facade.ChangeLocation(e);
        }

        public void CreatePlayer()
        {
            Task<string> create = Task.Run(() => Facade.GetConnector().PostAction("Player",
                "{\"Name\":\"" + MainPlayer.Name + "\"}"));
            create.Wait();
            var result = create.Result;
            var obj = JObject.Parse(result);
            MainPlayer.PlayerId = obj["playerId"].Value<int>();
        }

        public void DeletePlayer(int playerId)
        {
            Task.Run(() => Facade.GetConnector().DeleteAction("Player/" + playerId)).Wait();
        }

        /// <summary>
        /// Get player data. Updates player locations and leaderboard. Repeated.
        /// </summary>
        public void GetPlayerData()
        {
            while (!_cancelationTokenSourcePlayers.Token.IsCancellationRequested)
            {
                Task<string> getPlayers = Task.Run(() => Facade.GetConnector().GetAction("Player"));
                getPlayers.Wait();
                var result = getPlayers.Result;
                var array = JArray.Parse(result);

                foreach (var item in array)
                {
                    Facade.UpdateLeaderBoard(item, ref PlayerList, ref MainPlayer);
                }
                _cancelationTokenSourcePlayers.Token.WaitHandle.WaitOne(200);
            }
        }

        public void GetBottleData()
        {
            while (!_cancelationTokenSourceBottles.Token.IsCancellationRequested)
            {
                var task = Task.Run(() => Facade.GetConnector().GetAction("Bottle"));
                task.Wait();
                var result = task.Result;
                var array = JArray.Parse(result);
                Bottle bottle;
                AbstractFactory pointBottleFactory = new PointBottleFactory();
                AbstractFactory specialBottleFactory = new SpecialBottleFactory();
                foreach (var item in array)
                {
                    lock (GroundBottles)
                    {
                        if (GroundBottles.FirstOrDefault(x => x.BottleId == item["bottleId"].Value<int>()) == null)
                        {
                            string bottleType = BottleTypeIntToString(item["bottleType"].Value<int>());
                            bottle = pointBottleFactory.CreateBottle(bottleType);
                            if (bottle != null)
                            {
                                bottle.PosX = item["posX"].Value<int>();
                                bottle.PosY = item["posY"].Value<int>();
                                bottle.BottleId = item["bottleId"].Value<int>();
                                bottle.Image.Location = new Point(bottle.PosX, bottle.PosY);
                                bottle.IsNewlySpawned = true;
                                GroundBottles.Add(bottle);
                            }
                            else
                            {
                                bottle = specialBottleFactory.CreateBottle(bottleType);
                                if (bottle != null)
                                {
                                    bottle.PosX = item["posX"].Value<int>();
                                    bottle.PosY = item["posY"].Value<int>();
                                    bottle.BottleId = item["bottleId"].Value<int>();
                                    bottle.Image.Location = new Point(bottle.PosX, bottle.PosY);
                                    bottle.IsNewlySpawned = true;
                                    GroundBottles.Add(bottle);
                                }
                            }
                        }
                    }
                }
                _cancelationTokenSourceBottles.Token.WaitHandle.WaitOne(5000);
            }
        }

        /// <summary>
        /// Gets all shops and recycling machines
        /// </summary>
        private void GetMachines()
        {
            var task = Task.Run(() => Facade.GetConnector().GetAction("Machine"));
            task.Wait();
            var result = task.Result;
            var array = JArray.Parse(result);
            Machine machine;
            foreach (var item in array)
            {
                if (item["machineType"].Value<int>() == 0)
                {
                    machine = new RecyclingMachine(
                    item["posX"].Value<int>(), item["posY"].Value<int>(),
                    item["sizeX"].Value<int>(), item["sizeY"].Value<int>()
                    );
                    Machines.Add(machine);
                }
                else
                {
                    machine = new Shop(
                    item["posX"].Value<int>(), item["posY"].Value<int>(),
                    item["sizeX"].Value<int>(), item["sizeY"].Value<int>()
                    );
                    Machines.Add(machine);
                }
                Controls.Add(machine.Image);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeletePlayer(MainPlayer.PlayerId);
        }

        private void SpawnProps()
        {
                        PropSpawner propSpawner = new PropSpawner();
            MapPropBuilder builder = new TreeBuilder();

            for (int i = 0; i < 50; i++)
            {
                builder = new TreeBuilder();
                propSpawner.construct(builder);
                Controls.Add(builder.Prop.picture);
            }
            for (int i = 0; i < 50; i++)
            {
                builder = new MountainBuilder();
                propSpawner.construct(builder);
                Controls.Add(builder.Prop.picture);
            }
        }

        private void Timer1_tick(object sender, EventArgs e)
        {
            foreach (var item in PlayerList)
            {
                if (item.isNewlyCreated)
                {
                    item.playerObject = new PictureBox()
                    {
                        Image = Properties.Resources.Player,
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
            lock (GroundBottles)
            {
                foreach (var item in GroundBottles)
                {
                    if (item.IsNewlySpawned)
                    {
                        Controls.Add(item.Image);
                        item.IsNewlySpawned = false;
                    }
                }
            }
        }
        /*
         Wine,
        Vodka,
        Whiskey,
        GinOfDestruction,
        Cola,
        NukeCola
        */
        private string BottleTypeIntToString(int number)
        {
            switch (number)
            {
                case 0:
                    return "Wine";
                case 1:
                    return "Vodka";
                case 2:
                    return "Whiskey";
                case 3:
                    return "GinOfDestruction";
                case 4:
                    return "Cola";
                case 5:
                    return "NukeCola";
                default:
                    return "";
            }
        }
    }
}
