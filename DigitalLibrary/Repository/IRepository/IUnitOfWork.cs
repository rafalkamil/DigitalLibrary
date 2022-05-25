namespace DigitalLibrary.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBookRepository Book { get; }
        IBookTypeRepository BookType { get; }
        ICategoryRepository Category { get; }
        IGradeRepository Grade { get; }

        void Save();
    }
}
