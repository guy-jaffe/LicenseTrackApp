using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class SetDrivingLessonsView : ContentPage
{
	public SetDrivingLessonsView(SetDrivingLessonsViewModel vm)
	{
        this.BindingContext = vm;
        InitializeComponent();
	}
}