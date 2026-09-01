using Kutuphane.Models;
using Kutuphane.Routes;
using Kutuphane.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminStudentController : Controller
    {



        private readonly IStudentService _studentService;
        private readonly IUserService _userService;

        public AdminStudentController(IStudentService studentService, IUserService userService)
        {
            _studentService = studentService;
            _userService = userService;
        }



        public IActionResult Index()
        {
            var student=_studentService.GetStudents();
            return View(student);
        }
        [HttpGet]
        public IActionResult AddStudents()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudents(Student student, string UserName, string Password)
        {
            try
            {
                var newStudent = _studentService.AddStudent(student);

                var user = new AppUser
                {
                    UserName = UserName,
                    Student = newStudent,
                    Role = UserRole.User,
                    PasswordHash = Password,
                    MustChangePassword = true
                };


                _userService.AddUser(user);

                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                TempData["ErrorMessage"]= ex.Message;
                return View(student);
            }
        }


    }
}
