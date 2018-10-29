using CrazyRecycling.Models.Bottles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Models
{
    public class Player : IPlayer
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

        public void WarnPlayer()
        {
            throw new NotImplementedException();
        }
        public Player()
        {
            Color = new PlayerDefaultColor(characterClass);
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
        }

        
    }
}
