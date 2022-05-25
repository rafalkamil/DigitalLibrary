using DigitalLibrary.Models;

namespace DigitalLibrary.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category Object);
    }
}
