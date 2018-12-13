using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Mediator
{
    public delegate void AchievementReceivedEventHandler(string message);
    public delegate void NotificationReceivedEventHandler(string message);
    public class Notificator : ACommunicator
    {
        public event AchievementReceivedEventHandler AchievementReceived;
        public event NotificationReceivedEventHandler NotificationReceived;

        public Notificator(IMediator mediator) : base(mediator) {}

        public override void Receive(string m, int type)
        {
            switch (type)
            {
                case 1:
                    if (AchievementReceived != null)
                        AchievementReceived(m);
                    break;
                case 2:
                    if (NotificationReceived != null)
                        NotificationReceived(m);
                    break;


            }
        }
        public override void Send(string message, int type)
        {
            mediator.SendMessage(this, message, type);
        }
    }
}
