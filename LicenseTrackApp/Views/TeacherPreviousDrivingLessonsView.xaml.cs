using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class TeacherPreviousDrivingLessonsView : ContentPage
{
	public TeacherPreviousDrivingLessonsView(TeacherPreviousDrivingLessonsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}