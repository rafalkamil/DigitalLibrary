using DigitalLibrary.Data;
using DigitalLibrary.Models;
using DigitalLibrary.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> ObjectCategoryList = _unitOfWork.Category.GetAll();
            return View(ObjectCategoryList);
        }

        public IActionResult CreatePage() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category Object)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(Object);
                _unitOfWork.Save();
                return RedirectToAction("Index");   
            }
            return View(Object);    
        }

        public IActionResult DeletePage(int? Id) 
        { 
            if (Id == null || Id == 0) { return NotFound(); }

            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Id);

            if (categoryFromDb == null) { return NotFound(); }

            return View(categoryFromDb);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category Object)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Remove(Object);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(Object);
        }
    }
}
