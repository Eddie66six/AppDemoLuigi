using AppDemoLuigi.ViewModels;
using Xamarin.Forms;

namespace AppDemoLuigi.Views
{
    public class BaseContentPage:ContentPage
    {
        private BaseViewModel _viewModel => BindingContext as BaseViewModel;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadAsync();
        }
    }
}
