using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;

namespace SalonulNOST
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        
        async void OnProfileMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

    
        async void OnLogoutMenuClicked(object sender, EventArgs e)
        {
            Preferences.Remove("UserEmail");  
            await Navigation.PushAsync(new LoginPage());  
        }
    }
}
