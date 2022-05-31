using DigitalLibrary.Data;
using DigitalLibrary.Models;
using DigitalLibrary.Repository.IRepository;

namespace DigitalLibrary.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        private ApplicationDbContext _db;
        public StatusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Status Object)
        {
            _db.Statuses.Update(Object);
        }
    }
}
