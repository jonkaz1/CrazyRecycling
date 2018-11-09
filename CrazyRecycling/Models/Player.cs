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
        public int PlayerId;
        public string Name;
        public int PosX;
        public int PosY;
        public int Points;
        public Bottle Bottle;
        public PictureBox playerObject;
        public bool isNewlyCreated;
        public bool locationChanged;

        public ICharacterClass characterClass = new DefaultClass();
        public PlayerDefaultColor Color;

        //Player stats from playerClass
        public int HealthPoints;
        public int Damage;
        public int ColorNew;
        public int Speed;
        public int PointsBoost;


        public void WarnPlayer()
        {
            throw new NotImplementedException();
        }
        public Player()
        {
            Color = new PlayerDefaultColor(characterClass);
            //Gets stats from player characterClass
            PlayerStats stats = characterClass.GetStats();
            HealthPoints = stats.HealthPoints;
            Damage = stats.Damage;
            ColorNew = stats.Color;
            Speed = stats.Speed;
            PointsBoost = stats.PointsBoost;
        }
        public Player(string name, int posX, int posY, int points, ICharacterClass characterClass, Bottle bottle, PictureBox playerObject)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
            Points = points;
            Bottle = bottle;
            this.playerObject = playerObject;
            this.characterClass = characterClass;
            Color = new PlayerColor(characterClass);

            //Gets stats from player characterClass
            PlayerStats stats = characterClass.GetStats();
            HealthPoints = stats.HealthPoints;
            Damage = stats.Damage;
            ColorNew = stats.Color;
            Speed = stats.Speed;
            PointsBoost = stats.PointsBoost;
        }
        public Player(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }
        public void setClass(string charClass)
        {
            if (charClass == "Brute")
            {
                characterClass = new Brute();
            }
            else if (charClass == "Hoarder")
            {
                characterClass = new Hoarder();
            }
            else if (charClass == "Speedy")
            {
                characterClass = new Speedy();
            }
            Color = new PlayerColor(characterClass);
        }


    }
}
