using BookShoppingUI.Data;
using BookShoppingUI.Data.DTOs.BookDTOs;
using BookShoppingUI.DTOs;
using BookShoppingUI.Models;
using BookShoppingUI.Repository.BookRepo;
using BookShoppingUI.services.BookServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BookShoppingUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IBookService bookService;
		private readonly IBookRepo repo;

		public HomeController(ILogger<HomeController> logger, IBookService bookService, IBookRepo repo)
		{
			_logger = logger;
            this.bookService = bookService;
			this.repo = repo;
		}
		public  IActionResult Index(int? id, string? sTem)
		{
			var books = bookService.GetBook(id, sTem);


			return View(books);
		}

		public IActionResult CreateBook()
		{
			return View();
		}
		public IActionResult UpdateBook(int id)
		{
			var bookEdit = new EditBookDto
			{
				id = id,
			};

			return View(bookEdit);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
