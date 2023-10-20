
using ITManagement.Data;
using ITManagement.Models;
using ITManagement.Repository.IRepository;

namespace ITManagement.Repository
{ 
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private ApplicationITDbContect _db;
        public TeamRepository(ApplicationITDbContect db) : base(db)
        {
            _db = db;
        }

        void ITeamRepository.Update(Team obj)
        {
            _db.Teams.Update(obj);
        }
    }
}
