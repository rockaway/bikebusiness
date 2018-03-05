using System.Web.Http;
using FdvBikeRental.Model.Rental;

namespace FdvBikeRental.Service.Api.Rental
{
    public interface IRentalService
    {
        IHttpActionResult RentByHour(RentByHourRequest rentByHourRequest);

        IHttpActionResult RentByDay(RentByDayRequest rentByDayRequest);

        IHttpActionResult RentByWeek(RentByWeekRequest rentByWeekRequest);

        IHttpActionResult RentByFamily(RentByFamilyRequest rentByFamilyRequest);

    }
}
