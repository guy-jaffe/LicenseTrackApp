using LicenseTrackApp.Models;
using LicenseTrackApp.Services;
using LicenseTrackApp.Views;

namespace LicenseTrackApp
{
    public partial class App : Application
    {
        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new AppShell();
        //}

        //Application level variables
        public UsersModels? LoggedInUser { get; set; }
        //public List<UrgencyLevel> UrgencyLevels { get; set; } = new List<UrgencyLevel>();
        private LicenseTrackWebAPIProxy proxy;
        public App(IServiceProvider serviceProvider, LicenseTrackWebAPIProxy proxy)
        {
            this.proxy = proxy;
            LoggedInUser = null;
            InitializeComponent();
            //LoadBasicDataFromServer();
            //Start with the Login View
            MainPage = new NavigationPage(serviceProvider.GetService<LoginView>());
        }

        //private async void LoadBasicDataFromServer()
        //{
        //    List<UrgencyLevel>? levels = await this.proxy.GetUrgencyLevels();
        //    if (levels != null)
        //    {
        //        UrgencyLevels.Clear();
        //        foreach (UrgencyLevel level in levels)
        //        {
        //            UrgencyLevels.Add(level);
        //        }
        //    }
        //}
    }
}
