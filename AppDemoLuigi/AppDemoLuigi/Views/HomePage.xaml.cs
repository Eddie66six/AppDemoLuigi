using Xamarin.Forms;

namespace AppDemoLuigi.Views
{
    public partial class HomePage : BaseContentPage
    {
        public HomePage()
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
