using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.Services;
using BookshelfMVC.Application.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookshelfMVC.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var model = _bookService.GetAllBooksForList(2, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNumber, string searchString)
        {
            if (!pageNumber.HasValue)
            {
                pageNumber = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _bookService.GetAllBooksForList(pageSize, pageNumber.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View(new NewBookVm());
        }

        [HttpPost]
        public IActionResult AddBook(NewBookVm model)
        {
            _bookService.AddBook(model);
            return RedirectToAction("Index");
        }
        
        public IActionResult ViewBook(int bookId)
        {
            var bookModel = _bookService.GetBookDetails(bookId);

            return View(bookModel);
        }

        [HttpGet]
        public IActionResult EditBook(int id)
        {
            var book = _bookService.GetBookForEdit(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult EditPublisher(NewBookVm model)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(model);
                return RedirectToAction("Index");
            }

            return View(model);

        }
    }
}
