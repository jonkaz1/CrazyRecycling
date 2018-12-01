using CrazyRecycling.Models.Bottles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Models
{
    public class Player
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
        public Inventory Inventory { get; set; }

        public ICharacterClass CharacterClass { get; set; } = new DefaultClass();
        public PlayerDefaultColor Color { get; set; }

        //Player stats from playerClass
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public int Color2 { get; set; }
        public int Speed { get; set; }
        public int PointsBoost { get; set; }

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


    }
}
