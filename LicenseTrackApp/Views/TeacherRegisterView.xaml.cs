using LicenseTrackApp.ViewModels;
using LicenseTrackApp.Models;

namespace LicenseTrackApp.Views;

public partial class TeacherRegisterView : ContentPage
{
	public TeacherRegisterView(TeacheRegisterViewModel vm)
	{

        this.BindingContext = vm;
        InitializeComponent();
        
	}

    private void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        //if (e.Value)
        //{
        //    var radioButton = sender as RadioButton;
        //    TeacheRegisterViewModel vm = (TeacheRegisterViewModel)this.BindingContext;
        //    if (radioButton.Value.ToString() == "0")
        //        vm.ManualCar = true;
        //    else if (radioButton.Value.ToString() == "1")
        //        vm.ManualCar = false;
            
        //    //DisplayAlert("??? ????? ", $"??? ???? {radioButton.Content}", "?????");
        //}
    }
}