using DigitalLibrary.Data;
using DigitalLibrary.Models;
using DigitalLibrary.Repository.IRepository;

namespace DigitalLibrary.Repository
{
    public class BookTypeRepository : Repository<BookType>, IBookTypeRepository
    {
        private ApplicationDbContext _db;
        public BookTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BookType Object)
        {
            _db.BookTypes.Update(Object);
        }
    }
}
