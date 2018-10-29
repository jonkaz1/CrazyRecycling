using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public abstract class Bottle
    {
        [Key]
        public int BottleId { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public DateTime SpawnTime { get; set; }
        public bool IsProjectile { get; set; }
        public int Speed { get; set; }
        public int LastPosX { get; set; }
        public int LastPosY { get; set; }

        public Bottle()
        {
            
        }

        public abstract string GetBottleInfo();
    }
}
