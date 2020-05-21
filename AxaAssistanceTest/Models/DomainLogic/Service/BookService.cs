using AxaAssistanceTest.Models.ApplicationLogic.Exceptions;
using AxaAssistanceTest.Models.Entities.Books;
using AxaAssistanceTest.Models.Repositories.Books;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AxaAssistanceTest.Models.DomainLogic.Service
{
    /// <summary>
    /// Class holding the business logic for the CRUD operations of the Book entity.
    /// </summary>
    public class BookService
    {
        private IBookRepository BookRepository;

        public BookService(IBookRepository BookRepository)
        {
            this.BookRepository = BookRepository;
        }

        /// <summary>
        /// Searches the Data Source for a complete List of Book objects.
        /// </summary>
        /// <returns>
        /// Returns a list of all the Book objects found in the DataSource, an empty List if none are found.
        /// </returns>
        public List<Book> ListBooks()
        {
            List<Book> books = this.BookRepository.GetAllBooks();
            books = books.OrderBy(b => b.Name).ToList();

            return books;
        }

        /// <summary>
        /// Searches the Data Source for a Book object that matches the provided Id
        /// </summary>
        /// <returns>
        /// Returns a single Book object if found.
        /// </returns>
        /// <exception cref="EntityNotFoundException">Thrown when a Book is not found with the provided Id.</exception>
        public Book GetBook(long id)
        {
            Book book = this.BookRepository.GetBook(id);

            if(book == null)
            {
                throw new EntityNotFoundException(string.Format(ResponseMessages.BookNotFound, id));
            }

            return book;
        }

        /// <summary>
        /// Stores a Book object in the Data Source.
        /// </summary>
        public void SaveBook(Book value)
        {
            value.CreationTime = DateTime.Now;
            this.BookRepository.SaveBook(value);
        }

        /// <summary>
        /// Updates a Book object in the Data Source that matches the Id of the provided Book object, if the Book object doesn't exist, it is created instead.
        /// </summary>
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

        /// <summary>
        /// Deletes a Book object from the Data Source.
        /// </summary>
        public void DeleteBook(long id)
        {
            this.BookRepository.DeleteBook(id);
        }
    }
}