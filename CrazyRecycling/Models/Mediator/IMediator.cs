using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Mediator
{
    public interface IMediator
    {
        void AddComunicator(ACommunicator a);
        void SendMessage(ACommunicator caller, string message, int type);
    }
}
