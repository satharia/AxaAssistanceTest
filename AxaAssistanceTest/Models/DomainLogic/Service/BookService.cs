using AxaAssistanceTest.Models.ApplicationLogic.Exceptions;
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
                throw new EntityNotFoundException(string.Format(ResponseMessages.BookNotFound, id));
            }

            return book;
        }

        public void SaveBook(Book value)
        {
            value.CreationTime = DateTime.Now;
            this.BookRepository.SaveBook(value);
        }

        public void UpdateBook(Book value)
        {
            Book book = this.BookRepository.GetBook(value.Id.Value);

            if (book != null)
            {
                value.CreationTime = book.CreationTime;
            }
            else
            {
                value.CreationTime = DateTime.Now;
            }
            value.ModificationTime = DateTime.Now;
            this.BookRepository.UpdateBook(value);
        }

        public void DeleteBook(long id)
        {
            this.BookRepository.DeleteBook(id);
        }
    }
}