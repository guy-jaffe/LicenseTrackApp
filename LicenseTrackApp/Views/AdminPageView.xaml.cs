namespace LicenseTrackApp.Views;
using LicenseTrackApp.ViewModels;

public partial class AdminPageView : ContentPage
{
	public AdminPageView(AdminPageViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}