using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using SalonulNOST.Data;
using System;

namespace SalonulNOST
{
    public partial class App : Application
    {
        public static SalonDatabase Database { get; private set; }

        public App()
        {
            InitializeComponent();

            // Calea bazei de date
            var dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "salon.db3");
            Database = new SalonDatabase(dbPath);

            var userEmail = Preferences.Get("UserEmail", string.Empty);

            // Verifică dacă utilizatorul este logat sau nu
            if (string.IsNullOrEmpty(userEmail))
            {
                MainPage = new NavigationPage(new LoginPage()); // Dacă nu este logat, du-l pe LoginPage
            }
            else
            {
                MainPage = new NavigationPage(new AppShell()); // Dacă este logat, du-l pe AppShell (navigare)
            }
        }
    }
}
