﻿using DigitalLibrary.BusinessLogic;
using DigitalLibrary.Models;
using DigitalLibrary.Models.ViewModels;
using DigitalLibrary.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DigitalLibrary.Controllers
{
    public class WishListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBusinessLogicLayer _businessLogicLayer;

        public WishListController (IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, IBusinessLogicLayer businessLogicLayer)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _businessLogicLayer = businessLogicLayer;   
        }

        public IActionResult Index()
        {
            IEnumerable<Book> ObjectBookList = _unitOfWork.Book.GetAll(includeProperites: "Category,BookType,Status");
            return View(ObjectBookList);
        }

        public IActionResult GotItPage(int? Id)
        {
            BookVM bookVM = new()
            {
                Book = new(),
                BookType = _unitOfWork.BookType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.BookTypeName,
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

        public IActionResult UpsertPage(int? Id)
        {
            BookVM bookVM = new()
            {   
                Book = new() { BookTypeId = 6 },
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
        public IActionResult Upsert(BookVM Object, IFormFile fileImage, IFormFile fileEbook)
        {
            if (ModelState.IsValid)
            {
                _businessLogicLayer.UpsertWish(Object, fileImage, fileEbook);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(BookVM Object, IFormFile fileImage, IFormFile fileEbook)
        {
            if (ModelState.IsValid)
            {
                _businessLogicLayer.DeleteWish(Object, fileImage, fileEbook);
            }
            return RedirectToAction("Index");

        }


    }
}