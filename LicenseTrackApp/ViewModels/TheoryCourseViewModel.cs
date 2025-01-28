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

        private TheoryQuestionsAPIProxy proxy;
        private IServiceProvider serviceProvider;
        public TheoryCourseViewModel(TheoryQuestionsAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.proxy = proxy;
            this.serviceProvider = serviceProvider;
            StudentModels studentModels = (StudentModels)((App)Application.Current).LoggedInUser;
            currentQuestionIndex = -1;
            NextQuestionCommand = new Command(OnNextQuestion);
            Answer0Command = new Command(OnAnswer0);
            Answer1Command = new Command(OnAnswer1);
            Answer2Command = new Command(OnAnswer2);
            Answer3Command = new Command(OnAnswer3);
            ReadQuestions();
        }

        private int currentQuestionIndex;
        private async void ReadQuestions()
        {
            InServerCall = true;
            Question [] q = await proxy.GetQuestions(50);
            Questions = q;
            currentQuestionIndex++;
            InitQuestionData();
            InServerCall = false;
        }

        private void InitQuestionData()
        {
            Category = Questions[currentQuestionIndex].category;
            QuestionDescription = Questions[currentQuestionIndex].QuestionHeader;
            Answer0 = Questions[currentQuestionIndex].answers[0];
            Answer1 = Questions[currentQuestionIndex].answers[1];
            Answer2 = Questions[currentQuestionIndex].answers[2];
            Answer3 = Questions[currentQuestionIndex].answers[3];
            ImageUrl = Questions[currentQuestionIndex].imageURL;
            CorrectAnswer = Questions[currentQuestionIndex].correctAnswer;
            Color0 = Colors.LightGoldenrodYellow;
            Color1 = Colors.LightGoldenrodYellow;
            Color2 = Colors.LightGoldenrodYellow;
            Color3 = Colors.LightGoldenrodYellow;

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

        
        public bool ShowImage
        {
            get => !string.IsNullOrEmpty(ImageUrl);
            
        }

        private string imageUrl;
        public string ImageUrl
        {
            get => imageUrl;
            set
            {
                if (imageUrl != value)
                {
                    imageUrl = value;
                    OnPropertyChanged(nameof(ImageUrl));
                    OnPropertyChanged(nameof(ShowImage));

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

        private Color color0;
        public Color Color0
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



        private Color color1;
        public Color Color1
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

        private Color color2;
        public Color Color2
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

        private Color color3;
        public Color Color3
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

        private Question [] Questions { get; set; }

        private void OnNextQuestion()
        {
            if (currentQuestionIndex >= Questions.Length) 
                currentQuestionIndex = 0;
            currentQuestionIndex++;
            InitQuestionData();
        }

        private void OnAnswer0()
        {
            if (CorrectAnswer == 0)
                Color0 = Colors.Green;
            else
                Color0 = Colors.Red;
        }


        private void OnAnswer1()
        {
            if (CorrectAnswer == 1)
                Color1 = Colors.Green;
            else
                Color1 = Colors.Red;
        }

        private void OnAnswer2()
        {
            if (CorrectAnswer == 2)
                Color2 = Colors.Green;
            else
                Color2 = Colors.Red;

        }

        private void OnAnswer3()
        {
            if (CorrectAnswer == 3)
                Color3 = Colors.Green;
            else
                Color3 = Colors.Red;
        }

    }
}
