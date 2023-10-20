using ITManagement.Data;
using ITManagement.Models;
using ITManagement.Repository.IRepository;

namespace ITManagement.Repository
{
    public class DepartamentRepository : Repository<Departament>, IDepartamentRepository
    {
        private ApplicationITDbContect _db;
        public DepartamentRepository(ApplicationITDbContect db) : base(db)
        {
            _db = db;
        }

        void IDepartamentRepository.Update(Departament obj)
        {
            _db.Departaments.Update(obj);
        }
    }
}
