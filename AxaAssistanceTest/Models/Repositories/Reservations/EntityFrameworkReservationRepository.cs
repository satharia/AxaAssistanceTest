using AxaAssistanceTest.Models.Entities.Reservations;
using AxaAssistanceTest.Models.Repositories.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AxaAssistanceTest.Models.Repositories.Reservations
{
    public class EntityFrameworkReservationRepository : IReservationRepository
    {

        private AxaLibraryContext DbContext;

        public EntityFrameworkReservationRepository(AxaLibraryContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = this.DbContext.Reservations.ToList();
            return reservations;
        }

        public Reservation GetReservation(long id)
        {
            Reservation reservation = this.DbContext.Reservations.Find(id);
            return reservation;
        }

        public void SaveReservation(Reservation reservation)
        {
            this.DbContext.Reservations.Add(reservation);
            this.DbContext.SaveChanges();
        }

        public void UpdateReservation(Reservation reservation)
        {
            this.DbContext.Reservations.AddOrUpdate(reservation);
            this.DbContext.SaveChanges();
        }

        public void DeleteReservation(long id)
        {
            Reservation reservation = this.DbContext.Reservations.Find(id);
            if (reservation == null)
            {
                throw new Exception($"Reservation with ID: {id} not found, Delete failed");
            }

            this.DbContext.Reservations.Remove(reservation);
            this.DbContext.SaveChanges();
        }
    }
}