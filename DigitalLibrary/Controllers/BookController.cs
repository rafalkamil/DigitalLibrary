using DigitalLibrary.Models;
using DigitalLibrary.Models.ViewModels;
using DigitalLibrary.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DigitalLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment; 
        }
        public IActionResult Index()
        {
            IEnumerable<Book> ObjectBookList = _unitOfWork.Book.GetAll(includeProperites: "Category,BookType,Status");
            return View(ObjectBookList);
        }

        public IActionResult UpsertPage(int? Id)
        {
            BookVM bookVM = new()
            {
                Book = new(),
                BookType = _unitOfWork.BookType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.BookTypeName,
                    Value = i.Id.ToString()
                }),
                Category = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.Id.ToString()
                }),
                Status = _unitOfWork.Status.GetAll().Select(i => new SelectListItem
                {
                    Text = i.StatusName,
                    Value = i.Id.ToString()
                }),
            };
            if (Id == null || Id == 0)
            {
                return View(bookVM);
            }
            else
            {
                bookVM.Book = _unitOfWork.Book.GetFirstOrDefault(u => u.Id == Id);
                return View(bookVM);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM Object, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if(file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    var UploadImage = Path.Combine(wwwRootPath, @"images");
                    var UploadEbook = Path.Combine(wwwRootPath, @"e-books");
                    var Extension = Path.GetExtension(file.FileName);

                    if(Object.Book.ImageURL != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, Object.Book.ImageURL.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    if (Object.Book.BookURL != null)
                    {
                        var oldBookPath = Path.Combine(wwwRootPath, Object.Book.BookURL.TrimStart('\\'));
                        if (System.IO.File.Exists(oldBookPath))
                        {
                            System.IO.File.Delete(oldBookPath);
                        }
                    }

                    using (var fileStreamImage = new FileStream(Path.Combine(UploadImage, FileName + Extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreamImage);
                    }
                    Object.Book.ImageURL = @"\images\" + FileName + Extension;

                    using (var fileStreamEbook = new FileStream(Path.Combine(UploadEbook, FileName + Extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreamEbook);
                    }
                    Object.Book.BookURL = @"\e-books\" + FileName + Extension;
                }

                if(Object.Book.Id == 0)
                {
                    _unitOfWork.Book.Add(Object.Book);
                }
                else
                {
                    _unitOfWork.Book.Update(Object.Book);
                }

                _unitOfWork.Save();
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeletePage(int? Id)
        {
            BookVM bookVM = new();

            if(Id == null || Id == 0)
            {
                return View(bookVM);
            }
            else
            {
                bookVM.Book = _unitOfWork.Book.GetFirstOrDefault(u => u.Id == Id);
                return View(bookVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Delete(BookVM Object, IFormFile file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            var oldImagePath = Path.Combine(wwwRootPath, Object.Book.ImageURL.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Book.Remove(Object.Book);
            _unitOfWork.Save();
            return RedirectToAction("Index");

        }
    }
}
