﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Whiskey : Bottle
    {
        public int Damage { get; set; }

        public override string GetBottleInfo()
        {
            return Damage.ToString();
        }
    }
}
