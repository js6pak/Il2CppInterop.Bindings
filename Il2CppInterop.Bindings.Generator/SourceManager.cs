using System.IO.Compression;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using AssetRipper.VersionUtilities;

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

    public static async Task<(UnityVersion UnityVersion, string SourcePath)[]> FetchAsync(bool updateVersions = false)
    {
        const string unityVersionsTxtPath = "UnityVersions.txt";

        UnityVersion[] unityVersions;
        if (File.Exists(unityVersionsTxtPath))
        {
            unityVersions = (await File.ReadAllTextAsync(unityVersionsTxtPath)).Split("\n").Select(UnityVersion.Parse).ToArray();
        }
        else
        {
            if (!updateVersions) throw new InvalidOperationException("No UnityVersions.txt found");
            unityVersions = Array.Empty<UnityVersion>();
        }

        var sourcesPath = Path.Combine("bin", "libil2cpp-source");

        Directory.CreateDirectory(sourcesPath);

        try
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            Console.WriteLine("Fetching file index from " + BaseUrl);
            var files = await httpClient.GetFromJsonAsync<CaddyIndexFile[]>(BaseUrl) ?? throw new Exception("Failed to download file index");
            var contexts = files
                .Where(f => f.Name.EndsWith(".zip"))
                .Select(f =>
                    new
                    {
                        File = f,
                        ZipPath = Path.Join(sourcesPath, f.Name),
                        DestinationDirectory = Path.Join(sourcesPath, Path.GetFileNameWithoutExtension(f.Name)),
                        UnityVersion = UnityVersion.Parse(Path.GetFileNameWithoutExtension(f.Name)),
                    })
                .Where(ctx => ctx.UnityVersion.Type == UnityVersionType.Final)
                // Versions before 5.2.1 didn't have source files which we need for extracting metadata version
                .Where(ctx => ctx.UnityVersion.IsGreater(5, 2, 1));

            if (!updateVersions)
            {
                contexts = contexts.Where(ctx => unityVersions.Contains(ctx.UnityVersion));
            }

            contexts = contexts.ToArray();

            if (updateVersions)
            {
                await File.WriteAllTextAsync(unityVersionsTxtPath, string.Join("\n", contexts.Select(ctx => ctx.UnityVersion).Select(v => v.ToFriendlyString())));
            }

            await Parallel.ForEachAsync(contexts.Where(ctx => !Directory.Exists(ctx.DestinationDirectory) || File.Exists(ctx.ZipPath)), async (ctx, token) =>
            {
                var downloadUrl = Path.Combine(BaseUrl, ctx.File.Url);
                Console.WriteLine("Downloading " + downloadUrl);
                var response = await httpClient.GetAsync(downloadUrl, token);

                await using (var stream = await response.Content.ReadAsStreamAsync(token))
                await using (var fileStream = File.OpenWrite(ctx.ZipPath))
                {
                    await stream.CopyToAsync(fileStream, token);
                }

                ZipFile.ExtractToDirectory(ctx.ZipPath, ctx.DestinationDirectory);

                File.Delete(ctx.ZipPath);
            });

            Console.WriteLine($"Got {contexts.Count()} versions");
            return contexts.Select(ctx => (ctx.UnityVersion, ctx.DestinationDirectory)).ToArray();
        }
        catch (Exception)
        {
            Directory.Delete(sourcesPath, true);
            throw;
        }
    }
}
