using TeamPlanning.Application.Contracts.Models;

namespace TeamPlanning.Application.Contracts.Interfaces
{
    public interface IBacklogService
    {
        Task<List<Backlog>> GetBySprintId(int sprintId);
    }
}
