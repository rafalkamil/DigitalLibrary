using DigitalLibrary.Data;
using DigitalLibrary.Models;
using DigitalLibrary.Repository.IRepository;

namespace DigitalLibrary.Repository
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        private ApplicationDbContext _db;
        public GradeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Grade Object)
        {
            _db.Grades.Update(Object);
        }
    }
}
