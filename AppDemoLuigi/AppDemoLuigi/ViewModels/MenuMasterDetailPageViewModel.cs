using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDemoLuigi.ViewModels
{
    public class MenuMasterDetailPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public ICommand NavigateCommand { get; }
        public Models.MenuItem[] MenuItens { get; set; }
        public MenuMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new Command<Models.MenuItem>(Navigate);
            MenuItens = new Models.MenuItem[3]
            {
                new Models.MenuItem
                {
                    Name = "Home",
                    Path = "NavigationPage/HomePage"
                },
                new Models.MenuItem
                {
                    Name = "Perfil",
                    Path = "NavigationPage/PerfilPage"
                },
                new Models.MenuItem
                {
                    Name = "Sair",
                    Path = "LoginPage"
                }
            };
        }

        private void Navigate(Models.MenuItem parameter)
        {
            _navigationService.NavigateAsync(parameter.Path);
        }
    }
}
