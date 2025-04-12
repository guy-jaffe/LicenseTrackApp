using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class TeachersWaitingPagexaml : ContentPage
{
	public TeachersWaitingPagexaml(TeachersWaitingPagexamlViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}