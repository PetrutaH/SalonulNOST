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

            
            if (Preferences.Get("UserEmail", string.Empty) != string.Empty)
            {
                ProfileButton.IsVisible = true;
                LogoutButton.IsVisible = true;
            }
        }

    
        async void OnProfileButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

  
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            Preferences.Remove("UserEmail");  
            await Navigation.PushAsync(new LoginPage()); 
        }

       
        async void OnViewServicesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServicesPage());
        }

      
        async void OnMakeAppointmentClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppointmentPage());
        }

    
        async void OnViewAppointmentsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppointmentsPage());
        }


        async void OnAddServiceClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiceEntryPage());
        }

        
        async void OnCounterClicked(object sender, EventArgs e)
        {
           
        }
    }
}
