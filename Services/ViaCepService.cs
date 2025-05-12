using BuscaCEP.Models;
using System.Net.Http.Json;

namespace BuscaCEP.Services
{
    internal class ViaCepService: IViaCepService
    {
        private readonly HttpClient _httpClient;
        public ViaCepService()
        {
            _httpClient = new HttpClient
            { 
                BaseAddress = new Uri("https://viacep.com.br/ws/")
            };
        }
        public async Task<EnderecoResponse> BuscarEnderecoPorCep(string cep)
        {
            var response = await _httpClient.GetAsync($"{cep}/json/");
            response.EnsureSuccessStatusCode();
            var enderecoResponse = await response.Content.ReadFromJsonAsync<EnderecoResponse>();
            return enderecoResponse;
        }

    }    
}
