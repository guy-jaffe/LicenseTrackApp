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
    public class TeacherPreviousDrivingLessonsViewModel : ViewModelBase
    {

        private LicenseTrackWebAPIProxy proxy;
        private IServiceProvider serviceProvider;
        public TeacherPreviousDrivingLessonsViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            SaveCommentsCommand = new Command<LessonModels>(SaveComments);
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
            List<LessonModels>? lessons = await proxy.GetTeacherPreviousLessonsAsync();
            if (lessons != null)
            {
                Lessons = new ObservableCollection<LessonModels>(lessons);
            }
        }

        public Command SaveCommentsCommand { get; set; }
        private async void SaveComments(LessonModels lesson)
        {
            //call proxy to save / update lesson
            bool success = await proxy.UpdateLesson(lesson);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("הוספת הערה", "ההערה הוספה בהצלחה", "מעולה", FlowDirection.RightToLeft);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("הוספת הערה", "שגיאה בהוספת הערה", "בסדר", FlowDirection.RightToLeft);

            }




        }

    }
}
