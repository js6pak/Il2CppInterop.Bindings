using System.IO.Compression;
using Octokit;

namespace Il2CppInterop.Bindings.Generator;

public static class SourceManager
{
    public static async Task<string> EnsureExists()
    {
        const string sourcesPath = "libil2cpp-source";

        if (!Directory.Exists(sourcesPath))
        {
            Console.WriteLine("Downloading libil2cpp-source");

            Directory.CreateDirectory(sourcesPath);

            try
            {
                var httpClient = new HttpClient();
                var gitHubClient = new GitHubClient(new ProductHeaderValue("Il2CppInterop.Bindings.Generator"));
                var files = await gitHubClient.Repository.Content.GetAllContents("bepin-bot", "UnityDataMine", "libil2cpp-source/");

                await Parallel.ForEachAsync(files.Where(f => f.Name.EndsWith(".zip")), async (file, token) =>
                {
                    Console.WriteLine("Downloading " + file.DownloadUrl);
                    var response = await httpClient.GetAsync(file.DownloadUrl, token);

                    var zipPath = Path.Join(sourcesPath, file.Name);

                    await using (var stream = await response.Content.ReadAsStreamAsync(token))
                    await using (var fileStream = File.OpenWrite(zipPath))
                    {
                        await stream.CopyToAsync(fileStream, token);
                    }

                    ZipFile.ExtractToDirectory(zipPath, Path.Join(sourcesPath, Path.GetFileNameWithoutExtension(file.Name)));

                    File.Delete(zipPath);
                });

                Console.WriteLine("Downloaded libil2cpp-source");
            }
            catch (Exception)
            {
                Directory.Delete(sourcesPath, true);
                throw;
            }
        }

        return Path.GetFullPath(sourcesPath);
    }
}
