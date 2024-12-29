using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace AnimeDL
{
    public class FFmpegHandler
    {
        private readonly string ffmpegPath;

        public FFmpegHandler(string ffmpegPath)
        {
            this.ffmpegPath = ffmpegPath;
        }

        public async Task DownloadVideoAsync(string url, string outputPath, IProgress<int> progress)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = $"-i \"{url}\" -c copy \"{outputPath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

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
                    progress.Report(100);
                    // Handle success
                }
                else
                {
                    // Handle error
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
