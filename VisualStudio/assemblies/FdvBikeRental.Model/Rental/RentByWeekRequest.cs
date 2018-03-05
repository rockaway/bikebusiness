using System.ComponentModel.DataAnnotations;

namespace FdvBikeRental.Model.Rental
{
    public class RentByWeekRequest : IRentByRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Weeks { get; set; }
    }
}
