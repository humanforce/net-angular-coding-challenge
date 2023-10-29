using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace SprintPlanning.Common.Services;

public class JsonDataLoader : IJsonDataLoader
{
    public async Task<T> LoadAsync<T>(string filePath, CancellationToken cancellationToken)
    {
        string jsonContent = await File.ReadAllTextAsync(filePath, cancellationToken);

        var data = JsonConvert.DeserializeObject<T>(jsonContent, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });

        return data ?? throw new FileNotFoundException(filePath);
    }
}
