using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class NukeCola : Bottle
    {
        public int Count { get; set; }

        public override string GetBottleInfo()
        {
            return Count.ToString();
        }
    }
}
