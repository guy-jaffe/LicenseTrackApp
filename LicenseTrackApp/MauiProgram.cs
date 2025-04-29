using LicenseTrackApp.Services;
using LicenseTrackApp.ViewModels;
using LicenseTrackApp.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace LicenseTrackApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterDataServices()
                .RegisterPages()
                .RegisterViewModels();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<TeacherRegisterView>();
            builder.Services.AddTransient<StudentRegisterView>();
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<AccompaniedDetailsView>();
            builder.Services.AddTransient<AdminPageView>();
            builder.Services.AddTransient<DrivingLessonsView>();
            builder.Services.AddTransient<PreviousDrivingLessonsView>();
            builder.Services.AddTransient<TeacherPreviousDrivingLessonsView>();
            builder.Services.AddTransient<ProfileView>();
            builder.Services.AddTransient<SetDrivingLessonsView>();
            builder.Services.AddTransient<TheoryCourseView>();
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<TeacherProfileView>();
            builder.Services.AddTransient<TeacherDrivingLessonsView>();
            builder.Services.AddTransient<HomepageView>();
            builder.Services.AddTransient<TeachersWaitingPagexaml>();



            return builder;
        }

        public static MauiAppBuilder RegisterDataServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<LicenseTrackWebAPIProxy>();
            builder.Services.AddSingleton<TheoryQuestionsAPIProxy>();
            return builder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<TeacheRegisterViewModel>();
            builder.Services.AddTransient<StudentRegisterViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<AccompaniedDetailsViewModel>();
            builder.Services.AddTransient<AdminPageViewModel>();
            builder.Services.AddTransient<DrivingLessonsViewModel>();
            builder.Services.AddTransient<PreviousDrivingLessonsViewModel>();
            builder.Services.AddTransient<TeacherPreviousDrivingLessonsViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<TeacherProfileViewModel>();
            builder.Services.AddTransient<SetDrivingLessonsViewModel>();
            builder.Services.AddTransient<TheoryCourseViewModel>();
            builder.Services.AddTransient<AppShellViewModel>();
            builder.Services.AddTransient<TeacherProfileViewModel>();
            builder.Services.AddTransient<TeacherDrivingLessonsViewModel>();
            builder.Services.AddTransient<HomepageViewModel>();




            return builder;
        }
    }
}
