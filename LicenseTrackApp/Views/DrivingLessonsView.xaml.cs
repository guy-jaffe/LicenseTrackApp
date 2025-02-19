using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class DrivingLessonsView : ContentPage
{
	public DrivingLessonsView(DrivingLessonsViewModel vm)
	{
        this.BindingContext = vm;
        InitializeComponent();
	}
}