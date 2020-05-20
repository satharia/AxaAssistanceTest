using AxaAssistanceTest.Models.Entities.Books;
using AxaAssistanceTest.Models.Repositories.Books;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AxaAssistanceTest.Models.DomainLogic.Service
{
    public class BookService
    {
        private IBookRepository BookRepository;

        public BookService(IBookRepository BookRepository)
        {
            this.BookRepository = BookRepository;
        }

        public List<Book> ListBooks()
        {
            List<Book> books = this.BookRepository.GetAllBooks();
            books = books.OrderBy(b => b.Name).ToList();

            return books;
        }

        public Book GetBook(long id)
        {
            Book book = this.BookRepository.GetBook(id);

            if(book == null)
            {
                throw new Exception(string.Format("The resource was not found, Book with ID: {0}", id));
            }

            return book;
        }

        public void SaveBook(Book value)
        {
            this.BookRepository.SaveBook(value);
        }

        public void UpdateBook(Book value)
        {
            value.ModificationTime = DateTime.Now;
            this.BookRepository.UpdateBook(value);
        }

        public void DeleteBook(long id)
        {
            this.BookRepository.DeleteBook(id);
        }
    }
}