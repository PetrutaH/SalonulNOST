using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;

namespace SalonulNOST
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            var phone = PhoneEntry.Text;

            
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phone))
            {
                await DisplayAlert("Error", "Please fill in all fields", "OK");
                return;
            }

            
            Preferences.Set("UserName", name);
            Preferences.Set("UserEmail", email);
            Preferences.Set("UserPhone", phone);
            Preferences.Set("UserPassword", password);

            
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
