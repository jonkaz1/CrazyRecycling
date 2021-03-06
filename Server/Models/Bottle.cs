﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Bottle
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
        public BottleType BottleType { get; set; }   
        
        public int BagDeepness { get; set; }
        public int BagPosition { get; set; }

        public DateTime LastUseTime { get; set; }

        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public Player Player { get; set; }
    }

    public enum BottleType
    {
        Wine,
        Vodka,
        Whiskey,
        GinOfDestruction,
        Cola,
        NukeCola
    }
}
