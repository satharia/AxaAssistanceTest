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
    public class AxaLibraryContext : DbContext
    {
        public AxaLibraryContext() : base("AxaLibraryContext")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservedBook> ReservedBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}