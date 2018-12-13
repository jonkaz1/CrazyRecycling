using CrazyRecycling.Models.Bottles;
using CrazyRecycling.Models.HealthState;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Models
{
    public class Player : IPlayer
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Points { get; set; }
        public Bottle Bottle { get; set; }
        public PictureBox PlayerObject { get; set; }
        public bool IsNewlyCreated { get; set; }
        public bool LocationChanged { get; set; }
        public bool isBoostNeeded { get; set; }
        public Inventory Inventory { get; set; }

        IChatMediator chatMediator;

        public ICharacterClass CharacterClass { get; set; } = new DefaultClass();
        public PlayerDefaultColor Color { get; set; }

        //Player stats from playerClass
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public int Color2 { get; set; }
        public int Speed { get; set; }
        public int PointsBoost { get; set; }

        public HealthState.HealthState HealthState { get; set; }

        public Player()
        {
            Color = new PlayerDefaultColor(CharacterClass);
            //Gets stats from player characterClass
            PlayerStats stats = CharacterClass.GetStats();
            HealthPoints = stats.HealthPoints;
            Damage = stats.Damage;
            Color2 = stats.Color;
            Speed = stats.Speed;
            PointsBoost = stats.PointsBoost;
            isBoostNeeded = false;
        }
        public Player(string name, int positionX, int positionY, int points, ICharacterClass characterClass, Bottle bottle, PictureBox playerObject)
        {
            Name = name;
            PositionX = positionX;
            PositionY = positionY;
            Points = points;
            Bottle = bottle;
            this.PlayerObject = playerObject;
            this.CharacterClass = characterClass;
            Color = new PlayerColor(characterClass);

            //Gets stats from player characterClass
            PlayerStats stats = characterClass.GetStats();
            HealthPoints = stats.HealthPoints;
            Damage = stats.Damage;
            Color2 = stats.Color;
            Speed = stats.Speed;
            PointsBoost = stats.PointsBoost;
        }
        public Player(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public void SetClass(string charClass)
        {
            if (charClass == "Brute")
            {
                CharacterClass = new Brute();
            }
            else if (charClass == "Hoarder")
            {
                CharacterClass = new Hoarder();
            }
            else if (charClass == "Speedy")
            {
                CharacterClass = new Speedy();
            }
            Color = new PlayerColor(CharacterClass);
        }
        //start of Jonas Visitor code
        public void CheckBigBoost()
        {
            if (Points >= 1000 && isBoostNeeded)
            {
                Inventory.MainBag.Accept(new DamageVisitor());
                Inventory.MainBag.Accept(new PointsVisitor());
            }
        }
        //end
        

        public Player(IChatMediator chatMediator, string name)
        {
            this.Name = name;
            this.chatMediator = chatMediator;
        }

        public int CheckHealth()
        {
            if (HealthState is Alive alive)
            {
                return alive.HealthPoints;
            }
            else
            {
                return -1;
            }
        }

        public void ChangeHealth(int value)
        {
            if (HealthState is Alive alive)
            {
                alive.Handle(value, this);
            }
        }

        public void SendMessage(string message)
        {
            chatMediator.SendMessage(message, this);
        }

        public string ReceiveMessage(string message)
        {
            return string.Format(Name + ": " + message);
        }
    }
}
