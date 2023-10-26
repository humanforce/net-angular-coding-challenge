namespace Planning;

public interface IJiraService
{
    Task<string?> GetSprints();
    Task<string?> GetBacklog();
}
