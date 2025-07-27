using System.Collections.Concurrent;

namespace AdPlatform;

public class AdPlatformRepository
{
    private readonly ConcurrentDictionary<string, string> _platformsByLocation = [];
    public const string FileName = "adPlatfoms.txt";

    public List<string> SearchPlatform(string searchLocation)
    {
        var result = new List<string>();

        if (searchLocation.LastIndexOf("/") == 0 &&
            _platformsByLocation.TryGetValue(searchLocation, out string findLocation))
        {
            return [findLocation];
        }

        foreach (var item in _platformsByLocation)
        {
            var platform = item.Value;

            var location = item.Key;

            if (searchLocation.StartsWith(location))
                result.Add(platform);
        }

        return result;
    }

    public async Task<string> Load(IFormFile formFile)
    {
        using(var stream = formFile.OpenReadStream())
        {
            using var destination = File.Create(FileName);

            await stream.CopyToAsync(destination);
        }

        await LoadFromFileAsync();

        return "Все успешно загрузилось";
    }

    public async Task<string> LoadFromFileAsync()
    {
        _platformsByLocation.Clear();

        var lines = await File.ReadAllLinesAsync(FileName);

        return LoadFromLines(lines);
    }

    public string LoadFromLines(string[] lines)
    {
        foreach (var line in lines)
        {
            var platformAndLocation = line.Split(':');

            if (platformAndLocation.Length < 2)
                return "Неправильный файл";

            var platform = platformAndLocation[0];

            var locations = platformAndLocation[1].Split(',');

            foreach (var location in locations)
                _platformsByLocation.TryAdd(location.Trim(), platform);
        }

        return "Все успешно загрузилось";
    }
}
