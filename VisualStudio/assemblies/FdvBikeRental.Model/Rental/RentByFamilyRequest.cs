using System.ComponentModel.DataAnnotations;

namespace FdvBikeRental.Model.Rental
{
    public class RentByFamilyRequest
    {
        public RentByHourRequest RentByHourRequest { get; set; }

        public RentByDayRequest RentByDayRequest { get; set; }

        public RentByWeekRequest RentByWeekRequest { get; set; }

        [Range(3, 5)]
        public int FamilyMembers { get; set; }
    }
}
