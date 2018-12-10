using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.ChainOfResp
{
    public abstract class Handler
    {
        public ServerContext Context { get; set; }
        protected Handler _successor;

        public Handler Successor
        {
            get
            {
                return _successor;
            }
            set
            {
                _successor = value;
            }
        }
        
        public abstract Bottle HandleRequest(BottleDTOContainer bottle, int playerId);
    }
}
