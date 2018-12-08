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

namespace CrazyRecycling
{
    //context
    public partial class Form1 : Form
    {
        IChatMediator chatMediator = new ChatMediator();
        // create users and add them to chat mediator's user list

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

            IPlayer john = new Player(chatMediator, "John");
            IPlayer tina = new Player(chatMediator, "Tina");
            IPlayer lara = new Player(chatMediator, "Lara");
            chatMediator.AddPlayer(john);
            chatMediator.AddPlayer(tina);
            chatMediator.AddPlayer(lara);
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
            MainPlayer.PlayerObject = pictureBox1;
            pictureBox1.BackColor = Color.Transparent;
            MainPlayer.PositionX = pictureBox1.Location.X;
            MainPlayer.PositionY = pictureBox1.Location.Y;
            PlayerList.Add(MainPlayer);
            CreatePlayer();

            _cancelationTokenSourcePlayers = new CancellationTokenSource();
            _cancelationTokenSourceBottles = new CancellationTokenSource();
            new Task(() => GetPlayerData(), _cancelationTokenSourcePlayers.Token, TaskCreationOptions.LongRunning).Start();
            new Task(() => GetBottleData(), _cancelationTokenSourceBottles.Token, TaskCreationOptions.LongRunning).Start();
            GetMachines(1);

            Facade.AttachPlayer(MainPlayer);
            Facade.AddCommand(MainPlayer.PositionX + ";" + MainPlayer.PositionY);

            this.label3.Visible = false;
            this.label2.Visible = false;
            this.textBox1.Visible = false;
            this.maskedTextBox1.Visible = false;
            this.button1.Visible = false;


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

            if (e.KeyCode == Keys.Tab)
            {
                    this.button1.Enabled = this.button1.Enabled ? false : true;
                    this.maskedTextBox1.Enabled = this.maskedTextBox1.Enabled ? false : true;
                    this.button2.Enabled = this.button2.Enabled ? false : true;
            }
        }


        public void CreatePlayer()
        {
            Task<string> create = Facade.Connector.PostAction("Player",
                "{\"Name\":\"" + MainPlayer.Name + "\"}");
            var result = create.Result;
            var obj = JObject.Parse(result);
            MainPlayer.PlayerId = obj["playerId"].Value<int>();
        }

        public void DeletePlayer(int playerId)
        {
            Facade.Connector.DeleteAction("Player/" + playerId);
        }

        /// <summary>
        /// Get player data. Updates player locations and leaderboard. Repeated.
        /// </summary>
        public void GetPlayerData()
        {
            while (!_cancelationTokenSourcePlayers.Token.IsCancellationRequested)
            {
                Task<string> getPlayers = Facade.Connector.GetAction("Player");
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
                var task = Facade.Connector.GetAction("Bottle");
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
                                bottle.PositionX = item["posX"].Value<int>();
                                bottle.PositionY = item["posY"].Value<int>();
                                bottle.BottleId = item["bottleId"].Value<int>();
                                bottle.Image.Location = new Point(bottle.PositionX * 16, bottle.PositionY * 16);
                                bottle.IsNewlySpawned = true;
                                GroundBottles.Add(bottle);
                            }
                            else
                            {
                                bottle = specialBottleFactory.CreateBottle(bottleType);
                                if (bottle != null)
                                {
                                    bottle.PositionX = item["posX"].Value<int>();
                                    bottle.PositionY = item["posY"].Value<int>();
                                    bottle.BottleId = item["bottleId"].Value<int>();
                                    bottle.Image.Location = new Point(bottle.PositionX * 16, bottle.PositionY * 16);
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
        private void GetMachines(int imgNumber)
        {
            var task = Facade.Connector.GetAction("Machine");
            var result = task.Result;
            var array = JArray.Parse(result);
            Machine machine;
            foreach (var item in array)
            {
                if (item["machineType"].Value<int>() == 0)
                {
                    machine = new RecyclingMachine(
                    item["posX"].Value<int>(), item["posY"].Value<int>(),
                    item["sizeX"].Value<int>(), item["sizeY"].Value<int>(),
                    imgNumber
                    );
                    Machines.Add(machine);
                }
                else
                {
                    machine = new Shop(
                    item["posX"].Value<int>(), item["posY"].Value<int>(),
                    item["sizeX"].Value<int>(), item["sizeY"].Value<int>(),
                    imgNumber
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
                propSpawner.Construct(builder);
                Controls.Add(builder.Prop.Picture);
            }
            for (int i = 0; i < 50; i++)
            {
                builder = new MountainBuilder();
                propSpawner.Construct(builder);
                Controls.Add(builder.Prop.Picture);
            }
        }

        private void Timer1_tick(object sender, EventArgs e)
        {
            foreach (var item in PlayerList)
            {
                if (item.IsNewlyCreated)
                {
                    item.PlayerObject = new PictureBox()
                    {
                        Image = Properties.Resources.Player,
                        Size = new Size(16, 16),
                        Location = new Point(item.PositionX * 16, item.PositionY * 16)
                    };
                    Controls.Add(item.PlayerObject);
                    item.IsNewlyCreated = false;
                }
                if (item.LocationChanged)
                {
                    item.PlayerObject.Location = new Point(item.PositionX * 16, item.PositionY * 16);
                    item.LocationChanged = false;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IPlayer player = new Player(chatMediator, PlayerName);
            //chatMediator.AddPlayer(player);
            //string message = player.ReceiveMessage("Hello Everyone!");

            //string message = this.maskedTextBox1.Text;

            //if (message != "") {
            //    this.textBox1.Text += PlayerName + ": " + message + "\r\n";
            //}

            

            this.maskedTextBox1.Text = "";
            this.maskedTextBox1.Enabled = false;
            this.button1.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {


            //// send message
            //IPlayer player = new Player(chatMediator, PlayerName);
            //chatMediator.AddPlayer(player);
            //player.SendMessage("Hello Everyone!");

            this.button2.Visible = false;
            this.button2.Enabled = false;
            this.maskedTextBox1.Visible = true;
            this.textBox1.Visible = true;
            this.button1.Visible = true;
            this.label3.Visible = true;
            this.label2.Visible = true;

        }
    }
}
