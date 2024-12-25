using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class AccompaniedDetailsView : ContentPage
{
	public AccompaniedDetailsView(AccompaniedDetailsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}