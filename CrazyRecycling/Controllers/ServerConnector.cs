using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Controllers
{
    public class ServerConnector
    {
        HttpClient client = new HttpClient();
        string baseAdress = "https://crazyrecycling.azurewebsites.net/api/values";

        public void Action()
        {
            Console.WriteLine("Implement connector to website");
        }
    }
}
