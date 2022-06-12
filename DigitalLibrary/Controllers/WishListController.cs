using DigitalLibrary.Models;
using DigitalLibrary.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.Controllers
{
    public class WishListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WishListController (IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> ObjectBookList = _unitOfWork.Book.GetAll(includeProperites: "Category,BookType,Status");
            return View(ObjectBookList);
        }
    }
}
