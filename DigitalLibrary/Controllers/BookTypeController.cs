using DigitalLibrary.Models;
using DigitalLibrary.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.Controllers
{
    public class BookTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public BookTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<BookType> ObjectBookTypeList = _unitOfWork.BookType.GetAll();
            return View(ObjectBookTypeList);
        }

        public IActionResult CreatePage() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookType Object)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookType.Add(Object);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(Object);
        }

        public IActionResult DeletePage(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }

            var bookTypeFromDb = _unitOfWork.BookType.GetFirstOrDefault(u => u.Id == Id);

            if (bookTypeFromDb == null) { return NotFound(); }

            return View(bookTypeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(BookType Object)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookType.Remove(Object);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(Object);
        }

    }
}
