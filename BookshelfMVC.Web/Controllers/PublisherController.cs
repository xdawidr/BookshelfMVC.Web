using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Publisher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookshelfMVC.Web.Controllers
{

    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [Authorize(Policy = "CanViewPublisher")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _publisherService.GetAllPublishersForList(2, 1, "");
            return View(model);
        }

        [Authorize(Policy = "CanViewPublisher")]
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
            var model = _publisherService.GetAllPublishersForList(pageSize, pageNumber.Value, searchString);
            return View(model);
        }

        [Authorize(Policy = "CanViewPublisher")]
        public IActionResult ViewPublisher(int publisherId)
        {
            var publisherModel = _publisherService.GetPublisherDetails(publisherId);
            return View(publisherModel);
        }
        
        [Authorize(Policy = "CanViewPublisher")]
        [HttpGet]
        public IActionResult AddPublisher()
        {
            return View(new NewPublisherVm());
        }

        [Authorize(Policy = "CanViewPublisher")]
        [HttpPost]
        public IActionResult AddPublisher(NewPublisherVm model)
        {
            _publisherService.AddPublisher(model);
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "CanViewPublisher")]
        [HttpGet]
        public IActionResult EditPublisher(int id)
        {
            var publisher = _publisherService.GetPublisherForEdit(id);
            return View(publisher);
        }

        [Authorize(Policy = "CanViewPublisher")]
        [HttpPost]
        public IActionResult EditPublisher(NewPublisherVm model)
        {
            if (ModelState.IsValid)
            {
                _publisherService.UpdatePublisher(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Policy = "CanViewPublisher")]
        public IActionResult DeletePublisher(int id)
        {
            _publisherService.DeletePublisher(id);
            return RedirectToAction("Index");
        }
       
        
    }
}
