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
        public int Color;
        public PictureBox playerObject;

        public void WarnPlayer()
        {
            throw new NotImplementedException();
        }
        public Player()
        {

        }
        public Player(string name, int posX, int posY, int points, Bottle bottle, int color, PictureBox playerObject)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
            Points = points;
            Bottle = bottle;
            Color = color;
            this.playerObject = playerObject;
        }
        /// <summary>
        ///Method for IPlayer 
        /// </summary>
    }

}
