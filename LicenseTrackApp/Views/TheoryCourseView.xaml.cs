using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class TheoryCourseView : ContentPage
{
	public TheoryCourseView(TheoryCourseViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}