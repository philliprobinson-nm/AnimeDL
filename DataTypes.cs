using Newtonsoft.Json;

namespace AnimeDL
{
    public class SeriesDetails
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
        
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("poster")]
        public string? Poster { get; set; }

        [JsonProperty("episodes")]
        public EpisodesCount? Episodes { get; set; }

        public override string ToString()
        {
            return Name ?? string.Empty;
        }
    }

    public class Series
    {
        [JsonProperty("animes")]
        public List<SeriesDetails>? Animes { get; set; }
    }

    public class EpisodesCount
    {
        [JsonProperty("sub")]
        public int? Sub { get; set; }

        [JsonProperty("dub")]
        public int? Dub { get; set; }
    }

    public class SearchResponse
    {
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("data")]
        public Series? Data { get; set; }
    }

    public class Episodes
    {
        [JsonProperty("totalEpisodes")]
        public int? TotalEpisodes { get; set; }

        [JsonProperty("episodes")]
        public List<EpisodesDetails>? EpisodesDetails { get; set; }
    }

    public class EpisodesDetails
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("episodeId")]
        public string? EpisodeId { get; set; }

        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("isFiller")]
        public bool? IsFiller { get; set; }

        public override string ToString()
        {
            return $"{Number} - {Title}";
        }
    }

    public class EpisodeResponse
    {
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("data")]
        public Episodes? Data { get; set; }
    }

    public class StreamDetails
    {
        [JsonProperty("tracks")]
        public List<Track>? Tracks { get; set; }

        [JsonProperty("intro")]
        public Intro? Intro { get; set; }

        [JsonProperty("outro")]
        public Outro? Outro { get; set; }

        [JsonProperty("sources")]
        public List<Source>? Sources { get; set; }

        [JsonProperty("anilistID")]
        public int? AnilistID { get; set; }

        [JsonProperty("malID")]
        public int? MalID { get; set; }
    }

    public class Intro
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("end")]
        public int? End { get; set; }
    }

    public class Outro
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("end")]
        public int? End { get; set; }
    }

    public class StreamResponse
    {
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("data")]
        public StreamDetails? Data { get; set; }
    }

    public class Source
    {
        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }

    public class Track
    {
        [JsonProperty("file")]
        public string? File { get; set; }

        [JsonProperty("kind")]
        public string? Kind { get; set; }
    }
}
