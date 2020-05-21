using AxaAssistanceTest.Models.Entities.Reservations;
using System.Collections.Generic;

namespace AxaAssistanceTest.Models.Repositories.Reservations
{
    /// <summary>
    /// Data Source accessor for the Reservation entity.
    /// </summary>
    public interface IReservationRepository
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservation(long id);
        Reservation GetReservationByCustomerId(string CustomerId);
        void SaveReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(long id);
    }
}