using JustBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using JustBlog.ViewModels.Others;
using Microsoft.AspNetCore.Authorization;

namespace JustBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}