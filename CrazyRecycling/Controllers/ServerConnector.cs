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
        private readonly string baseAdress = "https://crazyrecycling.azurewebsites.net/api/";

        public async void Action(string value)
        {
            string[] request = value.Split(';');
            
            client.BaseAddress = new Uri(baseAdress);
            HttpResponseMessage message = await client.GetAsync("Player/1");
            Console.WriteLine(await message.Content.ReadAsStringAsync());
            
        }        
    }
}
