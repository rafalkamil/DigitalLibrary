using DigitalLibrary.Data;
using DigitalLibrary.Repository.IRepository;

namespace DigitalLibrary.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Book = new BookRepository(_db);
            BookType = new BookTypeRepository(_db);
            Category = new CategoryRepository(_db); 
            Status = new StatusRepository(_db);

        }
        public IBookRepository Book {get; private set;}

        public IBookTypeRepository BookType{ get; private set; }

        public ICategoryRepository Category { get; private set; }
        public IStatusRepository Status { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
