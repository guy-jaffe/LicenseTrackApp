﻿using LicenseTrackApp.Models;
using LicenseTrackApp.Services;
using LicenseTrackApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LicenseTrackApp.ViewModels
{
    public class TeacherDrivingLessonsViewModel : ViewModelBase
    {

        private LicenseTrackWebAPIProxy proxy;
        private IServiceProvider serviceProvider;
        public TeacherDrivingLessonsViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            PreviousDrivingLessonsCommand = new Command(OnPreviousDrivingLessons);
            DeleteLessonCommand = new Command<LessonModels>(OnDeleteLesson);
            InitData();
        }

        public Command PreviousDrivingLessonsCommand { get; }
        public Command DeleteLessonCommand { get; }

        private LessonModels selectedLesson;
        public LessonModels SelectedLesson
        {
            get
            {
                return selectedLesson;
            }
            set
            {
                selectedLesson = value;
                OnPropertyChanged();
            }
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
            List<LessonModels>? lessons = await proxy.GetTeacherFutureLessonsAsync();
            if (lessons != null)
            {
                Lessons = new ObservableCollection<LessonModels>(lessons);
            }
        }




        private void OnPreviousDrivingLessons()
        {
            ((App)Application.Current).MainPage.Navigation.PushAsync(serviceProvider.GetService<TeacherPreviousDrivingLessonsView>());
        }

        private async void OnDeleteLesson(LessonModels l)
        {
            bool ok = await Application.Current.MainPage.DisplayAlert("ביטול שיעור", "האם אתה בטוח?", "כן", "לא", FlowDirection.RightToLeft);
            if (ok)
            {
                ok = await proxy.TeacherDeleteLessonAsync(l.Id);
                if (ok)
                {
                    Lessons.Remove(l);
                }
                else
                    await Application.Current.MainPage.DisplayAlert("ביטול שיעור", "השיעור לא בוטל עקב תקלה. יש לנסות מאוחר יותר", "בסדר", FlowDirection.RightToLeft);
            }
        }

    }
}
