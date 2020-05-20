using AxaAssistanceTest.Models.Entities.Reservations;
using System.Collections.Generic;

namespace AxaAssistanceTest.Models.Repositories.Reservations
{
    public interface IReservationRepository
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservation(long id);
        void SaveReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(long id);
    }
}