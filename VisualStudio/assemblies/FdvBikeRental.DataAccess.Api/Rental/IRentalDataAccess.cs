using FdvBikeRental.DataAccess.Api.Framework;
using FdvBikeRental.Model.Rental;

namespace FdvBikeRental.DataAccess.Api.Rental
{
    public interface IRentalDataAccess : IAbstractDataAccess
    {
        BikeRentalInvoice RentByHour(RentByHourRequest rentByHourRequest);

        BikeRentalInvoice RentByDay(RentByDayRequest rentByDayRequest);

        BikeRentalInvoice RentByWeek(RentByWeekRequest rentByWeekRequest);

        BikeRentalInvoice RentByFamily(RentByFamilyRequest rentByFamilyRequest);
    }
}
