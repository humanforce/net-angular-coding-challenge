namespace SprintPlanning.Common.Services;

public interface IJsonDataLoader
{
    Task<T> LoadAsync<T>(string filePath, CancellationToken cancellationToken);
}
