using BuscaCEP.Views;
using BuscaCEP.ViewModels;
using BuscaCEP.Services;

namespace BuscaCEP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Instancia o ViewModel necessário e passa como argumento para a página
            var viaCepService = new ViaCepService();
            var viewModel = new BuscarCEPViewModel(viaCepService);
            MainPage = new BuscaCEPPage(viewModel);
        }
    }
}
