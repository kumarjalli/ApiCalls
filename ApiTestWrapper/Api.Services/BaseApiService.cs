using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
// For System.Web.Http install Microsoft.AspNet.WebApi
namespace Api.Services
{
    public class BaseApiService
    {
        private string m_ServiceBaseAddress;
        private string m_AuthorizationToken;
        private string m_ReportName;

        public BaseApiService(string serviceBaseAddress, string authorizationToken, string reportName)
        {
            m_ServiceBaseAddress = serviceBaseAddress;
            m_AuthorizationToken = authorizationToken;
            m_ReportName = reportName;
        }

        public BaseApiService(string serviceBaseAddress, string authorizationToken)
        {
            m_ServiceBaseAddress = serviceBaseAddress;
            m_AuthorizationToken = authorizationToken;
        }

        //public string Url
        //{
        //    get
        //    {
        //        return $"{m_ServiceBaseAddress}/api/{m_ReportName}";
        //    }
        //}

        //public string ServiceBaseAddress
        //{
        //    get
        //    {
        //        return m_ServiceBaseAddress;
        //    }
        //}

        public async Task<string> ReadAsStringAsync(string apiUrl)
        {
            string response;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponse = await httpClient.GetAsync(apiUrl))
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        response = await httpResponse.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new HttpResponseException(new HttpResponseMessage(httpResponse.StatusCode) { ReasonPhrase = httpResponse.ReasonPhrase });
                    }
                }
            }
            return response;
        }

        public async Task<T> ReadAsAsync<T>(string apiUrl)
        {
            T response;
            using (HttpClient httpClient = new HttpClient(new ApiMessageHandler(new HttpClientHandler(), m_AuthorizationToken)))
            {
                using (HttpResponseMessage httpResponse = await httpClient.GetAsync(apiUrl))
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        response = await httpResponse.Content.ReadAsAsync<T>();
                    }
                    else
                    {
                        throw new HttpResponseException(new HttpResponseMessage(httpResponse.StatusCode) { ReasonPhrase = httpResponse.ReasonPhrase });
                    }
                }
            }
            return response;
            //TODO How to call API with Headers
        }

        public async Task<Newtonsoft.Json.Linq.JToken> ReadAsJsonAsync(string apiUrl)
        {
            Newtonsoft.Json.Linq.JToken content;
            using (HttpClient httpClient = new HttpClient(new ApiMessageHandler(new HttpClientHandler(), m_AuthorizationToken)))
            {
                using (HttpResponseMessage httpResponse = await httpClient.GetAsync(apiUrl))
                {
                    httpResponse.EnsureSuccessStatusCode();
                    content = await httpResponse.Content.ReadAsAsync<Newtonsoft.Json.Linq.JToken>();
                }
            }
            return content;
        }

        public async Task<string> PostAsJsonAsync(string apiUrl, string reportName, string data)
        {
            string content;
            string requestUrl = $"api/report/{reportName}";
            using (HttpClient httpClient = new HttpClient(new ApiMessageHandler(new HttpClientHandler(), m_AuthorizationToken)))
            {
                httpClient.BaseAddress = new System.Uri(apiUrl);
                using (HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync(requestUrl, data))
                {
                    httpResponse.EnsureSuccessStatusCode();
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        // Deserialize the updated product from the response body.
                        content = await httpResponse.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new HttpResponseException(new HttpResponseMessage(httpResponse.StatusCode) { ReasonPhrase = httpResponse.ReasonPhrase });
                    }
                }

            }
            return content;
        }

        public async Task<string> PostAsync(string apiUrl, string apiName, string data)
        {
            string content = "";
            string requestUrl = $"api/Report/{apiName}";
         
            using (HttpClient httpClient = new HttpClient(new ApiMessageHandler(new HttpClientHandler(), m_AuthorizationToken)))
            {
                httpClient.BaseAddress = new System.Uri(apiUrl);
                StringContent stringContent = new StringContent(JsonHelper.Serialize(data), UnicodeEncoding.UTF8, "application/json");
                using (HttpResponseMessage httpResponse = await httpClient.PostAsync(requestUrl, stringContent))
                {
                    httpResponse.EnsureSuccessStatusCode();
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        content = await httpResponse.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new HttpResponseException(new HttpResponseMessage(httpResponse.StatusCode) { ReasonPhrase = httpResponse.ReasonPhrase });
                    }
                }

            }
            return content;
        }
    }
}
