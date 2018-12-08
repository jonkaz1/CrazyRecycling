namespace CrazyRecycling.Models
{
    public interface IChatMediator
    {
        void AddPlayer(IPlayer player);
        void SendMessage(string message, IPlayer sender);
    }
}