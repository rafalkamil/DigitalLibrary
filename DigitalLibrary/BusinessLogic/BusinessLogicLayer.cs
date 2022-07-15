using DigitalLibrary.Models;
using DigitalLibrary.Models.ViewModels;
using DigitalLibrary.Repository.IRepository;

namespace DigitalLibrary.BusinessLogic
{
    public class BusinessLogicLayer : IBusinessLogicLayer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BusinessLogicLayer(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        #region BOOK

        public void UpsertBook (BookVM Object, IFormFile fileImage, IFormFile fileEbook)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (fileImage != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var UploadImage = Path.Combine(wwwRootPath, @"images");
                var Extension = Path.GetExtension(fileImage.FileName);

                if (Object.Book.ImageURL != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, Object.Book.ImageURL.TrimStart('\\'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                using (var fileStreamImage = new FileStream(Path.Combine(UploadImage, FileName + Extension), FileMode.Create))
                {
                    fileImage.CopyTo(fileStreamImage);
                }
                Object.Book.ImageURL = @"\images\" + FileName + Extension;
            }

            if (fileEbook != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var UploadEbook = Path.Combine(wwwRootPath, @"e-books");
                var Extension = Path.GetExtension(fileEbook.FileName);

                if (Object.Book.BookURL != null)
                {
                    var oldBookPath = Path.Combine(wwwRootPath, Object.Book.BookURL.TrimStart('\\'));
                    if (File.Exists(oldBookPath))
                    {
                        File.Delete(oldBookPath);
                    }
                }

                using (var fileStreamEbook = new FileStream(Path.Combine(UploadEbook, FileName + Extension), FileMode.Create))
                {
                    fileEbook.CopyTo(fileStreamEbook);
                }
                Object.Book.BookURL = @"\e-books\" + FileName + Extension;
            }

            if (Object.Book.Id == 0)
            {
                _unitOfWork.Book.Add(Object.Book);
            }
            else
            {
                _unitOfWork.Book.Update(Object.Book);
            }

            _unitOfWork.Save();
        }

        public void DeleteBook (BookVM Object, IFormFile fileImage, IFormFile fileEbook)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            var oldImagePath = Path.Combine(wwwRootPath, Object.Book.ImageURL.TrimStart('\\'));
            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
            }

            var oldBookPath = Path.Combine(wwwRootPath, Object.Book.BookURL.TrimStart('\\'));
            if (File.Exists(oldBookPath))
            {
                File.Delete(oldBookPath);
            }

            _unitOfWork.Book.Remove(Object.Book);
            _unitOfWork.Save();
        }

        #endregion

        #region CATEGORY

        public void CreateCategory (Category Object)
        {
            _unitOfWork.Category.Add(Object);
            _unitOfWork.Save();
        }

        public void DeleteCategory(Category Object)
        {
            _unitOfWork.Category.Remove(Object);
            _unitOfWork.Save();
        }

        #endregion

        #region HOME
        #endregion

        #region WISHLIST

        public void UpsertWish (BookVM Object, IFormFile fileImage, IFormFile fileEbook)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (fileImage != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var UploadImage = Path.Combine(wwwRootPath, @"images");
                var Extension = Path.GetExtension(fileImage.FileName);

                if (Object.Book.ImageURL != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, Object.Book.ImageURL.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStreamImage = new FileStream(Path.Combine(UploadImage, FileName + Extension), FileMode.Create))
                {
                    fileImage.CopyTo(fileStreamImage);
                }
                Object.Book.ImageURL = @"\images\" + FileName + Extension;
            }

            if (fileEbook != null)
            {
                string FileName = Guid.NewGuid().ToString();
                var UploadEbook = Path.Combine(wwwRootPath, @"e-books");
                var Extension = Path.GetExtension(fileEbook.FileName);

                if (Object.Book.BookURL != null)
                {
                    var oldBookPath = Path.Combine(wwwRootPath, Object.Book.BookURL.TrimStart('\\'));
                    if (System.IO.File.Exists(oldBookPath))
                    {
                        System.IO.File.Delete(oldBookPath);
                    }
                }

                using (var fileStreamEbook = new FileStream(Path.Combine(UploadEbook, FileName + Extension), FileMode.Create))
                {
                    fileEbook.CopyTo(fileStreamEbook);
                }
                Object.Book.BookURL = @"\e-books\" + FileName + Extension;
            }

            if (Object.Book.Id == 0)
            {
                _unitOfWork.Book.Add(Object.Book);
            }
            else
            {
                _unitOfWork.Book.Update(Object.Book);
            }

            _unitOfWork.Save();
        }

        public void DeleteWish (BookVM Object, IFormFile fileImage, IFormFile fileEbook)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            var oldImagePath = Path.Combine(wwwRootPath, Object.Book.ImageURL.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            var oldBookPath = Path.Combine(wwwRootPath, Object.Book.BookURL.TrimStart('\\'));
            if (System.IO.File.Exists(oldBookPath))
            {
                System.IO.File.Delete(oldBookPath);
            }

            _unitOfWork.Book.Remove(Object.Book);
            _unitOfWork.Save();
        }

        #endregion
    }
}
