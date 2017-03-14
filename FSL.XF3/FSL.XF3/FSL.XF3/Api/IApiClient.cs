using FSL.XF3.Api.Models;
using System;
using System.Threading.Tasks;

namespace FSL.XF3.Api
{
    public interface IApiClient : IDisposable
    {
        Task<BaseApiResult<T>> GetAsync<T>(string apiRoute, Action<BaseApiResult<T>> callback = null);
        IApiClient UseSufix(string urlSufix);
    }
}
