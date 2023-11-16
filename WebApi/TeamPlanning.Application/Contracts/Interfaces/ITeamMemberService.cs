using TeamPlanning.Application.Contracts.Models;

namespace TeamPlanning.Application.Contracts.Interfaces
{
    public interface ITeamMemberService
    {
        Task<List<TeamMember>> GetAll();
    }
}
