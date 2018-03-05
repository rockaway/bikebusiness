using System;

namespace FdvBikeRental.Model.Rental
{
    public class BikeRentalInvoice
    {
        public double Total { get; set; }

        public DateTime ReturnDate;
        
        public Guid InvoiceId { get; set; }
    }
}
