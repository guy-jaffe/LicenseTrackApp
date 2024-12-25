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
            LoadQuestionsFromServer();
            //Start with the Login View
            MainPage = new NavigationPage(serviceProvider.GetService<LoginView>());
        }

        private async void LoadQuestionsFromServer()
        {
            TheoryQuestionsAPIProxy proxy = new TheoryQuestionsAPIProxy();
            Question[] arr = await proxy.GetQuestions(5); 
        }
    }
}
