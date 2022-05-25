using DigitalLibrary.Models;
using DigitalLibrary.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.Controllers
{
    public class GradeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GradeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public IActionResult Index()
        {
            IEnumerable<Grade> ObjectGradeList = _unitOfWork.Grade.GetAll();
            return View(ObjectGradeList);
        }

        public IActionResult CreatePage() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Grade Object)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Grade.Add(Object);
                _unitOfWork.Save();
                return RedirectToAction("Index");   
            }

            return View(Object);
        }

        public IActionResult DeletePage(int? ID) 
        { 
            if(ID == null || ID == 0) { return NotFound(); }

            var gradeFromDb = _unitOfWork.Grade.GetFirstOrDefault(u => u.ID == ID);

            if (gradeFromDb == null) { return NotFound(); }

            return View(gradeFromDb); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Grade Object)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Grade.Remove(Object);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(Object);
        }

    }
}
