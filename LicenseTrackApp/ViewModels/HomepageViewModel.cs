using LicenseTrackApp.Models;
using LicenseTrackApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.ViewModels
{
    public class HomepageViewModel : ViewModelBase
    {

        private LicenseTrackWebAPIProxy proxy;
        private IServiceProvider serviceProvider;

        private StudentModels Student
        {
            get; set;
        }
        public HomepageViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.proxy = proxy;
            this.serviceProvider = serviceProvider;

            FinishTheoryCommand = new Command(OnFinishTheory);
            FinishLessonsCommand = new Command(OnFinishLessons);

            UsersModels user = ((App)Application.Current).LoggedInUser;
            Student = (StudentModels)user;


            if (Student.LicenseStatus == 0)
            {
                InTheory = true;
                InLessons = false;
            }
            else if (Student.LicenseStatus == 1)
            {
                ColorTheory = Colors.Green;

                InTheory = false;
                InLessons = true;

            }
            else if(Student.LicenseStatus == 2)
            {
                ColorTheory = Colors.Green;
                ColorLessons = Colors.Green;

                InTheory = false;
                InLessons = false;


                DateTime testTime = new DateTime(Student.LicenseAcquisitionDate.Value.Year,
                    Student.LicenseAcquisitionDate.Value.Month,
                    Student.LicenseAcquisitionDate.Value.Day);
                DateTime today = DateTime.Today;
                int days = (today - testTime).Days;

                if (days > 180)
                {
                    Student.LicenseStatus = 3;
                    colorAccompanied = Colors.Green;
                    OnFinishAccompanied();
                }
            }
            else if (Student.LicenseStatus == 3)
            {
                ColorTheory = Colors.Green;
                ColorLessons = Colors.Green;
                colorAccompanied = Colors.Green;

                InTheory = false;
                InLessons = false;


            }
        }

        public Command FinishTheoryCommand { get; }
        public Command FinishLessonsCommand { get; }


        private bool inTheory;
        public bool InTheory
        {
            get => inTheory;
            set
            {
                if (inTheory != value)
                {
                    inTheory = value;
                    OnPropertyChanged(nameof(InTheory));
                }
            }
        }

        private bool inLessons;
        public bool InLessons
        {
            get => inLessons;
            set
            {
                if (inLessons != value)
                {
                    inLessons = value;
                    OnPropertyChanged(nameof(InLessons));
                }
            }
        }


        private Color colorTheory;
        public Color ColorTheory
        {
            get => colorTheory;
            set
            {
                if (colorTheory != value)
                {
                    colorTheory = value;
                    OnPropertyChanged(nameof(ColorTheory));
                }
            }
        }

        private Color colorLessons;
        public Color ColorLessons
        {
            get => colorLessons;
            set
            {
                if (colorLessons != value)
                {
                    colorLessons = value;
                    OnPropertyChanged(nameof(ColorLessons));
                }
            }
        }

        private Color colorAccompanied;
        public Color ColorAccompanied
        {
            get => colorAccompanied;
            set
            {
                if (colorAccompanied != value)
                {
                    colorAccompanied = value;
                    OnPropertyChanged(nameof(ColorAccompanied));
                }
            }
        }



        private async void OnFinishTheory()
        {
            if (Student.LicenseStatus == 0)
            {
                Student.LicenseStatus = 1;
                StudentModels s = await proxy.UpdateStudent(Student);
                if (s != null)
                {
                    ColorTheory = Colors.Green;
                    InTheory = false;
                    InLessons = true;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("שגיאה", "הנתונים לא נשמרו", "בסדר");
                }
            }
            
        }
        private async void OnFinishAccompanied()
        {
            await proxy.UpdateStudent(Student);
        }

        private async void OnFinishLessons()
        {
            if (Student.LicenseStatus == 1)
            {
                Student.LicenseStatus = 2;
                Student.LicenseAcquisitionDate = DateOnly.FromDateTime(DateTime.Today);
                StudentModels s = await proxy.UpdateStudent(Student);
                if (s != null)
                {
                    ColorTheory = Colors.Green;
                    ColorLessons = Colors.Green;

                    InLessons = false;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("שגיאה", "הנתונים לא נשמרו", "בסדר");
                }
            }
        }

    }
}
