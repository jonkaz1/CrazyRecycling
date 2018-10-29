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
        private HttpClient Client = new HttpClient();
        private readonly string BaseAdress = "https://crazyrecycling.azurewebsites.net/api/";
        //private readonly string baseAdress = "https://localhost:44399/api/";
        private readonly HttpMethod PatchMethod = new HttpMethod("PATCH");

        public ServerConnector()
        {
            Client.BaseAddress = new Uri(BaseAdress);
        }

        public async Task<string> GetAction(string requestUri)
        {
            HttpResponseMessage message = await Client.GetAsync(requestUri);
            return await message.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAction(string requestUri, string content)
        {
            HttpContent httpcontent = new StringContent(content, Encoding.UTF8, "application/json");

            HttpResponseMessage message = await Client.PostAsync(requestUri, httpcontent);

            return await message.Content.ReadAsStringAsync();
        }

        public async void PutAction(string requestUri, string content)
        {
            HttpContent httpcontent = new StringContent(content, Encoding.UTF8, "application/json");

            await Client.PutAsync(requestUri, httpcontent);
        }

        public async void PatchAction(string requestUri, string content)
        {
            HttpContent httpcontent = new StringContent(content, Encoding.UTF8, "application/json");

            await Client.SendAsync(new HttpRequestMessage(PatchMethod, requestUri) { Content = httpcontent });
        }

        public async void DeleteAction(string requestUri)
        {
            await Client.DeleteAsync(requestUri);
        }
    }
}
