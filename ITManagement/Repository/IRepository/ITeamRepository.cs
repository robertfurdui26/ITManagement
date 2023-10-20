using ITManagement.Models;

namespace ITManagement.Repository.IRepository
{
    public interface ITeamRepository : IRepository<Team>
    {
        void Update(Team obj);
    }
}
