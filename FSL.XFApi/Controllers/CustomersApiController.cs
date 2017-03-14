using FSL.XFApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FSL.XFApi.Controllers
{
    [RoutePrefix("api/customers")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomersApiController : ApiController
    {
        [Route("")]
        public IEnumerable<Customer> Get()
        {
            var customers = new List<Customer>();
            customers.Add(new Models.Customer() { Id = "1", Name = "Customer 1" });
            customers.Add(new Models.Customer() { Id = "2", Name = "Customer 2" });
            customers.Add(new Models.Customer() { Id = "3", Name = "Customer 3" });

            return customers;
        }
    }
}