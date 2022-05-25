using DigitalLibrary.Models;

namespace DigitalLibrary.Repository.IRepository
{
    public interface IGradeRepository : IRepository<Grade>
    {
        void Update(Grade Object);
    }
}
