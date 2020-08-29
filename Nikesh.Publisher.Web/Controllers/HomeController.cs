using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nikesh.Publisher.Models;
using Nikesh.Publisher.Services;
using Nikesh.Publisher.ViewModels;

namespace Nikesh.Publisher.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPublisherService _publisherService;

        public HomeController(IPublisherService publisherService)
        {
            this._publisherService = publisherService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(InformationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                await _publisherService.Send(viewModel);
            }

            return RedirectToAction("Success", "Home");
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
