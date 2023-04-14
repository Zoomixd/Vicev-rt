using PedelApp.Contract;
using PedelApp.Contract.Dtos;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace PedelApp.Infrastructure
{
    public class TidsRegistreringServiceProxy : ITidsRegistreringService
    {
        private readonly HttpClient _client;

        public TidsRegistreringServiceProxy(HttpClient client)
        {
            _client = client;
        }

        async Task ITidsRegistreringService.CreateAsync(TidsRegistreringDto tidsRegistreringDto)
        {
            var tidsRegistreringDtoJson = new StringContent(
                JsonSerializer.Serialize(tidsRegistreringDto),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            await _client.PostAsync("api/TidsRegistrering", tidsRegistreringDtoJson);
        }

        /* public Task EditAsync(RekvisitionDto rekvisitionDto)
         {
             throw new NotImplementedException();
         }*/

        async Task<TidsRegistreringDto?> ITidsRegistreringService.GetAsync(int tidsRegistreringsid)
        {
            return await _client.GetFromJsonAsync<TidsRegistreringDto?>($"api/TidsRegistrering/{tidsRegistreringsid}");
        }

        async Task<IEnumerable<TidsRegistreringDto>> ITidsRegistreringService.GetAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<TidsRegistreringDto>>($"api/TidsRegistrering");
        }
    }
}
