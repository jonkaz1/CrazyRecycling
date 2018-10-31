﻿using CrazyRecycling.Controllers;
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
        public static string PlayerName;
        Facade Facade = new Facade();
        ServerConnector Connector = new ServerConnector();
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
            Facade.AddCommand(Connector, MainPlayer.PosX + ";" + MainPlayer.PosY);
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
            Task<string> create = Task.Run(() => Connector.PostAction("Player",
                "{\"Name\":\"" + MainPlayer.Name + "\"}"));
            create.Wait();
            var result = create.Result;
            var obj = JObject.Parse(result);
            MainPlayer.PlayerId = obj["playerId"].Value<int>();
        }

        public void DeletePlayer(int playerId)
        {
            Task.Run(() => Connector.DeleteAction("Player/" + playerId)).Wait();
        }

        /// <summary>
        /// Get player data. Updates player locations and leaderboard. Repeated.
        /// </summary>
        public void GetPlayerData()
        {
            while (!_cancelationTokenSourcePlayers.Token.IsCancellationRequested)
            {
                Task<string> getPlayers = Task.Run(() => Connector.GetAction("Player"));
                getPlayers.Wait();
                var result = getPlayers.Result;
                var array = JArray.Parse(result);
                Player p;
                Point point = new Point();
                foreach (var item in array)
                {
                    p = PlayerList.FirstOrDefault(x => x.PlayerId == item["playerId"].Value<int>());
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
                        PlayerList.Add(p);
                    }
                    else
                    {
                        if (p.PlayerId == MainPlayer.PlayerId && !IsPlayerTooFar(MainPlayer.PosX, MainPlayer.PosY, point.X, point.Y))
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

                    Facade.UpdateLeaderBoard(p);
                }
                _cancelationTokenSourcePlayers.Token.WaitHandle.WaitOne(200);
            }
        }

        public void GetBottleData()
        {
            while (!_cancelationTokenSourceBottles.Token.IsCancellationRequested)
            {
                var task = Task.Run(() => Connector.GetAction("Bottle"));
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
            var task = Task.Run(() => Connector.GetAction("Machine"));
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

        private bool IsPlayerTooFar(int playerPosX, int playerPosY, int newPosX, int newPosY)
        {
            if (Math.Abs(playerPosX - newPosX) > 50 || Math.Abs(playerPosY - newPosY) > 50)
            {
                return true;
            }
            return false;
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
