using Xamarin.Forms;

namespace AppDemoLuigi.Views
{
    public partial class LoginPage : BaseContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            if (Device.OS == TargetPlatform.Android)
                return true;
            return base.OnBackButtonPressed();
        }
    }
}
