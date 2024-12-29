using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AnimeDL
{
    public partial class Form1 : Form
    {
        private SettingsManager settingsManager;
        private AnimeService animeService;
        private FFmpegHandler ffmpegHandler;

        private string saveDirectory = string.Empty;

        public Form1()
        {
            InitializeComponent();
            settingsManager = new SettingsManager();
            animeService = new AnimeService(settingsManager.Configuration);
            ffmpegHandler = new FFmpegHandler(settingsManager.Configuration["FFmpeg:Path"]);
            toolStripStatusLabel1.Text = "";

            LoadSettings();
        }

        private void LoadSettings()
        {
            var aniwatchSettings = settingsManager.Configuration.GetSection("AniwatchSettings");
            cmbAniwatchProtocol.Text = aniwatchSettings["Protocol"];
            txtAniwatchAddress.Text = aniwatchSettings["Address"];
            txtAniwatchPort.Text = aniwatchSettings["Port"];

            var ffmpegSettings = settingsManager.Configuration.GetSection("FFmpeg");
            txtFFmpegPath.Text = ffmpegSettings["Path"];
        }

        private void SettingsFieldChanged(object sender, EventArgs e)
        {
            settingsManager.SaveSettings(cmbAniwatchProtocol.Text, txtAniwatchAddress.Text, txtAniwatchPort.Text, txtFFmpegPath.Text);
        }

        private void UpdateStatus(string status)
        {
            toolStripStatusLabel1.Text = status;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text;

            UpdateStatus($"Searching for {query}...");
            var searchResponse = await animeService.SearchAnimeAsync(query);
            if (searchResponse?.Data?.Animes != null && lstSearchResults != null)
            {
                lstSearchResults.Items.Clear();
                foreach (var anime in searchResponse.Data.Animes)
                {
                    lstSearchResults.Items.Add(anime);
                }
            }
            UpdateStatus($"Searching for {query}... Complete!");
        }

        private async void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesDetails? model = (SeriesDetails?)lstSearchResults.SelectedItem;

            if (model == null || string.IsNullOrEmpty(model.Id))
            {
                MessageBox.Show("Selected item is invalid.");
                return;
            }

            lblId.Text = model.Id;
            lblName.Text = model.Name;
            lblSubs.Text = model.Episodes?.Sub.ToString();
            lblDubs.Text = model.Episodes?.Dub.ToString();

            UpdateStatus($"Fetching episodes for {model.Name}...");
            var episodeResponse = await animeService.SearchAnimeEpisodesAsync(model.Id);
            if (episodeResponse?.Data?.EpisodesDetails != null && lstEpisodes != null)
            {
                lstEpisodes.Items.Clear();
                foreach (var episode in episodeResponse.Data.EpisodesDetails)
                {
                    lstEpisodes.Items.Add(episode);
                }
            }
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
                var streamResponse = await animeService.GetEpisodeStreamAsync(episode.EpisodeId);
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
                                var progress = new Progress<int>(percent =>
                                {
                                    toolStripProgressBar1.Value = percent;
                                });
                                await ffmpegHandler.DownloadVideoAsync(masterUrl, outputPath, progress);
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Episode title is null.");
                        }
                    }
                }
                UpdateStatus($"Downloading episode {i++} of {EpisodeCount}... Complete!");
            }

            this.Enabled = true;
        }
    }
}
