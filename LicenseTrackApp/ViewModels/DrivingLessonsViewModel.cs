using LicenseTrackApp.Services;
using LicenseTrackApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LicenseTrackApp.ViewModels
{
    public class DrivingLessonsViewModel:ViewModelBase
    {

        private LicenseTrackWebAPIProxy proxy;
        private IServiceProvider serviceProvider;
        public DrivingLessonsViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            SetDrivingLessonCommand = new Command(OnSetDrivingLesson);
        }

        public Command SetDrivingLessonCommand { get; }

        private void OnSetDrivingLesson()
        {
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<SetDrivingLessonsView>());
        }

    }
}
