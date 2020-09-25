using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WorldPosts.Models;

namespace WorldPosts.Services
{
    class PostProviderService
    {
        private HttpClient httpClient = new HttpClient();

        public PostProviderService()
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Post>> GetPosts()
        {
            var response = await httpClient.GetAsync(Properties.Resources.PostsDataUrl);
            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Post>>(data);
        }
    }
}
