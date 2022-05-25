using DigitalLibrary.Data;
using DigitalLibrary.Models;
using DigitalLibrary.Repository.IRepository;

namespace DigitalLibrary.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }

        public void Update(Category Object)
        {
            _db.Categories.Update(Object);
        }
    }
}
