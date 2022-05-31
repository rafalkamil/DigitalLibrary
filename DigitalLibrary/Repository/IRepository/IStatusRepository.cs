using DigitalLibrary.Models;

namespace DigitalLibrary.Repository.IRepository
{
    public interface IStatusRepository : IRepository<Status>
    {
        void Update(Status Object);
    }
}
