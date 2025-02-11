using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class TeacherProfileView : ContentPage
{
	public TeacherProfileView(TeacherProfileViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}