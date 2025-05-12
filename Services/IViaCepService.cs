using BuscaCEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCEP.Services
{
    public interface IViaCepService
    {
        Task<EnderecoResponse> BuscarEnderecoPorCep(string cep);
    }
}
