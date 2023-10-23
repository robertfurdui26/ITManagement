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
            var objFromDb = _db.Projects.FirstOrDefault(u =>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.FinishProject = obj.FinishProject;
                objFromDb.EmployeeId = obj.EmployeeId;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
