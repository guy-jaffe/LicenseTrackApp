using LicenseTrackApp.Models;
using LicenseTrackApp.Services;
using LicenseTrackApp.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseTrackApp.ViewModels
{
    public class TeacheRegisterViewModel:ViewModelBase
    {
        private IServiceProvider serviceProvider;
        private LicenseTrackWebAPIProxy proxy;
        public TeacheRegisterViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.proxy = proxy;
            this.serviceProvider = serviceProvider;
            StudentRegisterCommand = new Command(OnStudentRegister);
            RegisterCommand = new Command(OnRegister);
            CancelCommand = new Command(OnCancel);
            ShowPasswordCommand = new Command(OnShowPassword);
            UploadPhotoCommand = new Command(OnUploadPhoto);
            PhotoURL = proxy.GetDefaultProfilePhotoUrl();
            LocalPhotoPath = "";
            IsPassword = true;
            NameError = "Name is required";
            LastNameError = "Last name is required";
            EmailError = "Email is required";
            PasswordError = "Password must be at least 4 characters long and contain letters and numbers";
            CityError = "city is required";
            SchoolNameError = "SchoolName is required";
            VehicleTypeError = "VehicleType is required";
            TeachingAreaError = "TeachingArea is required";
            ManualButton = "0";
            this.serviceProvider = serviceProvider;
        }

        //Defiine properties for each field in the registration form including error messages and validation logic
        #region Name
        private bool showNameError;

        public bool ShowNameError
        {
            get => showNameError;
            set
            {
                showNameError = value;
                OnPropertyChanged("ShowNameError");
            }
        }

        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                ValidateName();
                OnPropertyChanged("Name");
            }
        }

        private string nameError;

        public string NameError
        {
            get => nameError;
            set
            {
                nameError = value;
                OnPropertyChanged("NameError");
            }
        }

        private void ValidateName()
        {
            this.ShowNameError = string.IsNullOrEmpty(Name);
        }
        #endregion

        #region LastName
        private bool showLastNameError;

        public bool ShowLastNameError
        {
            get => showLastNameError;
            set
            {
                showLastNameError = value;
                OnPropertyChanged("ShowLastNameError");
            }
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                ValidateLastName();
                OnPropertyChanged("LastName");
            }
        }

        private string lastNameError;

        public string LastNameError
        {
            get => lastNameError;
            set
            {
                lastNameError = value;
                OnPropertyChanged("LastNameError");
            }
        }

        private void ValidateLastName()
        {
            this.ShowLastNameError = string.IsNullOrEmpty(LastName);
        }
        #endregion
        #region Email
        private bool showEmailError;

        public bool ShowEmailError
        {
            get => showEmailError;
            set
            {
                showEmailError = value;
                OnPropertyChanged("ShowEmailError");
            }
        }

        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                ValidateEmail();
                OnPropertyChanged("Email");
            }
        }

        private string emailError;

        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value;
                OnPropertyChanged("EmailError");
            }
        }

        private void ValidateEmail()
        {
            this.ShowEmailError = string.IsNullOrEmpty(Email);
            if (!ShowEmailError)
            {
                //check if email is in the correct format using regular expression
                if (!System.Text.RegularExpressions.Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    EmailError = "Email is not valid";
                    ShowEmailError = true;
                }
                else
                {
                    EmailError = "";
                    ShowEmailError = false;
                }
            }
            else
            {
                EmailError = "Email is required";
            }
        }
        #endregion
        #region Password
        private bool showPasswordError;

        public bool ShowPasswordError
        {
            get => showPasswordError;
            set
            {
                showPasswordError = value;
                OnPropertyChanged("ShowPasswordError");
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                ValidatePassword();
                OnPropertyChanged("Password");
            }
        }

        private string passwordError;

        public string PasswordError
        {
            get => passwordError;
            set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }

        private void ValidatePassword()
        {
            //Password must include characters and numbers and be longer than 4 characters
            if (string.IsNullOrEmpty(password) ||
                password.Length < 4 ||
                !password.Any(char.IsDigit) ||
                !password.Any(char.IsLetter))
            {
                this.ShowPasswordError = true;
            }
            else
                this.ShowPasswordError = false;
        }

        //This property will indicate if the password entry is a password
        private bool isPassword = true;
        public bool IsPassword
        {
            get => isPassword;
            set
            {
                isPassword = value;
                OnPropertyChanged("IsPassword");
            }
        }

        //This command will trigger on pressing the password eye icon
        public Command ShowPasswordCommand { get; }
        //This method will be called when the password eye icon is pressed
        public void OnShowPassword()
        {
            //Toggle the password visibility
            IsPassword = !IsPassword;
        }
        #endregion

        //#region id
        //private bool showIdError;

        //public bool ShowIdError
        //{
        //    get => showIdError;
        //    set
        //    {
        //        showIdError = value;
        //        OnPropertyChanged("ShowIdError");
        //    }
        //}

        //private int id;

        //public int Id
        //{
        //    get => id;
        //    set
        //    {
        //        id = value;
        //        //ValidateId();
        //        OnPropertyChanged("Id");
        //    }
        //}

        //private string idError;

        //public string IdError
        //{
        //    get => idError;
        //    set
        //    {
        //        idError = value;
        //        OnPropertyChanged("IdError");
        //    }
        //}

        ////private void ValidateId()
        ////{
        ////    this.ShowIdError = string.IsNullOrEmpty(Id);
        ////}
        //#endregion

        #region SchoolName
        private bool showSchoolNameError;

        public bool ShowSchoolNameError
        {
            get => showSchoolNameError;
            set
            {
                showSchoolNameError = value;
                OnPropertyChanged("ShowSchoolNameError");
            }
        }

        private string schoolName;

        public string SchoolName
        {
            get => schoolName;
            set
            {
                schoolName = value;
                ValidateSchoolName();
                OnPropertyChanged("SchoolName");
            }
        }

        private string schoolNameError;

        public string SchoolNameError
        {
            get => schoolNameError;
            set
            {
                schoolNameError = value;
                OnPropertyChanged("SchoolNameError");
            }
        }

        private void ValidateSchoolName()
        {
            this.ShowSchoolNameError = string.IsNullOrEmpty(SchoolName);
        }
        #endregion

        #region VehicleType
        private bool showVehicleTypeError;

        public bool ShowVehicleTypeError
        {
            get => showVehicleTypeError;
            set
            {
                showVehicleTypeError = value;
                OnPropertyChanged("ShowVehicleTypeError");
            }
        }

        private string vehicleType;

        public string VehicleType
        {
            get => vehicleType;
            set
            {
                vehicleType = value;
                ValidateVehicleType();
                OnPropertyChanged("VehicleType");
            }
        }

        private string vehicleTypeError;

        public string VehicleTypeError
        {
            get => vehicleTypeError;
            set
            {
                vehicleTypeError = value;
                OnPropertyChanged("VehicleTypeError");
            }
        }

        private void ValidateVehicleType()
        {
            this.ShowVehicleTypeError = string.IsNullOrEmpty(VehicleType);
        }
        #endregion

        #region TeachingArea
        private bool showTeachingAreaError;

        public bool ShowTeachingAreaError
        {
            get => showTeachingAreaError;
            set
            {
                showTeachingAreaError = value;
                OnPropertyChanged("ShowTeachingAreaError");
            }
        }

        private string teachingArea;

        public string TeachingArea
        {
            get => teachingArea;
            set
            {
                teachingArea = value;
                ValidateTeachingArea();
                OnPropertyChanged("TeachingArea");
            }
        }

        private string teachingAreaError;

        public string TeachingAreaError
        {
            get => teachingAreaError;
            set
            {
                teachingAreaError = value;
                OnPropertyChanged("TeachingAreaError");
            }
        }

        private void ValidateTeachingArea()
        {
            this.ShowTeachingAreaError = string.IsNullOrEmpty(TeachingArea);
        }
        #endregion

        #region ManualCar
        private string manualButton;

        public string ManualButton
        {
            get => manualButton;
            set
            {
                manualButton  = value;
                OnPropertyChanged();
            }
        }
        private bool showManualCarError;

        public bool ShowManualCarError
        {
            get => showManualCarError;
            set
            {
                showManualCarError = value;
                OnPropertyChanged("ShowManualCarError");
            }
        }

        
        public bool ManualCar
        {
            get {
                return ManualButton == "0";
            }
        }

        private string manualCarError;

        public string ManualCarError
        {
            get => manualCarError;
            set
            {
                manualCarError = value;
                OnPropertyChanged("ManualCarError");
            }
        }

        //private void ValidateManualCar()
        //{
        //    this.ShowManualCarError = string.IsNullOrEmpty(ManualCar);
        //}
        #endregion

        #region City
        private bool showCityError;

        public bool ShowCityError
        {
            get => showCityError;
            set
            {
                showCityError = value;
                OnPropertyChanged("ShowCityError");
            }
        }

        private string city;

        public string City
        {
            get => city;
            set
            {
                city = value;
                ValidateCity();
                OnPropertyChanged("City");
            }
        }

        private string cityError;

        public string CityError
        {
            get => cityError;
            set
            {
                cityError = value;
                OnPropertyChanged("CityError");
            }
        }

        private void ValidateCity()
        {
            this.ShowCityError = string.IsNullOrEmpty(City);
        }
        #endregion

        #region Photo

        private string photoURL;

        public string PhotoURL
        {
            get => photoURL;
            set
            {
                photoURL = value;
                OnPropertyChanged("PhotoURL");
            }
        }

        private string localPhotoPath;

        public string LocalPhotoPath
        {
            get => localPhotoPath;
            set
            {
                localPhotoPath = value;
                OnPropertyChanged("LocalPhotoPath");
            }
        }

        public Command UploadPhotoCommand { get; }
        //This method open the file picker to select a photo
        private async void OnUploadPhoto()
        {
            try
            {
                var result = await MediaPicker.Default.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = "Please select a photo",
                });

                if (result != null)
                {
                    // The user picked a file
                    this.LocalPhotoPath = result.FullPath;
                    this.PhotoURL = result.FullPath;
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void UpdatePhotoURL(string virtualPath)
        {
            Random r = new Random();
            PhotoURL = proxy.GetImagesBaseAddress() + virtualPath + "?v=" + r.Next();
            LocalPhotoPath = "";
        }

        #endregion

        //Define a command for the register button
        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }
        public Command StudentRegisterCommand { get; }

        //Define a method that will be called when the register button is clicked
        public async void OnRegister()
        {
            ValidateName();
            ValidateLastName();
            ValidateEmail();
            ValidatePassword();
            ValidateCity();
            ValidateSchoolName();
            ValidateVehicleType();
            ValidateTeachingArea();

            if (!ShowNameError && !ShowLastNameError && !ShowEmailError && !ShowPasswordError)
            {
                //Create a new AppUser object with the data from the registration form
                var newUser = new TeacherModels
                {
                    FirstName = Name,
                    LastName = LastName,
                    Email = Email,
                    PasswordHash = Password,
                    IsManager = false,
                    TeachingArea = teachingArea,
                    SchoolName = SchoolName,
                    VehicleType = VehicleType,
                    ManualCar = ManualCar,
                    ConfirmationStatus = 0,
                    FileExtension = GetImageExtention()
                };

                //Call the Register method on the proxy to register the new user
                
                newUser = await proxy.TeacherRegister(newUser);
                

                //If the registration was successful, navigate to the login page
                if (newUser != null)
                {
                    //UPload profile imae if needed
                    if (!string.IsNullOrEmpty(LocalPhotoPath))
                    {
                        await proxy.LoginAsync(new LoginInfoModels { UserEmail = newUser.Email, UserPassword = newUser.PasswordHash });
                        UsersModels? updatedUser = await proxy.UploadProfileImage(LocalPhotoPath);
                        if (updatedUser == null)
                        {
                            InServerCall = false;
                            await Application.Current.MainPage.DisplayAlert("Registration", "User Data Was Saved BUT Profile image upload failed", "ok");
                        }
                    }
                    InServerCall = false;

                    ((App)(Application.Current)).MainPage.Navigation.PopAsync();
                }
                else
                {

                    //If the registration failed, display an error message
                    string errorMsg = "Registration failed. Please try again.";
                    await Application.Current.MainPage.DisplayAlert("Registration", errorMsg, "ok");
                }
            }
        }

        //Define a method that will be called upon pressing the cancel button
        public void OnCancel()
        {
            //Navigate back to the login page
            ((App)(Application.Current)).MainPage.Navigation.PopAsync();
        }

        private string GetImageExtention()
        {
            int index = this.LocalPhotoPath.LastIndexOf(".");
            if (index == -1)
                return "";
            return this.LocalPhotoPath.Substring(index);
        }

        private void OnStudentRegister()
        {
            //ErrorMsg = "";
            //Email = "";
            //Password = "";
            // Navigate to the Register View page
            StudentRegisterView? t = serviceProvider.GetService<StudentRegisterView>();
            ((App)Application.Current).MainPage.Navigation.PushAsync(t);
        }

    }
}
