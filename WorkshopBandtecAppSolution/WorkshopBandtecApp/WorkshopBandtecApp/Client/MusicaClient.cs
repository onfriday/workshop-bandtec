using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkshopBandtecApp.Data;

namespace WorkshopBandtecApp.Client
{
    class MusicaClient
    {
        public async Task<List<MusicaDto>> Get()
        {
            try
            {
                await HttpClientService.Current.Autenticar();

                using (var _response = await HttpClientService.Current.Client.GetAsync("http://bandtec-api.azurewebsites.net/api/v1/musica"))
                {
                    if (!_response.IsSuccessStatusCode)
                    {

                    }

                    var _result = await _response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<MusicaDto>>(_result);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Post(MusicaDto pDto)
        {
            try
            {
                await HttpClientService.Current.Autenticar();

                using (var _response = await HttpClientService.Current.Client.PostAsync("http://bandtec-api.azurewebsites.net/api/v1/musica", new StringContent(JsonConvert.SerializeObject(pDto), Encoding.UTF8, "application/json")))
                {
                    if (!_response.IsSuccessStatusCode)
                    {

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
