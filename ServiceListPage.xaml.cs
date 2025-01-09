using SalonulNOST.Models;

namespace SalonulNOST
{
    public partial class ServiceListPage : ContentPage
    {
        public ServiceListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            listView.ItemsSource = await App.Database.GetServicesAsync();
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var service = (Service)menuItem.CommandParameter;


            var servicePage = new ServicePage();
            servicePage.BindingContext = service;  
            await Navigation.PushAsync(servicePage);
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var service = (Service)menuItem.CommandParameter;

            bool confirm = await DisplayAlert("Confirmare", $"Sigur doresti sa stergi serviciul {service.Name}?", "Da", "Nu");

            if (confirm)
            {
                await App.Database.DeleteServiceAsync(service);
                listView.ItemsSource = await App.Database.GetServicesAsync(); 
            }
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedService = e.SelectedItem as Service;
                await DisplayAlert("Serviciu Selectat", $"Ai selectat serviciul: {selectedService.Name}", "OK");
            }
        }
    }
}
