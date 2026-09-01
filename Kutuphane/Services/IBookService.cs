using Kutuphane.Models;

namespace Kutuphane.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetById(int id);
        void AddBook(Book book);
        void DeleteBook(Book book);
        void UpdateBook(Book book);
    }
}
