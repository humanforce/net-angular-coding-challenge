using TeamPlanning.Application.Contracts.Models;

namespace TeamPlanning.Application.Contracts.Interfaces
{
    public interface ISprintService
    {
        Task<List<Sprint>> GetAll();
    }
}
