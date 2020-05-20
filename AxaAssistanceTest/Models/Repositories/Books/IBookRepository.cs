using AxaAssistanceTest.Models.Entities.Books;
using System.Collections.Generic;

namespace AxaAssistanceTest.Models.Repositories.Books
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBook(long id);
        void SaveBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(long id);
    }
}