using SalonulNOST.Models;

namespace SalonulNOST
{
    public partial class ServiceEntryPage : ContentPage
    {
        public ServiceEntryPage()
        {
            InitializeComponent();
        }

        async void OnAddServiceClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(priceEntry.Text))
            {
                await DisplayAlert("Eroare", "Te rog sa completezi toate campurile.", "OK");
                return;
            }

            if (!decimal.TryParse(priceEntry.Text, out decimal price))
            {
                await DisplayAlert("Eroare", "Te rog sa introduci un pret valid.", "OK");
                return;
            }

            var newService = new Service
            {
                Name = nameEntry.Text.Trim(),
                Price = price
            };

            await App.Database.SaveServiceAsync(newService);

            nameEntry.Text = string.Empty;
            priceEntry.Text = string.Empty;

            await Navigation.PushAsync(new ServiceListPage());
        }
    }
}
