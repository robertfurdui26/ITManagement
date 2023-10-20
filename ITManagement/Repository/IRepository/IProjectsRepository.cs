
using ITManagement.Models;

namespace ITManagement.Repository.IRepository
{
    public interface IProjectsRepository : IRepository<Project>
    {
        void Update(Project  obj);
    }
}
