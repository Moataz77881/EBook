using BookShoppingUI.Models;
using BookShoppingUI.services.BookServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookShoppingUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IBookService bookService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService)
		{
			_logger = logger;
            this.bookService = bookService;
        }

		public IActionResult Index(int? id , string? sTem)
		{
			var books = bookService.GetBook(id,sTem);
			
			return View(books);
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
	}
}
