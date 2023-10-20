using ITManagement.Data;
using ITManagement.Repository.IRepository;

namespace ITManagement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationITDbContect _db;

        public IDepartamentRepository Departament {  get; private set; }
        public IEmployeeRepository Employee { get; private set; }

        public ITeamRepository Team { get; private set; }

        public IProjectsRepository Projects { get; private set; }

        public UnitOfWork(ApplicationITDbContect db)
        {
            _db = db;
            Departament = new DepartamentRepository(_db);
            Employee = new EmployeeRepository(_db);
            Team = new TeamRepository(_db);
            Projects = new ProjectsRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
