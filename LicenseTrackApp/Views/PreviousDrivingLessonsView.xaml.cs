using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class PreviousDrivingLessonsView : ContentPage
{
	public PreviousDrivingLessonsView(PreviousDrivingLessonsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}