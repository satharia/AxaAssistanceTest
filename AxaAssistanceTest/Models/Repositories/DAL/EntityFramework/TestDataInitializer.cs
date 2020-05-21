using AxaAssistanceTest.Models.Entities.Books;
using AxaAssistanceTest.Models.Entities.Customers;
using AxaAssistanceTest.Models.Entities.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxaAssistanceTest.Models.Repositories.DAL.EntityFramework
{
    /// <summary>
    /// Entity framework Database initializer.
    /// </summary>
    public class TestDataInitializer : System.Data.Entity.CreateDatabaseIfNotExists<AxaLibraryContext>
    {
        /// <summary>
        /// Dummy data generator.
        /// </summary>
        protected override void Seed(AxaLibraryContext libraryContext)
        {
            var books = new List<Book>
            {
                new Book{Id = 1, Name = "Un libro", Author = "Mr Writer", Category = "Education", PublicationDate = DateTime.Parse("2010-02-24")},
                new Book{Id = 2, Name = "Otro libro", Author = "Writer Junior", Category = "Biology", PublicationDate = DateTime.Parse("2020-01-11")},
                new Book{Id = 3, Name = "El libro de en medio", Author = "Ms Writer", Category = "Music", PublicationDate = DateTime.Parse("2014-12-24")},
                new Book{Id = 4, Name = "El penúltimo libro que lleva tílde", Author = "El Señor escritor con tílde", Category = "History", PublicationDate = DateTime.Parse("1995-02-02")},
                new Book{Id = 5, Name = "The last book with an english title and that is slightly longer than the others", Author = "El escritor de Rube Goldberg", Category = "Science", PublicationDate = DateTime.Parse("2013-10-31")}
            };

            books.ForEach(s => libraryContext.Books.Add(s));
            libraryContext.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer{Id = "111", IdType = IdTypes.CC, FirstName = "Cosme", LastName = "Fulanito", Cellphone = "123"},
                new Customer{Id = "222", IdType = IdTypes.PA, FirstName = "Ian", LastName = "McCormick", Cellphone = "234"},
                new Customer{Id = "333", IdType = IdTypes.TI, FirstName = "Carlos Andrés", LastName = "Martínez", Cellphone = "345"},
                new Customer{Id = "444", IdType = IdTypes.CC, FirstName = "Julia", LastName = "Roberts the Second", Cellphone = "456"},
                new Customer{Id = "555", IdType = IdTypes.CE, FirstName = "Mr", LastName = "Anders", Cellphone = "567"}
            };
            customers.ForEach(s => libraryContext.Customers.Add(s));
            libraryContext.SaveChanges();

            var enrollments = new List<Reservation>
            {
                new Reservation{Id = 1, ReservationDate = DateTime.Now, CustomerId = "222", ReservedBooks = new List<ReservedBook> {
                    new ReservedBook{ReservationId = 1, BookId = 1},
                    new ReservedBook{ReservationId = 1, BookId = 3},
                    new ReservedBook{ReservationId = 1, BookId = 5}
                }},
                new Reservation{Id = 2, ReservationDate = DateTime.Now, CustomerId = "555", ReservedBooks = new List<ReservedBook> {
                    new ReservedBook{ReservationId = 1, BookId = 2},
                    new ReservedBook{ReservationId = 1, BookId = 4}
                }},
            };
            enrollments.ForEach(s => libraryContext.Reservations.Add(s));
            libraryContext.SaveChanges();
        }
    }
}