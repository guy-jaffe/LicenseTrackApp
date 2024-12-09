using LicenseTrackApp.ViewModels;
using LicenseTrackApp.Views;

namespace LicenseTrackApp
{
    public partial class AppShell : Shell
    {

        public AppShell(AppShellViewModel vm)
        {
            this.BindingContext = vm;
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("TheoryCourseView", typeof(TheoryCourseView));
            Routing.RegisterRoute("AccompaniedDetailsView", typeof(AccompaniedDetailsView));
            Routing.RegisterRoute("DrivingLessonsView", typeof(DrivingLessonsView));
        }
    }
}
