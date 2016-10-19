using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopBandtecApp.Client
{
    sealed class HttpClientService
    {
        private static Lazy<HttpClientService> _lazy = new Lazy<HttpClientService>(() => new HttpClientService());

        public static HttpClientService Current { get { return _lazy.Value; } }

        private HttpClientService()
        {
            this.Client = new HttpClient();
        }

        public HttpClient Client { get; private set; }

        public async Task Autenticar()
        {
            try
            {
                if (this.Client.DefaultRequestHeaders.Authorization == null)
                {
                    var _args = new List<KeyValuePair<string, string>>();
                    _args.Add(new KeyValuePair<string, string>("grant_type", "password"));
                    _args.Add(new KeyValuePair<string, string>("userName", "jefferson@balivo.com.br"));
                    _args.Add(new KeyValuePair<string, string>("password", "123@Mudar"));

                    using (var _response = await this.Client.PostAsync("http://bandtec-api.azurewebsites.net/token", new FormUrlEncodedContent(_args)))
                    {
                        if (!_response.IsSuccessStatusCode)
                        {

                        }

                        var _result = await _response.Content.ReadAsStringAsync();

                        var _tokenResult = JsonConvert.DeserializeObject<TokenResult>(_result);

                        this.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(_tokenResult.token_type, _tokenResult.access_token);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        class TokenResult
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
        }
    }
}

