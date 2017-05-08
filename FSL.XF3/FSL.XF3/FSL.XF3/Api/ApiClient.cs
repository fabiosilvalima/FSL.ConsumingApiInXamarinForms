using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using FSL.XF3.Api.Models;
using Newtonsoft.Json.Converters;
using System.Text;

namespace FSL.XF3.Api
{
    public class ApiClient : IApiClient
    {
        public ApiClient(string apiUrlBase)
        {
            if (string.IsNullOrEmpty(apiUrlBase))
            {
                throw new ArgumentNullException("apiUrlBase", "Uma url base de API deve ser informada");
            }

            _apiUrlBase = apiUrlBase;
        }

        private HttpClient _restClient;
        private string _apiUrlBase;

        public async Task<BaseApiResult<TModel>> GetAsync<TModel>(string apiRoute, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var json = await GetAsync(apiRoute);
                var data = JsonConvert.DeserializeObject<TModel>(json, GetConverter());
                var result = new OkApiResult<TModel>(data);

                callback?.Invoke(result);

                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        private async Task<string> GetAsync(string apiRoute)
        {
            var url = _apiUrlBase + "/" + apiRoute;

            _restClient = _restClient ?? new HttpClient();
            _restClient.BaseAddress = new Uri(url);

            ClearReponseHeaders();
            AddReponseHeaders();

            var response = await _restClient.GetAsync(_restClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }

        public async Task<BaseApiResult<TModel>> PostAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var json = await PostAsync(apiRoute, body);
                var data = JsonConvert.DeserializeObject<TModel>(json, GetConverter());
                var result = new OkApiResult<TModel>(data);

                callback?.Invoke(result);

                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        public async Task<BaseApiResult<TModel>> PostResultAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var data = await PostAsync(apiRoute, body);
                var result = JsonConvert.DeserializeObject<OkApiResult<TModel>>(data, GetConverter());

                callback?.Invoke(result);

                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        private async Task<string> PostAsync(string apiRoute, object body)
        {
            var url = _apiUrlBase + "/" + apiRoute;

            _restClient = _restClient ?? new HttpClient();
            _restClient.BaseAddress = new Uri(url);

            ClearReponseHeaders();
            AddReponseHeaders();

            var bodySerialize = JsonConvert.SerializeObject(body);
            StringContent content = new StringContent(bodySerialize, Encoding.UTF8, "application/json");

            var response = await _restClient.PostAsync(_restClient.BaseAddress, content);
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }

        private IsoDateTimeConverter GetConverter()
        {
            return new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" };
        }
        
        public IApiClient UseSufix(string urlSufix)
        {
            if (!_apiUrlBase.EndsWith(urlSufix))
            {
                _apiUrlBase = _apiUrlBase + "/" + urlSufix;
            }

            return this;
        }
        
        private void AddReponseHeaders()
        {

        }

        private void ClearReponseHeaders()
        {
            _restClient.DefaultRequestHeaders.Clear();
        }

        public void Dispose()
        {

        }
    }
}
