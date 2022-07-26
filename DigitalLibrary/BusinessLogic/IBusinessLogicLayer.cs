using DigitalLibrary.Models;
using DigitalLibrary.Models.ViewModels;

namespace DigitalLibrary.BusinessLogic
{
    public interface IBusinessLogicLayer
    {
        #region BOOK
        public void UpsertBook(BookVM Object, IFormFile fileImage, IFormFile fileEbook);
        public void DeleteBook (BookVM Object, IFormFile fileImage, IFormFile fileEbook);
        #endregion

        #region CATEGORY
        public void CreateCategory(Category Object);
        public void DeleteCategory(Category Object);
        #endregion

        #region HOME (Book's to read)

        #endregion

    }
}
