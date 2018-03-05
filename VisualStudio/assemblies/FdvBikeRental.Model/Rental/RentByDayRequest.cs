using System.ComponentModel.DataAnnotations;

namespace FdvBikeRental.Model.Rental
{
    public class RentByDayRequest : IRentByRequest
    {
        [Range(1, 6)]
        public int Days { get; set; }
    }
}
