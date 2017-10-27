using Plugin.Media;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDemoLuigi.ViewModels
{
    public class PerfilPageViewModel : BaseViewModel
    {
        public ICommand TakePhotoDocumentsCommand { get; }
        public PerfilPageViewModel()
        {
            TakePhotoDocumentsCommand = new Command(TakePhotoDocuments);
        }
        private async void TakePhotoDocuments()
        {
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                // Supply media options for saving our photo after it's taken.
                var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Receipts",
                    Name = $"{DateTime.UtcNow}.jpg"
                };

                // Take a photo of the business receipt.
                var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
                OnLoad(true);
                var stream = file.GetStream();
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                string base64 = System.Convert.ToBase64String(bytes);
                OnLoad(false);
            }
        }
    }
}
