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
    public class AdminPageViewModel : ViewModelBase
    {
        private ObservableCollection<TeacherModels> pendingTeachers;
        public ObservableCollection<TeacherModels> PendingTeachers
        {
            get { return pendingTeachers; }
            set 
            { 
                pendingTeachers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TeacherModels> allTeachers;
        public ObservableCollection<TeacherModels> AllTeachers
        {
            get { return allTeachers; }
            set
            {
                allTeachers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<StudentModels> allStudents;
        public ObservableCollection<StudentModels> AllStudents
        {
            get { return allStudents; }
            set
            {
                allStudents = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TeacherModels> filteredTeachers;
        public ObservableCollection<TeacherModels> FilteredTeachers
        {
            get { return filteredTeachers; }
            set
            {
                filteredTeachers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<StudentModels> filteredStudents;
        public ObservableCollection<StudentModels> FilteredStudents
        {
            get { return filteredStudents; }
            set
            {
                filteredStudents = value;
                OnPropertyChanged();
            }
        }

        private string searchStudents;
        public string SearchStudents
        {
            get { return searchStudents; }
            set
            {
                searchStudents = value;
                FilterStudents();
                OnPropertyChanged();
            }
        }

        private string searchTeachers;
        public string SearchTeachers
        {
            get { return searchTeachers; }
            set
            {
                searchTeachers = value;
                FilterTeachers();
                OnPropertyChanged();
            }
        }

        private async void ReadData()
        {
            List<StudentModels>? students = await proxy.GetAllStudents();
            if (students != null)
                AllStudents = new ObservableCollection<StudentModels>(students);

            List<TeacherModels>? teachers = await proxy.GetAllTeachers();
            if (teachers != null)
                AllTeachers = new ObservableCollection<TeacherModels>(teachers);

            List<TeacherModels>? pending = await proxy.GetPendingTeachers();
            if (teachers != null)
                PendingTeachers = new ObservableCollection<TeacherModels>(pending);

            SearchTeachers = "";
            SearchStudents = "";

        }

        private async void FilterStudents()
        {
            FilteredStudents.Clear();

            foreach(StudentModels student in AllStudents)
            {
                if(string.IsNullOrEmpty(SearchStudents) || 
                    student.Email.Contains(SearchStudents) || 
                    student.FirstName.Contains(SearchStudents) || 
                    student.LastName.Contains(SearchStudents))
                    FilteredStudents.Add(student);
            }
        }

        private async void FilterTeachers()
        {
            FilteredTeachers.Clear();

            foreach (TeacherModels teacher in AllTeachers)
            {
                if (string.IsNullOrEmpty(SearchTeachers) ||
                    teacher.Email.Contains(SearchTeachers) ||
                    teacher.FirstName.Contains(SearchTeachers) ||
                    teacher.LastName.Contains(SearchTeachers))
                    FilteredTeachers.Add(teacher);
            }
        }

        private LicenseTrackWebAPIProxy proxy;
        public AdminPageViewModel(LicenseTrackWebAPIProxy proxy)
        {
            this.proxy = proxy;
            allStudents = new ObservableCollection<StudentModels>();
            allTeachers = new ObservableCollection<TeacherModels>();
            pendingTeachers = new ObservableCollection<TeacherModels>();
            filteredStudents = new ObservableCollection<StudentModels>();
            filteredTeachers = new ObservableCollection<TeacherModels>();
            ApproveCommand = new Command<TeacherModels>(OnApprove);
            DeclineCommand = new Command<TeacherModels>(OnDecline);
            ReadData();
        }

        public Command ApproveCommand { get; set; }
        public Command DeclineCommand { get; set; }

        private async void OnApprove(TeacherModels t)
        {
            t.ConfirmationStatus = 1;
            TeacherModels result = await proxy.UpdateTeacher(t);
            if (result != null)
            {
                PendingTeachers.Remove(t);
                TeacherModels? teacherModels = AllTeachers.Where(tt => tt.Id == result.Id).FirstOrDefault();
                if (teacherModels != null)
                {
                    teacherModels.ConfirmationStatus = 1;
                    AllTeachers.Remove(teacherModels);
                    AllTeachers.Add(teacherModels);

                }
            }
        }

        private async void OnDecline(TeacherModels t)
        {
            t.ConfirmationStatus = 2;
            TeacherModels result = await proxy.UpdateTeacher(t);
            if (result != null)
            {
                PendingTeachers.Remove(t);
                TeacherModels? teacherModels = AllTeachers.Where(tt => tt.Id == result.Id).FirstOrDefault();
                if (teacherModels != null)
                {
                    teacherModels.ConfirmationStatus = 2;
                    AllTeachers.Remove(teacherModels);
                    AllTeachers.Add(teacherModels);

                }
            }
        }
    }
}
