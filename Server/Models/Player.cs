using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Player : IPlayer
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Points { get; set; }
        public Bottle Bottle { get; set; }
        public int Color { get; set; }
        public CharacterClass CharacterClass { get; set; }

        public Player()
        {

        }
        public Player(string name, int posX, int posY, int points, Bottle bottle, int color)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
            Points = points;
            Bottle = bottle;
            Color = color;
        }
        public void WarnPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
