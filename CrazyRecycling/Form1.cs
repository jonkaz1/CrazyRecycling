using CrazyRecycling.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrazyRecycling.Models.Bottles;
using CrazyRecycling.Models.Props;
using CrazyRecycling.Models.Mediator;
using System.Timers;

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
        public static List<Bottle> GroundBottles = new List<Bottle>();
        List<Machine> Machines = new List<Machine>();



        CancellationTokenSource _cancelationTokenSourcePlayers;
        CancellationTokenSource _cancelationTokenSourceBottles;

        Mediator achievementMediator = new Mediator();
        bool tabPressed = false; bool hasBeenShown = false;

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

            setLabelsToNotVisible();
            MediatorStart();
            tenSecondsTimer();
        }

        public void MediatorStart()
        {
            Notificator SendToAchvievment = new Notificator(achievementMediator);
            Notificator SendToNotification = new Notificator(achievementMediator);
            SendToAchvievment.AchievementReceived += AchievementReceivedEventHandler;
            SendToNotification.NotificationReceived += NotificationReceivedEventHandler;
            achievementMediator.AddComunicator(SendToAchvievment);
            achievementMediator.AddComunicator(SendToNotification);
        }
        public void NotificationReceivedEventHandler(string message)
        {
            NotificationsLabel.Text = message;
            NotificationsLabel.Visible = true;
        }

        public void setLabelsToNotVisible()
        {
            PlayerMessageLabel.Visible = false;
            ChatRoomLabel.Visible = false;
            ChatTextBox.Visible = false;
            YourMessageTextBox.Visible = false;
            SendButton.Visible = false;
            AchievmentsLabel.Visible = false;
            NotificationsLabel.Visible = false;
        }
        public void tenSecondsTimer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            // Set the Interval to 10 seconds.
            aTimer.Interval = 10000;
            aTimer.Enabled = true;

            if (hasBeenShown == true)
                aTimer.Enabled = false;
        }
        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (hasBeenShown == false)
            {
                Event keyPressed = new Event(achievementMediator);
                achievementMediator.AddComunicator(keyPressed);
                achievementMediator.achievment = keyPressed;
                keyPressed.Send("Congratulations! You've been ingame for 10 seconds.", 2);
            }
            hasBeenShown = true;
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
                lock (GroundBottles)
                {
                    var bottle = GroundBottles.Find(x => x.PositionX == MainPlayer.PositionX && x.PositionY == MainPlayer.PositionY);
                    if (bottle != null)
                    {
                        Facade.PickUpBottle(bottle.BottleId);
                        Controls.Remove(bottle.Image);
                    }
                }
            }
            if (e.KeyCode == Keys.Q)
            {
                Facade.DepositBottle();
            }
            Facade.ChangeLocation(e);

            if (e.KeyCode == Keys.Tab)
            {
                if (tabPressed == false)
                {
                    Event keyPressed = new Event(achievementMediator);
                    achievementMediator.AddComunicator(keyPressed);
                    achievementMediator.achievment = keyPressed;
                    keyPressed.Send("Congratulations! You've found CHAT button.", 1);
                    tabPressed = true;
                }

                SendButton.Enabled = SendButton.Enabled ? false : true;
                YourMessageTextBox.Enabled = YourMessageTextBox.Enabled ? false : true;
                JoinChatButton.Enabled = JoinChatButton.Enabled ? false : true;
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
            Task<string> getPlayers;
            string result;
            JArray array;

            while (!_cancelationTokenSourcePlayers.Token.IsCancellationRequested)
            {
                getPlayers = Facade.Connector.GetAction("Player");
                result = getPlayers.Result;
                array = JArray.Parse(result);

                foreach (var item in array)
                {
                    Facade.UpdateLeaderBoard(item, ref PlayerList, ref MainPlayer);
                }
                _cancelationTokenSourcePlayers.Token.WaitHandle.WaitOne(200);
            }
        }

        public void GetBottleData()
        {
            Task<string> task;
            string result;
            JArray array;
            Bottle bottle;
            AbstractFactory pointBottleFactory = new PointBottleFactory();
            AbstractFactory specialBottleFactory = new SpecialBottleFactory();
            List<Bottle> toDelete;

            while (!_cancelationTokenSourceBottles.Token.IsCancellationRequested)
            {
                task = Facade.Connector.GetAction("Bottle");
                result = task.Result;
                array = JArray.Parse(result);
                lock (GroundBottles)
                {
                    foreach (var item in GroundBottles)
                    {
                        item.MarkedForDelete = true;
                    }
                    foreach (var item in array)
                    {
                        bottle = GroundBottles.FirstOrDefault(x => x.BottleId == item["bottleId"].Value<int>());
                        if (bottle == null)
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
                                bottle.MarkedForDelete = false;
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
                                    bottle.MarkedForDelete = false;
                                    GroundBottles.Add(bottle);
                                }
                            }
                        }
                        else
                        {
                            bottle.MarkedForDelete = false;
                        }
                    }
                    toDelete = GroundBottles.Where(x => x.MarkedForDelete == true).ToList();
                    foreach (Control item in Controls)
                    {
                        if (item is PictureBox pictureBox && toDelete.Exists(x => x.Image == (item as PictureBox)))
                        {
                            Controls.Remove(pictureBox);
                        }
                    }
                    GroundBottles.RemoveAll(x => x.MarkedForDelete == true);
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

            for (int i = 0; i < 200; i++)
            {
                builder = new TreeBuilder();
                propSpawner.Construct(builder);
                Controls.Add(builder.Prop.Picture);
            }
            for (int i = 0; i < 200; i++)
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
            label4.Text = MainPlayer.Points.ToString();
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
            this.YourMessageTextBox.Text = "";
            this.YourMessageTextBox.Enabled = false;
            this.SendButton.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.JoinChatButton.Visible = false;
            this.JoinChatButton.Enabled = false;
            this.YourMessageTextBox.Visible = true;
            this.ChatTextBox.Visible = true;
            this.SendButton.Visible = true;
            this.PlayerMessageLabel.Visible = true;
            this.ChatRoomLabel.Visible = true;
        }

        public void AchievementReceivedEventHandler(string message)
        {
            AchievmentsLabel.Text = message;
            AchievmentsLabel.Visible = true;
        }

        private void AchievmentsLabel_Click(object sender, EventArgs e)
        {
            AchievmentsLabel.Visible = false;
        }

        private void NotificationsLabel_Click(object sender, EventArgs e)
        {
            NotificationsLabel.Visible = false;
        }
    }
}
