﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Helper
{
    public class BottleGenerator : Generator
    {
        public override void GenerateData(ServerContext context)
        {
            creator.GenerateValues(context);
        }
    }
}
