using AxaAssistanceTest.Models.ApplicationLogic.Exceptions;
using AxaAssistanceTest.Models.Entities.Reservations;
using AxaAssistanceTest.Models.Repositories.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxaAssistanceTest.Models.DomainLogic.Service
{
    /// <summary>
    /// Class holding the business logic for the CRUD operations of the Reservation entity.
    /// </summary>
    public class ReservationService
    {
        private IReservationRepository ReservationRepository;

        public ReservationService(IReservationRepository ReservationRepository)
        {
            this.ReservationRepository = ReservationRepository;
        }

        /// <summary>
        /// Searches the Data Source for a complete List of Reservation objects.
        /// </summary>
        /// <returns>
        /// Returns a list of all the Reservation objects found in the DataSource, an empty List if none are found.
        /// </returns>
        public List<Reservation> ListReservations()
        {
            List<Reservation> reservations = this.ReservationRepository.GetAllReservations();
            reservations = reservations.OrderByDescending(c => c.CreationTime).ToList();

            return reservations;
        }

        /// <summary>
        /// Searches the Data Source for a Reservation object that matches the provided Id
        /// </summary>
        /// <returns>
        /// Returns a single Reservation object if found.
        /// </returns>
        /// <exception cref="EntityNotFoundException">Thrown when a Reservation is not found with the provided Id.</exception>
        public Reservation GetReservation(int id)
        {
            Reservation reservation = this.ReservationRepository.GetReservation(id);

            if (reservation == null)
            {
                throw new EntityNotFoundException(string.Format(ResponseMessages.ReservationNotFound, id));
            }

            return reservation;
        }

        /// <summary>
        /// Creates a Reservation object and it's associated ReservedBooks in the Data Source.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when a required property of the Reservation is missing.</exception>
        /// <exception cref="UnavailableStateException">Thrown when a the Customer associated with the new Reservation already has another Reservation open.</exception>
        public void CreateReservation(Reservation value)
        {
            if(string.IsNullOrEmpty(value.CustomerId))
            {
                throw new ArgumentNullException(ResponseMessages.ReservationMissingCustomer);
            }

            if(value.ReservedBooks == null || value.ReservedBooks.Count <= 0)
            {
                throw new ArgumentNullException(ResponseMessages.ReservationMissingBook);
            }

            Reservation reservation = this.ReservationRepository.GetReservationByCustomerId(value.CustomerId);
            if(reservation != null)
            {
                throw new UnavailableStateException(string.Format(ResponseMessages.ReservationAlreadyOpen, reservation.Id));
            }

            value.ReservationDate = DateTime.Now;
            value.CreationTime = DateTime.Now;
            this.ReservationRepository.SaveReservation(value);
        }

        /// <summary>
        /// Updates a Reservation to mark it as closed.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the Reservation's Id is missing.</exception>
        /// <exception cref="EntityNotFoundException">Thrown when the Reservation is not found with the provided Id.</exception>
        /// <exception cref="UnavailableStateException">Thrown when the Reservation is already closed.</exception>
        public void CloseReservation(Reservation value)
        {
            if(value.Id == null)
            {
                throw new ArgumentNullException(ResponseMessages.ReservationMissingID);
            }

            Reservation reservation = this.ReservationRepository.GetReservation(value.Id.Value);
            if (reservation == null)
            {
                throw new EntityNotFoundException(string.Format(ResponseMessages.ReservationNotFound, value.Id));
            }

            if(reservation.ReturnDate != null)
            {
                throw new UnavailableStateException(string.Format(ResponseMessages.ReservationAlreadyClosed, reservation.Id));
            }

            reservation.ReturnDate = DateTime.Now;
            reservation.ModificationTime = DateTime.Now;
            this.ReservationRepository.UpdateReservation(reservation);
        }
    }
}