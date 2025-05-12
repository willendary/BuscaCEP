using BuscaCEP.Models;

namespace BuscaCEP.Services
{
    public interface IViaCepService
    {
        Task<EnderecoResponse> BuscarEnderecoPorCep(string cep);
    }
}
