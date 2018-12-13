using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Mediator
{
    class Mediator : IMediator
    {
        List<ACommunicator> list = new List<ACommunicator>();
        public Notificator notification { get; set; }
        public Event achievment { get; set; }

        public void AddComunicator(ACommunicator a)
        {
            list.Add(a);
        }

        public void SendMessage(ACommunicator caller, string msg, int type)
        {
            foreach (ACommunicator communicator in list)
            {
                if (caller != communicator)
                    communicator.Receive(msg, type);
            }
        }
    }
}
