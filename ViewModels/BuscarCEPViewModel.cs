using BuscaCEP.Services;
using BuscaCEP.Models;
using System.Windows.Input;

namespace BuscaCEP.ViewModels
{
    public class BuscarCEPViewModel: BindableObject
    {
        private readonly IViaCepService _viaCepService;
        private EnderecoResponse _enderecoResponse;
        public EnderecoResponse Endereco 
        {
            get => _enderecoResponse;
            set
            {
                _enderecoResponse = value;
                OnPropertyChanged();
            }
        }
        private string _cep;
        public string Cep
        {
            get => _cep;
            set
            {
                _cep = value;
                OnPropertyChanged();
            }
        }
        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand BuscarCepCommand { get; }

        public BuscarCEPViewModel(IViaCepService viacepService)
        {
            _viaCepService = viacepService;
            BuscarCepCommand = new Command(async () => await BuscarCep());
        }

        private async Task BuscarCep()
        {
            if (string.IsNullOrEmpty(Cep) || Cep.Length !=8)
            {
                await Shell.Current.DisplayAlert("Erro", "CEP inválido", "OK");
                return;
            }
            try
            {
                IsBusy = true;
                Endereco = await _viaCepService.BuscarEnderecoPorCep(Cep);
                if (Endereco == null)
                {
                    await Shell.Current.DisplayAlert("Erro", "CEP não encontrado", "OK");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
