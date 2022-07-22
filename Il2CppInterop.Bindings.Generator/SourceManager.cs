using System.IO.Compression;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Il2CppInterop.Bindings.Generator;

public static class SourceManager
{
    private record CaddyIndexFile(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("size")] long Size,
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("mod_time")] DateTimeOffset ModificationTime,
        [property: JsonPropertyName("mode")] ushort Mode,
        [property: JsonPropertyName("is_dir")] bool IsDirectory,
        [property: JsonPropertyName("is_symlink")] bool IsSymlink
    );

    private const string BaseUrl = "https://unity.bepinex.dev/libil2cpp-source";

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

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                var files = await httpClient.GetFromJsonAsync<CaddyIndexFile[]>(BaseUrl) ?? throw new Exception("Failed to download file index");

                await Parallel.ForEachAsync(files.Where(f => f.Name.EndsWith(".zip")), async (file, token) =>
                {
                    var downloadUrl = Path.Combine(BaseUrl, file.Url);
                    Console.WriteLine("Downloading " + downloadUrl);
                    var response = await httpClient.GetAsync(downloadUrl, token);

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
