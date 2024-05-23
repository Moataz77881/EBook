using BookShoppingUI.Data.DTOs.BookDTOs;
using BookShoppingUI.DTOs;
using BookShoppingUI.services.BookServices;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppingUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost("/createbook")]
        public IActionResult CreateBook(BookDto bookDto)
        {
            var bookCreated = bookService.CreateBook(bookDto);
            //return Ok(bookCreated);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetBooks(int? FilterByGenreId, string? FilterByBookName)
        {
            return View(bookService.GetBook(FilterByGenreId, FilterByBookName));
        }

        //[HttpGet("/book")]
        //public IActionResult GetBooks([FromQuery] int? FilterByGenreId,[FromQuery]string? FilterByBookName) 
        //{
        //    var res = bookService.GetBook(FilterByGenreId,FilterByBookName);

        //    return RedirectToAction("Index", "Home");
        //}

        [HttpPost("/updatebook")]
        public IActionResult UpdateBook(EditBookDto editBookDto)
        {
			var res = bookService.UpdateBook(editBookDto.id, editBookDto.bookDto);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("/deletebook")]
        public IActionResult Removebook(int id) 
        {
            bookService.RemoveBook(id);
            return RedirectToAction("Index", "Home");

        }
    }
}
