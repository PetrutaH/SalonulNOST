using Microsoft.Maui.Controls;
using SalonulNOST.Models;
using System;
using Microsoft.Maui.Storage;

namespace SalonulNOST
{
    public partial class ServicePage : ContentPage
    {
        public ServicePage()
        {
            InitializeComponent();
            CheckAdminAccess();
        }

       
        private void CheckAdminAccess()
        {
            var userEmail = Preferences.Get("UserEmail", string.Empty);

            
            if (userEmail != "admin@gmail.com")
            {
                
                SaveButton.IsVisible = false;
                DeleteButton.IsVisible = false;
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var service = (Service)BindingContext;
            if (string.IsNullOrWhiteSpace(service.Name))
            {
                await DisplayAlert("Eroare", "Numele serviciului nu poate fi gol.", "OK");
                return;
            }
            await App.Database.SaveServiceAsync(service);
            await DisplayAlert("Succes", "Serviciul a fost salvat.", "OK");
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Confirmare", "Esti sigur ca vrei sa stergi acest serviciu?", "Da", "Nu");
            if (confirm)
            {
                var service = (Service)BindingContext;
                await App.Database.DeleteServiceAsync(service);
                await DisplayAlert("Succes", "Serviciul a fost sters.", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
