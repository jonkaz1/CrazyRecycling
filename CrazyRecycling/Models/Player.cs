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
        public string Name;
        public double PosX;
        public double PosY;
        public int Points;
        public Bottle Bottle;
        public int Color;
        public PictureBox playerObject;
<<<<<<< HEAD

        public void WarnPlayer()
        {
            throw new NotImplementedException();
        }
=======
        public Player()
        {

        }
        public Player(string name, double posX, double posY, int points, Bottle bottle, int color, PictureBox playerObject)
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
        public void WarnPlayer()
        {

        }

>>>>>>> e8c58a9211c6b3cf3db542e2739ffcbf467d0e21
    }

}
