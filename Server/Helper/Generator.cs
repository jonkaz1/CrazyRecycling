using Server.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Helper
{
    public abstract class Generator
    {
        protected DataCreator creator;

        public DataCreator Creator
        {
            set { creator = value; }
        }

        public virtual void GenerateData(ServerContext context)
        {
            creator.GenerateValues(context);
        }
    }
}
