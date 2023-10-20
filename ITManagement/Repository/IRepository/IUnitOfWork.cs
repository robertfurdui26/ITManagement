
namespace ITManagement.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDepartamentRepository Departament {  get; }
        IEmployeeRepository Employee { get; }
        ITeamRepository Team { get; }
        IProjectsRepository Projects { get; }
         void Save();
    }
}
