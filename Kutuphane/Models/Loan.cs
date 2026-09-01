namespace Kutuphane.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int StudentId { get; set; }
        //Loan.StudentId → Student.StudentId

        public int BookId { get; set; }
        //Loan.BookId    → Book.BookId
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; }
        public Student Student { get; set; }
        public Book Book { get; set; }
        //nagivation property
     

    }
}
