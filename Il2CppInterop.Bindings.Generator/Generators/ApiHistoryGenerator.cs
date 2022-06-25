using System.Text;
using AssetRipper.VersionUtilities;

namespace Il2CppInterop.Bindings.Generator.Generators;

public static class ApiHistoryGenerator
{
    public static async Task GenerateAsync(IDictionary<UnityVersion, Il2CppVersion> versions, string outputPath)
    {
        var exportedFunctions = new HashSet<string>();

        var additions = 0;
        var removals = 0;

        await using var historyStream = File.OpenWrite(Path.Combine(outputPath, "ApiHistory.txt"));
        await using var historyWriter = new StreamWriter(historyStream);

        foreach (var (unityVersion, version) in versions)
        {
            var changes = new StringBuilder();

            var currentFunctions = new List<string>();

            foreach (var function in version.Functions)
            {
                currentFunctions.Add(function.Name);

                if (!exportedFunctions.Contains(function.Name))
                {
                    additions++;
                    exportedFunctions.Add(function.Name);
                    changes.AppendLine("+ " + function.Name);
                }
            }

            foreach (var function in exportedFunctions.ToList())
            {
                if (!currentFunctions.Contains(function))
                {
                    removals++;
                    exportedFunctions.Remove(function);
                    changes.AppendLine("- " + function);
                }
            }

            if (changes.Length > 0)
            {
                await historyWriter.WriteLineAsync(unityVersion.ToFriendlyString());
                await historyWriter.WriteLineAsync(changes);
            }
        }

        Console.WriteLine($"Generated api history - {additions} additions, {removals} removals");
    }
}
