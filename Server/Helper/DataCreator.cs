using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Helper
{
    public abstract class DataCreator
    {
        protected Random Randomizer = new Random();

        public abstract void GenerateValues(ServerContext context);
    }
}
