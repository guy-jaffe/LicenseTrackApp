using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class TeacherDrivingLessonsView : ContentPage
{
	public TeacherDrivingLessonsView(TeacherDrivingLessonsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}