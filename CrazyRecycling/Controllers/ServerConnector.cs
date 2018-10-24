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
        //private readonly string baseAdress = "https://localhost:44399/api/";
        private readonly HttpMethod patchMethod = new HttpMethod("PATCH");

        public ServerConnector()
        {
            client.BaseAddress = new Uri(baseAdress);
        }

        public async Task<string> GetAction(string requestUri)
        {
            HttpResponseMessage message = await client.GetAsync(requestUri);
            return await message.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAction(string requestUri, string content)
        {
            HttpContent httpcontent = new StringContent(content, Encoding.UTF8, "application/json");

            HttpResponseMessage message = await client.PostAsync(requestUri, httpcontent);

            return await message.Content.ReadAsStringAsync();
        }

        public async void PutAction(string requestUri, string content)
        {
            HttpContent httpcontent = new StringContent(content, Encoding.UTF8, "application/json");

            await client.PutAsync(requestUri, httpcontent);
        }

        public async void PatchAction(string requestUri, string content)
        {
            HttpContent httpcontent = new StringContent(content, Encoding.UTF8, "application/json");

            await client.SendAsync(new HttpRequestMessage(patchMethod, requestUri) { Content = httpcontent });
        }

        public async void DeleteAction(string requestUri)
        {
            await client.DeleteAsync(requestUri);
        }
    }
}
