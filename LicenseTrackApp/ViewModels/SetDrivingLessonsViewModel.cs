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
    public class SetDrivingLessonsViewModel : ViewModelBase
    {

        private LicenseTrackWebAPIProxy proxy;
        private IServiceProvider serviceProvider;
        public SetDrivingLessonsViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            InServerCall = false;
            //איתחול כל התכונות בערכים ראשוניים
            

        }

        private ObservableCollection<TeacherModels> teachers;
        public ObservableCollection<TeacherModels> Teachers
        {
            get => teachers;
            set
            {
                if (teachers != value)
                {
                    teachers = value;
                    OnPropertyChanged(nameof(Teachers));
                }
            }
        }

        private string teacherName;
        public string TeacherName
        {
            get => teacherName;
            set
            {
                if (teacherName != value)
                {
                    teacherName = value;
                    OnPropertyChanged(nameof(TeacherName));
                }
            }
        }

        private string city;
        public string City
        {
            get => city;
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }


        private string carType;
        public string CarType
        {
            get => carType;
            set
            {
                if (carType != value)
                {
                    carType = value;
                    OnPropertyChanged(nameof(CarType));
                }
            }
        }

        private bool isManual;
        public bool IsManual
        {
            get => isManual;
            set
            {
                if (isManual != value)
                {
                    isManual = value;
                    OnPropertyChanged(nameof(IsManual));
                }
            }
        }


        private ObservableCollection<LessonScheduleModels> lessonsByDate;
        public ObservableCollection<LessonScheduleModels> LessonsByDate
        {
            get => lessonsByDate;
            set
            {
                if (lessonsByDate != value)
                {
                    lessonsByDate = value;
                    OnPropertyChanged(nameof(LessonsByDate));
                }
            }
        }


        private TeacherModels selectedTeacher;
        public TeacherModels SelectedTeacher
        {
            get => selectedTeacher;
            set
            {
                if (selectedTeacher != value)
                {
                    selectedTeacher = value;
                    OnPropertyChanged(nameof(SelectedTeacher));
                }
            }
        }


        private DateOnly selectedDate;
        public DateOnly SelectedDate
        {
            get => selectedDate;
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }


        private TimeOnly selectedTime;
        public TimeOnly SelectedTime
        {
            get => selectedTime;
            set
            {
                if (selectedTime != value)
                {
                    selectedTime = value;
                    OnPropertyChanged(nameof(SelectedTime));
                }
            }
        }


        private List<LessonScheduleModels> allLessons { get; set; }





    }
}
