using AssignmentProject.Models;
using AssignmentProject.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentProject.Controllers
{
    public class EventController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        private readonly ICreateRepository _createRepository = null;
        private readonly SignInManager<ApplicationUser> _signInManager = null;

        public EventController(ICreateRepository createRepository, IWebHostEnvironment webHostEnvironment, SignInManager<ApplicationUser> signInManager)
        {
            _createRepository = createRepository;
            _webHostEnvironment = webHostEnvironment;
            _signInManager = signInManager;
        }
        [Route("AddEvent")]
        public async Task<ViewResult> AddNewEvent(bool isSuccess = false, int bookId = 0)
        {
             var model = new CreateEventModel();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }
        [Route("AddEvent")]
        [HttpPost]
        public async Task<IActionResult> AddNewEvent(CreateEventModel createEventModel)
        {
            string email=null;
            if (_signInManager.IsSignedIn(User))
            {
                email = User.Identity.Name.ToString();
            }
            int id = await _createRepository.AddNewEvent(createEventModel, email);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewEvent), new { isSuccess = true, bookId = id });
            }
            return View();
        }

        //[Route("event-details/{id:int:min(1)}", Name = "eventDetailsRoute")]
        public async Task<ViewResult> GetEvent(int id)
        {
            var data = await _createRepository.GetEventById(id);

            return View(data);
        }
        public async Task<ViewResult> GetMyEvents()
        {
            string MyEmail = User.Identity.Name.ToString();
            var data = await _createRepository.GetMyEvents(MyEmail);
            return View(data);
        }

        public async Task<ViewResult> GetIvites()
        {
            string loggedInEmail = User.Identity.Name.ToString();
            ViewBag.loggedInEmail = loggedInEmail;
            var data = await _createRepository.GetIvites(loggedInEmail);
            return View(data);
        }
        public async Task<ViewResult> EditEvent(int id, bool isSuccess = false)
        {
            //ViewBag.Email = GetLoggedInEmail();
            var data = await _createRepository.GetEventById(id);
            ViewBag.IsSuccess = isSuccess;
            return View(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditEvent(CreateEventModel createEventModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _createRepository.EditEvent(createEventModel);

                return RedirectToAction(nameof(EditEvent), new { isSuccess = true });
            }
            //_bookRepository.AddNewEvent(bookModel);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetEvent(CreateEventModel bookModel)
        {
            string comment = bookModel.Comments;
            int id = await _createRepository.AddComment(comment, bookModel.Id);
            if (id > 0)
            {
                var data = await _createRepository.GetEventById(id);
                return View(data);
            }
            var data1 = await _createRepository.GetEventById(id);
            return View(data1);
        }

        public async Task<ViewResult> GetAllBookEvents()
        {
            var data = await _createRepository.GetAllEvents();
            return View(data);
        }

    }
}
