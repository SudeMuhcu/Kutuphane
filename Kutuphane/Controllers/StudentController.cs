using Kutuphane.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kutuphane.Controllers
{
    [Authorize(Roles = "User")]
    public class StudentController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IBookService _bookService;
        private readonly IStudentService _studentService;
        public StudentController(ILoanService loanService, IBookService bookService, IStudentService studentService)
        {
            _loanService = loanService;
            _bookService = bookService;
            _studentService = studentService;
        }

        private int? GetCurrentStudentId()
        {
            var appUserIdClaim = User.FindFirstValue("AppUserId");
            if (appUserIdClaim == null) return null;
            var student = _studentService.GetByAppUserId(int.Parse(appUserIdClaim));
            return student?.StudentId;

        }



        public IActionResult Index()
        {
            var studentId = GetCurrentStudentId();
            if (studentId == null) return Forbid();

            var student = _studentService.GetById(studentId.Value);
            var loans = _loanService.GetStudentLoans(studentId.Value);

            ViewBag.ActiveLoanCount = loans.Count(l => !l.IsReturned);
            return View(student);


        }

        public IActionResult Books()
        {
            var books = _bookService.GetBooks();

            return View(books);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Borrow(int bookId)
        {
            var studentId = GetCurrentStudentId();
            if(studentId == null) return Forbid();

            var message = _loanService.BorrowBook(studentId.Value, bookId);
            TempData["BorrowMessage"] = message;

            return RedirectToAction(nameof(Books));
        }


        public IActionResult MyLoans()
        {
            var studentId = GetCurrentStudentId();
            if (studentId == null) return Forbid();

            var loans = _loanService.GetStudentLoans(studentId.Value);
            return View(loans);
        }

    }
}