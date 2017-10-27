using AppDemoLuigi.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDemoLuigi.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        public ICommand LogarCommand { get; }

        public ICommand OpenModalCommand { get; }
        public ICommand CloseModalCommand { get; }
        public ICommand ObeterEnderecoCommand { get; }

        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        #region Cadastro
        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { SetProperty(ref _cpf, value); }
        }
        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { SetProperty(ref _senha, value); }
        }
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }
        }
        private DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { SetProperty(ref _dataNascimento, value); }
        }
        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { SetProperty(ref _cep, value); }
        }
        private string _bairro;
        public string Bairro
        {
            get { return _bairro; }
            set { SetProperty(ref _bairro, value); }
        }
        private string _endereco;
        public string Endereco
        {
            get { return _endereco; }
            set { SetProperty(ref _endereco, value); }
        }
        private string _cidade;
        public string Cidade
        {
            get { return _cidade; }
            set { SetProperty(ref _cidade, value); }
        }
        private string _uf;
        public string Uf
        {
            get { return _uf; }
            set { SetProperty(ref _uf, value); }
        }

        #endregion

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            LogarCommand = new Command(Logar);
            CloseModalCommand = new Command(CloseModal);
            OpenModalCommand = new Command(OpenModal);
            ObeterEnderecoCommand = new Command(ObeterEndereco);
        }

        private async void Logar()
        {
            OnLoad(true);
            await Task.Delay(2000);
            OnLoad(false);
            await _navigationService.NavigateAsync("MenuMasterDetailPage/NavigationPage/HomePage");
        }

        public async void ObeterEndereco()
        {
            OnLoad(true);
            var api = new ApiExterna();
            var endereco = await api.ObterEndereco(Cep);
            if (endereco == null) return;
            Cep = endereco.Cep;
            Bairro = endereco.Bairro;
            Endereco = endereco.Logradouro;
            Cidade = endereco.Localidade;
            Uf = endereco.Uf;
            OnLoad(false);
        }

        private void OpenModal()
        {
            DataNascimento = DateTime.Today;
            IsVisible = true;
        }
        private void CloseModal()
        {
            IsVisible = false;
        }
    }
}
