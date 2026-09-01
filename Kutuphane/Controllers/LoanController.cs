using Kutuphane.Models;

using Kutuphane.Routes;
using Kutuphane.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Kutuphane.Controllers
{
    [Authorize(Roles = "Admin")]

    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IBookService _bookService;
        private readonly IStudentService _studentService;

        public LoanController(ILoanService loanService,
            IBookService bookService,
            IStudentService studentService)
        {
            _loanService = loanService;
            _bookService = bookService;
            _studentService = studentService;
        }


        public IActionResult Index(string search, List<bool> returned)
        {
            List<Loan> loans;
            if (string.IsNullOrEmpty(search))
            {
                loans = _loanService.GetAllLoans();
            }
            else 
            { 
               loans= _loanService.SearchLoans(search); 
                if(loans.Count==0)
                {
                    ViewBag.SearchMessage = "Aradığınız öğrenci bulunamadı :(";
                }
                if (returned.Count == 1)
                {
                    loans = loans
                        .Where(x => x.IsReturned == returned[0])
                        .ToList();
                }
            }


            ViewBag.Students = _studentService.GetStudents();
            ViewBag.Books = _bookService.GetBooks();

            return View(loans);
        }

        [HttpPost(BorrowBokRoutes.BorrowBokRoutesIndex)]
        public IActionResult BorrowBokk(int studentId, int bookId)
        {
            var message = _loanService.BorrowBook(studentId, bookId);

            TempData["BorrowMessage"] = message;

            return RedirectToAction("Index");
        }




        [HttpPost(ReturnBookRoutes.ReturnBook)]
        public IActionResult ReturnBook(int loanId)
        {
            _loanService.ReturnBook(loanId);
            return RedirectToAction("Index");
        }

        public IActionResult BookLoans(int bookId)
        {
            var loans = _loanService.GetBookLoans(bookId);
            return View(loans);
        }


        public IActionResult StudentLoans(int studentId)
        {
              var loans = _loanService.GetStudentLoans(studentId);
              return View(loans);
        }


    }
}
