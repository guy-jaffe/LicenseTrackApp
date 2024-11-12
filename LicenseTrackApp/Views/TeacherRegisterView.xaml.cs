using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class TeacherRegisterView : ContentPage
{
	public TeacherRegisterView(TeacheRegisterViewModel vm)
	{
        this.BindingContext = vm;
        InitializeComponent();
	}
}