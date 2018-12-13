using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Mediator
{
    public abstract class ACommunicator
    {
        public string message;
        protected IMediator mediator;

        public ACommunicator(IMediator m)
        {
            mediator = m;
        }
        public abstract void Send(string message, int type);

        public abstract void Receive(string message, int type);
    }
}
