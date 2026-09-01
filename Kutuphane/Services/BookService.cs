using Kutuphane.DataAccess.Repositories;
using Kutuphane.Models;

namespace Kutuphane.Services
{
    public class BookService : IBookService
    {


        private readonly IGenericDal<Book> _bookRepository;
        
        public BookService(IGenericDal<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
       
            
            
        public List<Book> GetBooks()
        {
            return _bookRepository.GetList();
        }
        
        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
        }

        public void DeleteBook(Book book)
        {
            _bookRepository.Delete(book);
        }


        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }


    }
}
