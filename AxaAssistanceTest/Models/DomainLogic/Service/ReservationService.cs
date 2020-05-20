using AxaAssistanceTest.Models.ApplicationLogic.Exceptions;
using AxaAssistanceTest.Models.Entities.Reservations;
using AxaAssistanceTest.Models.Repositories.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxaAssistanceTest.Models.DomainLogic.Service
{
    public class ReservationService
    {
        private IReservationRepository ReservationRepository;

        public ReservationService(IReservationRepository ReservationRepository)
        {
            this.ReservationRepository = ReservationRepository;
        }

        public List<Reservation> ListReservations()
        {
            List<Reservation> reservations = this.ReservationRepository.GetAllReservations();
            reservations = reservations.OrderByDescending(c => c.CreationTime).ToList();

            return reservations;
        }

        public Reservation GetReservation(int id)
        {
            Reservation reservation = this.ReservationRepository.GetReservation(id);

            if (reservation == null)
            {
                throw new EntityNotFoundException(string.Format("The resource was not found, Reservation with ID: {0}", id));
            }

            return reservation;
        }

        public void CreateReservation(Reservation value)
        {
            if(string.IsNullOrEmpty(value.CustomerId))
            {
                throw new ArgumentNullException("Missing Customer ID, cannot create a Reservation without assigning a Customer");
            }

            if(value.ReservedBooks == null || value.ReservedBooks.Count <= 0)
            {
                throw new ArgumentNullException("Missing Reserved Books list, cannot create a Reservation without specifying the Reserved Books");
            }

            Reservation reservation = this.ReservationRepository.GetReservationByCustomerId(value.CustomerId);
            if(reservation != null)
            {
                throw new UnavailableStateException(string.Format("This Customer already has an open Book Reservation, the open Reservation's ID is: {0}", reservation.Id));
            }

            value.ReservationDate = DateTime.Now;
            value.CreationTime = DateTime.Now;
            this.ReservationRepository.SaveReservation(value);
        }

        public void CloseReservation(Reservation value)
        {
            if(value.Id == null)
            {
                throw new ArgumentNullException("Missing Reservation ID, cannot close a Reservation without it's identifyer");
            }

            Reservation reservation = this.ReservationRepository.GetReservation(value.Id.Value);
            if (reservation == null)
            {
                throw new EntityNotFoundException(string.Format("The resource was not found, Reservation with ID: {0}", value.Id));
            }

            if(reservation.ReturnDate != null)
            {
                throw new UnavailableStateException(string.Format("This Reservation is already closed, the closed Reservation's ID is: {0}", reservation.Id));
            }

            reservation.ReturnDate = DateTime.Now;
            reservation.ModificationTime = DateTime.Now;
            this.ReservationRepository.UpdateReservation(reservation);
        }
    }
}