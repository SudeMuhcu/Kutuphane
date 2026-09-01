namespace Kutuphane.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string SchoolNumber { get; set; }
        public bool Isactive { get; set; } = true;
        public int? AppUserId { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public AppUser? AppUser { get; set; }
        // bir öğrencinin birden fazla ödünç alma kaydı olabilir.


       
    }
}
