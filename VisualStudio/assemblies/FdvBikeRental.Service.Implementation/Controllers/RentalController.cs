using System.Net;
using System.Net.Http;
using FdvBikeRental.DataAccess.Api.Rental;
using FdvBikeRental.Service.Api.Rental;
using FdvBikeRental.Service.Implementation.Framework;
using System.Web.Http;
using System.Web.Http.Description;
using FdvBikeRental.Model.Rental;

namespace FdvBikeRental.Service.Implementation.Controllers
{
    /// <summary>
    /// Rental Service
    /// </summary>
    [RoutePrefix("api/rental")]
    public class RentalController : AbstractService<IRentalDataAccess>, IRentalService
    {
        /// <summary>
        /// Rent by hour
        /// </summary>
        /// <param name="rentByHourRequest"></param>
        /// <returns></returns>
        [Route("rentbyhour")]
        [ResponseType(typeof(BikeRentalInvoice))]
        public IHttpActionResult RentByHour(RentByHourRequest rentByHourRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(Dao.RentByHour(rentByHourRequest));
        }

        /// <summary>
        /// Rent by day
        /// </summary>
        /// <param name="rentByDayRequest"></param>
        /// <returns></returns>
        [Route("rentbyday")]
        [ResponseType(typeof(BikeRentalInvoice))]
        public IHttpActionResult RentByDay(RentByDayRequest rentByDayRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(Dao.RentByDay(rentByDayRequest));
        }

        /// <summary>
        /// Rent by week
        /// </summary>
        /// <param name="rentByWeekRequest"></param>
        /// <returns></returns>
        [Route("rentbyweek")]
        [ResponseType(typeof(BikeRentalInvoice))]
        public IHttpActionResult RentByWeek(RentByWeekRequest rentByWeekRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(Dao.RentByWeek(rentByWeekRequest));
        }

        /// <summary>
        /// Rent by family
        /// </summary>
        /// <param name="rentByFamilyRequest"></param>
        /// <returns></returns>
        [Route("rentbyfamily")]
        [ResponseType(typeof(BikeRentalInvoice))]
        public IHttpActionResult RentByFamily(RentByFamilyRequest rentByFamilyRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int numberOfSelectedRentalTypes = 0;
            if (rentByFamilyRequest.RentByHourRequest != null)
                numberOfSelectedRentalTypes++;
            if (rentByFamilyRequest.RentByDayRequest != null)
                numberOfSelectedRentalTypes++;
            if (rentByFamilyRequest.RentByWeekRequest != null)
                numberOfSelectedRentalTypes++;

            if (numberOfSelectedRentalTypes == 0)
            {
                return BadRequest("You have to select one of the rental options");
            }

            if (numberOfSelectedRentalTypes != 1)
            {
                return BadRequest("You can´t select more than one rental option");
            }

            return Ok(Dao.RentByFamily(rentByFamilyRequest));
        }
    }
}
