using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;

namespace SalonulNOST
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Verifică dacă utilizatorul este autentificat
            if (Preferences.Get("UserEmail", string.Empty) != string.Empty)
            {
                ProfileButton.IsVisible = true;
                LogoutButton.IsVisible = true;
            }
        }

        // Navighează la pagina de profil
        async void OnProfileButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        // Deconectează utilizatorul
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            Preferences.Remove("UserEmail");  // Șterge email-ul din preferințe
            await Navigation.PushAsync(new LoginPage());  // Mergi la pagina de logare
        }

        // Navighează la pagina de servicii
        async void OnViewServicesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServicesPage());
        }

        // Navighează la pagina de programări
        async void OnMakeAppointmentClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppointmentPage());
        }

        // Navighează la pagina cu lista de programări
        async void OnViewAppointmentsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppointmentsPage());
        }

        // Navighează la pagina pentru adăugarea unui serviciu
        async void OnAddServiceClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiceEntryPage());
        }

        // Buton pentru count, exemplu de buton care crește un contor
        async void OnCounterClicked(object sender, EventArgs e)
        {
            // Logică pentru contor, dacă ai nevoie de asta
        }
    }
}
