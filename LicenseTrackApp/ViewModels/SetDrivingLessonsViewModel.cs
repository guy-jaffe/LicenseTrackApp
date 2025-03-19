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
            Teachers = new ObservableCollection<TeacherModels>();
            LessonsByDate = new ObservableCollection<LessonScheduleModels>();
            allLessons = new List<LessonScheduleModels>();
            SaveCommand = new Command(OnSave);
            selectedDate = DateTime.Now;
            InitData();

        }

        public Command SaveCommand { get; set; }
        private async void OnSave()
        {
            if (SelectedTime == null)
            {
                await Application.Current.MainPage.DisplayAlert("שגיאה", "יש לבחור מורה, יום ושעה", "בסדר");
            }
            else
            {
                LessonModels lesson = new LessonModels()
                {
                    InstructorId = SelectedTeacher.Id,
                    StudentId = ((App)Application.Current).LoggedInUser.Id,
                    LessonDate = SelectedTime.LessonDate,
                    LessonTime = SelectedTime.LessonTime,
                    LessonType = "שיעור רגיל",
                    
                };
                bool success = await proxy.AddLesson(lesson);
                if (!success)
                {
                    await Application.Current.MainPage.DisplayAlert("שגיאה", "השיעור לא נשמר", "בסדר");
                }
                else
                {
                    //Refresh the driving lesson page
                    ((AppShell)Shell.Current).Refresh(typeof(DrivingLessonsViewModel));
                    await Shell.Current.Navigation.PopAsync();
                }
            }
        }
        private async void InitData()
        {
            List<TeacherModels>? teachers = await proxy.GetTeachers();
            if (teachers != null) 
            {
                Teachers = new ObservableCollection<TeacherModels>(teachers);
                if (Teachers.Count > 0)
                    SelectedTeacher = Teachers[0];
            }

            
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

        private string isManual;
        public string IsManual
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
                    LoadTeacherData();
                    OnPropertyChanged(nameof(SelectedTeacher));
                }
            }
        }

        private async void LoadTeacherData()
        {
            City = SelectedTeacher.City;
            TeacherName = $"{SelectedTeacher.FirstName} {SelectedTeacher.LastName}";
            if (SelectedTeacher.ManualCar != null && selectedTeacher.ManualCar.Value)
            {
                IsManual = "ידני";
            }
            else
            {

                IsManual = "אוטומט";
            }
            CarType = SelectedTeacher.VehicleType;

            

            OnDateSelected(true);

        }

        private async void OnDateSelected(bool readFromServer)
        {
            if (readFromServer)
            {
                List<LessonScheduleModels>? schedule = await proxy.GetAvailableLessonSchedules(SelectedTeacher.Id, SelectedDate.Month, SelectedDate.Year);
                if (schedule != null)
                {
                    allLessons = schedule;
                }
                else
                    allLessons = new List<LessonScheduleModels>();
            }

            LessonsByDate.Clear();

            foreach(LessonScheduleModels s in allLessons)
            {
                if (s.LessonDate.Year == SelectedDate.Year && s.LessonDate.Month == SelectedDate.Month && s.LessonDate.Day == SelectedDate.Day)
                {
                    LessonsByDate.Add(s);
                }
            }


        }



        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get => selectedDate;
            set
            {
                if (selectedDate != value)
                {
                    bool readFromServer = false;
                    if (selectedDate.Month != value.Month || selectedDate.Year != value.Year)
                    {
                        readFromServer = true;
                    }
                    selectedDate = value;
                    OnDateSelected(readFromServer);
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }


        private LessonScheduleModels selectedTime;
        public LessonScheduleModels SelectedTime
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
