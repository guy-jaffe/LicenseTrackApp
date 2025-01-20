using LicenseTrackApp.Models;
using LicenseTrackApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LicenseTrackApp.ViewModels
{
    public class TheoryCourseViewModel:ViewModelBase
    {

        private LicenseTrackWebAPIProxy proxy;
        private IServiceProvider serviceProvider;
        public TheoryCourseViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.proxy = proxy;
            this.serviceProvider = serviceProvider;
            StudentModels studentModels = (StudentModels)((App)Application.Current).LoggedInUser;
        }



        private string category;
        public string Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }



        private string questionDescription;
        public string QuestionDescription
        {
            get => questionDescription;
            set
            {
                if (questionDescription != value)
                {
                    questionDescription = value;
                    OnPropertyChanged(nameof(QuestionDescription));
                }
            }
        }

        private string answer0;
        public string Answer0
        {
            get => answer0;
            set
            {
                if (answer0 != value)
                {
                    answer0 = value;
                    OnPropertyChanged(nameof(Answer0));
                }
            }
        }

        private string answer1;
        public string Answer1
        {
            get => answer1;
            set
            {
                if (answer1 != value)
                {
                    answer1 = value;
                    OnPropertyChanged(nameof(Answer1));
                }
            }
        }

        private string answer2;
        public string Answer2
        {
            get => answer2;
            set
            {
                if (answer2 != value)
                {
                    answer2 = value;
                    OnPropertyChanged(nameof(Answer2));
                }
            }
        }

        private string answer3;
        public string Answer3
        {
            get => answer3;
            set
            {
                if (answer3 != value)
                {
                    answer3 = value;
                    OnPropertyChanged(nameof(Answer3));
                }
            }
        }

        private string color0;
        public string Color0
        {
            get => color0;
            set
            {
                if (color0 != value)
                {
                    color0 = value;
                    OnPropertyChanged(nameof(Color0));
                }
            }
        }

        private string color1;
        public string Color1
        {
            get => color1;
            set
            {
                if (color1 != value)
                {
                    color1 = value;
                    OnPropertyChanged(nameof(Color1));
                }
            }
        }

        private string color2;
        public string Color2
        {
            get => color2;
            set
            {
                if (color2 != value)
                {
                    color2 = value;
                    OnPropertyChanged(nameof(Color2));
                }
            }
        }

        private string color3;
        public string Color3
        {
            get => color3;
            set
            {
                if (color3 != value)
                {
                    color3 = value;
                    OnPropertyChanged(nameof(Color3));
                }
            }
        }

        private int correctAnswer;
        public int CorrectAnswer
        {
            get => correctAnswer;
            set
            {
                if (correctAnswer != value)
                {
                    correctAnswer = value;
                    OnPropertyChanged(nameof(CorrectAnswer));
                }
            }
        }

        public ICommand Answer0Command { get; }
        public ICommand Answer1Command { get; }
        public ICommand Answer2Command { get; }
        public ICommand Answer3Command { get; }

        public ICommand NextQuestionCommand { get; }

        public List<Question> Questions { get; set; }

    }
}
