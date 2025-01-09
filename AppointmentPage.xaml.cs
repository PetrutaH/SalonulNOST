using Microsoft.Maui.Controls;
using Plugin.LocalNotification;
using SalonulNOST.Models;
using System;

namespace SalonulNOST
{
    public partial class AppointmentPage : ContentPage
    {
        public AppointmentPage()
        {
            InitializeComponent();
            LoadServices();
        }

        private async void LoadServices()
        {
            var services = await App.Database.GetServicesAsync();
            servicePicker.ItemsSource = services;
            servicePicker.ItemDisplayBinding = new Binding("Name");
        }

        async void OnConfirmAppointmentClicked(object sender, EventArgs e)
        {
            if (servicePicker.SelectedItem == null || appointmentDatePicker.Date == null)
            {
                await DisplayAlert("Eroare", "Te rog sa completezi toate campurile.", "OK");
                return;
            }

            var selectedService = (Service)servicePicker.SelectedItem;

            var appointment = new Appointment
            {
                ClientID = 1,
                ServiceID = selectedService.ServiceID,
                AppointmentDate = appointmentDatePicker.Date
            };

            await App.Database.SaveAppointmentAsync(appointment);


            await DisplayAlert("Succes", "Programarea a fost adaugata cu succes!", "OK");

            string address = "Va asteptam pe Strada Plopilor nr. 10";


            var request = new NotificationRequest
            {
                Title = "Multumim ca ne-ati ales!",
                Description = address,
                Schedule = new NotificationRequestSchedule
                {
              
                    NotifyTime = DateTime.Now.AddSeconds(60)
                }
            };

           
            LocalNotificationCenter.Current.Show(request);

            await Navigation.PopAsync();
        }
    }
}
