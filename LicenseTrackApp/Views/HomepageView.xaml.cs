using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class HomepageView : ContentPage
{
	public HomepageView(HomepageViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}