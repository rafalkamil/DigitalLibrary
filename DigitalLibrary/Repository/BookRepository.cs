using DigitalLibrary.Data;
using DigitalLibrary.Models;
using DigitalLibrary.Repository.IRepository;

namespace DigitalLibrary.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Book Object)
        {
            _db.Books.Update(Object);
        }
    }
}
