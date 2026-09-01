using Kutuphane.Models;
namespace Kutuphane.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetById(int id);
        Student AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
        Student? GetByAppUserId(int appUserId);
    }
}
