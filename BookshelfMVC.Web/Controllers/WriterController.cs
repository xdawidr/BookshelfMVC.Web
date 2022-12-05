using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.Services;
using BookshelfMVC.Application.ViewModels.Writer;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookshelfMVC.Web.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _writerService.GetAllWritersForList(2, 1, "");
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
           
            var model = _writerService.GetAllWritersForList(pageSize, pageNumber.Value, searchString);
            return View(model);
        }

        public IActionResult ViewWriter(int id)
        {
            var model = _writerService.GetWriter(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddWriter()
        {
            return View(new NewWriterVm());
        }

        [HttpPost]
        public IActionResult AddWriter(NewWriterVm model)
        {
            _writerService.AddWriter(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditWriter(int id) 
        {
            var writer = _writerService.GetWriterToEdit(id);
            return View(writer);
        }

        [HttpPost]
        public IActionResult EditWriter(NewWriterVm model)
        {
            if (ModelState.IsValid)
            {
                _writerService.UpdateWriter(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult DeleteWriter(int id)
        {
            _writerService.DeleteWriter(id);
            return RedirectToAction("Index");
        }

    }
}
