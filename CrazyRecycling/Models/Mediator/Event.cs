using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Mediator
{
    public class Event : ACommunicator
    {
        public Event(IMediator mediator) : base(mediator) { }

        public override void Send(string message, int type)
        {
            mediator.SendMessage(this, message, type);
        }

        public override void Receive(string message, int type)
        {
            this.message = message;
        }
    }
}
