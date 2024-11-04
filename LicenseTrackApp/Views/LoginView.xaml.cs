using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}