using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class ProfileView : ContentPage
{
	public ProfileView(ProfileViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}