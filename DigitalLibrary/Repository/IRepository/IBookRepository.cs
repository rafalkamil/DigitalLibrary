using DigitalLibrary.Models;

namespace DigitalLibrary.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book Object);
    }
}
