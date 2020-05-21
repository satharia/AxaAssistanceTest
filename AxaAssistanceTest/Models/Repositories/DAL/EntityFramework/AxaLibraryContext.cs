using AxaAssistanceTest.Models.Entities.Books;
using AxaAssistanceTest.Models.Entities.Customers;
using AxaAssistanceTest.Models.Entities.Reservations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AxaAssistanceTest.Models.Repositories.DAL.EntityFramework
{
    /// <summary>
    /// Entity Framework Database context definition.
    /// </summary>
    public class AxaLibraryContext : DbContext
    {
        public AxaLibraryContext() : base("AxaLibraryContext")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservedBook> ReservedBooks { get; set; }

        /// <summary>
        /// Configuration method for Entity Framework behaviours.
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}