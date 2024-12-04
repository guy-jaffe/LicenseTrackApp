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
    public class StudentRegisterViewModel:ViewModelBase
    {
        private IServiceProvider serviceProvider;
        private LicenseTrackWebAPIProxy proxy;
        public StudentRegisterViewModel(LicenseTrackWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            RegisterCommand = new Command(OnRegister);
            CancelCommand = new Command(OnCancel);
            TeacherRegisterCommand = new Command(OnTeacherRegister);
            ShowPasswordCommand = new Command(OnShowPassword);
            UploadPhotoCommand = new Command(OnUploadPhoto);
            PhotoURL = proxy.GetDefaultProfilePhotoUrl();
            LocalPhotoPath = "";
            IsPassword = true;
            NameError = "Name is required";
            LastNameError = "Last name is required";
            EmailError = "Email is required";
            PasswordError = "Password must be at least 4 characters long and contain letters and numbers";
            //IdError = "id is required";
            CityError = "city is required";
            StreetError = "street is required";
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

        #region Street
        private bool showStreetError;

        public bool ShowStreetError
        {
            get => showStreetError;
            set
            {
                showStreetError = value;
                OnPropertyChanged("ShowStreetError");
            }
        }

        private string street;

        public string Street
        {
            get => street;
            set
            {
                street = value;
                ValidateStreet();
                OnPropertyChanged("Street");
            }
        }

        private string streetError;

        public string StreetError
        {
            get => streetError;
            set
            {
                streetError = value;
                OnPropertyChanged("StreetError");
            }
        }

        private void ValidateStreet()
        {
            this.ShowStreetError = string.IsNullOrEmpty(Street);
        }
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
        public Command TeacherRegisterCommand { get; }

        //Define a method that will be called when the register button is clicked
        public async void OnRegister()
        {
            ValidateName();
            ValidateLastName();
            ValidateEmail();
            ValidatePassword();
            //ValidateId();
            ValidateCity();
            ValidateStreet();
            if (!ShowNameError && !ShowLastNameError && !ShowEmailError && !ShowPasswordError)
            {
                //Create a new AppUser object with the data from the registration form
                var newUser = new StudentModels
                {
                    FirstName = Name,
                    LastName = LastName,
                    Email = Email,
                    PasswordHash = Password,
                    IsManager = false,
                    City = City,
                    Street = Street,
                    LicenseAcquisitionDate = null,
                    LicenseStatus = 0,
                    FileExtension = GetImageExtention()
                };

                //Call the Register method on the proxy to register the new user
                InServerCall = true;
                newUser = await proxy.StudentRegister(newUser);
                InServerCall = false;

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

        private void OnTeacherRegister()
        {
            //ErrorMsg = "";
            //Email = "";
            //Password = "";
            // Navigate to the Register View page
            TeacherRegisterView? t = serviceProvider.GetService<TeacherRegisterView>();
            ((App)Application.Current).MainPage.Navigation.PushAsync(t);
        }


    }
}
