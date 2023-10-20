
using ITManagement.Models;
using ITManagement.Repository.IRepository;

namespace ITManagement.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void Update(Employee obj);
    }
}
