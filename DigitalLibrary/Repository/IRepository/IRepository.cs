using System.Linq.Expressions;

namespace DigitalLibrary.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperites = null);
        IEnumerable<T> GetAll(string? includeProperites = null);

        void Add(T entity);
        void Remove(T entity);  
        void RemoveRange(IEnumerable<T> entities);  
    }
}
