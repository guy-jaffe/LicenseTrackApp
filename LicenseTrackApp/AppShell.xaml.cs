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

        public event Action<Type> DataChanged;
        public void Refresh(Type type)
        {
            if (DataChanged != null)
            {
                DataChanged(type);
            }
        }
    }
}
