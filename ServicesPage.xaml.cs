using Microsoft.Maui.Controls;
using SalonulNOST.Models;

namespace SalonulNOST
{
    public partial class ServicesPage : ContentPage
    {
        public ServicesPage()
        {
            InitializeComponent();
            LoadServices();
        }

        async void LoadServices()
        {
            servicesListView.ItemsSource = await App.Database.GetServicesAsync();
        }

        async void OnServiceTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var selectedService = (Service)e.Item;

          
            await DisplayAlert("Serviciu selectat", $"{selectedService.Name} - {selectedService.Price:C}", "OK");

           
            ((ListView)sender).SelectedItem = null;
        }
    }
}
