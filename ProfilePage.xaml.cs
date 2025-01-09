using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;

namespace SalonulNOST
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            string userEmail = Preferences.Get("UserEmail", "No email found");
            string userName = Preferences.Get("UserName", "No name found");
            string userPhone = Preferences.Get("UserPhone", "No phone found");

            EmailLabel.Text = $"Email: {userEmail}";
            NameLabel.Text = $"Name: {userName}";
            PhoneLabel.Text = $"Phone Number: {userPhone}";
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            Preferences.Remove("UserEmail");
            Preferences.Remove("UserName");  
            Preferences.Remove("UserPhone"); 

            await Navigation.PushAsync(new LoginPage()); 
        }
    }
}
