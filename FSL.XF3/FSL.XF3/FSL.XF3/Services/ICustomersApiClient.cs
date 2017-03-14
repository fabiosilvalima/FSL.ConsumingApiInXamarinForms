using FSL.XF3.Api;
using FSL.XF3.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSL.XF3.Services
{
    public interface ICustomersApiClient : IApiClient
    {
        Task<BaseApiResult<List<Customer>>> GetAllCustomers();
    }
}
