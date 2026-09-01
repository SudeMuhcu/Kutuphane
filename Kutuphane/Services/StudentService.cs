using Kutuphane.DataAccess.Repositories;
using Kutuphane.Models;

namespace Kutuphane.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericDal<Student> _studentRepository;


        public StudentService(IGenericDal<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }







        public List<Student> GetStudents()
        {
            return _studentRepository.GetList();
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public Student AddStudent(Student student)
        {
            var existingStudent = _studentRepository
            .GetList()
            .FirstOrDefault(x => x.SchoolNumber == student.SchoolNumber);

            if (existingStudent != null)
            {
                throw new Exception("Bu okul numarası zaten kayıtlı.");
            }

            _studentRepository.Add(student);

            return student;


        }

        public void DeleteStudent(Student student)
        {
            _studentRepository.Delete(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public Student? GetByAppUserId(int appUserId)
        {
            return _studentRepository.GetList().FirstOrDefault(x => x.AppUserId == appUserId);
        }
    }
}