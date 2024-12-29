using System.Xml.Linq;

namespace AnimeDL
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class SeriesDetails
    {
        public string id { get; set; }
        public string name { get; set; }
        public string poster { get; set; }
        public EpisodesCount episodes { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

    public class Series
    {
        public List<SeriesDetails> animes { get; set; }
    }

    public class EpisodesCount
    {
        public int? sub { get; set; }
        public int? dub { get; set; }
    }

    public class SearchResponse
    {
        public bool success { get; set; }
        public Series data { get; set; }
    }

    public class Episodes
    {
        public int totalEpisodes { get; set; }
        public List<EpisodesDetails> episodes { get; set; }
    }

    public class EpisodesDetails
    {
        public string title { get; set; }
        public string episodeId { get; set; }
        public int number { get; set; }
        public bool isFiller { get; set; }
        public override string ToString()
        {
            return $"{number} - {title}";
        }
    }

    public class EpisodeResponse
    {
        public bool success { get; set; }
        public Episodes data { get; set; }
    }

    public class StreamDetails
    {
        public List<Track> tracks { get; set; }
        public Intro intro { get; set; }
        public Outro outro { get; set; }
        public List<Source> sources { get; set; }
        public int anilistID { get; set; }
        public int malID { get; set; }
    }

    public class Intro
    {
        public int start { get; set; }
        public int end { get; set; }
    }

    public class Outro
    {
        public int start { get; set; }
        public int end { get; set; }
    }

    public class StreamResponse
    {
        public bool success { get; set; }
        public StreamDetails data { get; set; }
    }

    public class Source
    {
        public string url { get; set; }
        public string type { get; set; }
    }

    public class Track
    {
        public string file { get; set; }
        public string kind { get; set; }
    }
}
