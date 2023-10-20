
using ITManagement.Models;

namespace ITManagement.Repository.IRepository
{
    public interface IDepartamentRepository : IRepository<Departament>
    {
        void Update(Departament obj);
    }
}
