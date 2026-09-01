using Kutuphane.Models;
using Kutuphane.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    [Authorize(Roles = "Admin")]

    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        //serviceyi tanımlıyoruzz


        public BookController(IBookService bookService)
        {
            _bookService = bookService;
            //controller oluştururken bana bir service
            //ver ve bu service book olucak
        }

        public IActionResult Index()
        {
            var books= _bookService.GetBooks();
            return View(books);
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookService.AddBook(book);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditBook(int id)
        {
            var book = _bookService.GetById(id);
            if(book==null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult EditBook(Book book)
        {
            _bookService.UpdateBook(book);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.DeleteBook(book);

            return RedirectToAction("Index");
        }

    }
}
