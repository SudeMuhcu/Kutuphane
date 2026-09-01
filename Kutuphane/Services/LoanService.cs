using Kutuphane.DataAccess.Repositories;
using Kutuphane.Models;

namespace Kutuphane.Services
{
    public class LoanService : ILoanService
    {
        
        private readonly IGenericDal<Student> _studentRepository;
        //öğrenciyi bul
        private readonly IGenericDal<Book> _bookRepository;
        //kitabı bul
        private readonly IGenericDal<Loan> _loanRepository;
        //loan oluştur

        //Consructor:
        public LoanService(IGenericDal<Student> studentRepository,
            IGenericDal<Book> bookRepository,
            IGenericDal<Loan> loanRepository)
        {
            _studentRepository = studentRepository;
            _bookRepository = bookRepository;
            _loanRepository = loanRepository;
        }










        public string BorrowBook(int studentId, int bookId)
        {
         

            var student = _studentRepository.GetById(studentId);
      
            if (student == null)
            {
               
                return "ÖĞRENCİ BULUNAMADI";
            }
            
            if(!student.Isactive)
            {
                return "Bu öğrenci kütüphaneden çıkarılmış";   
            }


            var activeLoan = _loanRepository.GetList()
            .FirstOrDefault(x => x.StudentId == studentId && !x.IsReturned);


            if (activeLoan != null)
            {
                var days = (DateTime.Now - activeLoan.BorrowDate).TotalDays;
                if(days>90)
                {
                    student.Isactive = false;
                    _studentRepository.Update(student);
                    return "Öğrencinin kitabı 90 günü geçti. öğrenci kütüphaneden çıkarıldı.";
                }


                if(days>15)
                {
                    return "Örencinin kitabı 15 günü geçti. Yeni Kitap alamaz.";
                }
               
                return "Öğrencinin İade etmediği Kitap var.";
            }


            var book = _bookRepository.GetById(bookId);

            if (book == null)
            {

                return "KİTAP BULUNAMADI";
            }

           

            if (book.BookStock <= 0)
            {
                return "STOK YOK";
            }

            book.BookStock--;

            

            var loan = new Loan
            {
                StudentId = studentId,
                BookId = bookId,
                BorrowDate = DateTime.Now,
                IsReturned = false
            };

            _loanRepository.Add(loan);
            _bookRepository.Update(book);

            return "Kitap başarıyla ödünç verildi.";
        }





        public void ReturnBook(int loanId)
        {
            var returnbook = _loanRepository.GetById(loanId);



             if(returnbook==null)
             { return; }



            if(returnbook.IsReturned)
            { return; }

              var book= _bookRepository.GetById(returnbook.BookId);

            if(book==null)
            { return; }

            returnbook.IsReturned=true;
            returnbook.ReturnDate= DateTime.Now;

            book.BookStock++;

            _loanRepository.Update(returnbook);
            _bookRepository.Update(book);





           

        }

        public List<Loan> GetStudentLoans(int studentId)
        {
            var loans = _loanRepository.GetList(x=>x.Book,x=>x.Student);

            return loans.Where(x=>x.StudentId==studentId).ToList();
            //LINUQ
        }

        public List<Loan> GetBookLoans(int bookId)
        {
            var loans = _loanRepository.GetList(x => x.Book, x => x.Student);
            return loans.Where(x=>x.BookId==bookId).ToList();
        }



        public List<Loan> GetAllLoans()
        {
            return _loanRepository.GetList(x => x.Book, x => x.Student);
        }



        public List<Loan> SearchLoans(string search)
        {
            var loans=_loanRepository.GetList(x => x.Book, x => x.Student);
            return loans.Where(x =>
             x.Student.StudentName.Contains(search) ||
             x.Student.StudentSurname.Contains(search) ||
             x.Student.SchoolNumber.Contains(search)
             ).ToList(); 
        }

    }
}
