using LicenseTrackApp.Models;
using LicenseTrackApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.ViewModels
{
    public class PreviousDrivingLessonsViewModel : ViewModelBase
    {

        private LicenseTrackWebAPIProxy proxy;
        private IServiceProvider serviceProvider;
        public PreviousDrivingLessonsViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            InitData();
        }


        private ObservableCollection<LessonModels> lessons;
        public ObservableCollection<LessonModels> Lessons
        {
            get => lessons;
            set
            {
                if (lessons != value)
                {
                    lessons = value;
                    OnPropertyChanged(nameof(Lessons));
                }
            }
        }

        private async void InitData()
        {
            List<LessonModels>? lessons = await proxy.GetPreviousLessonsAsync();
            if (lessons != null)
            {
                Lessons = new ObservableCollection<LessonModels>(lessons);
            }
        }

    }
}
