using System.Configuration;
using System.Diagnostics;
using System.Net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AnimeDL
{
    public partial class Form1 : Form
    {
        private IConfigurationRoot configuration;

        private string saveDirectory = string.Empty;

        public Form1()
        {
            InitializeComponent();
            configuration = LoadSettings();
            toolStripStatusLabel1.Text = "";
        }

        private IConfigurationRoot LoadSettings()
        {
            var settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "settings.json");

            if (!File.Exists(settingsFilePath))
            {
                // Create default settings
                var defaultSettings = new
                {
                    AniwatchSettings = new
                    {
                        Protocol = "http://",
                        Address = "localhost",
                        Port = "4000"
                    },
                    FFmpeg = new
                    {
                        Path = "C:\\ffmpeg\\bin\\ffmpeg.exe"
                    }
                };

                var defaultJson = System.Text.Json.JsonSerializer.Serialize(defaultSettings, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(settingsFilePath, defaultJson);
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();

            var aniwatchSettings = configuration.GetSection("AniwatchSettings");
            cmbAniwatchProtocol.Text = aniwatchSettings["Protocol"];
            txtAniwatchAddress.Text = aniwatchSettings["Address"];
            txtAniwatchPort.Text = aniwatchSettings["Port"];

            var ffmpegSettings = configuration.GetSection("FFmpeg");
            txtFFmpegPath.Text = ffmpegSettings["Path"];

            return builder.Build();
        }

        private void SettingsFieldChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            var aniwatchSettings = new
            {
                Protocol = cmbAniwatchProtocol.Text,
                Address = txtAniwatchAddress.Text,
                Port = txtAniwatchPort.Text
            };

            var ffmpegSettings = new
            {
                Path = txtFFmpegPath.Text
            };

            var settings = new
            {
                AniwatchSettings = aniwatchSettings,
                FFmpeg = ffmpegSettings
            };

            var json = System.Text.Json.JsonSerializer.Serialize(settings, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("settings.json", json);
        }

        private void UpdateStatus(string status)
        {
            toolStripStatusLabel1.Text = status;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text;

            UpdateStatus($"Searching for {query}...");
            await SearchAnimeAsync(query);
            UpdateStatus($"Searching for {query}... Complete!");
        }

        private async Task SearchAnimeAsync(string query)
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
                    var searchResponse = JsonConvert.DeserializeObject<SearchResponse>(responseData);

                    if (searchResponse?.Data?.Animes != null && lstSearchResults != null)
                    {
                        lstSearchResults.Items.Clear();
                        foreach (var anime in searchResponse.Data.Animes)
                        {
                            lstSearchResults.Items.Add(anime);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("No results found or list is not initialized.");
                        Debug.WriteLine(responseData);
                    }
                }
                else
                {
                    //MessageBox.Show("Error fetching data from API");
                }
            }
        }

        private async Task SearchAnimeEpisodesAsync(string id)
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
                    var episodeResponse = JsonConvert.DeserializeObject<EpisodeResponse>(responseData);

                    if (episodeResponse?.Data?.EpisodesDetails != null && lstEpisodes != null)
                    {
                        lstEpisodes.Items.Clear();
                        foreach (var episode in episodeResponse.Data.EpisodesDetails)
                        {
                            lstEpisodes.Items.Add(episode);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("No results found or list is not initialized.");
                        Debug.WriteLine(responseData);
                    }
                }
                else
                {
                    //MessageBox.Show("Error fetching data from API");
                }
            }
        }

        private async void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesDetails? model = (SeriesDetails?)lstSearchResults.SelectedItem;

            if (model == null || string.IsNullOrEmpty(model.Id))
            {
                // Handle the case where model or model.Id is null
                MessageBox.Show("Selected item is invalid.");
                return;
            }

            lblId.Text = model.Id;
            lblName.Text = model.Name;
            lblSubs.Text = model.Episodes?.Sub.ToString();
            lblDubs.Text = model.Episodes?.Dub.ToString();

            UpdateStatus($"Fetching episodes for {model.Name}...");
            await SearchAnimeEpisodesAsync(model.Id);
            UpdateStatus($"Fetching episodes for {model.Name}... Complete!");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var selEpisodes = lstEpisodes.SelectedItems.Cast<EpisodesDetails>().ToList();

            if (selEpisodes.Count == 0)
            {
                MessageBox.Show("No episodes selected.");
                return;
            }

            this.Enabled = false;

            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    saveDirectory = folderDialog.SelectedPath;
                }
                else
                {
                    MessageBox.Show("No folder selected.");
                    return;
                }
            }

            var EpisodeCount = selEpisodes.Count;
            var i = 1;

            foreach (var episode in selEpisodes)
            {
                UpdateStatus($"Downloading episode {i} of {EpisodeCount}...");
                await DownloadAnimeEpisode(episode);
                UpdateStatus($"Downloading episode {i++} of {EpisodeCount}... Complete!");
            }

            this.Enabled = true;
        }

        private async Task DownloadAnimeEpisode(EpisodesDetails episode)
        {
            var protocol = configuration["AniwatchSettings:Protocol"];
            var address = configuration["AniwatchSettings:Address"];
            var port = configuration["AniwatchSettings:Port"];
            string url = $"{protocol}{address}:{port}/api/v2/hianime/episode/sources?animeEpisodeId={episode.EpisodeId}&category=dub";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var streamResponse = JsonConvert.DeserializeObject<StreamResponse>(responseData);

                    if (streamResponse?.Data?.Sources != null)
                    {
                        var masterUrl = streamResponse.Data.Sources.FirstOrDefault()?.Url;
                        if (!string.IsNullOrEmpty(masterUrl))
                        {
                            if (episode.Title != null)
                            {
                                string sanitizedTitle = string.Concat(episode.Title.Split(Path.GetInvalidFileNameChars()));
                                string outputFileName = $"{lblName.Text} - {episode.Number:D3} - {sanitizedTitle}.mp4";
                                string outputPath = Path.Combine(saveDirectory, outputFileName);

                                if (!File.Exists(outputPath))
                                {
                                    await DownloadVideoAsync(masterUrl, outputPath);
                                }
                            }
                            else
                            {
                                // Handle the case where episode.Title is null
                                Debug.WriteLine("Episode title is null.");
                            }
                        }
                        else
                        {
                            //MessageBox.Show("No valid stream URL found.");  
                        }
                    }
                    else
                    {
                        //MessageBox.Show("No stream sources found.");  
                    }
                }
                else
                {
                    //MessageBox.Show("Error fetching data from API");  
                }
            }
        }

        private async Task DownloadVideoAsync(string url, string outputPath)
        {
            var ffmpegPath = configuration["FFmpeg:Path"]; // Accessing the FFmpeg path from settings
            var processInfo = new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = $"-i \"{url}\" -c copy \"{outputPath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            var progress = new Progress<int>(percent =>
            {
                toolStripProgressBar1.Value = percent;
            });

            using (var process = new Process { StartInfo = processInfo })
            {
                process.Start();

                // Asynchronously read the standard output and error streams
                var outputTask = ReadStreamAsync(process.StandardOutput, progress);
                var errorTask = ReadStreamAsync(process.StandardError, progress);

                await Task.WhenAll(outputTask, errorTask);
                await process.WaitForExitAsync();

                if (process.ExitCode == 0)
                {
                    ((IProgress<int>)progress).Report(100);
                    //MessageBox.Show($"Download complete: {outputPath}");
                }
                else
                {
                    //MessageBox.Show($"Error downloading video. Exit code: {process.ExitCode}");
                }
            }
        }

        private async Task ReadStreamAsync(StreamReader reader, IProgress<int> progress)
        {
            string? line; // Allow line to be nullable

            TimeSpan totalDuration = TimeSpan.Zero;

            while ((line = await reader.ReadLineAsync()) != null)
            {
                // Parse the total duration from the ffmpeg output if possible
                // Example: Duration: 00:01:30.00, start: 0.000000, bitrate: 0 kb/s
                if (line.Contains("Duration:"))
                {
                    var durationIndex = line.IndexOf("Duration:");
                    var durationString = line.Substring(durationIndex + 10, 11); // Extract the duration part
                    if (TimeSpan.TryParse(durationString, out var duration))
                    {
                        totalDuration = duration;
                    }
                }

                // Parse the current time from the ffmpeg output if possible
                // Example: frame=  100 fps=0.0 q=-1.0 size=       0kB time=00:00:04.00 bitrate=   0.0kbits/s speed=8.01x
                if (line.Contains("time="))
                {
                    var timeIndex = line.IndexOf("time=");
                    var timeString = line.Substring(timeIndex + 5, 11); // Extract the time part
                    if (TimeSpan.TryParse(timeString, out var time))
                    {
                        if (totalDuration > TimeSpan.Zero)
                        {
                            var percent = (int)((time.TotalSeconds / totalDuration.TotalSeconds) * 100);
                            progress.Report(percent);
                        }
                    }
                }
            }
        }
    }
}
