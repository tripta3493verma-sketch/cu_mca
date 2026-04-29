using AssignmentProject.Models;
using AssignmentProject.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        private readonly ICreateRepository _createRepository = null;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICreateRepository createRepository, IWebHostEnvironment webHostEnvironment, ILogger<HomeController> logger)
        {
            _createRepository = createRepository;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        
        

        public async Task<IActionResult> Index()
        {
            var data = await _createRepository.GetAllEvents();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("/customer-support")]
        public ActionResult CustomerSupport()
        {
            return Redirect("https://helpdesk.nagarro.com");
        }
    }
}
