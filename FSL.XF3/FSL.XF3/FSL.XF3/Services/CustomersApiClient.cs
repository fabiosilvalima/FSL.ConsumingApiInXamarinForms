using System.Collections.Generic;
using System.Threading.Tasks;
using FSL.XF3.Api;
using FSL.XF3.Api.Models;

namespace FSL.XF3.Services
{
    public sealed class CustomersApiClient : ApiClient, ICustomersApiClient
    {
        public CustomersApiClient() 
            : base("http://10.0.2.2/FSL.XFApi/api")
        {

        }

        public async Task<BaseApiResult<List<Customer>>> GetAllCustomers()
        {
            return await FslApiClient.Current.GetAsync<List<Customer>>("customers");
        }
    }
}
