using DigitalLibrary.Models;

namespace DigitalLibrary.Repository.IRepository
{
    public interface IBookTypeRepository : IRepository<BookType>
    {
        void Update(BookType Object);
    }
}
