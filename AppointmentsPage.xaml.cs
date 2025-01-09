using Microsoft.Maui.Controls;
using SalonulNOST.Models;
using System.Collections.Generic;

namespace SalonulNOST
{
    public partial class AppointmentsPage : ContentPage
    {
        public AppointmentsPage()
        {
            InitializeComponent();
            LoadAppointments();
        }

        async void LoadAppointments()
        {
            var appointments = await App.Database.GetAppointmentsAsync();
            foreach (var appointment in appointments)
            {
                appointment.ServiceName = (await App.Database.GetServiceAsync(appointment.ServiceID)).Name;
            }
            appointmentsListView.ItemsSource = appointments;
        }

        async void OnAppointmentTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var selectedAppointment = (Appointment)e.Item;
            await DisplayAlert("Programare", $"Serviciu: {selectedAppointment.ServiceName}\nData: {selectedAppointment.AppointmentDate.ToShortDateString()}", "OK");

            ((ListView)sender).SelectedItem = null;
        }
    }
}
