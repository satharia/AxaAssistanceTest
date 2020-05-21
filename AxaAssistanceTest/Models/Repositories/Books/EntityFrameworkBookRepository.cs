using AxaAssistanceTest.Models.Entities.Books;
using AxaAssistanceTest.Models.Repositories.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AxaAssistanceTest.Models.Repositories.Books
{
    /// <summary>
    /// Data Source accessor for the Book entity using Entity Framework.
    /// </summary>
    public class EntityFrameworkBookRepository : IBookRepository
    {
        private AxaLibraryContext DbContext;

        public EntityFrameworkBookRepository(AxaLibraryContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = this.DbContext.Books.ToList();
            return books;
        }

        public Book GetBook(long id)
        {
            Book book = this.DbContext.Books.Find(id);
            return book;
        }

        public void SaveBook(Book book)
        {
            this.DbContext.Books.Add(book);
            this.DbContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            this.DbContext.Books.AddOrUpdate(book);
            this.DbContext.SaveChanges();
        }

        public void DeleteBook(long id)
        {
            Book book = this.DbContext.Books.Find(id);
            if(book == null)
            {
                throw new Exception(string.Format(ResponseMessages.DeleteBookFailure, id));
            }

            this.DbContext.Books.Remove(book);
            this.DbContext.SaveChanges();
        }
    }
}