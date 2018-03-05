using System;
using FdvBikeRental.DataAccess.Api.Rental;
using FdvBikeRental.DataAccess.Implementation.Framework;
using FdvBikeRental.Model.Rental;

namespace FdvBikeRental.DataAccess.Implementation.Rental
{
    public class RentalDataAccess : AbstractDataAccess, IRentalDataAccess
    {
        private enum BikeRentalType
        {
            Hour = 1,
            Day = 2,
            Week = 3
        }

        private const int PriceByHour = 5;
        private const int PriceByDay = 20;
        private const int PriceByWeek = 60;
        private const int FamilyDiscountPercent = 30;

        private DateTime GetBusinessTime()
        {
            return DateTime.Now;
        }

        public BikeRentalInvoice RentByHour(RentByHourRequest rentByHourRequest)
        {
            BikeRentalInvoice invoice = new BikeRentalInvoice();
            
            invoice.ReturnDate = CalculateReturnDate(rentByHourRequest.Hours, BikeRentalType.Hour);
            invoice.Total = CalculateTotal(rentByHourRequest.Hours, BikeRentalType.Hour, 0);
            invoice.InvoiceId = CreateInvoiceId();

            return invoice;
        }

        public BikeRentalInvoice RentByDay(RentByDayRequest rentByDayRequest)
        {
            BikeRentalInvoice invoice = new BikeRentalInvoice();
            
            invoice.ReturnDate = CalculateReturnDate(rentByDayRequest.Days, BikeRentalType.Day);
            invoice.Total = CalculateTotal(rentByDayRequest.Days, BikeRentalType.Day, 0);
            invoice.InvoiceId = CreateInvoiceId();

            return invoice;
        }

        public BikeRentalInvoice RentByWeek(RentByWeekRequest rentByWeekRequest)
        {
            BikeRentalInvoice invoice = new BikeRentalInvoice();
            
            invoice.ReturnDate = CalculateReturnDate(rentByWeekRequest.Weeks, BikeRentalType.Week);
            invoice.Total = CalculateTotal(rentByWeekRequest.Weeks, BikeRentalType.Week, 0);
            invoice.InvoiceId = CreateInvoiceId();

            return invoice;
        }

        public BikeRentalInvoice RentByFamily(RentByFamilyRequest rentByFamilyRequest)
        {
            BikeRentalInvoice invoice = new BikeRentalInvoice();
            
            BikeRentalType bikeRentalType;
            int number;

            if (rentByFamilyRequest.RentByHourRequest != null)
            {
                RentByHourRequest rentByHourRequest = rentByFamilyRequest.RentByHourRequest;

                bikeRentalType = BikeRentalType.Hour;
                number = rentByHourRequest.Hours;
            }
            else if (rentByFamilyRequest.RentByDayRequest != null)
            {
                RentByDayRequest rentByDayRequest = rentByFamilyRequest.RentByDayRequest;

                bikeRentalType = BikeRentalType.Day;
                number = rentByDayRequest.Days;
            }
            else if (rentByFamilyRequest.RentByWeekRequest != null)
            {
                RentByWeekRequest rentByDayRequest = rentByFamilyRequest.RentByWeekRequest;

                bikeRentalType = BikeRentalType.Week;
                number = rentByDayRequest.Weeks;
            }
            else
            {
                throw new NotImplementedException();
            }

            invoice.ReturnDate = CalculateReturnDate(number, bikeRentalType);
            invoice.Total = CalculateTotal(number, bikeRentalType, FamilyDiscountPercent);
            invoice.InvoiceId = CreateInvoiceId();
            return invoice;
        }

        private DateTime CalculateReturnDate(int value, BikeRentalType bikeRentalType)
        {
            DateTime result;

            switch (bikeRentalType)
            {
                case BikeRentalType.Hour:
                    result = GetBusinessTime().AddHours(value);
                    break;
                case BikeRentalType.Day:
                    result = GetBusinessTime().AddDays(value);
                    break;
                case BikeRentalType.Week:
                    result = GetBusinessTime().AddDays(value * 7);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        private double CalculateTotal(int value, BikeRentalType bikeRentalType, int discount)
        {
            double result;

            switch (bikeRentalType)
            {
                case BikeRentalType.Hour:
                    result = PriceByHour * value;
                    break;
                case BikeRentalType.Day:
                    result = PriceByDay * value;
                    break;
                case BikeRentalType.Week:
                    result = PriceByWeek * value;
                    break;
                default:
                    throw new NotImplementedException();
            }

            double discountAux = (discount * result) / 100;
            result = result - discountAux;
            
            return result;
        }

        private Guid CreateInvoiceId()
        {
            return Guid.NewGuid();
        }
    }
}
