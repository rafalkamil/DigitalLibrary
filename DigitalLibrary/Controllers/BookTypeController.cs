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

    }
}
