using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDemoLuigi.Views.Controls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty IsUnfocusedProperty =
            BindableProperty.Create("IsUnfocused", typeof(ICommand), typeof(CustomEntry), null);

        public ICommand IsUnfocused
        {
            get { return (ICommand)GetValue(IsUnfocusedProperty); }
            set { SetValue(IsUnfocusedProperty, value); }
        }

        public CustomEntry()
        {
            Unfocused += CustomUnfocused;
        }

        private void CustomUnfocused(object sender, FocusEventArgs e)
        {
            if (IsUnfocused != null)
                IsUnfocused.Execute(null);
        }
    }
}
