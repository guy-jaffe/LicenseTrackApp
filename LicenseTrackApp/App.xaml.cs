using LicenseTrackApp.Models;
using LicenseTrackApp.Services;
using LicenseTrackApp.Views;

namespace LicenseTrackApp
{
    public partial class App : Application
    {
        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new AppShell();
        //}

        //Application level variables
        public UsersModels? LoggedInUser { get; set; }
        //public List<UrgencyLevel> UrgencyLevels { get; set; } = new List<UrgencyLevel>();
        private LicenseTrackWebAPIProxy proxy;
        public App(IServiceProvider serviceProvider, LicenseTrackWebAPIProxy proxy)
        {
            //TestQuestions();
            this.proxy = proxy;
            LoggedInUser = null;
            InitializeComponent();
            LoadQuestionsFromServer();
            //Start with the Login View
            MainPage = new NavigationPage(serviceProvider.GetService<LoginView>());
        }

        private async void LoadQuestionsFromServer()
        {
            TheoryQuestionsAPIProxy proxy = new TheoryQuestionsAPIProxy();
            Question[] arr = await proxy.GetQuestions(5); 
        }

        private void TestQuestions()
        {
            GetAnswers("<div dir=\"rtl\" style=\"text-align: right\"><ul><li><span>רשאי, רק כאשר הרכב העוקף הוא רכב משא.</span></li><li><span>רשאי, רק בדרך שאינה עירונית.</span></li><li><span id=\"correctAnswer1759\">רשאי.</span></li><li><span>רשאי, אם באוטובוס אין נוסעים.</span></li></ul><div style=\"padding-top: 4px;\"><span><button type=\"button\" onclick=\"var correctAnswer=document.getElementById('correctAnswer1759');correctAnswer.style.background='yellow'\">הצג תשובה נכונה</button></span><br/><span style=\"float: left;\">| «D» | </span></div></div>");
        }

        private string[] GetAnswers (string description4)
        {
            string[] arr = new string[4];
            int startIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                startIndex = description4.IndexOf("<span", startIndex);
                if (description4[startIndex + 5] == '>')
                {
                    startIndex += 6;
                    int endIndex = description4.IndexOf("</span>", startIndex);
                    arr[i] = description4.Substring(startIndex, endIndex - startIndex);
                }
                else
                {
                    //correctAnswer = i;
                    startIndex = description4.IndexOf(">", startIndex) + 1;
                    int endIndex = description4.IndexOf("</span>", startIndex);
                    arr[i] = description4.Substring(startIndex, endIndex - startIndex);
                }
            }
            return arr;
        }
    }
}
