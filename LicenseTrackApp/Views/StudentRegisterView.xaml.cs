using LicenseTrackApp.ViewModels;

namespace LicenseTrackApp.Views;

public partial class StudentRegisterView : ContentPage
{
	public StudentRegisterView(StudentRegisterViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}