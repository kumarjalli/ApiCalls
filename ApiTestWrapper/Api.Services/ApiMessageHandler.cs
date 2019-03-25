using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class ApiMessageHandler: DelegatingHandler
    {
        private const string m_AuthorizationHeader = "Authorization-Token";
        //private HttpClientHandler httpClientHandler;
        private string m_Authorization;

        public ApiMessageHandler(HttpMessageHandler innerHandler, string authorization):base(innerHandler)
        {
            m_Authorization = authorization;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, 
                                                               System.Threading.CancellationToken cancellationToken)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!String.IsNullOrWhiteSpace(m_Authorization))
            {
                request.Headers.Add(m_AuthorizationHeader, m_Authorization);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
