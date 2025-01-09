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

        // Eveniment pentru a accesa pagina de profil
        async void OnProfileMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        // Eveniment pentru a deconecta utilizatorul
        async void OnLogoutMenuClicked(object sender, EventArgs e)
        {
            Preferences.Remove("UserEmail");  // Șterge email-ul din preferințe
            await Navigation.PushAsync(new LoginPage());  // Mergi la pagina de logare
        }
    }
}
