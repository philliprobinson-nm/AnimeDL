using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimeDL
{
    public class AnimeService(IConfigurationRoot configuration)
    {
        private readonly IConfigurationRoot configuration = configuration;

        public async Task<SearchResponse?> SearchAnimeAsync(string query)
        {
            var protocol = configuration["AniwatchSettings:Protocol"];
            var address = configuration["AniwatchSettings:Address"];
            var port = configuration["AniwatchSettings:Port"];
            string url = $"{protocol}{address}:{port}/api/v2/hianime/search?q={query}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SearchResponse?>(responseData);
                }
                else
                {
                    // Handle error
                    return null;
                }
            }
        }

        public async Task<EpisodeResponse?> SearchAnimeEpisodesAsync(string id)
        {
            var protocol = configuration["AniwatchSettings:Protocol"];
            var address = configuration["AniwatchSettings:Address"];
            var port = configuration["AniwatchSettings:Port"];
            string url = $"{protocol}{address}:{port}/api/v2/hianime/anime/{id}/episodes";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EpisodeResponse?>(responseData);
                }
                else
                {
                    // Handle error
                    return null;
                }
            }
        }

        public async Task<StreamResponse?> GetEpisodeStreamAsync(string episodeId, string language)
        {
            var protocol = configuration["AniwatchSettings:Protocol"];
            var address = configuration["AniwatchSettings:Address"];
            var port = configuration["AniwatchSettings:Port"];
            string url = $"{protocol}{address}:{port}/api/v2/hianime/episode/sources?animeEpisodeId={episodeId}&category={language.ToLower()}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<StreamResponse?>(responseData);
                }
                else
                {
                    // Handle error
                    return null;
                }
            }
        }
    }
}
