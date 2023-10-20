using ITManagement.Data;
using ITManagement.Models;
using ITManagement.Repository.IRepository;

namespace ITManagement.Repository
{
    public class ProjectsRepository : Repository<Project>, IProjectsRepository
    {
        private ApplicationITDbContect _db;
        public ProjectsRepository(ApplicationITDbContect db) : base(db)
        {
            _db = db;
        }

        void IProjectsRepository.Update(Project obj)
        {
            _db.Projects.Update(obj);
        }
    }
}
