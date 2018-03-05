using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using FdvBikeRental.Model.Rental;
using FdvBikeRental.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace FdvBikeRental.UnitTests
{
    [TestClass]
    public class RentalTest
    {
        [TestMethod]
        public async Task RentByHourBadRequest()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByHour";
                
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByHourRequest rent = new RentByHourRequest();
                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                    }
                } 
            }
        }

        [TestMethod]
        public async Task RentByHourOk()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByHour";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByHourRequest rent = new RentByHourRequest();
                    rent.Hours = 4;
                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        BikeRentalInvoice invoice = response.Content.ReadAsAsync<BikeRentalInvoice>().Result;
                        
                        Assert.IsTrue(invoice.InvoiceId != null && invoice.ReturnDate != DateTime.MinValue && invoice.Total>0);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByDayBadRequest()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByDay";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByDayRequest rent = new RentByDayRequest();
                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByDayOk()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByDay";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByDayRequest rent = new RentByDayRequest();
                    rent.Days = 4;
                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        BikeRentalInvoice invoice = response.Content.ReadAsAsync<BikeRentalInvoice>().Result;

                        Assert.IsTrue(invoice.InvoiceId != null && invoice.ReturnDate != DateTime.MinValue && invoice.Total > 0);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByDayDaysExceeded()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByDay";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByDayRequest rent = new RentByDayRequest();
                    rent.Days = 8;
                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByWeekBadRequest()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByWeek";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByWeekRequest rent = new RentByWeekRequest();
                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByWeekOk()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByWeek";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByWeekRequest rent = new RentByWeekRequest();
                    rent.Weeks = 30;
                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        BikeRentalInvoice invoice = response.Content.ReadAsAsync<BikeRentalInvoice>().Result;

                        Assert.IsTrue(invoice.InvoiceId != null && invoice.ReturnDate != DateTime.MinValue && invoice.Total > 0);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByFamilyBadRequest()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByFamily";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByFamilyRequest rent = new RentByFamilyRequest();
                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByFamilyOk()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByFamily";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByFamilyRequest rent = new RentByFamilyRequest();
                    rent.FamilyMembers = 4;
                    rent.RentByHourRequest = new RentByHourRequest() {Hours = 23};

                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        BikeRentalInvoice invoice = response.Content.ReadAsAsync<BikeRentalInvoice>().Result;

                        Assert.IsTrue(invoice.InvoiceId != null && invoice.ReturnDate != DateTime.MinValue && invoice.Total > 0);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByFamilyNumberOfFamilyMembersExceeded()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByFamily";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByFamilyRequest rent = new RentByFamilyRequest();
                    rent.FamilyMembers = 40;
                    rent.RentByHourRequest = new RentByHourRequest() { Hours = 1 };

                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByFamilyNumberOfFamilyMembersLessThanMinimal()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByFamily";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByFamilyRequest rent = new RentByFamilyRequest();
                    rent.FamilyMembers = 1;
                    rent.RentByHourRequest = new RentByHourRequest() { Hours = 1 };

                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByFamilyRentTypeMethodNotSelected()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByFamily";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByFamilyRequest rent = new RentByFamilyRequest();
                    rent.FamilyMembers = 1;
                    
                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                    }
                }
            }
        }

        [TestMethod]
        public async Task RentByFamilyRentTypeMoreThanOneMethodSelected()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            using (HttpServer server = new HttpServer(config))
            {
                HttpClient client = new HttpClient(server);

                string url = "http://localhost/api/rental/RentByFamily";

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    RentByFamilyRequest rent = new RentByFamilyRequest();
                    rent.RentByHourRequest = new RentByHourRequest() { Hours = 1 };
                    rent.RentByWeekRequest = new RentByWeekRequest() { Weeks = 1 };
                    rent.FamilyMembers = 1;

                    request.Content = new StringContent(JsonConvert.SerializeObject(rent), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                    }
                }
            }
        }
    }
}
