using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;

namespace AppDemoLuigi.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }
        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
        public virtual Task LoadAsync()
        {
            return Task.FromResult(0);
        }
        private bool _isVisibleOrEnable = true;
        public bool IsVisibleOrEnable
        {
            get { return _isVisibleOrEnable; }
            set { SetProperty(ref _isVisibleOrEnable, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private decimal _opacity;
        public decimal Opacity
        {
            get { return _opacity == 0 ? 1.0m : _opacity; }
            set { SetProperty(ref _opacity, value); }
        }

        public void OnLoad(bool isLoad)
        {
            Opacity = isLoad == true ? 0.5m : 1.0m;
            IsBusy = isLoad;
            IsVisibleOrEnable = !isLoad;
        }
    }
}
