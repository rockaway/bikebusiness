using System.ComponentModel.DataAnnotations;

namespace FdvBikeRental.Model.Rental
{
    public class RentByHourRequest : IRentByRequest
    {
        [Range(1, 23)]
        public int Hours { get; set; }
    }
}
