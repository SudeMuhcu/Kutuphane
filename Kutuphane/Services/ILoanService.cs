using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Services
{
    public interface ILoanService
    {
        string BorrowBook(int studentId, int bookId);
        // öğrenci kitap almak isteyince çalışacak kod
        void ReturnBook(int loanId);
        //daha önce alınmıi olan kitabi vermek
        //isteyine çalışacak olan kod
        List<Loan> GetBookLoans(int bookId);

        List<Loan> GetStudentLoans(int studentId);
        List<Loan> GetAllLoans();
        List<Loan> SearchLoans(string search);

    }
}
