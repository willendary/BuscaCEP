using BuscaCEP.ViewModels;
namespace BuscaCEP.Views
{
    public partial class BuscaCEPPage : ContentPage
    {       
        public BuscaCEPPage(BuscarCEPViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
