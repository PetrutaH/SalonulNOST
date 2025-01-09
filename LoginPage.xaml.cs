using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;

namespace SalonulNOST
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please enter both email and password", "OK");
                return;
            }

           
            var savedEmail = Preferences.Get("UserEmail", string.Empty);
            var savedPassword = Preferences.Get("UserPassword", string.Empty);

            if (email == savedEmail && password == savedPassword)
            {
               
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid email or password", "OK");
            }
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
